using Moq;
using NUnit.Framework;
using Shouldly;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Interfaces.Repositories;

namespace LibraryManager.Tests;

public class BookRepoTests {
    private Mock<IBookRepository> _mockBookRepository;
    private IBookRepository _bookRepository;
    private readonly List<Book> _booksStore = [];

    [SetUp]
    public void SetUp() {
        SetUpScene();
    }

    [Test]
    public async Task AddBookTest() {
        await AddOneBook();
    }

    [Test]
    public async Task UpdateBookTest() {
        await AddOneBook();
        var book = new Book {
            Title = "The Hobbit 2: The return",
        };

        await _bookRepository.Update(1, book);
        var book1 = await _bookRepository.GetById(1);
        book1.ShouldNotBeNull();
        book1.Title.ShouldBe("The Hobbit 2: The return");
    }

    private async Task AddOneBook() {
        _booksStore.Clear();
        var book = new Book {
            Id = 1,
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            ISBN = "9780547928227",
            PublishDate = new DateOnly(1937, 9, 21)
        };

        await _bookRepository.Add(book);
        var books = await _bookRepository.GetAll();
        var book1 = await _bookRepository.GetById(1);

        books.Count().ShouldBe(1);
        book1.Title.ShouldBe("The Hobbit");
    }

    private void SetUpScene() {
        _mockBookRepository = new Mock<IBookRepository>();

        _mockBookRepository.Setup(repo => repo.GetAll())
            .ReturnsAsync(_booksStore);

        _mockBookRepository.Setup(repo => repo.Add(It.IsAny<Book>()))
            .Callback<Book>(book => _booksStore.Add(book))
            .Returns(Task.CompletedTask);

        _mockBookRepository.Setup(repo => repo.GetById(It.IsAny<int>()))
            .ReturnsAsync((int id) => _booksStore.FirstOrDefault(b => b.Id == id));

        _mockBookRepository.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<Book>()))
            .Callback<int, Book>((id, bookToUpdate) => {
                var bookInStore = _booksStore.FirstOrDefault(b => b.Id == id);
                if (bookInStore != null) {
                    bookInStore.Title = bookToUpdate.Title;
                    bookInStore.Author = bookToUpdate.Author;
                    bookInStore.ISBN = bookToUpdate.ISBN;
                    bookInStore.PublishDate = bookToUpdate.PublishDate;
                }
            })
            .Returns(Task.CompletedTask);

        _bookRepository = _mockBookRepository.Object;
    }
}