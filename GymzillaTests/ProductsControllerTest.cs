using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymzilla.Data;
using Gymzilla.Controllers;
using Gymzilla.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore; // for the in memory db
using Microsoft.AspNetCore.Mvc; // to extract the view result

namespace GymzillaTests
{
    [TestClass]
    public class ProductsControllerTest
    {
        // When a test uses a database
        // we need to 'Mock' this data
        // use in-memory databases for testing
        private ApplicationDbContext _context;
        private ProductsController _controller;
        private List<Product> _products = new List<Product>();


        // Arrange step
        [TestInitialize]
        public void TestInitialize()
        {
            // instantiate in-memory db context
            // similar to registering your db in startup.cs
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                                .Options;
            _context = new ApplicationDbContext(options);

            // mock some data
            // categories
            var category = new Category { CategoryId = 1, Name = "Cardio" };
            _context.Categories.Add(category);
            _context.SaveChanges();
            // brands
            var brand = new Brand { BrandId = 1, Name = "Canadian Tire" };
            _context.Brands.Add(brand);
            _context.SaveChanges();

            // list of products
            var product1 = new Product { ProductId = 1, Name = "Elliptical", Brand = brand, Category = category };
            var product2 = new Product { ProductId = 2, Name = "Bicyle", Brand = brand, Category = category };
            var product3 = new Product { ProductId = 3, Name = "Treadmill", Brand = brand, Category = category };
            
            // add products to mock dbs
            _context.Products.Add(product1);
            _context.Products.Add(product2);
            _context.Products.Add(product3);
            _context.SaveChanges();

            // add products to local list
            _products.Add(product1);
            _products.Add(product2);
            _products.Add(product3);

            // instantiate the controller object with mock db context
            _controller = new ProductsController(_context);
        }

        // Test 1 > making sure index loads
        [TestMethod]
        public void IndexReturnsView() {
            // skip arrange, TestInitialize is called everytime the test runs
            // Act
            var result = _controller.Index();
            // Assert
            Assert.IsNotNull(result);
        }

        // Test 2 > making sure index loads some data
        [TestMethod]
        public void IndexReturnsProductData() {
            // Act > call index and retrieve data from view
            var result = _controller.Index();
            // extract view
            var viewResult = (ViewResult)result.Result;
            // extract the model
            var model = (List<Product>)viewResult.Model;
            // order data
            var orderedProducts = _products.OrderBy(p => p.Name).ToList();
            // Assert
            CollectionAssert.AreEqual(orderedProducts, model);
        }

        // Test 3 > making sure I get a NotFound result if I try to get details from a non-existant ID
        [TestMethod]
        public void DetailsReturnsNotFoundIfIdIsNotValid() {
            var testId = 100;
            var actionResult = _controller.Details(testId);
            var notFoundResult = (NotFoundResult)actionResult.Result; // convert generic ActionResult object to the expected result
            // make sure app returns 404 when searching for an invalid id
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        // Test 4 > making sure I can add a new product
        [TestMethod]
        public void PostCreateProduct() {
            // create a new product
            var newProduct = new Product
            {
                ProductId = 4,
                Name = "Jumping Rope",
                Category = new Category() { CategoryId = 2, Name = "Jumping Gear" },
                Brand = new Brand() { BrandId = 2, Name = "PC Gym" }
            };

            // call create method and pass new product, this will add it to the database from the controller
            var result = _controller.Create(newProduct, null);

            // test the context to check whether I can find a product with ID 4
            var prod = _context.Products.Find(4);
            // check whether prod is null (not found)
            Assert.IsNotNull(prod);
        }

    }
}
