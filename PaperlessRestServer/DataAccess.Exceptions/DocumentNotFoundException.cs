using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Exceptions
{
    public class DocumentNotFoundException : Exception
    {
        public DocumentNotFoundException() { }
        public DocumentNotFoundException(string message) : base(message) { }
        public DocumentNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
