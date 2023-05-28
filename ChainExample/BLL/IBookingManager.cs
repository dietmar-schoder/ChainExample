namespace ChainExample.BLL
{
    public interface IBookingManager
    {
        Task<IResult> ConfirmBookingAsync(string calledBy, IResult redirectToErrorPage);
    }
}
