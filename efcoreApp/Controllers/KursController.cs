using efcoreApp.Data;
using efcoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class KursController: Controller
    {
        private readonly DataContext _context;
        public KursController(DataContext context)
        {
            _context=context;
        }

        public async Task<IActionResult>  CreateKurs()
        {   
            ViewBag.Ogretmenler=new SelectList(await _context.Ogretmenler.ToListAsync(),"OgretmenId","AdSoyad");
            return View("CreateKurs");
        }
        [HttpPost]
        public async Task<IActionResult> CreateKurs(KursViewModel model)
        {

            if(ModelState.IsValid){
            var maxId = await _context.Kurslar.MaxAsync(k => (int?)k.KursId) ?? 0;
            model.KursId = maxId + 1;
            _context.Kurslar.Add(new Kurs() {KursId = model.KursId,Baslik=model.Baslik,OgretmenId=model.OgretmenId });
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            }
            ViewBag.Ogretmenler=new SelectList(await _context.Ogretmenler.ToListAsync(),"OgretmenId","AdSoyad");
            return View(model);
        }
        public async Task<IActionResult> Index()
        {
            

            return View(await _context.Kurslar.Include(k=>k.Ogretmen).ToListAsync());
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

           // var ogr = await _context.Kurslar.FindAsync(id);  sadece id ye göre arama yapar 
           var ogr = await _context
           .Kurslar
           .Include(x=> x.KursKayitlari)
           .ThenInclude(k=>k.Ogrenci)
           .Select(k=> new KursViewModel
           {
            KursId =k.KursId,
            Baslik=k.Baslik,
            KursKayitlari=k.KursKayitlari
           })
           .FirstOrDefaultAsync(o => o.KursId==id);  // istediğimiz kritere göre arama yapabiliriz örn o => o.KursSoyad==id


            if (ogr==null){ return NotFound();}
            ViewBag.Ogretmenler=new SelectList(await _context.Ogretmenler.ToListAsync(),"OgretmenId","AdSoyad");
            return View(ogr);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,KursViewModel model)
    
        {
            if(id != model.KursId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Kurs() {KursId = model.KursId,Baslik=model.Baslik,OgretmenId=model.OgretmenId });
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateException)
                {
                    if(!_context.Kurslar.Any(o => o.KursId==model.KursId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // kaldığın yerden devam et
                    }
                }

                return RedirectToAction("Index");
            }
            ViewBag.Ogretmenler=new SelectList(await _context.Ogretmenler.ToListAsync(),"OgretmenId","AdSoyad");

            return View(model);

        }


                public async Task<IActionResult> Delete(int? id )
        {
            if( id == null)
            {
                return NotFound();
            }

            var Kurs = await _context.Kurslar.FindAsync(id);

            if (Kurs == null)
            {
                return NotFound();
            }
            return View(Kurs);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {



            var Kurs = await _context.Kurslar.FindAsync(id);
   

            if (Kurs == null)
            {
                return NotFound();
            }
            _context.Kurslar.Remove(Kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

            
        }

    }
}

