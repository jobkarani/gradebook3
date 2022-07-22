using System;
using Xunit;

namespace GradeBook.Tests;

public delegate string WriteLogDelegate (string logMessage);

public class TypeTest
{
    int count = 0;
    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log = ReturnMessage;

        log += ReturnMessage;
        log += IncrementCount;

        var result = log ("Hello!");
        // Assert.Equal("Hello!", result);
        Assert.Equal(3, count);
    }   

    string IncrementCount(string message){
        count ++;
        return message;
    } 
    string ReturnMessage(string message){
        count ++;
        return message;
    } 

    [Fact]
    public void Test1()
    {
        var x = GetInt();
        SetInt( ref x);


        Assert.Equal( 42, x);

    }
    public void SetInt(ref int x)
    {
        x = 42;
    }
    private int GetInt()
    {
        return 3;
    }

    [Fact]
    public void CsharpCanPassByReference()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(ref book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetName(ref Book Book, string name)
    {
        Book = new Book(name);
    }
    
    [Fact]
    public void CsharpIsPassByValue()
    {
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");

        Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(Book Book, string name)
    {
        Book = new Book(name);
    }

    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
        string name = "Job";
        var upper = MakeUpperCase(name);

        Assert.Equal("Job", name);
        Assert.Equal("JOB", upper);
    }
    private string MakeUpperCase(string param)
    {
        return param.ToUpper();
    }

    [Fact]
    public void CanSetNameFromReference()
    {
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        Assert.Equal("New Name", book1.Name);
    }

    private void SetName(Book Book, string name)
    {
        Book.Name = name;
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotSame(book1, book2);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObjects()
    {
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1,book2));
    }

    Book GetBook(string name)
    {
        return new Book(name);
    }
}   