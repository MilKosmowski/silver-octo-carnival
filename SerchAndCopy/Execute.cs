using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

using CustomExtensions;

using SearchWindow;

namespace SearchAndCopy
{
    internal static class Execute
    {
        public static void Run(SearchWindowModel Execution, BackgroundWorker backgroundWorkerSearchForFile)
        {
            string[] searchResult;

            if (Execution.lineToCheck != 0)
            {
                SearchForText SearchInst = new SearchForSpecificLine(Execution, backgroundWorkerSearchForFile);
                searchResult = SearchInst.ResultArray;
            }
            else
            {
                SearchForText SearchInst = new SearchLinqMethod(Execution, backgroundWorkerSearchForFile);
                searchResult = SearchInst.ResultArray;
            }

            if (MyExtensions.IsNullOrEmpty(searchResult))
            {
                MessageBox.Show("Nie znaleziono żadnych wyników wyszukiwania");
            }
            else
            {
                var result = MessageBox.Show($"Znaleziono wyniki wyszukiwania, kopie plików zapisano do folderu: \n {Execution.destinationLocation} \n\n Czy otworzyć raport wyszukiwania i folder z wynikami?", "Sukces", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Process.Start("notepad.exe", "TransferLog.log");
                    Process.Start("explorer.exe", $@"{Environment.CurrentDirectory}\DefaultFolder");




                Application.Restart();
            }
        }
    }
}
//C:\Rozwiązania c#\Central Packaging Main Program\Serch And Copy\bin\Debug\DefaultFolder