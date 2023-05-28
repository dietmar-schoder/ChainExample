using ChainExample.BLL;
using ChainExample.BLL.BookingActions;
using ChainExample.Helpers;
using SchoderChain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ISlackManager, SlackManager>();
builder.Services.AddScoped<IChain, Chain>();

builder.Services.AddScoped<IBookingManager, BookingManager>();
builder.Services.AddSingleton<BookingData, BookingData>();

builder.Services.AddScoped<IProcessor, CalculateResult>();
builder.Services.AddScoped<IProcessor, FetchFromDB1>();
builder.Services.AddScoped<IProcessor, GetDataFromExternalService>();
builder.Services.AddScoped<IProcessor, InsertDataIntoDB2>();
builder.Services.AddScoped<IProcessor, UpdateDataInDB1>();
builder.Services.AddScoped<IProcessor, ValidateDataInput>();

var app = builder.Build();

var userErrorPage = "/error";
var userErrorRedirect = Results.Redirect(userErrorPage);

var bookingsEndpoint = "/bookings";
app.MapGet(bookingsEndpoint, async (IBookingManager bookingManager) =>
{
    return await bookingManager.ConfirmBookingAsync(bookingsEndpoint, userErrorRedirect);
});

app.MapGet(userErrorPage, () =>
{
    return Results.Empty;
});

app.Run();
