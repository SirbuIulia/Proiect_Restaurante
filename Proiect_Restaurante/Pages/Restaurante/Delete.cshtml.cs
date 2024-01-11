using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restaurante.Data;
using Proiect_Restaurante.Models;

namespace Proiect_Restaurante.Pages.Restaurante
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Restaurante.Data.Proiect_RestauranteContext _context;

        public DeleteModel(Proiect_Restaurante.Data.Proiect_RestauranteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Restaurant == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant
                .Include(r => r.Rezervari) // Include related reservations
                .FirstOrDefaultAsync(m => m.ID == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            // Check if there are related reservations
            if (restaurant.Rezervari != null && restaurant.Rezervari.Any())
            {
                // Handle related reservations (delete or update references)

                // Example: Deleting related reservations
                _context.Rezervare.RemoveRange(restaurant.Rezervari);
                await _context.SaveChangesAsync();
            }

            // Now you can safely delete the restaurant
            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
