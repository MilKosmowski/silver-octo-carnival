using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

using CustomExtensions;

namespace SearchWindow
{
    internal interface ISearch
    {
        void LogProgress(string searchItem, string whereWasItFound);

        void ReportStatus(double currentItemIndex, double itemsLeft, string itemName, BackgroundWorker backgroundWorker);

        void CopyFile(string whatToLookFor, string destination, string file);
    }

    public class GenericSearch : ISearch
    {
        public void LogProgress(string whatToLookFor, string file)
        {
            using (StreamWriter sw = File.AppendText($"TransferLog.log"))
                sw.WriteLine($"{Path.GetFileName(file),-50} --> contains text: {whatToLookFor}");
        }

        public void ReportStatus(double currentItemIndex, double itemsLeft, string itemName, BackgroundWorker backgroundWorker)
        {
            int CompletionPercentage = Convert.ToInt32(Math.Round(currentItemIndex / itemsLeft, 2) * 100);
            Progress currentProgress = new Progress(CompletionPercentage, itemName);
            backgroundWorker.ReportProgress(currentProgress.PercentageProgress, currentProgress.TextProgress);
        }

        public void CopyFile(string whatToLookFor, string destination, string file)
        {
            if (!File.Exists($@"{destination}\{Path.GetFileName(file)}") && File.Exists(file))
                File.Copy(file, $@"{destination}\{Path.GetFileName(file)}");
            LogProgress(whatToLookFor, file);
        }
    }

    public abstract class SearchForText : GenericSearch
    {
        public SearchForText(SearchWindowModel execution, BackgroundWorker backgroundWorker)
        {
            this.Execution = execution;
            this.BWorker = backgroundWorker;

            this.ResultArray = SearchLineExecutionTemplate(MethodSearchExecution, execution, backgroundWorker);
        }

        protected bool SearchLineForText(SearchWindowModel Execution, BackgroundWorker BWorker, string file, string line)
        {
            int index = 0;
            foreach (string text in Execution.arrayOfWhatToLookFor)
            {
                if (text == "")
                {
                    index++;
                    continue;
                }
                if (line.Contains(text))
                {
                    if (!Execution.searchForMultipleOccurences) Execution.arrayOfWhatToLookFor[index] = "";
                    CopyFile(text, Execution.destinationLocation, file);
                    return true;
                }
                index++;
            }
            return false;
        }

        protected string[] SearchLineExecutionTemplate(Func<SearchWindowModel, BackgroundWorker, string, string[]> SearchMethod, SearchWindowModel execution, BackgroundWorker backgroundWorker)
        {
            List<string> _resultArray = new List<string>();

            if (File.Exists("TransferLog.log")) File.Delete("TransferLog.log");

            foreach (string file in Execution.fileList)
            {
                _resultArray.AddRange(SearchMethod(Execution, BWorker, file));

                if (Execution.fileList.IndexOf(file) % 10 == 0) ReportStatus(Execution.fileList.IndexOf(file), Execution.amountInFileList, file, BWorker);

                if (execution.searchForMultipleOccurences==false && MyExtensions.IsNullOrEmpty(Execution.arrayOfWhatToLookFor)) break;
            }

            return _resultArray.ToArray();
        }

        protected abstract string[] MethodSearchExecution(SearchWindowModel Execution, BackgroundWorker backgroundWorker, string file);

        protected SearchWindowModel Execution { get; }
        protected BackgroundWorker BWorker { get; }
        public string[] ResultArray;
    }

    public class SearchForSpecificLine : SearchForText
    {
        public SearchForSpecificLine(SearchWindowModel execution, BackgroundWorker backgroundWorker) : base(execution, backgroundWorker)
        {
        }

        protected override string[] MethodSearchExecution(SearchWindowModel Execution, BackgroundWorker backgroundWorker, string file)
        {
            return File.ReadLines(file)
                       .Skip(Execution.lineToCheck - 1)
                       .Where(lines => SearchLineForText(Execution, BWorker, file, lines))
                       .ToArray();
        }
    }

    public class SearchLinqMethod : SearchForText
    {
        public SearchLinqMethod(SearchWindowModel execution, BackgroundWorker backgroundWorker) : base(execution, backgroundWorker)
        {
        }

        protected override string[] MethodSearchExecution(SearchWindowModel Execution, BackgroundWorker backgroundWorker, string file)
        {
            return File.ReadLines(file)
                            .Where(line => SearchLineForText(Execution, BWorker, file, line))
                            .ToArray();
        }
    }

    public class SearchStreamReaderMethod : SearchForText
    {
        public SearchStreamReaderMethod(SearchWindowModel execution, BackgroundWorker backgroundWorker) : base(execution, backgroundWorker)
        {
        }

        private List<string> result = new List<string>();

        protected override string[] MethodSearchExecution(SearchWindowModel Execution, BackgroundWorker backgroundWorker, string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (SearchLineForText(Execution, BWorker, file, line))
                        result.Add(line);
                }
            }
            return result.ToArray();
        }
    }
}