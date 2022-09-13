using Microsoft.AspNetCore.Mvc;
using NankTech.SimpleLibrary.API.Controllers;
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
    public void Get_Should_Return_Ok_Books_When_Request_Comes_Without_Any_Parameters()
    {
        //Arrange -> No Match
        //Act
        var actual = _booksController.Get();

        //Assert
        Assert.IsType<OkObjectResult>(actual.Result);

    }
}