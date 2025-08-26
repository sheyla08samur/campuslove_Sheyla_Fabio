using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_Sheyla_Fabio.src.Shared.Context;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Service;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.User.Infrastructure.Repositories;
using Spectre.Console;


namespace Campuslove_Sheyla_Fabio.src.UI
{
    public class MenuHandler
    {
        public static void MostrarMenuHandler()
        {
            var dbContext = new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>());
            var usuarioRepository = new UsuarioRepository(dbContext);
            IUsuarioService usuarioService = new UsuarioService(usuarioRepository);
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(
                    new FigletText("¡ CAMPUSLOVE !")
                    .Centered()
                    .Color(Color.Pink1));
                AnsiConsole.Write(new Rule("[bold purple]\n❤️  Encuentra el amor de tu vida con CampusLove ❤️  [/]").Centered());

                AnsiConsole.MarkupLine("[bold blue]Menu Principal[/]");

                var selection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[bold]Seleccione una opción[/]")
                    .AddChoices(new[]
                    {
                        "0. Crear Cuenta",
                        "1. Iniciar Sesión",
                        "2. Salir"
                    }));

                switch (selection[0])
                {
                    case '0':
                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        RegistrarUsuario(usuarioService);
                        break;
                    case '1':
                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        IniciarSesion(usuarioService);
                        break;
                    case '2':
                        AnsiConsole.Clear();
                        AnsiConsole.MarkupLine("[bold red]¡Gracias por usar CampusLove![/]");
                        Environment.Exit(0);
                        break;
                    default:
                        AnsiConsole.MarkupLine("[bold red]Opción no válida. Por favor, intente de nuevo.[/]");
                        Thread.Sleep(2000);
                        MostrarMenuHandler();
                        break;
                }
            }
        }

        private static void RegistrarUsuario(IUsuarioService usuarioService)
        {
            var nombre = AnsiConsole.Ask<string>("Escribe tu [green]nombre[/]: ");
            var email = AnsiConsole.Ask<string>("Escribe tu [green]email[/]: ");
            var contrasena = AnsiConsole.Prompt(
                new TextPrompt<string>("Escribe tu [green]contraseña[/]: ")
                .PromptStyle("red")
                .Secret());

            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Email = email,
                Contrasena = contrasena
            };

            usuarioService.RegisterAsync(nuevoUsuario).Wait();

            AnsiConsole.MarkupLine("[bold green]✅ Usuario registrado con éxito![/]");
            Thread.Sleep(2000);
        }

        private static void IniciarSesion(IUsuarioService usuarioService)
        {
            var email = AnsiConsole.Ask<string>("Introduce tu [green]email[/]: ");
            var contrasena = AnsiConsole.Prompt(
                new TextPrompt<string>("Introduce tu [green]contraseña[/]: ")
                .PromptStyle("red")
                .Secret());

            var usuario = usuarioService.LoginAsync(email, contrasena).Result;

            if (usuario is null)
            {
                AnsiConsole.MarkupLine("[bold red]❌ Credenciales inválidas.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine($"[bold green]✅ Bienvenido {usuario.Nombre}![/]");
            }

            Thread.Sleep(2000);
        }
    }
}