
using System;

public class MCQQuestion : Question
{
    public MCQQuestion(
        string header,
        string body,
        int mark,
        Answer[] answerList,
        Answer rightAnswer)
        : base(header, body, mark, answerList, rightAnswer)
    {
    }

    public override void DisplayQuestion()
    {
        Console.WriteLine(ToString());

        foreach (Answer answer in AnswerList)
        {
            Console.WriteLine(answer);
        }
    }
}