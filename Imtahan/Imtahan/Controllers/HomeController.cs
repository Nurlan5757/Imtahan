
using Imtahan.DAL;
using Imtahan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Imtahan.Controllers
{
	public class HomeController : Controller
	{
        private readonly FreshContext _context;

        public HomeController(FreshContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
		{
            return View(await _context.chefs.Select(s => new GetVM
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Image = s.Image,
            }).ToListAsync());
        }

		
	}
}
