using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectWeb.Data;
using ProiectWeb.Models;

namespace ProiectWeb.Pages.Proprietati
{
    public class EditModel : PageModel
    {
        private readonly ProiectWeb.Data.ProiectWebContext _context;

        public EditModel(ProiectWeb.Data.ProiectWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proprietate Proprietate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proprietate = await _context.Proprietate.FirstOrDefaultAsync(m => m.ID == id);

            if (Proprietate == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Proprietate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProprietateExists(Proprietate.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProprietateExists(int id)
        {
            return _context.Proprietate.Any(e => e.ID == id);
        }
    }
}
