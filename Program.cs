using Campuslove_Sheyla_Fabio.src.Shared.Context;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Service;
using Campuslove_Sheyla_Fabio.src.Modules.User.Infrastructure.Repositories;
using Campuslove_Sheyla_Fabio.src.UI;
using Microsoft.EntityFrameworkCore;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Interfaces;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseMySql(
            "server=localhost;database=campuslove;user=root;password=Fabioandres2007;",
            new MySqlServerVersion(new Version(8, 0, 36))
        );

        var context = new AppDbContext(optionsBuilder.Options);

        IUsuarioService usuarioService = new UsuarioService(context);
        await MenuHandler.MostrarMenuHandler(usuarioService);
    }
}