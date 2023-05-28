using SchoderChain;

namespace ChainExample.BLL.BookingActions
{
    public class FetchFromDB1 : Processor
    {
        private readonly BookingData _bookingData;

        public FetchFromDB1(BookingData bookingData, ISlackManager slackManager)
            : base(slackManager) => _bookingData = bookingData;

        protected override void Process()
        {
            _bookingData.Result = Results.Accepted();
        }
    }
}
