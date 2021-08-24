using System;
using System.IO;
using System.Windows.Forms;

using CustomExtensions;

using SearchAndCopy;

namespace SearchWindow
{
    public partial class SearchWindowViewModel : Form
    {
        public SearchWindowViewModel()
        {
            InitializeComponent();
        }

        private void ButtonStartSearch_Click(object sender, EventArgs e)
        {
            labelSearchProgress.Visible = true;
            textBoxSearchProgress.Visible = true;
            progressBarSearchProgress.Visible = true;
            if (!backgroundWorkerSearchForFile.IsBusy)
                backgroundWorkerSearchForFile.RunWorkerAsync();
        }

        private void BackgroundWorkerSearchForFile_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SearchWindowModel Execution = new SearchWindowModel(_WhatToLookFor, _SourceLocation, _DestinationLocation, checkBoxsearchForMultipleOccurences.Checked, _LineNumberToCheck);
            Execute.Run(Execution, backgroundWorkerSearchForFile);
        }

        private void BackgroundWorkerSearchForFile_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            this.progressBarSearchProgress.Value = e.ProgressPercentage;
            this.textBoxSearchProgress.Text = Path.GetFileName(e.UserState.ToString());
        }

        private string _WhatToLookFor { get { return MyExtensions.IsNotEmptyExc(textBoxWhatToLookFor.Text); } }
        private string _SourceLocation { get { return MyExtensions.IsLocationExc(textBoxSourceLocation.Text); } }
        private string _DestinationLocation { get { if (textBoxDestinationLocation.Text == $@"{Environment.CurrentDirectory}\DefaultFolder") { MyExtensions.CreateFolderIfDoesntExist(textBoxDestinationLocation.Text); } return MyExtensions.IsLocationExc(textBoxDestinationLocation.Text); } }
        private int _LineNumberToCheck { get { return MyExtensions.IsNumberExc(textBoxLineNumberToCheck.Text); } }
        private string ProgressSneakPeek { set { textBoxSearchProgress.Text = value; } }
    }
}