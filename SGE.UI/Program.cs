using SGE.UI.Components;
using SGE.Aplicacion;
using SGE.Repositorios;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<SGESqlite>();
SGESqlite.Inicializar();
builder.Services.AddDbContext<SGEcontext>();

//==================================================
// Caso de uso usuario alta. 
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
// Registro de dependencias necesarias para CasoDeUsoUsuarioAlta
builder.Services.AddScoped<IUsuarioRepositorio,RepositorioUsuario>();
builder.Services.AddScoped<IValidadorUsuario, UsuarioValidador>();
builder.Services.AddScoped<IServicioHashContraseña, ServicioHashContraseña>();
//==================================================


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
