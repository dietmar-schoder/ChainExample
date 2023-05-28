using SchoderChain;

namespace ChainExample.BLL.BookingActions
{
    public class UpdateDataInDB1 : Processor
    {
        private readonly BookingData _bookingData;

        public UpdateDataInDB1(BookingData bookingData, ISlackManager slackManager)
            : base(slackManager) => _bookingData = bookingData;

        protected override void Process()
        {
            _bookingData.Result = Results.Json(_chainResult.StackTrace);
        }
    }
}
