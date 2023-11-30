using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Sql
{
    public class CorrespondentRepository : ICorrespondentRepository
    {
        private readonly AppDbContext _context;

        public CorrespondentRepository(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public void AddCorrespondent(Correspondent correspondent)
        {
            _context.Correspondents.Add(correspondent);
            _context.SaveChanges();
        }

        public void DeleteCorrespondent(long id)
        {
            var correspondent = _context.Correspondents.Find(id);
            if (correspondent != null)
            {
                _context.Correspondents.Remove(correspondent);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Correspondent> GetAllCorrespondents()
        {
            return _context.Correspondents.ToList();
        }

        public Correspondent GetCorrespondent(long id)
        {
            return _context.Correspondents.Find(id);
        }

        public Correspondent UpdateCorrespondent(Correspondent correspondent)
        {
            var existingCorrespondent = _context.Correspondents.Find(correspondent.Id);
            if (existingCorrespondent != null)
            {
                _context.Entry(existingCorrespondent).CurrentValues.SetValues(correspondent);
                _context.SaveChanges();
                return existingCorrespondent;
            }

            throw new ArgumentException("Correspondent not found");
        }
    }
}
