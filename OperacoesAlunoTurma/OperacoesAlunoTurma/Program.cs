using Microsoft.Extensions.DependencyInjection;
using OperacoesAlunoTurma.Interfaces;
using OperacoesAlunoTurma.Interfaces.Services;
using OperacoesAlunoTurma.Repositories;
using OperacoesAlunoTurma.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = (builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(connectionString);

builder.Services.AddTransient<AlunoRepository>();
builder.Services.AddTransient<TurmaRepository>();
builder.Services.AddTransient<AlunoTurmaRepository>();

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IAlunoTurmaService, AlunoTurmaService>();

builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ITurmaRepository, TurmaRepository>();
builder.Services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();