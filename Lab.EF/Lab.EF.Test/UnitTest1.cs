using Lab.EF.Data;
using Lab.EF.Entities;
using Lab.EF.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;

namespace Lab.EF.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllCategories()
        {
            var data = new List<Categories>{}.AsQueryable();

            var mockSet = new Mock<DbSet<Categories>>();
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var service = new CategoriesLogic(mockContext.Object);
            var blogs = service.GetAll();

            Assert.AreEqual(8, blogs.Count);
            Assert.AreEqual(1, blogs[0].CategoryID);
            Assert.AreEqual("Beverages", blogs[0].CategoryName);
            Assert.AreEqual("Soft drinks, coffees, teas, beers, and ales", blogs[0].Description);
        }

    }
}
