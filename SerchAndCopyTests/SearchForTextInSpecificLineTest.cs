using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SearchWindow.Tests
{
    [TestClass()]
    public class SearchForTextVariants
    {
        [TestInitialize()]
        public void Startup()
        {
            Directory.CreateDirectory("SourceDirectoryTest");
            Directory.CreateDirectory("DestinationDirectoryTest");
            //Directory.CreateDirectory("Test text files source");

            for (int i = 1; i <= 5; i++)
            {
                if (File.Exists($@"SourceDirectoryTest\{i}.txt"))
                    File.Delete($@"SourceDirectoryTest\{i}.txt");

                if (File.Exists($@"DestinationDirectoryTest\{i}.log"))
                    File.Delete($@"DestinationDirectoryTest\{i}.txt");

                if (File.Exists($@"TestTextFilesSource\{i}.txt"))
                    File.Move($@"TestTextFilesSource\{i}.txt", $@"SourceDirectoryTest\{i}.txt");
            }

            this.BWorker = new System.ComponentModel.BackgroundWorker();
            this.BWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWorker_DoWork);
            BWorker.WorkerReportsProgress = true;
        }

        [TestMethod()]
        public void SearchForTextInOneLineTest()
        {
            SearchWindowModel Model1 = new SearchWindowModel("TestStringToFindInFile", "SourceDirectoryTest", "DestinationDirectoryTest", 171);
            SearchForSpecificLine SearchInst = new SearchForSpecificLine(Model1, BWorker);

            string[] LogText = null;
            if (File.Exists("TransferLog.log"))
                LogText = File.ReadAllLines("TransferLog.log");

            Assert.IsTrue(File.Exists(@"DestinationDirectoryTest\4.txt"));
            Assert.IsTrue(LogText.Contains(@"4.txt                                              --> contains text: TestStringToFindInFile"));
        }

        [TestMethod()]     
        public void SearchForTextInBigFiles()
        {
            SearchWindowModel Model2 = new SearchWindowModel("TestStringToFindInFile", "SourceDirectoryTest", "DestinationDirectoryTest");

            SearchWindow.SearchStreamReaderMethod SearchInst = new SearchWindow.SearchStreamReaderMethod(Model2, BWorker);

            string[] LogText = null;
            if (File.Exists("TransferLog.log"))
                LogText = File.ReadAllLines("TransferLog.log");

            Assert.IsTrue(File.Exists(@"DestinationDirectoryTest\4.txt"));
            Assert.IsTrue(LogText.Contains(@"4.txt                                              --> contains text: TestStringToFindInFile"));
        }

        [TestMethod()]
        public void SearchForTextInLotsOfSmallFiles()
        {
            SearchWindowModel Model3 = new SearchWindowModel("TestStringToFindInFile", "SourceDirectoryTest", "DestinationDirectoryTest");

            SearchWindow.SearchLinqMethod SearchInst = new SearchWindow.SearchLinqMethod(Model3, BWorker);

            string[] LogText = null;

            if (File.Exists("TransferLog.log"))
                LogText = File.ReadAllLines("TransferLog.log");

            Assert.IsTrue(File.Exists(@"DestinationDirectoryTest\4.txt"));
            Assert.IsTrue(LogText.Contains(@"4.txt                                              --> contains text: TestStringToFindInFile"));
        }

        [TestMethod()]
        public void SearchForTextInLotsOfSmallFilesMultiple()
        {
            SearchWindowModel Model3 = new SearchWindowModel("TestStringToFindInFile", "SourceDirectoryTest", "DestinationDirectoryTest",true);

            SearchWindow.SearchLinqMethod SearchInst = new SearchWindow.SearchLinqMethod(Model3, BWorker);

            string[] LogText = null;

            if (File.Exists("TransferLog.log"))
                LogText = File.ReadAllLines("TransferLog.log");

            Assert.IsTrue(File.Exists(@"DestinationDirectoryTest\4.txt"));
            Assert.IsTrue(File.Exists(@"DestinationDirectoryTest\5.txt"));
            Assert.IsTrue(LogText.Contains(@"4.txt                                              --> contains text: TestStringToFindInFile"));
        }



        [TestCleanup()]
        public void Cleanup()
        {
            for (int i = 1; i <= 5; i++)
            {
                if (File.Exists($@"DestinationDirectoryTest\{i}.txt"))
                    File.Move($@"DestinationDirectoryTest\{i}.txt", $@"TestTextFilesSource\{i}.txt");

                if (File.Exists($@"SourceDirectoryTest\{i}.txt") && !File.Exists($@"TestTextFilesSource\{i}.txt"))
                    File.Copy($@"SourceDirectoryTest\{i}.txt", $@"TestTextFilesSource\{i}.txt");
            }

            if (File.Exists("TransferLog.log"))
                File.Delete("TransferLog.log");
        }

        private void BWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }

        private System.ComponentModel.BackgroundWorker BWorker;
    }
}