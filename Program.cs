// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using backMeUp;

List<WatchedFile> watchedFiles = new List<WatchedFile>();

foreach (var arg in args)
{
    if (!File.Exists(arg))
        continue;

    watchedFiles.Add(new WatchedFile(arg));
}

foreach (var watchedFile in watchedFiles)
    watchedFile.start();

Console.WriteLine($"Watching for {watchedFiles.Count} files.");

Console.WriteLine("Press SHIFT+Q to stop.");
var input = Console.ReadKey(true);
while (input.Key != ConsoleKey.Q && (input.Modifiers & ConsoleModifiers.Shift) != 0)
{
    input = Console.ReadKey(true);
}

foreach (var watchedFile in watchedFiles)
    watchedFile.worker.Interrupt();
