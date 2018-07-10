using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStringUtils
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStartWithSpaceOrNull()
        {
            string[] words = { string.Empty, null };
            foreach (var w in words)
            {
                bool result = UtilsLibraries.StringUtils.IsFirstCharUpper(w);
                Assert.IsFalse(result, $"Risultato per {(w == null ? "<null>" : w)} = {result}");
            }
        }

        [TestMethod]
        public void TestStartWithUpper()
        {
            string[] words = { "MyTestTest", "MyFirstTest", "MYFIRST TEST" };
            foreach (string w in words)
            {
                bool result = UtilsLibraries.StringUtils.IsFirstCharUpper(w);
                Assert.IsTrue(result, $"Risultato per {w} = {result}");
            }
        }

        [TestMethod]
        public void TestStartWithLower()
        {
            string[] words = { "myTestTest", "myfirsttestest", "mYFIRST TEST" };
            foreach (string w in words)
            {
                bool result = !UtilsLibraries.StringUtils.IsFirstCharUpper(w);
                Assert.IsTrue(result, $"Risultato per {w} = {result}");
            }
        }
    }
}
