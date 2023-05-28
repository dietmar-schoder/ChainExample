using SchoderChain;

namespace ChainExample.BLL.BookingActions
{
    public class GetDataFromExternalService : Processor
    {
        private readonly BookingData _bookingData;

        public GetDataFromExternalService(BookingData bookingData, ISlackManager slackManager)
            : base(slackManager) => _bookingData = bookingData;

        protected override void Process()
        {
            _bookingData.Result = Results.Accepted();
        }
    }
}
