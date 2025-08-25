using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace Campuslove_Sheyla_Fabio.src.UI
{
    public class LoadingAnimation
    {
        public static void MostrarAnimacionCarga(string mensaje)
        {
            AnsiConsole.Clear();
            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    var task = ctx.AddTask(mensaje);
                    while (!ctx.IsFinished)
                    {
                        task.Increment(5);
                        Thread.Sleep(100);
                    }
                });
        }
    }
}