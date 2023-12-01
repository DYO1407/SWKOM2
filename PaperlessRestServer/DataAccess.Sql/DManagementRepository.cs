using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Sql
{
    public class DManagementRepository : IDManagementRepository
    {

        private readonly AppDbContext _context;
        public DManagementRepository(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

        }
    }
}
