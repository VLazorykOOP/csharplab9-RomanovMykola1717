using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Завдання 1: Робота з ArrayList та IComparer
        string text1 = "abc#d##c";
        ArrayList result1 = ProcessText(text1);
        Console.WriteLine("Результат для завдання 1: " + string.Join("", result1.ToArray()));

        // Завдання 2: Робота з ArrayList, IEnumerable та IComparer
        string filePath = "students.txt";
        PrintStudents(filePath);
    }

    // Завдання 1: Робота з ArrayList та IComparer
    static ArrayList ProcessText(string text)
    {
        ArrayList result = new ArrayList();
        foreach (char c in text)
        {
            if (c == '#')
            {
                if (result.Count > 0)
                {
                    result.RemoveAt(result.Count - 1);
                }
            }
            else
            {
                result.Add(c);
            }
        }
        return result;
    }

    // Завдання 2: Робота з ArrayList, IEnumerable та IComparer
    static void PrintStudents(string filePath)
    {
        ArrayList students = new ArrayList();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                students.Add(line);
            }
        }

        ArrayList successfulStudents = FilterSuccessfulStudents(students);
        ArrayList otherStudents = FilterOtherStudents(students);

        Console.WriteLine("\nУспішні студенти (оцінки 4 або 5):");
        foreach (string student in successfulStudents)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("\nІнші студенти:");
        foreach (string student in otherStudents)
        {
            Console.WriteLine(student);
        }
    }

    static ArrayList FilterSuccessfulStudents(ArrayList students)
    {
        ArrayList successfulStudents = new ArrayList();
        foreach (string student in students)
        {
            if (IsSuccessful(student))
            {
                successfulStudents.Add(student);
            }
        }
        return successfulStudents;
    }

    static ArrayList FilterOtherStudents(ArrayList students)
    {
        ArrayList otherStudents = new ArrayList();
        foreach (string student in students)
        {
            if (!IsSuccessful(student))
            {
                otherStudents.Add(student);
            }
        }
        return otherStudents;
    }

    static bool IsSuccessful(string student)
    {
        // Ця функція може бути реалізована залежно від вашого формату файлу і вимог
        // Наприклад, тут можна перевірити оцінки студента і повернути true, якщо вони більше або рівні 4
        return true;
    }
}
