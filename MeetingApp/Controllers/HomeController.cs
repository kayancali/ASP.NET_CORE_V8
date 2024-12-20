using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    
    public class HomeController: Controller{

        // localhosst/home
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            

 
            ViewBag.UserCount = Repository.Users.Where(i=> i.WillAttend == true).Count();

            ViewData["selamlama"]= saat > 12 ? " İyi Günler ": "Günaydın";
            ViewData["UserName"] = "Ali";
            ViewData["unvan"] = "Bey";

            var meetingInfo = new MeetingInfo(){
                Id =1,
                Location ="Sakarya , Serdivan",
                Date = new DateTime (2024,01,20,20,0,0),
                NumberOfPeople = 100

            };


            return View(meetingInfo);
        }
    }




}