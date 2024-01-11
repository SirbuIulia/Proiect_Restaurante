using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Restaurante.Data;
using Proiect_Restaurante.Models;

namespace Proiect_Restaurante.Pages.Recenzii
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Restaurante.Data.Proiect_RestauranteContext _context;

        public CreateModel(Proiect_Restaurante.Data.Proiect_RestauranteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "Nume");
        ViewData["RestaurantID"] = new SelectList(_context.Set<Restaurant>(), "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Recenzie Recenzie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Recenzie == null || Recenzie == null)
            {
                return Page();
            }

            _context.Recenzie.Add(Recenzie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
