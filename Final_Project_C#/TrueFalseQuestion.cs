
using System;

public class TrueFalseQuestion : Question
{
    public TrueFalseQuestion(
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