using SGE.UI.Components;
using SGE.Aplicacion;
using SGE.Repositorios;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

        SGESqlite.Inicializar();
        using var context = new SGEcontext();

// VALIDADORES
builder.Services.AddSingleton<IValidadorUsuario, UsuarioValidador>();
builder.Services.AddSingleton<IServicioHashContraseña, ServicioHashContraseña>();

// CASOS DE USO 
builder.Services.AddTransient<CasoDeUsoUsuarioAlta>();

builder.Services.AddTransient<CasoDeUsoListarUsuarios>();

// REPOSITORIOS
builder.Services.AddScoped<IUsuarioRepositorio, RepositorioUsuario>(usuRepo => new RepositorioUsuario(context));


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
