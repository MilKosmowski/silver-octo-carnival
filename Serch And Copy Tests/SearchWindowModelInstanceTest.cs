using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchWindow.Tests
{
    [TestClass()]
    public class SearchWindowModelInstanceTest
    {
        [TestInitialize()]
        public void Startup()
        {
            string srcName = @"SourceDirectorySearchWindowModelInstanceTest";

            Directory.CreateDirectory(srcName);

            for (int i = 1; i <= 4; i++)
                if (!File.Exists($@"{srcName}\{i}.txt"))
                    File.Move($@"Test text files source\{i}.txt", $@"{srcName}\{i}.txt");
        }

        [TestMethod()]
        public void SearchWindowModelOverloadTest()
        {
            string srcName = @"SourceDirectorySearchWindowModelInstanceTest";

            SearchWindowModel Model = new SearchWindowModel("TestStringToFind TestStringToFind2 TestStringToFind3", srcName, "DestinationDirectoryTest", 3);

            List<string> fileListTest = new List<string>() { $@"{srcName}\1.txt", $@"{srcName}\2.txt", $@"{srcName}\3.txt", $@"{srcName}\4.txt" };
            List<string> listOfWhatToLookForTest = new List<string>() { "TestStringToFind", "TestStringToFind2", "TestStringToFind3" };

            CollectionAssert.AreEqual(fileListTest, Model.fileList);
            CollectionAssert.AreEqual(listOfWhatToLookForTest, Model.arrayOfWhatToLookFor);
            Assert.AreEqual(3, Model.lineToCheck);
            Model = null;
            fileListTest = null;
            listOfWhatToLookForTest = null;
        }

        [TestCleanup()]
        public void Cleanup()
        {
            string srcName = @"SourceDirectorySearchWindowModelInstanceTest";

            for (int i = 1; i <= 4; i++)
                if (File.Exists($@"{srcName}\{i}.txt"))
                    File.Delete($@"{srcName}\{i}.txt");

            if (Directory.Exists(srcName))
                Directory.Delete(srcName);

            Debug.WriteLine("TestCleanup");
        }
    }
}