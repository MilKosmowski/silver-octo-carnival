namespace SearchWindow
{
    partial class SearchWindowViewModel
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartSearch = new System.Windows.Forms.Button();
            this.textBoxSourceLocation = new System.Windows.Forms.TextBox();
            this.textBoxDestinationLocation = new System.Windows.Forms.TextBox();
            this.textBoxWhatToLookFor = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDestination = new System.Windows.Forms.Label();
            this.labelTextToLookFor = new System.Windows.Forms.Label();
            this.textBoxSearchProgress = new System.Windows.Forms.TextBox();
            this.labelSearchProgress = new System.Windows.Forms.Label();
            this.labelLineNumberToCheck = new System.Windows.Forms.Label();
            this.textBoxLineNumberToCheck = new System.Windows.Forms.TextBox();
            this.backgroundWorkerSearchForFile = new System.ComponentModel.BackgroundWorker();
            this.progressBarSearchProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // buttonStartSearch
            // 
            this.buttonStartSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonStartSearch.Location = new System.Drawing.Point(95, 432);
            this.buttonStartSearch.Name = "buttonStartSearch";
            this.buttonStartSearch.Size = new System.Drawing.Size(122, 35);
            this.buttonStartSearch.TabIndex = 0;
            this.buttonStartSearch.Text = "Search";
            this.buttonStartSearch.UseVisualStyleBackColor = true;
            this.buttonStartSearch.Click += new System.EventHandler(this.ButtonStartSearch_Click);
            // 
            // textBoxSourceLocation
            // 
            this.textBoxSourceLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSourceLocation.Location = new System.Drawing.Point(95, 66);
            this.textBoxSourceLocation.Name = "textBoxSourceLocation";
            this.textBoxSourceLocation.Size = new System.Drawing.Size(866, 26);
            this.textBoxSourceLocation.TabIndex = 1;
            // 
            // textBoxDestinationLocation
            // 
            this.textBoxDestinationLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxDestinationLocation.Location = new System.Drawing.Point(95, 148);
            this.textBoxDestinationLocation.Name = "textBoxDestinationLocation";
            this.textBoxDestinationLocation.Size = new System.Drawing.Size(866, 26);
            this.textBoxDestinationLocation.TabIndex = 2;
            this.textBoxDestinationLocation.Text = "DefaultFolder";
            // 
            // textBoxWhatToLookFor
            // 
            this.textBoxWhatToLookFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxWhatToLookFor.Location = new System.Drawing.Point(95, 230);
            this.textBoxWhatToLookFor.Multiline = true;
            this.textBoxWhatToLookFor.Name = "textBoxWhatToLookFor";
            this.textBoxWhatToLookFor.Size = new System.Drawing.Size(866, 79);
            this.textBoxWhatToLookFor.TabIndex = 3;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelSource.Location = new System.Drawing.Point(89, 32);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(618, 31);
            this.labelSource.TabIndex = 4;
            this.labelSource.Text = "Source location. Files from all subfolders included:";
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelDestination.Location = new System.Drawing.Point(89, 114);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(864, 31);
            this.labelDestination.TabIndex = 5;
            this.labelDestination.Text = "Destination location. Files containing searched text will be copied here:";
            // 
            // labelTextToLookFor
            // 
            this.labelTextToLookFor.AutoSize = true;
            this.labelTextToLookFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelTextToLookFor.Location = new System.Drawing.Point(89, 196);
            this.labelTextToLookFor.Name = "labelTextToLookFor";
            this.labelTextToLookFor.Size = new System.Drawing.Size(427, 31);
            this.labelTextToLookFor.TabIndex = 6;
            this.labelTextToLookFor.Text = "Text to look for (space separated):";
            // 
            // textBoxSearchProgress
            // 
            this.textBoxSearchProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSearchProgress.Location = new System.Drawing.Point(95, 579);
            this.textBoxSearchProgress.Name = "textBoxSearchProgress";
            this.textBoxSearchProgress.Size = new System.Drawing.Size(866, 26);
            this.textBoxSearchProgress.TabIndex = 7;
            this.textBoxSearchProgress.Visible = false;
            this.textBoxSearchProgress.TextChanged += new System.EventHandler(this.textBoxSearchProgress_TextChanged);
            // 
            // labelSearchProgress
            // 
            this.labelSearchProgress.AutoSize = true;
            this.labelSearchProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelSearchProgress.Location = new System.Drawing.Point(89, 499);
            this.labelSearchProgress.Name = "labelSearchProgress";
            this.labelSearchProgress.Size = new System.Drawing.Size(131, 31);
            this.labelSearchProgress.TabIndex = 8;
            this.labelSearchProgress.Text = "Progress:";
            this.labelSearchProgress.Visible = false;
            // 
            // labelLineNumberToCheck
            // 
            this.labelLineNumberToCheck.AutoSize = true;
            this.labelLineNumberToCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.labelLineNumberToCheck.Location = new System.Drawing.Point(89, 333);
            this.labelLineNumberToCheck.Name = "labelLineNumberToCheck";
            this.labelLineNumberToCheck.Size = new System.Drawing.Size(747, 31);
            this.labelLineNumberToCheck.TabIndex = 9;
            this.labelLineNumberToCheck.Text = "Specific line to check (Input line number. 0 -> check all lines):";
            // 
            // textBoxLineNumberToCheck
            // 
            this.textBoxLineNumberToCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLineNumberToCheck.Location = new System.Drawing.Point(95, 367);
            this.textBoxLineNumberToCheck.Multiline = true;
            this.textBoxLineNumberToCheck.Name = "textBoxLineNumberToCheck";
            this.textBoxLineNumberToCheck.Size = new System.Drawing.Size(122, 31);
            this.textBoxLineNumberToCheck.TabIndex = 10;
            this.textBoxLineNumberToCheck.Text = "0";
            // 
            // backgroundWorkerSearchForFile
            // 
            this.backgroundWorkerSearchForFile.WorkerReportsProgress = true;
            this.backgroundWorkerSearchForFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerSearchForFile_DoWork);
            this.backgroundWorkerSearchForFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerSearchForFile_ProgressChanged);
            // 
            // progressBarSearchProgress
            // 
            this.progressBarSearchProgress.Location = new System.Drawing.Point(95, 550);
            this.progressBarSearchProgress.Name = "progressBarSearchProgress";
            this.progressBarSearchProgress.Size = new System.Drawing.Size(866, 23);
            this.progressBarSearchProgress.TabIndex = 11;
            this.progressBarSearchProgress.Visible = false;
            // 
            // SearchWindowViewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 629);
            this.Controls.Add(this.progressBarSearchProgress);
            this.Controls.Add(this.textBoxLineNumberToCheck);
            this.Controls.Add(this.labelLineNumberToCheck);
            this.Controls.Add(this.labelSearchProgress);
            this.Controls.Add(this.textBoxSearchProgress);
            this.Controls.Add(this.labelTextToLookFor);
            this.Controls.Add(this.labelDestination);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.textBoxWhatToLookFor);
            this.Controls.Add(this.textBoxDestinationLocation);
            this.Controls.Add(this.textBoxSourceLocation);
            this.Controls.Add(this.buttonStartSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SearchWindowViewModel";
            this.Text = "Search For Text In FIles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartSearch;
        private System.Windows.Forms.TextBox textBoxSourceLocation;
        private System.Windows.Forms.TextBox textBoxDestinationLocation;
        private System.Windows.Forms.TextBox textBoxWhatToLookFor;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.Label labelTextToLookFor;
        private System.Windows.Forms.TextBox textBoxSearchProgress;
        private System.Windows.Forms.Label labelSearchProgress;
        private System.Windows.Forms.Label labelLineNumberToCheck;
        private System.Windows.Forms.TextBox textBoxLineNumberToCheck;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSearchForFile;
        private System.Windows.Forms.ProgressBar progressBarSearchProgress;
    }
}

