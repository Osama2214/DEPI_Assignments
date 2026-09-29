
using System;

public abstract class Exam
{
    public int Time { get; set; }
    public int NumberOfQuestions { get; set; }
    public Question[] QuestionList { get; set; }

    public Exam(int time, int numberOfQuestions)
    {
        Time = time;
        NumberOfQuestions = numberOfQuestions;
        QuestionList = new Question[numberOfQuestions];
    }

    public abstract void ShowExam();

    protected int ReadAnswer(Question question)
    {
        while (true)
        {
            Console.Write("Enter Answer Id: ");

            if (int.TryParse(Console.ReadLine(), out int answerId))
            {
                foreach (Answer answer in question.AnswerList)
                {
                    if (answer.AnswerId == answerId)
                    {
                        return answerId;
                    }
                }
            }

            Console.WriteLine("Invalid answer. Try again.");
        }
    }
}
