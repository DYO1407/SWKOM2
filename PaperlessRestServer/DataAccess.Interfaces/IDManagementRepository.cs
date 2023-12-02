using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public  interface IDManagementRepository
    {
       Document GetDocument(int id);
       void DeleteDocument(int id);

       Document UpdateDocument(Document doc);
    }
}
