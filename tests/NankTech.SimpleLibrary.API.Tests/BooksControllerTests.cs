using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using NankTech.SimpleLibrary.API.Controllers;
using NankTech.SimpleLibrary.API.Data.Models;
using NankTech.SimpleLibrary.API.Services;
using NuGet.ContentModel;

namespace NankTech.SimpleLibrary.API.Tests;

public class BooksControllerTests
{
    private readonly IBookService _bookService;
    private readonly BooksController _booksController;

    public BooksControllerTests()
    {
        _bookService = new BookService();
        _booksController = new BooksController(_bookService);
    }

    [Fact]
    public void Get_Should_Return_Ok_When_Request_Comes_Without_Any_Parameters()
    {
        //Arrange -> No Match
        
        //Act
        var actual = _booksController.Get();

        //Assert
        Assert.IsType<OkObjectResult>(actual.Result);

    }

    [Fact]
    public void Get_Should_Be_Type_As_A_Books_List_When_Request_Comes_Without_Any_Parameters()
    {
        //Arrange
       
        //Act
        var actual = _booksController.Get();

        var myBookList = actual.Result as OkObjectResult;
        
        //Assert
        Assert.IsType<List<Book>>(myBookList?.Value);
        
    }

    [Theory]
    [InlineData(5)]
    public void Get_Should_Return_Just_5_Books_When_Request_Comes_Without_Any_Parameters(int expected)
    {
        //Arrange
        //Act
        var actual = _booksController.Get();
        
        var list = actual.Result as OkObjectResult;
        var myBooksList = list?.Value as List<Book>;
        
        //Assert
        Assert.Equal(expected, myBooksList?.Count);
    }


    [Theory]
    [InlineData("cfb9d878-f920-4909-8860-b53b81b202df")]
    public void GetById_Should_Return_Not_Found_When_Invalid_Guid_Comes(string randomGuid)
    {
        //Arrange
        var invalidGuid = new Guid(randomGuid);
        //Act
        var actual = _booksController.GetById(invalidGuid);

        //Assert
        Assert.IsType<NotFoundResult>(actual.Result);

    }

    [Theory]
    [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
    public void GetById_Should_Return_Ok_When_Valid_Guid_Comes(string randomGuid)
    {
        //Arrange
        var validGuid = new Guid(randomGuid);
        //Act
        var actual = _booksController.GetById(validGuid);
        
        //Assert
        Assert.IsType<OkObjectResult>(actual.Result);
    }

    [Theory]
    [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
    public void GetById_Should_Be_Type_As_A_Book_When_Valid_Guid_Comes(string randomGuid)
    {
        //Arrange
        var validGuid = new Guid(randomGuid);
        //Act
        var actual = _booksController.GetById(validGuid);
        var singleBook = actual.Result as OkObjectResult;
        
        //Assert
        Assert.IsType<Book>(singleBook?.Value);
    }

    [Theory]
    [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
    public void GetById_Should_Be_Match_All_Fields_When_With_Valid_Incoming_Guid(string randomGuid)
    {
        //Arrange
        var validGuid = new Guid(randomGuid);
        var expectedId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        var expectedTitle = "Managing Oneself";
        var expectedAuthor = "Peter Ducker";
        
        //Act
        var actual = _booksController.GetById(validGuid);
        var item = actual.Result as OkObjectResult;
        var myBook = item?.Value as Book;
        
        //Assert
        Assert.Equal(expectedId, myBook?.Id);
        Assert.Equal(expectedTitle, myBook?.Title);
        Assert.Equal(expectedAuthor, myBook?.Author);
    }
    
    [Fact]
    public void Post_Should_Return_Created_When_Valid_All_Book_Parameters_Comes_From_Request_Body()
    {
        //arrange
        var myNewBook = new Book()
        {
            Id = Guid.NewGuid(),
            Title = "The Conqueror",
            Description = "random",
            Author = "Mustafa KARACABEY"
        };
        
        //Act
        var actualResponse = _booksController.Post(myNewBook);
        
        //Assert

        Assert.IsType<CreatedAtActionResult>(actualResponse);
    }

    [Fact]
    public void Post_Should_Be_Type_As_A_Book_When_Valid_Book_Parameters_Comes_From_Request_Body()
    {
        //arrange
        var myNewBook = new Book()
        {
            Id = Guid.NewGuid(),
            Title = "The Conqueror",
            Description = "random",
            Author = "Mustafa KARACABEY"
        };
        
        //Act
        var actualResponse = _booksController.Post(myNewBook);
        var item = actualResponse as CreatedAtActionResult;
        
        //Assert
        Assert.IsType<Book>(item?.Value);
    }

    [Fact]
    public void Post_Should_Be_Equal_All_Field_When_My_New_Book_Comes()
    {
        //arrange
        var myNewBook = new Book()
        {
            Id = Guid.NewGuid(),
            Title = "The Conqueror",
            Description = "random",
            Author = "Mustafa KARACABEY"
        };
        
        //Act
        var actualResponse = _booksController.Post(myNewBook);
        var item = actualResponse as CreatedAtActionResult;
        var myBook = item?.Value as Book;
        //Assert
        Assert.Equal(myNewBook.Id, myBook?.Id);
        Assert.Equal(myNewBook.Author, myBook?.Author);
        Assert.Equal(myNewBook.Description, myBook?.Description);
    }

    [Fact]
    public void Post_Should_Return_Bad_Request_When_InComplete_Parameters_Comes_From_Request_Body()
    {
        //Assert
        var myNewBook = new Book()
        {
            Description = "random",
            Author = "Mustafa KARACABEY"
        };
        
        //Act
        _booksController.ModelState.AddModelError("Title", "Title is a required filed");
        var actualResponse = _booksController.Post(myNewBook);
        
        //Arrange
        Assert.IsType<BadRequestObjectResult>(actualResponse);
    }

    [Theory]
    [InlineData("ab2bd817-98cd-4cf3-a80a-53ea11d9c200")]
    public void Remove_Should_Return_Not_Found_When_Not_Existing_Id_Guid_Comes(string id)
    {
        //Arrange
        var myGuid = new Guid(id);
        
        //Act
        var actualResponse = _booksController.Remove(myGuid);
        var totalBookCount = _bookService.GetAll().Count();
        
        //Assert
        Assert.IsType<NotFoundResult>(actualResponse);
        Assert.Equal(5, totalBookCount);
    }

    [Theory]
    [InlineData("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200")]
    public void Remove_Should_Return_Ok_When_Existing_Id_Guid_Comes(string id)
    {
        //Arrange
        var myGuid = new Guid(id);
        
        //Act
        var actualResponse = _booksController.Remove(myGuid);
        var totalBookCount = _bookService.GetAll().Count();
        
        //Assert
        Assert.IsType<OkResult>(actualResponse);
        Assert.Equal(4, totalBookCount);
    }

}