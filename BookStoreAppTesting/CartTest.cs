using BookStoreApplication.Controllers;
using BookStoreManagerLayer.IManager;
using BookStoreModelLayer;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAppTesting
{
    public class CartTest
    {
        public readonly Cart cart = new Cart();
        Mock<ICartManager> serviceController;
        [SetUp]
        public void Setup()
        {
            cart.BookId = 1;
            cart.SelectedBookCount = 1;
            this.serviceController = new Mock<ICartManager>();
        }
        [Test]
        public void GivenCartDetails_WhenAdded_ShouldReturnDataObject()
        {
            var controller = new CartController(this.serviceController.Object);
            var result = controller.AddBooksToCart(cart);
            Assert.NotNull(result);
        }
        [Test]
        public void GivenCartId_WhenDeleted_ShouldReturnCartItemDeteled()
        {
            var controller = new CartController(this.serviceController.Object);
            var result = controller.DeleteBookFromCart(1);
            Assert.NotNull(result);
        }
        [Test]
        public void GivenCartDetails_WhenUpdated_ShouldReturnDataObject()
        {
            var controller = new CartController(this.serviceController.Object);
            var result = controller.UpdateBookInCart(cart);
            Assert.NotNull(result);
        }
    }
}
