using Microsoft.EntityFrameworkCore;

namespace SGE.Repositorios
{
    public class SGESqlite
    {
        public static void Inicializar()
        {
            using var context = new SGEcontext();
            if (context.Database.EnsureCreated())
            {
                var connection = context.Database.GetDbConnection();
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "PRAGMA journal_mode=DELETE;";
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("Se creó la base de datos.");
            }
        }
    }
}
