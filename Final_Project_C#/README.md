# Examination System

A simple console-based examination system built with C# and Object-Oriented Programming principles.

## Features

- Supports Final and Practical exams.
- Supports True/False and MCQ questions.
- Accepts the student's ID and name.
- Validates the selected answer ID.
- Calculates and displays the final grade.
- Shows whether the student passed or failed.
- Displays incorrect questions with their correct answers.
- Shows correct answers after completing a Practical exam.
- Supports Arabic student names in the console.

## OOP Concepts

- Abstraction through the `Question` and `Exam` base classes.
- Inheritance for question and exam types.
- Polymorphism through the `ShowExam` and `DisplayQuestion` methods.
- Association between `Subject`, `Exam`, `Question`, and `Answer`.
- Implementation of `ICloneable` and `IComparable`.
- Constructor chaining and method overriding.

## Project Structure

- `Answer.cs`: Represents an answer and its ID.
- `Question.cs`: Base class for all question types.
- `TrueFalseQuestion.cs`: Represents True/False questions.
- `MCQQuestion.cs`: Represents multiple-choice questions.
- `Exam.cs`: Base class for all exam types.
- `FinalExam.cs`: Calculates the grade and shows incorrect answers.
- `PracticalExam.cs`: Shows the correct answers after the exam.
- `Subject.cs`: Associates a subject with its exam.
- `Program.cs`: Creates and starts the exam.

## Pass and Fail Rule

- A student passes with 50% or more of the total grade.
- A student fails with less than 50%.

## Run the Project

Make sure the .NET 10 SDK is installed, then run:

```bash
dotnet run
```

## Author

**Osama Ahmed**

GitHub: [@Osama2214](https://github.com/Osama2214)
