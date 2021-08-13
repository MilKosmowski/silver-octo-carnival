using System;
using System.Collections.Generic;
using System.IO;
using CustomExtensions;
using System.Linq;
using System.Text.RegularExpressions;

namespace SearchWindow
{
    public class SearchWindowModel
    {
        public SearchWindowModel(string _whatToLookFor, string _sourceLocation, string _destinationLocation)
        {
            
            this.whatToLookFor = MyExtensions.IsNotEmptyExc(_whatToLookFor);
            this._sourceLocation = MyExtensions.IsLocationExc(_sourceLocation);
            this.destinationLocation = MyExtensions.IsLocationExc(_destinationLocation);
            this.fileList = Directory.GetFiles(_sourceLocation, "*", SearchOption.AllDirectories)
                                     .ToList();

            arrayOfWhatToLookFor = _whatToLookFor.Split(null);

            this.amountInFileList = fileList.Count;
        }

        public SearchWindowModel(string _whatToLookFor, string _sourceLocation, string _destinationLocation, int _lineToCheck) : this(_whatToLookFor, _sourceLocation, _destinationLocation)
        {
            this.lineToCheck = MyExtensions.IsGreaterOrEqualThanZeroExc(_lineToCheck);
        }

        private readonly string _sourceLocation;
        public readonly string whatToLookFor;
        public readonly string destinationLocation;
        public readonly string[] arrayOfWhatToLookFor;
        public readonly int lineToCheck;
        public readonly List<string> fileList;
        public readonly double amountInFileList;
    }
}

