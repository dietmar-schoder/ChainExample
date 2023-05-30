using ChainExample.DAL;
using SchoderChain;
using System.Text.Json;

namespace ChainExample.BLL.BookingActions
{
    public class UpdateDataInDB1 : Processor
    {
        private readonly BookingData _bookingData;
        private readonly IDataAccessorDB1 _dataAccessorDB1;

        public UpdateDataInDB1(BookingData bookingData, IDataAccessorDB1 dataAccessorDB1, ISlackManager slackManager)
            : base(slackManager)
        {
            _bookingData = bookingData;
            _dataAccessorDB1 = dataAccessorDB1;
        }


        protected override async Task ProcessAsync()
        {
    if (_bookingData.AnyDataObject is not null)
    {
        await _dataAccessorDB1.UpdateAsync(_bookingData.AnyDataObject);
        if (_bookingData.UserInput?.ToString()?.ToLower() == "error")
        {
            throw new Exception($"ERROR: Update in DB1 for object {JsonSerializer.Serialize(_bookingData.AnyDataObject)} went wrong.");
        }
    }
        }
    }
}
