using System;
using System.IO;
using System.Runtime.CompilerServices;

class Program
{
    static string[] lines;

    static void Main()
    {
        string filePath = "input.csv";
        lines = File.ReadAllLines(filePath);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayAllCharacters(lines);
                    break;
                case "2":
                    AddCharacter(ref lines);
                    break;
                case "3":
                    LevelUpCharacter(lines);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }


    static void DisplayAllCharacters(string[] lines)
    {
        // Skip the header row
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string name;
            string profession;
            string level;
            string health;
            string equipment;

            // Check if the name is quoted
            if (line.StartsWith("\""))
{
                int closingQuoteIndex = line.IndexOf('\"', 1);
                if (closingQuoteIndex < 0) continue;

                name = line.Substring(1, closingQuoteIndex - 1);

                string remainder = line.Substring(closingQuoteIndex + 2);
                string[] newLines = remainder.Split(',');

                if (newLines.Length < 4) continue;

                profession = newLines[0];
                level = newLines[1];
                health = newLines[2];
                equipment = newLines[3];
            }
            else
            {
                string[] splitLine = line.Split(',');

                if (splitLine.Length < 5) continue;

                name = splitLine[0];
                profession = splitLine[1];
                level = splitLine[2];
                health = splitLine[3];
                equipment = splitLine[4];
            }

            Console.WriteLine($"   Name: {name}");
            Console.WriteLine($"   Profession: {profession}");
            Console.WriteLine($"   Level: {level}");
            Console.WriteLine($"   Health: {health}");

            var equipmentIndividuals = equipment.Split("|").ToList();

            Console.WriteLine("   Equipment: ");

            foreach (var item in equipmentIndividuals)
            {
                Console.WriteLine($"   - {item}");
            }

            Console.WriteLine();

            // TODO: Parse characterClass, level, hitPoints, and equipment
            // string characterClass = ...
            // int level = ...
            // int hitPoints = ...

            // TODO: Parse equipment noting that it contains multiple items separated by '|'
            // string[] equipment = ...

            // Display character information
            // Console.WriteLine($"Name: {name}, Class: {characterClass}, Level: {level}, HP: {hitPoints}, Equipment: {string.Join(", ", equipment)}");
        }
    }

    static void AddCharacter(ref string[] lines)
    {
        Console.WriteLine("\n=== Add New Character ===\n");

        Console.Write("Enter Name: ");
        var charName = Console.ReadLine();
        Console.Write("Enter Class: ");
        var charClass = Console.ReadLine();
        Console.Write("Enter Level: ");
        var charLevel = Console.ReadLine();
        Console.Write("Enter HP: ");
        var charHP = Console.ReadLine();
        Console.Write("Enter Equipment: ");
        var charEquipment = Console.ReadLine();

        var newChar = $"{charName},{charClass},{charLevel},{charHP},{charEquipment}";
        File.AppendAllText("input.csv", Environment.NewLine + newChar);

        lines = File.ReadAllLines("input.csv");
    }

    static void LevelUpCharacter(string[] lines)
    {
        Console.Write("Enter the name of the character to level up: ");
        string nameToLevelUp = (Console.ReadLine() ?? string.Empty).Trim();

        bool found = false;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');

            if (fields.Length < 5)
                continue;

            string name = fields[0].Trim();

            if (name.Equals(nameToLevelUp, StringComparison.OrdinalIgnoreCase))
            {
                found = true;

                if (int.TryParse(fields[2].Trim(), out int level) &&
                    int.TryParse(fields[3].Trim(), out int hp))
                {
                    level += 1;

                    fields[2] = level.ToString();
                    fields[3] = hp.ToString();

                    lines[i] = string.Join(",", fields);
                }

                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Character not found.");
            return;
        }

        File.WriteAllLines("input.csv", lines);

        Console.WriteLine("Character leveled up successfully!");
    }
}