using SchoderChain;

namespace ChainExample.BLL.BookingActions
{
    public class InsertDataIntoDB2 : Processor
    {
        private readonly BookingData _bookingData;

        public InsertDataIntoDB2(BookingData bookingData, ISlackManager slackManager)
            : base(slackManager) => _bookingData = bookingData;

        protected override void Process()
        {
            _bookingData.Result = Results.Accepted();
        }
    }
}
