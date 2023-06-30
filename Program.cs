using System;

enum Gender
{
    Male,
    Female
}

struct Student
{
    public string LastName;
    public int AlbumNumber;
    public double Grade;
    public Gender Gender;
}

class Program
{
    static void Main(string[] args)
    {
        Student[] group = new Student[5];

        for (int i = 0; i < group.Length; i++)
        {
            Console.WriteLine($"Wprowadź informacje dla studenta {i+1}:");
            FillStudentInfo(ref group[i]);
            Console.WriteLine();
        }

        Console.WriteLine("Informacje o studentach:");
        foreach (Student student in group)
        {
            DisplayStudentInfo(student);
        }

        double averageGrade = CalculateAverageGrade(group);
        Console.WriteLine($"Średnia ocen wszystkich studentów: {averageGrade}");
    }

    static void FillStudentInfo(ref Student student)
    {
        Console.Write("Nazwisko: ");
        student.LastName = Console.ReadLine();

        Console.Write("Numer albumu: ");
        student.AlbumNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ocena: ");
        double grade = Convert.ToDouble(Console.ReadLine());
        student.Grade = Math.Max(2.0, Math.Min(5.0, grade));

        Console.Write("Płeć (M/F): ");
        string genderInput = Console.ReadLine();
        student.Gender = (genderInput.ToLower() == "m") ? Gender.Male : Gender.Female;
    }

    static void DisplayStudentInfo(Student student)
    {
        Console.WriteLine($"Nazwisko: {student.LastName}, Numer albumu: {student.AlbumNumber}, Ocena: {student.Grade}, Płeć: {student.Gender}");
    }

    static double CalculateAverageGrade(Student[] group)
    {
        double sum = 0;
        foreach (Student student in group)
        {
            sum += student.Grade;
        }

        return sum / group.Length;
    }
}
