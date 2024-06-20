using SGE.UI.Components;
using SGE.Aplicacion;
using SGE.Repositorios;
using SGE.Autenticacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<SGESqlite>();
SGESqlite.Inicializar();
builder.Services.AddDbContext<SGEcontext>();


//==================================================


// Caso de usos de usuario: 
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();
builder.Services.AddTransient<CasoDeUsoUsuarioBaja>();
builder.Services.AddTransient<CasoDeUsoUsuarioModificacion>();
builder.Services.AddTransient<CasoDeUsoListarUsuarios>();
builder.Services.AddTransient<CasoDeUsoPermisoAlta>();
builder.Services.AddTransient<CasoDeUsoPermisoBaja>();
// Registro de dependencias necesarias casos de uso de usuarios.
builder.Services.AddScoped<IUsuarioRepositorio,RepositorioUsuario>();
builder.Services.AddScoped<IValidadorUsuario, UsuarioValidador>();
builder.Services.AddScoped<IServicioHashContraseña, ServicioHashContraseña>();

//==================================================


// Caso de uso autenticar usuario
builder.Services.AddTransient<CasoDeUsoIniciarSesion>();
// Registro de dependencias necesarias para CasoDeUsoIniciarSesion
builder.Services.AddSingleton<IServicioSesion, ServicioSesion>();
builder.Services.AddScoped<IServicioIniciarSesion, ServicioIniciarSesion>();
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
