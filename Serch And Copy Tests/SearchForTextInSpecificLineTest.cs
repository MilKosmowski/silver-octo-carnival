using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchWindow;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Directory.CreateDirectory("Test text files source");

            for (int i = 1; i <= 4; i++)
            {
                if (File.Exists($@"SourceDirectoryTest\{i}.txt"))
                    File.Delete($@"SourceDirectoryTest\{i}.txt");

                if (File.Exists($@"DestinationDirectoryTest\{i}.log"))
                    File.Delete($@"DestinationDirectoryTest\{i}.txt");

                if (File.Exists($@"Test text files source\{i}.txt"))
                    File.Move($@"Test text files source\{i}.txt", $@"SourceDirectoryTest\{i}.txt");
            }

            this.BWorker = new System.ComponentModel.BackgroundWorker();
            this.BWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWorker_DoWork);
            BWorker.WorkerReportsProgress = true;
        }

        [TestMethod()]
        public void SearchForTextInOneLineTest()
        {
            SearchWindowModel Model1 = new SearchWindowModel("TestStringToFindInFile", "SourceDirectoryTest", "DestinationDirectoryTest", 171);
            SearchForTextInSpecificLine SearchInst = new SearchForTextInSpecificLine(Model1, BWorker);

            string[] LogText=null;
            if (File.Exists("TransferLog.log"))
                LogText = File.ReadAllLines("TransferLog.log");

            Assert.IsTrue(File.Exists(@"DestinationDirectoryTest\4.txt") && LogText.Contains(@"SourceDirectoryTest\4.txt                          --> contains text: TestStringToFindInFile"));
        }

        [TestMethod()]
        public void SearchForTextInBigFiles()
        {
            SearchWindowModel Model2 = new SearchWindowModel("TestStringToFindInFile", "SourceDirectoryTest", "DestinationDirectoryTest");

            SearchWindow.SearchForTextStreamReaderMethod SearchInst = new SearchWindow.SearchForTextStreamReaderMethod(Model2, BWorker);

            string[] LogText = null;
            if (File.Exists("TransferLog.log"))
                LogText = File.ReadAllLines("TransferLog.log");

            Assert.IsTrue(File.Exists(@"DestinationDirectoryTest\4.txt"));
            Assert.IsTrue(LogText.Contains(@"SourceDirectoryTest\4.txt                          --> contains text: TestStringToFindInFile"));
        }

        [TestMethod()]
        public void SearchForTextInLotsOfSmallFiles()
        {
            SearchWindowModel Model2 = new SearchWindowModel("TestStringToFindInFile", "SourceDirectoryTest", "DestinationDirectoryTest");

            SearchWindow.SearchForTextLinqMethod SearchInst = new SearchWindow.SearchForTextLinqMethod(Model2, BWorker);

            string[] LogText = null;

            if (File.Exists("TransferLog.log"))
                LogText = File.ReadAllLines("TransferLog.log");

            Assert.IsTrue(File.Exists(@"DestinationDirectoryTest\4.txt"));
            Assert.IsTrue(LogText.Contains(@"SourceDirectoryTest\4.txt                          --> contains text: TestStringToFindInFile"));
        }

        [TestCleanup()]
        public void Cleanup()
        {
            for (int i = 1; i <= 4; i++)
            {
                if (File.Exists($@"DestinationDirectoryTest\{i}.txt"))
                    File.Move($@"DestinationDirectoryTest\{i}.txt", $@"Test text files source\{i}.txt");
                
                if (File.Exists($@"SourceDirectoryTest\{i}.txt") && !File.Exists($@"Test text files source\{i}.txt"))
                    File.Copy($@"SourceDirectoryTest\{i}.txt", $@"Test text files source\{i}.txt");
            }

            if (File.Exists("TransferLog.log"))
                    File.Delete("TransferLog.log");
        }

        private void BWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e){}
        private System.ComponentModel.BackgroundWorker BWorker;
    }
}