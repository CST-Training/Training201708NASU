using System;
using System.Collections.Generic;

namespace CSTEntryForm02.Models
{
    public partial class TEntryData
    {
        public int Id { get; set; }
        public string ELastname { get; set; }
        public string EFirstname { get; set; }
        public string ELastnameKana { get; set; }
        public string EFirstnameKana { get; set; }
        public int? ENenrei { get; set; }
        public string EEmail { get; set; }
        public string EDenwa { get; set; }
        public string EMoyoriekiRosen { get; set; }
        public string EMoyoriekiEki { get; set; }
        public int? EMoyoriekiKyori { get; set; }
        public string EShigotoKibou { get; set; }
        public int? EMendan1Month { get; set; }
        public int? EMendan1Day { get; set; }
        public string EMendan1Ampm { get; set; }
        public int? EMendan2Month { get; set; }
        public int? EMendan2Day { get; set; }
        public string EMendan2Ampm { get; set; }
        public int? EMendan3Month { get; set; }
        public int? EMendan3Day { get; set; }
        public string EMendan3Ampm { get; set; }
        public string EQuestion { get; set; }
    }
}
