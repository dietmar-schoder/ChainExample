var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/bookings", () =>
{
    return "Booking confirmed.";
});

app.Run();

