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
        public static async Task MostrarMenuHandler(IUsuarioService usuarioService)
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
                        await IniciarSesion(usuarioService);
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

        private static async Task IniciarSesion(IUsuarioService usuarioService)
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
                // ✅ le paso el usuario a MenuHome
                await MenuHome(usuarioService, usuario);
            }

            Thread.Sleep(2000);
        }

        private static async Task MenuHome(IUsuarioService usuarioService, Usuario usuario)
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
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine("[bold red]¡Tus Matches![/]");
                    var matches0 = usuarioService.GetMatchesAsync(usuario.Id).Result;
                    AnsiConsole.MarkupLine($"[bold green]Tienes {matches0} matches![/]");
                    Console.ReadKey();
                    break;
                case '1':
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine("[bold red]¡Tus Estadísticas![/]");

                    var likesRecibidos = usuarioService.GetLikesReceivedAsync(usuario.Id).Result;
                    var dislikesRecibidos = usuarioService.GetDislikesReceivedAsync(usuario.Id).Result;
                    var matches = usuarioService.GetMatchesAsync(usuario.Id).Result;

                    var m_estadisticas = new Table();
                    m_estadisticas.Border = TableBorder.Rounded;
                    m_estadisticas.AddColumn("Tipo");
                    m_estadisticas.AddColumn("Cantidad");

                    m_estadisticas.AddRow("Mis Likes", usuario.meGusta.ToString());
                    m_estadisticas.AddRow("Mis Dislikes", usuario.noMeGusta.ToString());
                    m_estadisticas.AddRow("Likes Recibidos", likesRecibidos.ToString());
                    m_estadisticas.AddRow("Dislikes Recibidos", dislikesRecibidos.ToString());
                    m_estadisticas.AddRow("Matches", matches.ToString());

                    AnsiConsole.Write(m_estadisticas);
                    Console.ReadKey();
                    break;
                case '2':
                    AnsiConsole.Clear();
                    AnsiConsole.MarkupLine("[bold red]¡Conoce Personas![/]");
                    var usuarios = usuarioService.SearchAsync().Result;

                    foreach (var u in usuarios)
                    {
                        Console.WriteLine($"[{u.Id}] {u.Nombre} - {u.Carrera} - {u.Intereses}");
                    }

                    Console.Write("\nSelecciona el ID del usuario que quieres ver en detalle: ");
                    if (int.TryParse(Console.ReadLine(), out int idSeleccionado))
                    {
                        var usuarioSeleccionado = usuarios.FirstOrDefault(u => u.Id == idSeleccionado);

                        if (usuarioSeleccionado != null)
                        {
                            AnsiConsole.Clear();
                            AnsiConsole.MarkupLine("[bold yellow]Información detallada del usuario[/]");
                            Console.WriteLine($@"
                            ID: {usuarioSeleccionado.Id}
                            Nombre: {usuarioSeleccionado.Nombre}
                            Email: {usuarioSeleccionado.Email}
                            Edad: {usuarioSeleccionado.Edad}
                            Género: {usuarioSeleccionado.Genero}
                            Carrera: {usuarioSeleccionado.Carrera}
                            Intereses: {usuarioSeleccionado.Intereses}
                            Frase: {usuarioSeleccionado.Frase}
                            Me Gusta: {usuarioSeleccionado.meGusta}
                            No Me Gusta: {usuarioSeleccionado.noMeGusta}
                            ");

                            var likingOpt = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("[bold]Seleccione una opción[/]")
                                .AddChoices(new[]
                                {
                                    "0. Like",
                                    "1. Dislike",
                                    "2. Salir"
                                }));
                            switch (likingOpt[0])
                            {
                                    case '0': // Like
                                        await usuarioService.DarLikeAsync(usuario.Id, usuarioSeleccionado.Id, true);
                                        AnsiConsole.MarkupLine("[bold green]✅ Has dado like![/]");
                                        break;
                                    case '1': // Dislike
                                        await usuarioService.DarLikeAsync(usuario.Id, usuarioSeleccionado.Id, false);
                                        AnsiConsole.MarkupLine("[bold green]✅ Has dado dislike![/]");
                                        break;
                                case '2':
                                    break;
                                default:
                                    AnsiConsole.MarkupLine("[bold red]Opción no válida. Por favor, intente de nuevo.[/]");
                                    Thread.Sleep(2000);
                                    break;
                            }

                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[bold red]Usuario no encontrado[/]");
                        }
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[bold red]ID inválido[/]");
                    }
                    break;
                case '3':
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


        private static void ConsultarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}