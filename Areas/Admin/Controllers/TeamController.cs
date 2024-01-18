using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
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
            return RedirectToAction("Index");

            
         }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var data = await _mvcDbContext.Teams.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
             _mvcDbContext.Teams.Remove(data);
            await _mvcDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (id == null)
            {
                return BadRequest();
            }
            var data = await _mvcDbContext.Teams.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(new TeamUpdateVM
            {
                Name = data.Name,
                ImgUrl = data.ImgUrl,
                Description = data.Description,
            });

        }
        [HttpPost]

        public async Task<IActionResult> Update(TeamUpdateVM vm, int id)
        {
            var data = await _mvcDbContext.Teams.FindAsync(id);
            data.Name = vm.Name;
            data.ImgUrl = vm.ImgUrl;
            data.Description = vm.Description;

            await _mvcDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
            
    }
    
}
