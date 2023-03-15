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
        public void El_Metodo_Add_de_la_logica_invoca_al_Add_y_al_SaveChanges_del_Context()
        {
            var mockSet = new Mock<DbSet<Categories>>();

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Categories).Returns(mockSet.Object);

            CategoriesLogic categoryLogic = new CategoriesLogic(mockContext.Object);

            categoryLogic.Add(new Categories
            {
                CategoryName = "Prueba",
                Description = "Descripción prueba",      

            });

            mockSet.Verify(m => m.Add(It.IsAny<Categories>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetAll_Devuelve_Mas_de_un_elemento()
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
