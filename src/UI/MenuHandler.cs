using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campuslove_Sheyla_Fabio.src.Shared.Context;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Interfaces;
using Campuslove_Sheyla_Fabio.src.Modules.User.Applications.Service;
using Campuslove_Sheyla_Fabio.src.Modules.User.Domain.Entities;
using Campuslove_Sheyla_Fabio.src.Modules.User.Infrastructure.Repositories;
using Spectre.Console;


namespace Campuslove_Sheyla_Fabio.src.UI
{
    public class MenuHandler
    {
        public static void MostrarMenuHandler(IUsuarioService usuarioService) // ✅ recibe el servicio
        {
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
                        break;
                }
            }
        }

        private static void RegistrarUsuario(IUsuarioService usuarioService)
        {
            AnsiConsole.Write(
                    new FigletText("¡Registrate!")
                    .Centered()
                    .Color(Color.Pink1));
            AnsiConsole.Write(new Rule("[bold purple]\n❤️  Da el primer paso para encontrar el amor de tu vida ❤️ [/]").Centered());
            var nombre = AnsiConsole.Ask<string>("Escribe tu [pink1]nombre[/]: ");
            var email = AnsiConsole.Ask<string>("Escribe tu [pink1]email[/]: ");
            var contrasena = AnsiConsole.Prompt(
                new TextPrompt<string>("Escribe tu [red]contraseña[/]: ")
                .PromptStyle("red")
                .Secret());
            var edad = AnsiConsole.Ask<short>("Escribe tu [pink1]edad[/]: ");
            var genero = AnsiConsole.Ask<string>("Escribe tu [pink1]género[/]: ");
            var intereses = AnsiConsole.Ask<string>("Escribe tus [red]intereses[/] (separa por comas si son varios): ");
            var carrera = AnsiConsole.Ask<string>("Escribe tu [pink1]carrera[/]: ");
            var frase = AnsiConsole.Ask<string>("Escribe una [red]frase personal[/]: ");

            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                Email = email,
                Contrasena = contrasena,
                Edad = edad,
                Genero = string.IsNullOrWhiteSpace(genero) ? null : genero,
                Intereses = intereses,
                Carrera = carrera,
                Frase = frase
            };

            usuarioService.RegisterAsync(nuevoUsuario).Wait();

            AnsiConsole.MarkupLine("[bold green]\n✅ Usuario registrado con éxito![/]");
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
                AnsiConsole.MarkupLine($"[bold green]\n✅ Bienvenido {usuario.Nombre}![/]");
                Console.ReadKey();
                MenuHome();
            }

            Thread.Sleep(2000);
        }


        private static void MenuHome()
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(
                    new FigletText("Home")
                    .Centered()
                    .Color(Color.Pink1));
            AnsiConsole.MarkupLine("[bold blue]Menu Principal[/]");

                var selection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[bold]Seleccione una opción[/]")
                    .AddChoices(new[]
                    {
                        "0. Ver mis matches",
                        "1. Ver mis estadisticas",
                        "2. Conocer personas",
                        "3. Salir"
                    }));

                switch (selection[0])
                {
                    case '0':
                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        ConsultarTodosAsync();
                        break;
                    case '1':
                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        // Mostrar menu    aqui falta contador 
                        break;
                    case '2':
                        AnsiConsole.Clear();
                        AnsiConsole.MarkupLine("[bold red]¡Gracias por usar CampusLove![/]");
                        var usuarios = UsuarioService.SearchAsync(usuario); // lista todos
                        foreach (var u in usuarios)
                        {
                            Console.WriteLine($"[{u.Id}] {u.Nombre} - {u.Carrera} - {u.Intereses}");
                        }

                        break;
                    case '3':
                        AnsiConsole.Clear();
                        AnsiConsole.MarkupLine("[bold red]¡Gracias por usar CampusLove![/]");

                        break;
                    default:
                        AnsiConsole.MarkupLine("[bold red]Opción no válida. Por favor, intente de nuevo.[/]");
                        Thread.Sleep(2000);
                        MostrarMenuHandler(usuarioService);
                        break;
                }
        }

        private static void ConsultarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}