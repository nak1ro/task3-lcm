var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/maxim_azarov1_gmail_com", (string? x, string? y) =>
{
    // Validate input
    if (!IsNaturalNumber(x, out var a) || !IsNaturalNumber(y, out var b))
    {
        return Results.Text("NaN", "text/plain");
    }

    var result = CalculateLcm(a, b);
    return Results.Text(result.ToString(), "text/plain");
});

var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    app.Urls.Add($"http://0.0.0.0:{port}");
}

app.Run();

return;

static bool IsNaturalNumber(string? value, out long number)
{
    if (!long.TryParse(value, out number))
        return false;

    return number > 0;
}

static long CalculateLcm(long x, long y)
{
    return x / CalculateGcd(x, y) * y;
}

static long CalculateGcd(long x, long y)
{
    while (y != 0)
    {
        var remainder = x % y;
        x = y;
        y = remainder;
    }

    return x;
}