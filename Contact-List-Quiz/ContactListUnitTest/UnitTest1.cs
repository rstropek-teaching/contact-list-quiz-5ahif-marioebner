using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contact_List_Quiz;
using Microsoft.AspNetCore.Mvc;

namespace ContactListUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAll()
        {
            var controller = new ContactController();

            var result = controller.GetAll() as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestFindByName()
        {
            var controller = new ContactController();

            var result = controller.GetByName("ebner") as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
