using HangmanOnline.Models.Context;
using HangmanOnline.Services.Contracts;
using HangmanOnline.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HangmanContext>()
    .AddSingleton<HangmanContext>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<ICoreService, CoreService>();
builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddHttpClient<CreateWordService>();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();