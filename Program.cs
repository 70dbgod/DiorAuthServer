using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var app = WebApplication.Create();

app.MapPost("/login", async (HttpContext context) =>
{
    var data = await context.Request.ReadFromJsonAsync<LoginRequest>();

    if (data == null)
        return Results.BadRequest();

    // 🔐 SIMPLE TEST ACCOUNT (replace later with DB)
    if (data.Username == "admin" && data.Password == "1234")
    {
        return Results.Ok(new
        {
            success = true,
            token = "DIOR_AUTH_TOKEN"
        });
    }

    return Results.Ok(new
    {
        success = false
    });
});

app.Run();

record LoginRequest(string Username, string Password);