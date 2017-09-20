using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CSTEntryForm.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string last_name, string first_name,
                                   string last_name_kana, string first_name_kana,
                                   string birthday_year, string birthday_month, string birthday_day,
                                   string mail_address,
                                   string tel_area, string tel_local, string tel_sub,
                                   string work, string train, string station, string transportation, string distance, 
                                   string interview1_month, string interview1_day, string ampm1, 
                                   string interview2_month, string interview2_day, string ampm2, 
                                   string interview3_month, string interview3_day, string ampm3, 
                                   string question
        
                                   )
        {
            ViewData["last_name"] = last_name;
            ViewData["first_name"] = first_name;

            ViewData["last_name_kana"] = last_name_kana;
            ViewData["first_name_kana"] = first_name_kana;

            ViewData["birthday_year"] = birthday_year;
            ViewData["birthday_month"] = birthday_month;
            ViewData["birthday_day"] = birthday_day;

            ViewData["mail_address"] = mail_address;

            ViewData["tel_area"] = tel_area;
            ViewData["tel_local"] = tel_local;
            ViewData["tel_sub"] = tel_sub;

            ViewData["work"] = work;

            ViewData["train"] = train + "線";
            ViewData["station"] = station + "駅";
            ViewData["transportation"] = transportation;
            ViewData["distance"] = distance + "分";

            ViewData["interview1_month"] = interview1_month;
            ViewData["interview1_day"] = interview1_day;
            ViewData["ampm1"] = ampm1;

            ViewData["interview2_month"] = interview2_month;
            ViewData["interview2_day"] = interview2_day;
            ViewData["ampm2"] = ampm2;

            ViewData["interview3_month"] = interview3_month;
            ViewData["interview3_day"] = interview3_day;
            ViewData["ampm3"] = ampm3;

            ViewData["question"] = question;






            CSTEntryFormModel model = new CSTEntryFormModel();

            model.Last_name = last_name;
            model.First_name = first_name;

            model.Last_name_kana = last_name_kana;
            model.First_name_kana = first_name_kana;

            model.Birthday_year = birthday_year;
            model.Birthday_month = birthday_month;
            model.Birthday_day = birthday_day;

            model.Mail_address = mail_address;

            model.Tel_area = tel_area;
            model.Tel_local = tel_local;
            model.Tel_sub = tel_sub;

            model.Work = work;

            model.Train = train;
            model.Station = station;
            model.Transportation = transportation;
            model.Distance = distance;

            model.Interview1_month = interview1_month;
            model.Interview1_day = interview1_day;
            model.Ampm1 = ampm1;

            model.Interview2_month = interview2_month;
            model.Interview2_day = interview2_day;
            model.Ampm2 = ampm2;

            model.Interview3_month = interview3_month;
            model.Interview3_day = interview3_day;
            model.Ampm3 = ampm3;

            model.Question = question;



            return View(model);
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Error()
        //{
        //    return View();
        //}
    }
}
