﻿using ColoredConsoleHelper;

string? name = ColoredConsole.Prompt("What is your name?");
ColoredConsole.WriteLine("Hello " + name, ConsoleColor.Green);

Console.ReadLine();