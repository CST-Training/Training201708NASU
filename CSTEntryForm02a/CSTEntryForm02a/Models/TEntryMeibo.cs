﻿using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace CSTEntryForm02a.Models
{
    public class AmpmGen
    {
        public string mendan1ampm = "";
       
        public AmpmGen()
        {
          
        }

        public bool EMendan1Am { get; set; }

        public bool EMendan1Pm { get; set; }

        public string Mendan1Ampm
        {
            get { return mendan1ampm; }

            set
            {
                if(EMendan1Am == true && EMendan1Pm == true)
                mendan1ampm = "AMPM";
                else if (EMendan1Am == true && EMendan1Pm == false)
                mendan1ampm = "AM";
                else if (EMendan1Am == false && EMendan1Pm == true)
                mendan1ampm = "PM";
                else
                mendan1ampm = "none";


            }
        }


    }

    public partial class TEntryMeibo
    {
        public string ampm1 = "";
        public string emendan1ampm = "";

        AmpmGen ampmgen = new AmpmGen();

        public TEntryMeibo()
        {
            EMendan1Ampm = ampmgen.Mendan1Ampm;
        }

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
        public string EMendan1Ampm
        {
            get { return emendan1ampm; }

            set
            {
                emendan1ampm = ampm1;
            }
        }

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
