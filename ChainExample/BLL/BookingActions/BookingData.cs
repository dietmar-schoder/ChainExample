using ChainExample.Models;

namespace ChainExample.BLL.BookingActions
{
    public class BookingData
    {
        public object? UserInput { get; set; }

        public AnyDataObject? AnyDataObject { get; set; }

        public IResult Result { get; set; } = Results.Empty;
    }
}
