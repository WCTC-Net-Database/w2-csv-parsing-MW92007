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
            int commaIndex;

            // Check if the name is quoted
            if (line.StartsWith("\""))
            {
                // TODO: Find the closing quote and the comma right after it
                // TODO: Remove quotes from the name if present and parse the name
                // name = ...

                commaIndex = line.IndexOf('\"', 1);
                name = line.Substring(1, commaIndex - 1);
                var contLine = line.Substring(commaIndex + 2);

                var newLines = contLine.Split(',');

                profession = newLines[0];
                level = newLines[1];
                health = newLines[2];
                equipment = newLines[3];

            }
            else
            {

                var splitLine = line.Split(',');

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

        //Taken from my WK1 Repos
        Console.WriteLine("\n=== Add New Character ===\n");

        Console.WriteLine("Enter Name: ");
        var charName = Console.ReadLine();
        Console.WriteLine("Enter Class: ");
        var charClass = Console.ReadLine();
        Console.WriteLine("Enter Level: ");
        var charLevel = Console.ReadLine();
        Console.WriteLine("Enter HP: ");
        var charHP = Console.ReadLine();
        Console.WriteLine("Enter Equipment: ");
        var charEquipment = Console.ReadLine();

        var newChar = $"\n{charName}, {charClass}, {charLevel}, {charHP}, {charEquipment}";
        File.AppendAllText("input.csv", newChar + Environment.NewLine);

        Console.WriteLine(File.ReadAllText("input.csv"));
        lines = File.ReadAllLines("input.csv");
    }

    static void LevelUpCharacter(string[] lines)
    {
        Console.Write("Enter the name of the character to level up: ");
        string nameToLevelUp = Console.ReadLine();

        // Loop through characters to find the one to level up
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            // TODO: Check if the name matches the one to level up
            // Do not worry about case sensitivity at this point
            if (line.Contains(nameToLevelUp))
            {

                // TODO: Split the rest of the fields locating the level field
                // string[] fields = ...
                // int level = ...

                // TODO: Level up the character
                // level++;
                // Console.WriteLine($"Character {name} leveled up to level {level}!");

                // TODO: Update the line with the new level
                // lines[i] = ...
                break;
            }
        }
    }
}