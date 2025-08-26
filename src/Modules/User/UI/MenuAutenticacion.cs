using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace Campuslove_Sheyla_Fabio.src.UI
{
    public class MenuInicioSesion()
    {
        public static void MostrarMenuInicioSesion()
        {

            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(
                    new FigletText("Inicia Sesion")
                    .Centered()
                    .Color(Color.Pink1));
                Console.WriteLine("Ingrese su email");
                Console.WriteLine("Ingrese su contraseña");
            }
        }
    }
}


/*
    AnsiConsole.Clear();
    AnsiConsole.Write(
        new FigletText("Crea Tu Perfil")
        .Centered()
        .Color(Color.Pink1));
    Console.WriteLine("Ingrese su nombre");
    Console.WriteLine("Ingrese su edad");
    Console.WriteLine("Ingrese su genero");
    Console.WriteLine("Ingrese sus Intereses (Música, arte..)");
    Console.WriteLine("Ingrese su carrera");
    Console.WriteLine("Ingrese una frase");

*/

/*
    AnsiConsole.Clear();
    AnsiConsole.Write(
        new FigletText("Filtros")
        .Centered()
        .Color(Color.Pink1));

    var selection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[[bold blue]Filtrar Por:[/]")
        .AddChoices(new[]
        {
            "0. Código",  //id
            "1. Nombre",
            "2. Edad",
            "3. Género",
            "4. Salir"

        }));
*/

/*
    AnsiConsole.Clear();
    AnsiConsole.Write(
        new FigletText("Estadisticsa")
        .Centered()
        .Color(Color.Pink1));

    var selection = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[[bold blue]Elije una opción:[/]")
        .AddChoices(new[]
        {
            "0. Mis likes",
            "1. Mis dislikes",
            "2. Cantidad de likes recibidos",
            "3. Cantidad de dislikes recibidos",
            "4. Cantidad de matches"
            "5. Salir"
        }));
*/

/*
    public class MenuRegistroUsuario()
    {
        public static void MostrarMenuRegistroUsuario()
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(
                    new FigletText("¡Registrate!")
                    .Centered()
                    .Color(Color.Pink1);
            AnsiConsole.Write(new Rule("[bold purple]\n❤️  Da el primer paso para encontrar el amor de tu vida ❤️ [/]").Centered());
*/


/*
    public class MenuHome()
    {
        public static void MostrarMenuHome()
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(
                    new FigletText("Home")
                    .Centered()
                    .Color(Color.Pink1);
            AnsiConsole.MarkupLine("[bold blue]Menu Principal[/]");

                var selection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[bold]Seleccione una opción[/]")
                    .AddChoices(new[]
                    {
                        "0. Ver mis matches",
                        "1. Ver mis estadisticas",
                        "2. Conocer personas"
                        "3. Salir"
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
                    case '3':
                        AnsiConsole.Clear();
                        AnsiConsole.MarkupLine("[bold red]¡Gracias por usar CampusLove![/]");
                        Environment.Exit(0);
                        break;
                    default:
                        AnsiConsole.MarkupLine("[bold red]Opción no válida. Por favor, intente de nuevo.[/]");
                        Thread.Sleep(2000);
                        MostrarMenuHandler();
                        break;
*/




/*
    public class MenuHome()
    {
        public static void MostrarMenuHome()
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(
                    new FigletText("¡Registrate!")
                    .Centered()
                    .Color(Color.Pink1);
            AnsiConsole.Write(new Rule("[bold purple]\n❤️  Da el primer paso para encontrar el amor de tu vida ❤️ [/]").Centered());
            Console.WriteLine("Ingrese su email");
            Console.WriteLine("Ingrese su contraseña");
*/