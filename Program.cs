var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/login", async (HttpContext context) =>
{
    var data = await context.Request.ReadFromJsonAsync<Login>();

    if (data?.Username == "admin" && data?.Password == "1234")
    {
        return Results.Ok(new { success = true });
    }

    return Results.Ok(new { success = false });
});

app.Run("http://0.0.0.0:10000");

record Login(string Username, string Password);
