using ChainExample.DAL;
using ChainExample.Models;
using SchoderChain;

namespace ChainExample.BLL.BookingActions
{
    public class InsertDataIntoDB2 : Processor
    {
        private readonly BookingData _bookingData;
        private readonly IDataAccessorDB2 _dataAccessorDB2;

        public InsertDataIntoDB2(BookingData bookingData, IDataAccessorDB2 dataAccessorDB2, ISlackManager slackManager)
            : base(slackManager)
        {
            _bookingData = bookingData;
            _dataAccessorDB2 = dataAccessorDB2;
        }

        protected override async Task<bool> ProcessOkAsync()
        {
            _bookingData.AnyDataObject = new AnyDataObject { Id = Guid.NewGuid() };
            var ok = await _dataAccessorDB2.InsertAsync(_bookingData.AnyDataObject);
            return ok; // The chain only continues if the insert was successful
        }

        protected override async Task UndoAsync()
        {
    if (_bookingData.AnyDataObject is not null)
    {
        await _dataAccessorDB2.DeleteAsync(_bookingData.AnyDataObject.Id);
        _chainResult.StackTrace.Add($"Undo {GetType().Name}: deleted record with id {_bookingData.AnyDataObject.Id}");
    }
        }
    }
}
