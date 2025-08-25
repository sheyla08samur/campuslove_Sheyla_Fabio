using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace Campuslove_Sheyla_Fabio.src.UI
{
    public class MenuHandler
    {
        public static void MostrarMenuHandler()
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
                        // Mostrar menu
                        break;
                    case '1':
                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        // Mostrar menu
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
    }
}