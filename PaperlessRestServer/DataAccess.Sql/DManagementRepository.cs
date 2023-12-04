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

        public void DeleteDocument(int id)
        {
            var Doc = _context.Documents.Find(id);
            if (Doc != null)
            {
                _context.Documents.Remove(Doc);
                _context.SaveChanges();
            }

        }

        public Document GetDocument(int id)
        {
            return _context.Documents.Find(id);
        }


        public Document UpdateDocument(Document doc)
        {
            var existingDocument = _context.Documents.Find(doc.Id);
            if (existingDocument != null)
            {
                _context.Entry(existingDocument).CurrentValues.SetValues(doc);
                _context.SaveChanges();
                return existingDocument;
            }

            throw new ArgumentException("Document not found");
        }

     
    
    }
}
