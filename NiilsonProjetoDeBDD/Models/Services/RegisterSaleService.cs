using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NiilsonProjetoDeBDD.Models;
using NiilsonProjetoDeBDD.Models.ViewModels;

namespace NiilsonProjetoDeBDD.Models.Services
{
    public class RegisterSaleService
    {
        private readonly NiilsonProjetoDeBDDContext _context;

         public RegisterSaleService(NiilsonProjetoDeBDDContext context)
        {
            _context = context;
        }
        
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }



    }
}
