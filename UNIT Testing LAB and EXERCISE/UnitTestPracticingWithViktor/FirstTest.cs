namespace UnitTestPracticingWithViktor
{
    public class FirstTest
    {
        [Test]
        public void Test()
        {
            int result = 1 + 5;
            Assert.AreEqual(6, result);
        }
    }
}