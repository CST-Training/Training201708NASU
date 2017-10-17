using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSTEntryForm02a.Models;

using System.IO;




namespace CSTEntryForm02a.Controllers
{
     

    public class TEntryMeiboesController : Controller
    {

        int idnew;


        private readonly EntryMeiboContext _context;

        public TEntryMeiboesController(EntryMeiboContext context)
        {
            _context = context;
        }


       

        // GET: TEntryMeiboes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TEntryMeibo.ToListAsync());
        }




        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Id = id;

            if (id == null)
            {
                return NotFound();



            }

            var tEntryMeibo = new TEntryMeibo();

            if (id != -1 && id != -2)
            {
                tEntryMeibo = await _context.TEntryMeibo
                    .SingleOrDefaultAsync(m => m.Id == id);
                if (tEntryMeibo == null)
                {
                    return NotFound();
                }
            }
            else if (id == -1)
            {
                //var tEntryMeibo = new TEntryMeibo();

                var ejitakutoeki_koutsu = Request.Form["EJitakuToEki_Koutsu"];
                var ejitakutoeki_jikan = Request.Form["EJitakuToEki_Jikan"];

                var emendan1tsuki = Request.Form["EMendan1Tsuki"];
                var emendan1hi = Request.Form["EMendan1Hi"];
                var emendan1youbi = Request.Form["EMendan1Youbi"];
                var emendan2tsuki = Request.Form["EMendan2Tsuki"];
                var emendan2hi = Request.Form["EMendan2Hi"];
                var emendan2youbi = Request.Form["EMendan2Youbi"];
                var emendan3tsuki = Request.Form["EMendan3Tsuki"];
                var emendan3hi = Request.Form["EMendan3Hi"];
                var emendan3youbi = Request.Form["EMendan3Youbi"];

                var kibou = Request.Form["EKibou_textarea"];
                var question = Request.Form["EQ_textarea"];

                var localdate = DateTime.Now;

                string emendan1date = "";
                string emendan2date = "";
                string emendan3date = "";

                string ejitakutoeki = "";

                emendan1date = emendan1tsuki;
                emendan1date += emendan1hi;
                emendan1date += emendan1youbi;
                emendan2date = emendan2tsuki;
                emendan2date += emendan2hi;
                emendan2date += emendan2youbi;
                emendan3date = emendan3tsuki;
                emendan3date += emendan3hi;
                emendan3date += emendan3youbi;

                ejitakutoeki = ejitakutoeki_koutsu;
                ejitakutoeki += ejitakutoeki_jikan;

                var formdata = Request.Form;

                tEntryMeibo.ENameSei = Request.Form["ENameSei"];
                tEntryMeibo.ENameNamae = Request.Form["ENameNamae"];
                tEntryMeibo.ENameSeiKana = Request.Form["ENameSeiKana"];
                tEntryMeibo.ENameNamaeKana = Request.Form["ENameNamaeKana"];
                tEntryMeibo.ENenrei = Request.Form["ENenrei"];
                tEntryMeibo.EJitakuRosen = Request.Form["EJitakuRosen"];
                tEntryMeibo.EJitakuMoyorieki = Request.Form["EJitakuMoyorieki"];
                tEntryMeibo.EJitakuToEki = ejitakutoeki;
                tEntryMeibo.EShigotoKibou = kibou;
                tEntryMeibo.EEmail = Request.Form["EEmail"];
                tEntryMeibo.EPhone = Request.Form["EPhone"];
                tEntryMeibo.EMendan1Date = emendan1date;
                tEntryMeibo.EMendan1Ampm = Request.Form["EMendan1Ampm"];
                tEntryMeibo.EMendan2Date = emendan2date;
                tEntryMeibo.EMendan2Ampm = Request.Form["EMendan2Ampm"];
                tEntryMeibo.EMendan3Date = emendan3date;
                tEntryMeibo.EMendan3Ampm = Request.Form["EMendan3Ampm"];
                tEntryMeibo.EQuestion = question;
                tEntryMeibo.ETimeStamp = localdate;

              
            }
            else if(id == -2)
                {

                var localdate = DateTime.Now;

                var formdata = Request.Form;

                tEntryMeibo.ENameSei = Request.Form["ENameSei"];
                tEntryMeibo.ENameNamae = Request.Form["ENameNamae"];
                tEntryMeibo.ENameSeiKana = Request.Form["ENameSeiKana"];
                tEntryMeibo.ENameNamaeKana = Request.Form["ENameNamaeKana"];
                tEntryMeibo.ENenrei = Request.Form["ENenrei"];
                tEntryMeibo.EJitakuRosen = Request.Form["EJitakuRosen"];
                tEntryMeibo.EJitakuMoyorieki = Request.Form["EJitakuMoyorieki"];
                tEntryMeibo.EJitakuToEki = Request.Form["EJitakuToEki"];
                tEntryMeibo.EShigotoKibou = Request.Form["EShigotoKibou"];
                tEntryMeibo.EEmail = Request.Form["EEmail"];
                tEntryMeibo.EPhone = Request.Form["EPhone"];
                tEntryMeibo.EMendan1Date = Request.Form["EMendan1Date"];
                tEntryMeibo.EMendan1Ampm = Request.Form["EMendan1Ampm"];
                tEntryMeibo.EMendan2Date = Request.Form["EMendan2Date"];
                tEntryMeibo.EMendan2Ampm = Request.Form["EMendan2Ampm"];
                tEntryMeibo.EMendan3Date = Request.Form["EMendan2Date"];
                tEntryMeibo.EMendan3Ampm = Request.Form["EMendan3Ampm"];
                tEntryMeibo.EQuestion = Request.Form["EQuestion"];
                tEntryMeibo.ETimeStamp = localdate;

                if (ModelState.IsValid)
                    {

                    ////CST228 または Azure　での「記録ファイル」へのパス
                    string path = @"/エントリー/エントリー.txt";


                    ////Local　の「記録ファイル」へのパス
                    //string path = @"c:\エントリー\エントリー.txt";
                    using (var s = new FileStream(path, FileMode.Append))
                        {



                            using (var sw = new StreamWriter(s))
                            {
                                sw.WriteLine(DateTime.Now + "\t" +
                                             tEntryMeibo.ENameSei + "\t" +
                                             tEntryMeibo.ENameNamae + "\t" +
                                             tEntryMeibo.ENameSeiKana + "\t" +
                                             tEntryMeibo.ENameNamaeKana + "\t" +
                                             tEntryMeibo.ENenrei + "\t" +
                                             tEntryMeibo.EJitakuRosen + "\t" +
                                             tEntryMeibo.EJitakuMoyorieki + "\t" +
                                             tEntryMeibo.EJitakuToEki + "\t" +
                                             tEntryMeibo.EShigotoKibou + "\t" +
                                             tEntryMeibo.EEmail + "\t" +
                                             tEntryMeibo.EPhone + "\t" +
                                             tEntryMeibo.EMendan1Date + "\t" +
                                             tEntryMeibo.EMendan1Ampm + "\t" +
                                             tEntryMeibo.EMendan2Date + "\t" +
                                             tEntryMeibo.EMendan2Ampm + "\t" +
                                             tEntryMeibo.EMendan3Date + "\t" +
                                             tEntryMeibo.EMendan3Ampm + "\t" +
                                             tEntryMeibo.EQuestion + "\t" +

                                             "END"
                                             );
                                sw.Dispose();
                            }
                        }

                        _context.Add(tEntryMeibo);
                        await _context.SaveChangesAsync();


                        ////return RedirectToAction("Index");
                        return RedirectToAction("Create");
                    }

               

            }
            return View(tEntryMeibo);
        }



        //// GET: TEntryDatas/ReviewAndEdit
        //public IActionResult Review(string ENameSei, string ENameNamae, string ENameSeiKana, string ENameNamaeKana, string ENenrei, string EJitakuRosen, string EJitakuMoyorieki, string EJitakuToEki, string EShigotoKibou, string EEmail, string EPhone, string EMendan1Date, string EMendan1Ampm, string EMendan2Date, string EMendan2Ampm, string EMendan3Date, string EMendan3Ampm, string EQuestion, string ETimeStamp)
        //{
        //    return RedirectToAction("Review");
        //}

        // GET: TEntryDatas/ReviewAndEdit


        //public IActionResult Review(int? id)
        //{
        //    //ViewBag.Id = id;
            

        //    return View();
        //}






        // GET: TEntryDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TEntryMeiboes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create( string EMendan1Am, string EMendan1Pm, string EMendan2Am, string EMendan2Pm, string EMendan3Am, string EMendan3Pm, [Bind("Id,ENameSei,ENameNamae,ENameSeiKana,ENameNamaeKana,ENenrei,EJitakuRosen,EJitakuMoyorieki,EJitakuToEki,EShigotoKibou,EEmail,EPhone,EMendan1Date,EMendan1Ampm,EMendan2Date,EMendan2Ampm,EMendan3Date,EMendan3Ampm,EQuestion,ETimeStamp")] TEntryMeibo tEntryMeibo)
        public async Task<IActionResult> Create([Bind("Id,ENameSei,ENameNamae,ENameSeiKana,ENameNamaeKana,ENenrei,EJitakuRosen,EJitakuMoyorieki,EJitakuToEki,EShigotoKibou,EEmail,EPhone,EMendan1Date,EMendan1Ampm,EMendan2Date,EMendan2Ampm,EMendan3Date,EMendan3Ampm,EQuestion,ETimeStamp")] TEntryMeibo tEntryMeibo)
        {

            var formdata = Request.Form;

            var enamesei = Request.Form["ENameSei"];
            var enamenamae = Request.Form["ENameNamae"];
            var enameseikana = Request.Form["ENameSeiKana"];
            var enamenamaekana = Request.Form["ENameNamaeKana"];
            var enenrei = Request.Form["ENenrei"];
            var ejitakurosen = Request.Form["EJitakuRosen"];
            var ejitakumoyorieki = Request.Form["EJitakuMoyorieki"];
            //var ejitakutoeki = Request.Form["EJitakuToEki"];
            var ejitakutoeki_koutsu = Request.Form["EJitakuToEki_Koutsu"];
            var ejitakutoeki_jikan = Request.Form["EJitakuToEki_Jikan"];
            var eemail = Request.Form["EEmail"];
            var ephone = Request.Form["EPhone"];

            var emendan1ampm = Request.Form["EMendan1Ampm"];
            var emendan2ampm = Request.Form["EMendan2Ampm"];
            var emendan3ampm = Request.Form["EMendan3Ampm"];

            var emendan1tsuki = Request.Form["EMendan1Tsuki"];
            var emendan1hi = Request.Form["EMendan1Hi"];
            var emendan1youbi = Request.Form["EMendan1Youbi"];
            var emendan2tsuki = Request.Form["EMendan2Tsuki"];
            var emendan2hi = Request.Form["EMendan2Hi"];
            var emendan2youbi = Request.Form["EMendan2Youbi"];
            var emendan3tsuki = Request.Form["EMendan3Tsuki"];
            var emendan3hi = Request.Form["EMendan3Hi"];
            var emendan3youbi = Request.Form["EMendan3Youbi"];

            string emendan1date = "";
            string emendan2date = "";
            string emendan3date = ""; 

            string ejitakutoeki = "";

            emendan1date = emendan1tsuki;
            emendan1date += emendan1hi;
            emendan1date += emendan1youbi;
            emendan2date = emendan2tsuki;
            emendan2date += emendan2hi;
            emendan2date += emendan2youbi;
            emendan3date = emendan3tsuki;
            emendan3date += emendan3hi;
            emendan3date += emendan3youbi;

            var kibou = Request.Form["EKibou_textarea"];
            var question = Request.Form["EQ_textarea"];

            var localdate = DateTime.Now;

            ejitakutoeki = ejitakutoeki_koutsu;
            ejitakutoeki += ejitakutoeki_jikan;

           
            tEntryMeibo.EJitakuToEki = ejitakutoeki;
            tEntryMeibo.EShigotoKibou = kibou;
            tEntryMeibo.EQuestion = question;
            tEntryMeibo.ETimeStamp = localdate;


            
            if (ModelState.IsValid)
            {

                //_context.Add(tEntryMeibo);
                //await _context.SaveChangesAsync();


                //if (soshin == "入力内容を確認")
                //{

                //    var id = tEntryMeibo.Id;
                //    idnew = id;

                //    List<string> inputs = new List<string>();
                //    inputs.Add(enamesei);
                //    inputs.Add(enamenamae);
                //    inputs.Add(enameseikana);
                //    inputs.Add(enamenamaekana);

                //    ViewData["Review"] = new SelectList(inputs);


                //    return RedirectToAction("Review");



                //}
                //else
                //{

                ////CST228 または Azure　での「記録ファイル」へのパス
                //string path = @"/エントリー/エントリー.txt";


                ////Local　の「記録ファイル」へのパス
                string path = @"c:\エントリー\エントリー.txt";
                using (var s = new FileStream(path, FileMode.Append))
                    {
                    using (var sw = new StreamWriter(s))
                    {
                        sw.WriteLine(DateTime.Now + "\t" +
                                     tEntryMeibo.ENameSei + "\t" +
                                     tEntryMeibo.ENameNamae + "\t" +
                                     tEntryMeibo.ENameSeiKana + "\t" +
                                     tEntryMeibo.ENameNamaeKana + "\t" +
                                     tEntryMeibo.ENenrei + "\t" +
                                     tEntryMeibo.EJitakuRosen + "\t" +
                                     tEntryMeibo.EJitakuMoyorieki + "\t" +
                                     tEntryMeibo.EJitakuToEki + "\t" +
                                     tEntryMeibo.EShigotoKibou + "\t" +
                                     tEntryMeibo.EEmail + "\t" +
                                     tEntryMeibo.EPhone + "\t" +
                                     tEntryMeibo.EMendan1Date + "\t" +
                                     tEntryMeibo.EMendan1Ampm + "\t" +
                                     tEntryMeibo.EMendan2Date + "\t" +
                                     tEntryMeibo.EMendan2Ampm + "\t" +
                                     tEntryMeibo.EMendan3Date + "\t" +
                                     tEntryMeibo.EMendan3Ampm + "\t" +
                                     tEntryMeibo.EQuestion + "\t" +

                                     "END"
                                     );
                        sw.Dispose();
                    }


                    //using (var sw = new StreamWriter(s))
                    //{
                    //    sw.WriteLine(DateTime.Now + "\t" +
                    //                 enamesei + "\t" +
                    //                 enamenamae + "\t" +
                    //                 enameseikana + "\t" +
                    //                 enamenamaekana + "\t" +
                    //                 enenrei + "\t" +
                    //                 ejitakurosen + "\t" +
                    //                 ejitakumoyorieki + "\t" +
                    //                 ejitakutoeki + "\t" +
                    //                 kibou + "\t" +
                    //                 eemail + "\t" +
                    //                 ephone + "\t" +
                    //                 emendan1date + "\t" +
                    //                 emendan1ampm + "\t" +
                    //                 emendan2date + "\t" +
                    //                 emendan2ampm + "\t" +
                    //                 emendan3date + "\t" +
                    //                 emendan3ampm + "\t" +
                    //                 question + "\t" +

                    //                 "END"
                    //                 );
                    //    sw.Dispose();
                    //}
                }

                _context.Add(tEntryMeibo);
                await _context.SaveChangesAsync();


                ////return RedirectToAction("Index");
                return RedirectToAction("Create");
                }

                
            //}
            return View(tEntryMeibo);

        }


        // GET: TEntryMeiboes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tEntryMeibo = await _context.TEntryMeibo.SingleOrDefaultAsync(m => m.Id == id);
            if (tEntryMeibo == null)
            {
                return NotFound();
            }
            return View(tEntryMeibo);
        }

        // POST: TEntryMeiboes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id,ENameSei,ENameNamae,ENameSeiKana,ENameNamaeKana,ENenrei,EJitakuRosen,EJitakuMoyorieki,EJitakuToEki,EShigotoKibou,EEmail,EPhone,EMendan1Date,EMendan1Ampm,EMendan2Date,EMendan2Ampm,EMendan3Date,EMendan3Ampm,EQuestion,ETimeStamp")] TEntryMeibo tEntryMeibo)
        {
            if (id != tEntryMeibo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tEntryMeibo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TEntryMeiboExists(tEntryMeibo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(tEntryMeibo);
        }

        // GET: TEntryMeiboes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tEntryMeibo = await _context.TEntryMeibo
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tEntryMeibo == null)
            {
                return NotFound();
            }

            return View(tEntryMeibo);
        }

        // POST: TEntryMeiboes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tEntryMeibo = await _context.TEntryMeibo.SingleOrDefaultAsync(m => m.Id == id);
            _context.TEntryMeibo.Remove(tEntryMeibo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TEntryMeiboExists(int id)
        {
            return _context.TEntryMeibo.Any(e => e.Id == id);
        }
    }
}
