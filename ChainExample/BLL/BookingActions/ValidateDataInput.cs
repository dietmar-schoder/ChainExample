using SchoderChain;

namespace ChainExample.BLL.BookingActions
{
    public class ValidateDataInput : Processor
    {
        private readonly BookingData _bookingData;

        public ValidateDataInput(BookingData bookingData, ISlackManager slackManager)
            : base(slackManager) => _bookingData = bookingData;

        protected override void Process()
        {
            _bookingData.Result = Results.Accepted();
        }
    }
}
