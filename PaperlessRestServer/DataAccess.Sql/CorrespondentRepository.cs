using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DataAccess.Exceptions;

namespace DataAccess.Sql
{
    public class CorrespondentRepository : ICorrespondentRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CorrespondentRepository> _logger;

        public CorrespondentRepository(AppDbContext context, ILogger<CorrespondentRepository> logger)
        {
            _context = context;
            _context.Database.EnsureCreated();
            _logger = logger;
            _logger.LogInformation("CorrespondentRepository initialized");
        }

        public void AddCorrespondent(Correspondent correspondent)
        {
            try
            {
                _context.Correspondents.Add(correspondent);
                _context.SaveChanges();
                _logger.LogInformation($"Correspondent {JsonSerializer.Serialize(correspondent)} successfully added to database ");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Correspondent {JsonSerializer.Serialize(correspondent)} could not be added to database");
                throw new DatabaseException($"Could not add correspondent to Database", ex);
            } 
        }

        public void DeleteCorrespondent(long id)
        {
            var correspondent = _context.Correspondents.Find(id);
            if (correspondent != null)
            {
                try
                {
                    _context.Correspondents.Remove(correspondent);
                    _context.SaveChanges();

                }
                catch (Exception ex)
                {
                    _logger.LogError($"Correspondent with ID {id} could not be deleted");
                    throw new DatabaseException($"Correspondent with ID {id} could not be deleted", ex);
                }
                _logger.LogInformation($"Correspondent with ID {id} successfully deleted");
            }
            else
            {
                _logger.LogWarning($"No correspondent with ID {id} in database");
                throw new CorrespondentNotFoundException(id.ToString());
            }
        }

        public IEnumerable<Correspondent> GetAllCorrespondents()
        {
            List<Correspondent> correspondents = _context.Correspondents.ToList();
            if(correspondents.Count == 0)
            {
                _logger.LogError("No correspondents in database");
                throw new ArgumentException("No Correspondents in DB");
            }
            return correspondents;
        }

        public Correspondent GetCorrespondent(long id)
        {
            var Correspondent = _context.Correspondents.Find(id);
            if (Correspondent != null)
            {
                _logger.LogInformation($"Correspondent {JsonSerializer.Serialize(Correspondent)} found");
                return Correspondent;
            }
            else
            {
                _logger.LogWarning($"No Correspondent found with ID {id}");
                throw new CorrespondentNotFoundException(id.ToString());
            }
        }

        public Correspondent UpdateCorrespondent(Correspondent correspondent)
        {
            var existingCorrespondent = _context.Correspondents.Find(correspondent.Id);
            if (existingCorrespondent != null)
            {
                _context.Entry(existingCorrespondent).CurrentValues.SetValues(correspondent);
                _context.SaveChanges();
                _logger.LogInformation($"Correspondent {JsonSerializer.Serialize(correspondent)} successfully updated");
                return existingCorrespondent;
            }
            _logger.LogWarning($"No correspondent found to { JsonSerializer.Serialize(correspondent) } ");
            throw new Exception(correspondent.Id.ToString());
        }
    }
}
