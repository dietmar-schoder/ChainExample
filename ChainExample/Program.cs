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

var errorRedirect = Results.Redirect("/error");

var bookingsEndpoint = "/bookings";
app.MapGet(bookingsEndpoint, (IBookingManager bookingManager) =>
{
    return bookingManager.ConfirmBookingAsync(bookingsEndpoint, errorRedirect);
});

app.Run();
