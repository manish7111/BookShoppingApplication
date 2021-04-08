using BookStoreApplication.Controllers;
using BookStoreManagerLayer.IManager;
using BookStoreManagerLayer.Manager;
using BookStoreModelLayer;
using BookStoreRepositoryLayer.IRepository;
using Moq;
using NUnit.Framework;

namespace BookStoreAppTesting
{
    public class Tests
    {
        public readonly Books book = new Books();
        Mock<IBookManager> serviceController;
        Mock<IBookRepo> serviceRepo;
        [SetUp]
        public void Setup()
        {
            book.BookTitle = "Life of pie";
            book.AuthorName = "Bala";
            book.Price = 200;
            book.Summary = "Refelects the life of an person";
            book.BookImage = "image";
            book.BookCount = 20;
            this.serviceController = new Mock<IBookManager>();
            this.serviceRepo = new Mock<IBookRepo>();
        }

        [Test]
        public void GivenBookDetails_WhenAdded_ShouldReturnDataObject()
        {
            var controller = new BookController(this.serviceController.Object);
            var result = controller.AddBooks(book);
            Assert.NotNull(result);
        }
        [Test]
        public void WhenCalled_ShouldReturnAllBooks()
        {
            var controller = new BookController(serviceController.Object);
            var result = controller.GetAllBooks();
            Assert.NotNull(result);
        }
        [Test]
        public void GivenBookDetails_WhenAdded_ShouldReturnDataObjectRepository()
        {
            var repo = new BookManager(this.serviceRepo.Object);
            var result = repo.AddBooks(book);
            Assert.NotNull(result);
        }
    }
}