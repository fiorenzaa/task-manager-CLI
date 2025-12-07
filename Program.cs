// using System;
// using System.Collections.Generic;

using TaskManagerCLI;

public class Program
{
    public static void Main()
    {
        try
        {
            Run();
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"Operasi tidak valid: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Input harus berupa angka");
        }
    }

    public static void Run()
    {
        List<TaskItem> tasks = new List<TaskItem>();
        int id = 1;
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Add | 2. List | 3. Mark as Complete | 4. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Title: ");
                    tasks.Add(new TaskItem { Id = id++, Title = Console.ReadLine() });
                    break;
                case "2":
                    foreach (var t in tasks)
                        Console.WriteLine(
                            $"{t.Id}. {t.Title} - {(t.IsCompleted ? "Done" : "Pending")}"
                        );
                    break;
                case "3":
                    Console.Write("Enter ID: ");
                    int markId = int.Parse(Console.ReadLine());
                    var task = tasks.Find(t => t.Id == markId);
                    if(task == null)
                    {
                        throw new ArgumentException($"Task dengan ID {markId} tidak ditemukan");
                    }
                    task.MarkComplete();
                    break;
                case "4":
                    running = false;
                    break;
            }
        }
    }
}
