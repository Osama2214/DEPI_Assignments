
using System;

public class FinalExam : Exam
{
    public FinalExam(int time, int numberOfQuestions)
        : base(time, numberOfQuestions)
    {
    }

    public override void ShowExam()
    {
        Console.WriteLine("===== Final Exam =====");
        Console.WriteLine($"Time: {Time} minutes");
        Console.WriteLine($"Number of Questions: {NumberOfQuestions}");

        int grade = 0;
        int totalGrade = 0;
        List<Question> wrongQuestions = new List<Question>();

        foreach (Question question in QuestionList)
        {
            question.DisplayQuestion();

            int answerId = ReadAnswer(question);

            if (answerId == question.RightAnswer.AnswerId)
            {
                grade += question.Mark;
            }
            else
            {
                wrongQuestions.Add(question);
            }

            totalGrade += question.Mark;
            Console.WriteLine();
        }

        Console.WriteLine($"Grade: {grade} / {totalGrade}");

        if (grade >= totalGrade / 2.0)
        {
            Console.WriteLine("Result: Passed");
        }
        else
        {
            Console.WriteLine("Result: Failed");
        }

        if (wrongQuestions.Count > 0)
        {
            Console.WriteLine("\n===== Wrong Answers =====");

            foreach (Question question in wrongQuestions)
            {
                Console.WriteLine($"Question: {question.Body}");
                Console.WriteLine($"Correct Answer: {question.RightAnswer.AnswerText}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("All answers are correct.");
        }
    }
}
