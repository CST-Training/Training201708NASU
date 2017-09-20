using System;
using System.Collections.Generic;

namespace CSTEntryForm.Models
{
    public partial class TKojin
    {
        public int Id { get; set; }
        public string ENamae { get; set; }
        public string ENamaeNamae { get; set; }
        public string ENamaeSeiKana { get; set; }
        public string ENamaeNamaeKana { get; set; }
        public short? ENenrei { get; set; }
        public int? ESeibetsu { get; set; }
        public string EEmail { get; set; }
        public short? EDenwaArea { get; set; }
        public short? EDenwaLocal { get; set; }
        public short? EDenwa4num { get; set; }
        public string EShigotoKibou { get; set; }
        public short? EMendan1Month { get; set; }
        public short? EMendan1Day { get; set; }
        public string EMendan1Ampm { get; set; }
        public short? EMendan2Month { get; set; }
        public short? EMendan2Day { get; set; }
        public string EMendan2Ampm { get; set; }
        public short? EMendan3Month { get; set; }
        public short? EMendan3Day { get; set; }
        public string EMendan3Ampm { get; set; }
        public string EQuestion { get; set; }

        public virtual TSeibetsu ESeibetsuNavigation { get; set; }
    }
}
