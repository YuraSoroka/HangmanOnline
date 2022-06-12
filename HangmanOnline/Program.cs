using HangmanOnline.Models.Context;
using HangmanOnline.Services.Contracts;
using HangmanOnline.Services;
using HangmanOnline.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HangmanContext>()
    .AddSingleton<HangmanContext>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<ICoreService, CoreService>();
builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddHttpClient<CreateWordService>();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.MapHub<HangmanHub>("/hangmanhub");

app.Run();