using SchoderChain;

namespace ChainExample.BLL.BookingActions
{
    // Inherit the SchoderChain.Processor class
    public class ValidateUserInput : Processor
    {
        private readonly BookingData _bookingData;

        // Inject your data object for the user data
        // Inject your slack manager for the system error notifications
        public ValidateUserInput(BookingData bookingData, ISlackManager slackManager)
            : base(slackManager) => _bookingData = bookingData;

        // Insert your business logic here
        protected override bool ProcessOk()
        {
            if (_bookingData.UserInput is null)
            {
                // this is a user error
                _bookingData.Result = Results.Json("Please enter data.");
            }
            // return "true" when everything is o.k. and the chain shall continue
            // return "false" when the chain shall stop (i.e. user error)
            return _bookingData.Result is not null;
        }
    }
}
