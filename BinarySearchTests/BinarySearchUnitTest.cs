using Binary.Search;
using System.Diagnostics;

namespace BinarySearchTests
{
    public class BinarySearchUnitTest
    {
        void setLogger(string testName)
        {
            string logPath = Path.Combine(Environment.CurrentDirectory, $"log-{testName}.txt");
            TextWriterTraceListener logFile = new(File.CreateText(logPath));
            Trace.Listeners.Add(logFile);
            Trace.AutoFlush = true;
        }

        [Fact]
        public void Test1()
        {
            setLogger("Test1");
            var bs = new BinarySearchClass();
            var l = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var val = 5;
            var result = bs.BinarySearch(l, val);
            Assert.Equal(4, result);
        }
        [Fact]
        public void Test2()
        {
            setLogger("Test2");
            var bs = new BinarySearchClass();
            var l = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < l.Count; i++)
            {
                var val = l[i];
                var result = bs.BinarySearch(l, val);
                Assert.Equal(i, result);
            }
        }
        [Fact]
        public void Test3()
        {
            setLogger("Test3");
            var bs = new BinarySearchClass();
            var l = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var val = 20;
            var result = bs.BinarySearch(l, val);
            Assert.Equal(-1, result);

        }
        [Fact]
        public void Test4()
        {
            setLogger("Test4");
            var bs = new BinarySearchClass();
            var l = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            for (int i = 0; i < l.Count; i++)
            {
                var val = l[i];
                var result = bs.BinarySearch(l, val);
                Assert.Equal(i, result);
            }
        }

    }
}