using System.Numerics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Bind PORT for Render
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

var app = builder.Build();

app.MapGet("/maxim_azarov1_gmail_com", (string? x, string? y) =>
{
    if (!TryParseNatural(x, out var a) || !TryParseNatural(y, out var b))
        return Results.Text("NaN", "text/plain");

    var lcm = Lcm(a, b);
    return Results.Text(lcm.ToString(), "text/plain");
});

app.Run();

static bool TryParseNatural(string? value, out BigInteger number)
{
    number = BigInteger.Zero;

    if (string.IsNullOrEmpty(value))
        return false;

    // Strict: digits only
    foreach (char c in value)
    {
        if (c < '0' || c > '9')
            return false;
    }

    number = BigInteger.Parse(value);
    return number > 0;
}

static BigInteger Gcd(BigInteger a, BigInteger b)
{
    while (b != 0)
    {
        var r = a % b;
        a = b;
        b = r;
    }
    return a;
}

static BigInteger Lcm(BigInteger a, BigInteger b)
{
    return (a / Gcd(a, b)) * b;
}