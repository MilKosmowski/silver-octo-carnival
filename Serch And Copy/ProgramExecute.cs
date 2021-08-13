using CustomExtensions;
using SearchWindow;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace SearchAndCopy
{
    static class ProgramExecute
    {
        public static void Run(SearchWindowModel Execution, BackgroundWorker backgroundWorkerSearchForFile)
        {
            string[] searchResult;

            if (Execution.lineToCheck != 0)
            {
                SearchForTextInSpecificLine SearchInst = new SearchForTextInSpecificLine(Execution, backgroundWorkerSearchForFile);
                searchResult = SearchInst.ResultArray;
            }
            else
            {
                SearchForTextLinqMethod SearchInst = new SearchForTextLinqMethod(Execution, backgroundWorkerSearchForFile);
                searchResult = SearchInst.ResultArray;
            }

            if (MyExtensions.IsNullOrEmpty(searchResult))
            {
                MessageBox.Show("Nie znaleziono żadnych wyników wyszukiwania");
            }
            else
            {
                var result = MessageBox.Show($"Znaleziono wyniki wyszukiwania, kopie plików zapisano do folderu: \n {Execution.destinationLocation} \n\n Czy otworzyć raport wyszukiwania?", "Sukces", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    Process.Start("notepad.exe", "TransferLog.log");
                Application.Restart();
            }
        }
    }
}
