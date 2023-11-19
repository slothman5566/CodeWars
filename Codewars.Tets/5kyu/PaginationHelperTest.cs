using CodeWars._5kyu;

namespace Codewars.Tets._5kyu
{
    [TestFixture, Order(1)]
    public class SampleTestsFromDescription
    {
        private readonly IList<char> collection = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f' };
        private PaginationHelper<char> helper;

        [SetUp]
        public void SetUp()
        {
            helper = new PaginationHelper<char>(collection, 4);
        }

        [Test]
        public void PageCountTest()
        {
            Assert.AreEqual(2, helper.PageCount);
        }

        [Test]
        public void ItemCountTest()
        {
            Assert.AreEqual(6, helper.ItemCount);
        }


        [Test]
        [TestCase(0, ExpectedResult = 4)]
        [TestCase(1, ExpectedResult = 2)]
        [TestCase(2, ExpectedResult = -1)]
        public int PageItemCountTest(int pageIndex)
        {
            return helper.PageItemCount(pageIndex);
        }

        [Test]
        [TestCase(5, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 0)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(-10, ExpectedResult = -1)]
        public int PageIndexTest(int itemIndex)
        {
            return helper.PageIndex(itemIndex);
        }

    }

    [TestFixture, Order(2)]
    public class EmptyCollection
    {
        private readonly IList<string> collection = Array.Empty<string>();
        private PaginationHelper<string> helper;

        [SetUp]
        public void SetUp()
        {
            helper = new PaginationHelper<string>(collection, 4);
        }

        [Test]
        public void PageCountTest()
        {
            Assert.AreEqual(0, helper.PageCount);
        }

        [Test]
        public void ItemCountTest()
        {
            Assert.AreEqual(0, helper.ItemCount);
        }


        [Test]
        [TestCase(0, ExpectedResult = -1)]
        [TestCase(1, ExpectedResult = -1)]
        [TestCase(-1, ExpectedResult = -1)]
        public int PageItemCountTest(int pageIndex)
        {
            return helper.PageItemCount(pageIndex);
        }

        [Test]
        [TestCase(0, ExpectedResult = -1)]
        [TestCase(1, ExpectedResult = -1)]
        [TestCase(-1, ExpectedResult = -1)]
        public int PageIndexTest(int itemIndex)
        {
            return helper.PageIndex(itemIndex);
        }
    }
}
