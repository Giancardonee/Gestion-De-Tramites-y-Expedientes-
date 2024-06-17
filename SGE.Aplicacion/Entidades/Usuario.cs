namespace SGE.Aplicacion;

public class Usuario
{
    public String Nombre { get; set; }
    public String Apellido { get; set; }
    public String Correo { get; set; }
    public String Contraseña { get; set; } // guardarla hasheada en la bd 
    public List<Permiso> ListaPermisos {get; set; } // se encarga el administrador
    public int id{ get; set; }

    public Usuario (String Nombre, String Apellido, String Correo, String Contrase){
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.Correo = Correo;
        this.Contraseña = Contrase;
    }
}
