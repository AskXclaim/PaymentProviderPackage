using WebApi.EndPoints;
using WebApi.StartUp;

var builder = WebApplication.CreateBuilder(args);
builder.AddDependencies();

var app = builder.Build();
app.UseOpenApi();
app.UseException();
app.UseHttpsRedirection();

app.MapGroup("/api/payments").MapPaymentEndpoints();

app.Run();