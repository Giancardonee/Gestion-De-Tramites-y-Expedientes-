namespace SGE.Aplicacion;

public class Usuario
{
    public String Nombre { get; set; }
    public String Apellido { get; set; }
    public String Correo { get; set; }
    public String Contraseña { get; set; } // guardarla hasheada en la bd 
    public String? ListaPermisos { get; set; } // se encarga el administrador
    public int id { get; set; }

    public Usuario(String Nombre, String Apellido, String Correo, String Contraseña)
    {
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Correo = Correo;
        this.Contraseña = Contraseña;
    }
    // para iniciar sesion. 
    public Usuario(String Correo, String Contraseña)
    {
        this.Correo = Correo;
        this.Contraseña = Contraseña;
        this.Nombre = "";
        this.Apellido = "";
    }

    // para testing sobre consola. Cuando usemos blazor borrar esto
    public Usuario(String Nombre, String Apellido, String Correo, String Contraseña, int id)
    {
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Correo = Correo;
        this.Contraseña = Contraseña;
        this.id = id;
    }
}
