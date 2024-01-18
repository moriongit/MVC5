using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC5.Context;
using MVC5.Models;
using MVC5.ViewModels.HomeVM;
using MVC5.ViewModels.TeamVM;

namespace MVC5.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        MvcDbContext _mvcDbContext;

        public TeamController(MvcDbContext dbContext)
        {
            _mvcDbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {

            var items = await _mvcDbContext.Teams.Select(x => new TeamListItemVM
            {
                Id = x.Id,
                Name = x.Name,
                ImgUrl = x.ImgUrl,
                Description = x.Description,
            }).ToListAsync();

            return View(items);
        }
        public async Task<IActionResult> Create()
        {
            return View();

        }
      [HttpPost]

         public async Task<IActionResult> Create(TeamCreateVM vm)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest();
             }

            Team team = new Team
            {
                Description = vm.Description,
                Name = vm.Name,
                ImgUrl = vm.ImgUrl,
            };
            await _mvcDbContext.Teams.AddAsync(team);
            await _mvcDbContext.SaveChangesAsync();
            return View(vm);

            
         }

    } 
}
