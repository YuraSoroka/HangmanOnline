var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddRazorRuntimeCompilation();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
