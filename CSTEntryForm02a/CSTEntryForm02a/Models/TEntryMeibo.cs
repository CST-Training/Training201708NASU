using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace CSTEntryForm02a.Models
{
    public partial class TEntryMeibo
    {
        [Display(Name = "エントリーID")]
        public int Id { get; set; }
        [Display(Name = "氏名")]
        public string ENameSei { get; set; }
        [Display(Name = "（名）")]
        public string ENameNamae { get; set; }
        [Display(Name = "ふりがな")]
        public string ENameSeiKana { get; set; }
        [Display(Name = "(めい)")]
        public string ENameNamaeKana { get; set; }
        [Display(Name = "年齢")]
        public short? ENenrei { get; set; }
        [Display(Name = "自宅最寄り駅(路線-駅)")]
        public string EJitakuRosen { get; set; }
        [Display(Name = "駅")]
        public string EJitakuMoyorieki { get; set; }
        [Display(Name = "最寄り駅までの距離")]
        public short? EJitakuToEki { get; set; }
        [Display(Name = "希望する仕事")]
        public string EShigotoKibou { get; set; }
        [Display(Name = "email")]
        public string EEmail { get; set; }
        [Display(Name = "電話")]
        public string EPhone { get; set; }
        [Display(Name = "個人面談日 第一希望")]
        public DateTime? EMendan1Date { get; set; }
        [Display(Name = "AMPM")]
        public string EMendan1Ampm { get; set; }
        [Display(Name = "個人面談日 第二希望")]
        public DateTime? EMendan2Date { get; set; }
        [Display(Name = "AMPM")]
        public string EMendan2Ampm { get; set; }
        [Display(Name = "個人面談日 第三希望")]
        public DateTime? EMendan3Date { get; set; }
        [Display(Name = "AMPM")]
        public string EMendan3Ampm { get; set; }
        [Display(Name = "質問・要望など")]
        public string EQuestion { get; set; }
        [Display(Name = "記入日")]
        public byte[] ETimeStamp { get; set; }

    }
}
