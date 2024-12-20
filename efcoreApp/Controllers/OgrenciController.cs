using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OgrenciController: Controller
    {
        private readonly DataContext _context;
        public OgrenciController(DataContext context)
        {
            _context=context;
        }

        public async Task<IActionResult> Index()
        {
            

            return View(await _context.Ogrenciler.ToListAsync());
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Create(Ogrenci model)
        {   
            var maxId = await _context.Ogrenciler.MaxAsync(k => (int?)k.OgrenciId) ?? 0;
            model.OgrenciId = maxId + 1;
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            
        }

       
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

           // var ogr = await _context.Ogrenciler.FindAsync(id);  sadece id ye göre arama yapar 
           var ogr = await _context
           .Ogrenciler
           .Include(o=> o.KursKayitlari)
           .ThenInclude(o=> o.Kurs)
           .FirstOrDefaultAsync(o => o.OgrenciId==id);  // isteediğimiz kritere göre arama yapabiliriz örn o => o.OgrenciSoyad==id


            if (ogr==null){ return NotFound();}

            return View(ogr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Ogrenci model)
    
        {
            if(id != model.OgrenciId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    if(!_context.Ogrenciler.Any(o => o.OgrenciId==model.OgrenciId))
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
            return View(model);

        }
    

        [HttpGet]

        public async Task<IActionResult> Delete(int? id )
        {
            if( id == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenciler.FindAsync(id);

            if (ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {



            var ogrenci = await _context.Ogrenciler.FindAsync(id);
   

            if (ogrenci == null)
            {
                return NotFound();
            }
            _context.Ogrenciler.Remove(ogrenci);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

            
        }




    }

}