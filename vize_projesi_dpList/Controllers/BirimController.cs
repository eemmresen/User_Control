using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vize_projesi_dpList.Models;

namespace vize_projesi_dpList.Controllers
{
    public class BirimController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var BirimListe = context.Birims.ToList();
            return View(BirimListe);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim gönderilenBirim)
        {
            context.Birims.Add(gönderilenBirim);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var dep = context.Birims.Find(id);
            context.Birims.Remove(dep);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {

            var depart = context.Birims.Find(id);

            return View(depart);

        }
        public IActionResult BirimGuncelle(Birim gönderilenBirim)
        {

            var dep = context.Birims.Find(gönderilenBirim.BirimID);
            dep.BirimAd = gönderilenBirim.BirimAd;

            context.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult BirimDetay(int id)
        {

            var degerler = context.Personels.Where(x => x.BirimID == id).ToList();


            return View(degerler);

        }


    }
}