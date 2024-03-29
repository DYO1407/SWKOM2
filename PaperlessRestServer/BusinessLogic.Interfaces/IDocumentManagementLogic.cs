﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;
using Document = BusinessLogic.Entities.Document;

namespace BusinessLogic.Interfaces
{
    public interface IDocumentManagementLogic
    {
        Document GetDocument(int id);
        bool DeleteDocument(int id);

        Document UpdateDocument(Document doc); // could be bool
    }
}
