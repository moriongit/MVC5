using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC5.Context;
using MVC5.Models;
using MVC5.ViewModels.HomeVM;
using MVC5.ViewModels.TeamVM;
using System.Diagnostics;

namespace MVC5.Controllers
{
    public class HomeController : Controller
    {
     
        public readonly MvcDbContext _mvcDbContext;

        public HomeController(MvcDbContext mvcDbContext)
        {
            _mvcDbContext = mvcDbContext;
        }
        

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM
            {
                Teams = await _mvcDbContext.Teams.Select(x => new TeamListItemVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImgUrl = x.ImgUrl,
                    Description = x.Description,
                }).ToListAsync()
            };
            return View(vm);
        }


    }
}
