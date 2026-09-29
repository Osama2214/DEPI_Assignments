
using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        // Enter Student Data
        Console.Write("Enter Student ID: ");
        int studentId = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Student Name: ");
        string studentName = Console.ReadLine()!;

        Console.WriteLine();

        // Create Subject
        Subject subject = new Subject(1, "C# Programming");

        // Create True / False Question
        Answer[] answers1 =
        {
            new Answer(1, "True"),
            new Answer(2, "False")
        };

        Question q1 = new TrueFalseQuestion(
            "True / False",
            "C# is an object-oriented programming language.",
            5,
            answers1,
            answers1[0]
        );

        // Create MCQ Question
        Answer[] answers2 =
        {
            new Answer(1, "HTML"),
            new Answer(2, "C#"),
            new Answer(3, "CSS"),
            new Answer(4, "SQL")
        };

        Question q2 = new MCQQuestion(
            "Choose the correct answer",
            "Which language is used with .NET?",
            5,
            answers2,
            answers2[1]
        );

        // Create Final Exam
        FinalExam finalExam = new FinalExam(30, 2);

        finalExam.QuestionList[0] = q1;
        finalExam.QuestionList[1] = q2;

        // Assign Exam to Subject
        subject.CreateExam(finalExam);

        // Display Subject
        Console.WriteLine($"Student ID: {studentId}, Student Name: {studentName}");
        Console.WriteLine(subject);

        // Start Exam
        if (subject.Exam != null)
        {
            subject.Exam.ShowExam();
        }
    }
}
