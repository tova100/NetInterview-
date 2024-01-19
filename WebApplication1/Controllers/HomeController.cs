using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using System.Xml;
using WebApplication1.Dal;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDal _dal;

        public HomeController(IDal dal, IMemoryCache memoryCache)
        {
            _dal = dal;
        }
        public async Task<IActionResult> Index()
        {
            var newsModel = await _dal.GetNewsList();
            var titlesOnly = newsModel.list.Select(item => item.title).ToList();
            return View(titlesOnly);
        }
        [HttpGet]
        public NewsModel Details(string title)
        {
            NewsModel result = _dal.TryGetCachedNewsList(title);

            if (result != null)
            {

                return result;
                
                   
            }
            else
            {
                return null; 
            }
        }

    }

}
