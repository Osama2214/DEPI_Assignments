
using System;

public class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public Exam? Exam { get; private set; }

    public Subject(int subjectId, string subjectName)
    {
        SubjectId = subjectId;
        SubjectName = subjectName;
    }

    public void CreateExam(Exam exam)
    {
        Exam = exam;
    }

    public override string ToString()
    {
        return $"Subject ID: {SubjectId}, Subject Name: {SubjectName}";
    }
}