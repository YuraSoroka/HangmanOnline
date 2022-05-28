using HangmanOnline.Models.Context;
using HangmanOnline.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HangmanContext>();
builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddHttpClient<CreateWordService>();

var app = builder.Build();

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();