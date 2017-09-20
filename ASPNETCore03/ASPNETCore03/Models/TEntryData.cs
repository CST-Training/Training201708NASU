using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCore03.Models
{
    public partial class TEntryData
    {
        public int Id { get; set; }
        [Display(Name = "お名前(姓)")]
        public string ELastname { get; set; }
        [Display(Name = "お名前(名)")]
        public string EFirstname { get; set; }
        [Display(Name = "ふりがな(せい)")]
        public string ELastnameKana { get; set; }
        [Display(Name = "ふりがな(めい)")]
        public string EFirstnameKana { get; set; }
        [Display(Name = "年齢")]
        public int? ENenrei { get; set; }
        [Display(Name = "email")]
        public string EEmail { get; set; }
        [Display(Name = "電話")]
        public string EDenwa { get; set; }
        [Display(Name = "最寄り駅 路線")]
        public string EMoyoriekiRosen { get; set; }
        [Display(Name = "駅")]
        public string EMoyoriekiEki { get; set; }
        [Display(Name = "駅までの徒歩")]
        public int? EMoyoriekiKyori { get; set; }
        [Display(Name = "希望する仕事")]
        public string EShigotoKibou { get; set; }
        [Display(Name = "個人面談 第一希望 月")]
        public int? EMendan1Month { get; set; }
        [Display(Name = "日")]
        public int? EMendan1Day { get; set; }
        [Display(Name = "AMPM")]
        public string EMendan1Ampm { get; set; }
        [Display(Name = "個人面談 第二希望 月")]
        public int? EMendan2Month { get; set; }
        [Display(Name = "日")]
        public int? EMendan2Day { get; set; }
        [Display(Name = "AMPM")]
        public string EMendan2Ampm { get; set; }
        [Display(Name = "個人面談 第三希望 月")]
        public int? EMendan3Month { get; set; }
        [Display(Name = "日")]
        public int? EMendan3Day { get; set; }
        [Display(Name = "AMPM")]
        public string EMendan3Ampm { get; set; }
        [Display(Name = "質問・要望など")]
        public string EQuestion { get; set; }

    }
}
