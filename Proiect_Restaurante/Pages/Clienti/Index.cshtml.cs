﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Restaurante.Data;
using Proiect_Restaurante.Models;

namespace Proiect_Restaurante.Pages.Clienti
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Restaurante.Data.Proiect_RestauranteContext _context;

        public IndexModel(Proiect_Restaurante.Data.Proiect_RestauranteContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Client != null)
            {
                Client = await _context.Client.ToListAsync();
            }
        }
    }
}
