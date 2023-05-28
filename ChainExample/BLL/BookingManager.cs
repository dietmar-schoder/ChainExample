using ChainExample.BLL.BookingActions;
using SchoderChain;

namespace ChainExample.BLL
{
    public class BookingManager : IBookingManager
    {
        private readonly IChain _chain;
        private readonly BookingData _bookingData;

        public BookingManager(IChain chain, BookingData bookingData)
        {
            _chain = chain;
            _bookingData = bookingData;
        }

        public async Task<IResult> ConfirmBookingAsync(string calledBy, IResult redirectToErrorPage)
        {
            // _bookingData.InputData = inputData;
            var result = await _chain.ProcessAsync(calledBy,
                typeof(ValidateDataInput),
                typeof(FetchFromDB1),
                typeof(GetDataFromExternalService),
                typeof(CalculateResult),
                typeof(InsertDataIntoDB2),
                typeof(UpdateDataInDB1));

            return result.Exception is null
                ? _bookingData.Result
                : redirectToErrorPage;
        }
    }
}
