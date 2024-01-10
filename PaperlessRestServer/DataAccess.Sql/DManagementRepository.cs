using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using DataAccess.Exceptions;

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
                try
                {
                    _context.Documents.Remove(Doc);
                    _context.SaveChanges();
                    _logger.LogInformation($"Document with ID {id} successfully deleted");
                }
                catch(Exception ex)
                {
                    _logger.LogWarning($"Document with ID {id} could not be deleted");
                    throw new DatabaseException("Document could not be deleted", ex);
                }
                
            }
            else
            {
                _logger.LogWarning($"Document with ID {id} not found");
                throw new DocumentNotFoundException();
            }
        }

        public Document GetDocument(int id)
        {
            Document document = new Document();
            try
            {
                document = _context.Documents.Find(id);
            }
            catch(Exception ex)
            {
                throw new DatabaseException("Document may exist but could not be accessed",ex);
            }

            if (document != null)
            {
                return document;
            }
            else
            {
                throw new DocumentNotFoundException();
            }
        }


        public Document UpdateDocument(Document doc)
        {
            var existingDocument = _context.Documents.Find(doc.Id);
            if (existingDocument != null)
            {
                try
                {
                    _context.Entry(existingDocument).CurrentValues.SetValues(doc);
                    _context.SaveChanges();
                    _logger.LogInformation($"Document with  {JsonSerializer.Serialize(doc)} successfully updated");
                    return existingDocument;// das gibt doch das allte document zurück?
                }
                catch(Exception ex)
                {
                    throw new DatabaseException("Document could not be updated", ex);
                }
            }
            _logger.LogWarning($"Document { JsonSerializer.Serialize(doc) } not found");
            throw new DocumentNotFoundException();
        }

        public Document AddDocument(Document doc)
        {
            try
            {
                _context.Documents.Add(doc);
                _context.SaveChanges();
                _logger.LogInformation($"Document {JsonSerializer.Serialize(doc)} successfully added to database");
                return doc;
            }
            catch(Exception ex)
            {
                throw new DatabaseException($"Document {JsonSerializer.Serialize(doc)} could not be added");
            }
            
        }
    }
}
