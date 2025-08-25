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
                AnsiConsole.Write(new Rule("[bold purple]\n❤️ Encuentra el amor de tu vida con CampusLove ❤️[/]").Centered());

                AnsiConsole.MarkupLine("[bold blue] Menu Principal[/]");
                AnsiConsole.MarkupLine("[bold]Elije la opción que deseas gestionar:\n[/]");

                var m_handler = new Table();
                m_handler.Border = TableBorder.Rounded;

                m_handler.AddColumn("#");
                m_handler.AddColumn("Opción");
                m_handler.AddRow("1", "Crear Torneo");
                m_handler.AddRow("2", "Registro Equipos");
                m_handler.AddRow("3", "Registro Jugadores");
                m_handler.AddRow("4", "Transferencia (Compra, Prestamo)");
                m_handler.AddRow("5", "Estadisticas");
                m_handler.AddRow("6", "Salir");

                AnsiConsole.Write(m_handler);

                int opc = AnsiConsole.Ask<int>("[bold blue]Ingrese la opción deseada: [/]");
                switch (opc)
                {
                    case 1:

                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        // Mostrar menu
                        break;

                    case 2:
                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        // Mostrar menu

                        break;
                    case 3:
                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        // Mostrar menu
                        break;
                    case 4:
                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        // Mostrar menu
                        break;
                    case 5:
                        LoadingAnimation.MostrarAnimacionCarga("Espera un momento...");
                        AnsiConsole.Clear();
                        // Mostrar menu
                        break;
                    case 6:
                        // Salir del programa
                        //AnimacionCarga.MostrarAnimacionCarga();
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