using ChainExample.BLL;
using ChainExample.BLL.BookingActions;
using ChainExample.DAL;
using ChainExample.Helpers;
using SchoderChain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISlackManager, SlackManager>();
builder.Services.AddScoped<IChain, Chain>();

builder.Services.AddScoped<IBookingManager, BookingManager>();
builder.Services.AddSingleton<BookingData, BookingData>();

builder.Services.AddScoped<IProcessor, CalculateResult>();
builder.Services.AddScoped<IProcessor, FetchFromDB1>();
builder.Services.AddScoped<IProcessor, GetDataFromExternalService>();
builder.Services.AddScoped<IProcessor, InsertDataIntoDB2>();
builder.Services.AddScoped<IProcessor, UpdateDataInDB1>();
builder.Services.AddScoped<IProcessor, ValidateUserInput>();
builder.Services.AddScoped<IProcessor, ShowStackTrace>();

builder.Services.AddScoped<IDataAccessorDB1, DataAccessorDB1>();
builder.Services.AddScoped<IDataAccessorDB2, DataAccessorDB2>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

var userErrorPage = "/error";
var userErrorRedirect = Results.Redirect(userErrorPage);

var bookingsEndpoint = "/bookings";
app.MapGet(bookingsEndpoint, async (string? userInput, IBookingManager bookingManager) =>
{
    return await bookingManager.ConfirmBookingAsync(bookingsEndpoint, userInput, userErrorRedirect);
});

app.MapGet(userErrorPage, () =>
{
    return Results.Empty;
});

app.Run();
