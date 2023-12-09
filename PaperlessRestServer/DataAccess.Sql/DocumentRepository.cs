using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Sql
{
    public class DocumentSearchRepository : IDocumentSearchRepository
    {
        private readonly AppDbContext _context;
        public DocumentSearchRepository(AppDbContext context) 
        {
            _context = context;
            _context.Database.EnsureCreated();


        }



    }
}
