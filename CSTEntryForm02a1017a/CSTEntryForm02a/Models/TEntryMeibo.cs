using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.IO;

namespace CSTEntryForm02a.Models
{


    public partial class TEntryMeibo
    {
        //Ampm ampm = new Ampm();

        //string emendan1ampm;


        [Display(Name = "エントリーID")]
        public int Id { get; set; }
        [Display(Name = "姓　")]
        public string ENameSei { get; set; }
        [Display(Name = "名　")]
        public string ENameNamae { get; set; }
        [Display(Name = "せい　")]
        public string ENameSeiKana { get; set; }
        [Display(Name = "めい　")]
        public string ENameNamaeKana { get; set; }
        [Display(Name = "年齢")]
        public string ENenrei { get; set; }
        [Display(Name = "路線")]
        public string EJitakuRosen { get; set; }
        [Display(Name = "駅")]
        public string EJitakuMoyorieki { get; set; }
        [Display(Name = "最寄り駅までの距離")]
        public string EJitakuToEki_Koutsu { get; set; }
        [Display(Name = "最寄り駅までの時間")]
        public string EJitakuToEki_Jikan { get; set; }
        [Display(Name = "希望する仕事")]
        public string EShigotoKibou { get; set; }
        [Display(Name = "email")]
        public string EEmail { get; set; }
        [Display(Name = "電話")]
        public string EPhone { get; set; }
        [Display(Name = "個人面談日 第一希望月")]
        public string EMendan1Tsuki { get; set; }
        [Display(Name = "個人面談日 第一希望日")]
        public string EMendan1Hi { get; set; }
        [Display(Name = "個人面談日 曜日")]
        public string EMendan1Youbi { get; set; }
        [Display(Name = "午前/午後")]
        public string EMendan1Ampm { get; set; }
       

        //[Display(Name = "AMPM")]
        //public string EMendan1Ampm
        //{ get { return emendan1ampm; }
        //  set { emendan1ampm = EMendan1Ampm; }
        //}

        [Display(Name = "個人面談日 第二希望")]
        public string EMendan2Tsuki { get; set; }
        [Display(Name = "個人面談日 第二希望日")]
        public string EMendan2Hi { get; set; }
        [Display(Name = "個人面談日 曜日")]
        public string EMendan2Youbi { get; set; }
        [Display(Name = "午前/午後")]
        public string EMendan2Ampm { get; set; }
        [Display(Name = "個人面談日 第三希望")]
        public string EMendan3Tsuki { get; set; }
        [Display(Name = "個人面談日 第三希望日")]
        public string EMendan3Hi { get; set; }
        [Display(Name = "個人面談日 曜日")]
        public string EMendan3Youbi { get; set; }
        [Display(Name = "午前/午後")]
        public string EMendan3Ampm { get; set; }
        [Display(Name = "質問・要望など")]
        public string EQuestion { get; set; }

        ////LocalDb用のCreate(TimeStamp無し)
        [Display(Name = "記入日")]
        public DateTime? ETimeStamp { get; set; }

    }



}
