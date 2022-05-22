using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Exceptions
{
    public class AlphanumericCharactersException : DomainException
    {
        public AlphanumericCharactersException(string field) : base(string.Format(Messages.OnlyAphanumericCharactesIsAllowedForX, field.ToLower()))
        {
        }
    }
}
