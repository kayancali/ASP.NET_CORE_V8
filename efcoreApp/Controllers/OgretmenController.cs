using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class OgretmenController: Controller
    {
        private readonly DataContext _context;
        public OgretmenController(DataContext context)
        {
            _context=context;
        }

        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {
            var maxId = await _context.Ogretmenler.MaxAsync(k => (int?)k.OgretmenId) ?? 0;
            model.OgretmenId = maxId + 1;
            _context.Ogretmenler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Ogretmenler.ToListAsync());
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

           // var ogr = await _context.Ogretmenler.FindAsync(id);  sadece id ye göre arama yapar 
           var ogr = await _context
           .Ogretmenler
           .FirstOrDefaultAsync(o => o.OgretmenId==id);  // istediğimiz kritere göre arama yapabiliriz örn o => o.OgretmenSoyad==id


            if (ogr==null){ return NotFound();}

            return View(ogr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Ogretmen model)
    
        {
            if(id != model.OgretmenId)
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
                    if(!_context.Ogretmenler.Any(o => o.OgretmenId==model.OgretmenId))
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


                public async Task<IActionResult> Delete(int? id )
        {
            if( id == null)
            {
                return NotFound();
            }

            var Ogretmen = await _context.Ogretmenler.FindAsync(id);

            if (Ogretmen == null)
            {
                return NotFound();
            }
            return View(Ogretmen);
        }


        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {



            var Ogretmen = await _context.Ogretmenler.FindAsync(id);
   

            if (Ogretmen == null)
            {
                return NotFound();
            }
            _context.Ogretmenler.Remove(Ogretmen);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

            
        }

    }
}

