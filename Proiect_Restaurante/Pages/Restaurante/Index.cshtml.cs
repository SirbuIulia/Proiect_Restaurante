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
using Proiect_Restaurante.Models.ViewModels;

namespace Proiect_Restaurante.Pages.Restaurante
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Restaurante.Data.Proiect_RestauranteContext _context;

        public IndexModel(Proiect_Restaurante.Data.Proiect_RestauranteContext context)
        {
            _context = context;
        }



        public IList<Restaurant> Restaurant { get; set; } = new List<Restaurant>();
        public RestaurantIndexData RestaurantData { get; set; }
        public int RestaurantID { get; set; }
        public int RecenzieID { get; set; }

        // public string NumeSort { get; set; }
        // public string AdresaSort { get; set; }
        public RestaurantData RestaurantD { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, string
searchString)
        {
            RestaurantData = new RestaurantIndexData();
            RestaurantData.Restaurante = await _context.Restaurant
            .Include(i => i.Recenzii)
            .OrderBy(i => i.RatingTotal)
            .ToListAsync();
            if (id != null)
            {
                RestaurantID = id.Value;
                Restaurant restaurant = RestaurantData.Restaurante
                .Where(i => i.ID == id.Value).Single();
                RestaurantData.Recenzii = restaurant.Recenzii;
            }

            CurrentFilter = searchString;
          

            if (!String.IsNullOrEmpty(searchString))
            {
  
                RestaurantData.Restaurante = RestaurantData.Restaurante
               .Where(s => s.Adresa.Contains(searchString) || s.Nume.Contains(searchString))
               .ToList();
            }


        }
    }
}
