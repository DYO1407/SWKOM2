﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.Extensions.Logging;


namespace DataAccess.Sql
{
    public class DManagementRepository : IDManagementRepository
    {

        private readonly AppDbContext _context;
        private readonly ILogger<DManagementRepository> _logger;
        public DManagementRepository(AppDbContext context, ILogger<DManagementRepository> logger)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _logger = logger;
        }

        public void DeleteDocument(int id)
        {
            var Doc = _context.Documents.Find(id);
            if (Doc != null)
            {
                _context.Documents.Remove(Doc);
                _context.SaveChanges();
                _logger.LogInformation($"Document with ID {id} successfully deleted");
            }
            else
            {
                _logger.LogWarning($"Document with ID {id} not found");
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
                _logger.LogInformation($"Document with  {JsonSerializer.Serialize(doc)} successfully updated.");
                return existingDocument;// das gibt doch das allte document zurück?
            }
            _logger.LogWarning($"Document { JsonSerializer.Serialize(doc) } not found");
            throw new ArgumentException("Document not found");
        }

        public Document AddDocument(Document doc)
        {
            _context.Documents.Add(doc);
            _context.SaveChanges();
            _logger.LogInformation($"Document {JsonSerializer.Serialize(doc)} successfully added to database");
            return doc; 
        }
    }
}
