// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using backMeUp;

List<Watched> watchTargets = new List<Watched>();

foreach (var arg in args)
{
    if (!File.Exists(arg) && !Directory.Exists(arg))
        continue;

    if (Utils.isFile(arg))
        watchTargets.Add(new WatchedFile(arg));
    else
        watchTargets.Add(new WatchedDirectory(arg));
}

foreach (var watched in watchTargets)
    watched.start();

Console.WriteLine($"Watching for {watchTargets.Count} files.");

Console.WriteLine("Press SHIFT+Q to stop.");
var input = Console.ReadKey(true);
while (input.Key != ConsoleKey.Q && (input.Modifiers & ConsoleModifiers.Shift) != 0)
{
    input = Console.ReadKey(true);
}

foreach (var watched in watchTargets)
    watched.worker.Interrupt();