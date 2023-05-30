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

        public async Task<IResult> ConfirmBookingAsync(string calledBy, object? userInput, IResult redirectToErrorPage)
        {
            _bookingData.UserInput = userInput;
            var result = await _chain.ProcessAsync($"{calledBy} {userInput}",
                typeof(ValidateUserInput),
                typeof(FetchFromDB1),
                typeof(GetDataFromExternalService),
                typeof(CalculateResult),
                typeof(InsertDataIntoDB2),
                typeof(UpdateDataInDB1),
                typeof(ShowStackTrace)
                );

            return result.Exception is null
                ? _bookingData.Result
                : redirectToErrorPage;
        }

//public async Task<IResult> ConfirmBookingAsync(object inputData)
//{
//    var errorMessage = ValidateUserInput();
//    if (!string.IsNullOrEmpty(errorMessage))
//    {
//        return Results.Json(errorMessage);
//    }
//    var data1 = await _data1Accessor.GetAsync(inputData);
//    if (data1 is null)
//    {
//        return Results.Json("Could not find data in DB1.");
//    }
//    var data2 = await _data2Client.GetAsync(inputData);
//    if (data1 is null)
//    {
//        return Results.Json("Could not get data from external service.");
//    }
//    var result = _calculator.Calculate(inputData, data1, data2);
//    var newId = await _data2Accessor.InsertAsync(result);
//    if (newId is null)
//    {
//        return Results.Json("Could not insert result into DB2.");
//    }
//    var ok = await _data1Accessor.UpdateAsync(inputData, newId);
//    if (!ok)
//    {
//        await _data2Accessor.DeleteAsync(newId);
//        return Results.Json("Could not update data in DB1.");
//    }

//    return Results.Redirect("/nextpage");
//}
    }
}
