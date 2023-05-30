using ChainExample.BLL.BookingActions;
using SchoderChain;

namespace ChainExample.BLL
{
    public class ShowStackTrace : Processor
    {
        private readonly BookingData _bookingData;

        public ShowStackTrace(BookingData bookingData, ISlackManager slackManager)
            : base(slackManager) => _bookingData = bookingData;

        protected override void Process()
        {
            _bookingData.Result = Results.Json(_chainResult.StackTrace);
        }
    }
}
