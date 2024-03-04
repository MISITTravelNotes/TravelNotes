using Azure;
using Lab0225_InitProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace Lab0225_InitProject.Controllers
{
    public class AiRecommendController : Controller
    {
        private readonly TravelContext _context;

        public AiRecommendController(TravelContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            //問題: 一個index用了2個partivalView這兩個View各自用了不同的資料表 應該怎麼處裡?
            var tagLists = await _context.TagList.ToListAsync();
            var spots = await _context.Spots.ToListAsync();
            var cityList = await _context.UniqueCity.ToListAsync();

            ArrayList myAL = new ArrayList();
            myAL.Add(tagLists);
            myAL.Add(spots);
            myAL.Add(cityList);
            return View(myAL.ToArray());
        }

        [HttpPost]
        public List<Spots> Itinerary(string city)
        {
            var query = _context.Spots.Where(x => x.city == city);
            return query.ToList();
        }

        public string MlHandel(string Interests1, string Interests2, string Interests3,string weather, string country)
        {
            return $"OK-POST-V2-{1}-{Interests1}-{Interests2}-{Interests3}-{weather}-{country}";
        }


    }

    
}

