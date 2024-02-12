using ParcelLocker.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<ParcelService>();
builder.Services.AddSingleton<FileStore>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
