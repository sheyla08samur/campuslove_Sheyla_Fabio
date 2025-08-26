using Campuslove_Sheyla_Fabio.src.Shared.Context;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Service;
using Campuslove_Sheyla_Fabio.src.Modules.User.Infrastructure.Repositories;
using Campuslove_Sheyla_Fabio.src.UI;
using Microsoft.EntityFrameworkCore;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseMySql(
            "server=localhost;database=campuslove;user=root;password=Fabioandres2007;",
            new MySqlServerVersion(new Version(8, 0, 36))
        );

        var context = new AppDbContext(optionsBuilder.Options);

        var usuarioRepository = new UsuarioRepository(context);
        IUsuarioService usuarioService = new UsuarioService(usuarioRepository);

        // ✅ Pasamos el servicio ya configurado al menú
        MenuHandler.MostrarMenuHandler(usuarioService);

    }
}