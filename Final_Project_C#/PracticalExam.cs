
using System;

public class PracticalExam : Exam
{
    public PracticalExam(int time, int numberOfQuestions)
        : base(time, numberOfQuestions)
    {
    }

    public override void ShowExam()
    {
        Console.WriteLine("===== Practical Exam =====");
        Console.WriteLine($"Time: {Time} minutes");
        Console.WriteLine($"Number of Questions: {NumberOfQuestions}");

        foreach (Question question in QuestionList)
        {
            question.DisplayQuestion();
            ReadAnswer(question);
            Console.WriteLine();
        }

        Console.WriteLine("===== Correct Answers =====");

        foreach (Question question in QuestionList)
        {
            Console.WriteLine(
                $"{question.Body} -> {question.RightAnswer.AnswerText}");
        }
    }
}
