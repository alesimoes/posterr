using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class MaximunCharactersException : DomainException
    {
        public MaximunCharactersException(int length, string field) : base(string.Format(Messages.MaximunCharactersXcharactesIsAllowdForY, length,  field.ToLower()))
        {
        }
    }
}
