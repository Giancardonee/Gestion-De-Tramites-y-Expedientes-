namespace SGE.Aplicacion;

public class CasoDeUsoUsuarioConsultaPorId (IUsuarioRepositorio repoUsuario)
{
    public Usuario? Ejecutar (int Id)
    {
        try{
            return repoUsuario.ConsultaPorId(Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}
