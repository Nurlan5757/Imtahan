using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Imtahan.DAL;
using Imtahan.Models;
using Imtahan.ViewModels;

namespace Imtahan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChefsController : Controller
    {
        private readonly FreshContext _context;

        public ChefsController(FreshContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index( )
        {
            return View(await _context.chefs.Select(s => new GetAdminVM 
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Image = s.Image,
            }).ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Create(CreateVM vm)
        {
            await _context.chefs.AddAsync(new Chefs
            {
                
                Name = vm.Name,
                Description = vm.Description,
                Image = vm.Image,
            });
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefs = await _context.chefs.FindAsync(id);
            if (chefs == null)
            {
                return NotFound();
            }
            return View(chefs);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id, UpdateVM vm)
        {
           if(id==null && id < 1)
            {
                return NotFound();
            }
           var exsited = await _context.chefs.FirstOrDefaultAsync(x => x.Id == id);
            if (exsited == null)
            {
                return NotFound();
            }
            exsited.Name=vm.Name;
            exsited.Description=vm.Description;
            exsited.Image=vm.Image;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delete = await _context.chefs.FirstOrDefaultAsync(m => m.Id == id);
            if (delete == null)
            {
                return NotFound();
            }
            _context.Remove(delete);
            await _context.SaveChangesAsync();   
            return RedirectToAction(nameof(Index));

        }


    }
}
