using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vize_projesi_dpList.Models;
namespace vize_projesi_dpList.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var personellerListesi = context.Personels.Include(x => x.Birim).ToList();
            return View(personellerListesi);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in context.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            var per = context.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = per;

            context.Personels.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}