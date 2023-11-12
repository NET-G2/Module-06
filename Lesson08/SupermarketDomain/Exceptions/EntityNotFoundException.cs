using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDomain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) { }
        public EntityNotFoundException(string message, Exception innerException) { }
        public EntityNotFoundException(string message, string entityType) { }
    }
}
