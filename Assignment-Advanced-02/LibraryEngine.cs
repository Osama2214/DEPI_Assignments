
using System;
using System.Collections.Generic;

// User-defined delegate
public delegate string BookDelegate(Book B);

public class LibraryEngine
{
    // Case A: User-defined Delegate
    public static void ProcessBooks(
        List<Book> bList,
        BookDelegate fPtr)
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(fPtr(B));
        }
    }

    // Case B: Built-in Func Delegate
    public static void ProcessBooks(
        List<Book> bList,
        Func<Book, string> fPtr)
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(fPtr(B));
        }
    }
}