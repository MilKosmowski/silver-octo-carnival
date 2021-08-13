namespace SearchWindow
{
    class Progress
    {
        public Progress(int _PercentageProgress, string _TextProgress)
        {
            this.TextProgress = _TextProgress;
            this.PercentageProgress = _PercentageProgress;
        }

        public string TextProgress { get; set; }
        public int PercentageProgress { get; set; }

    }
}