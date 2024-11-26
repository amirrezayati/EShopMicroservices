var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Configure the HTTP request pipeline.
app.UseRouting();
app.MapCarter();

app.Run();
