using As.Posterr.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace As.Posterr.Domain.ValueObjects
{
    public readonly struct Username
    {
        private readonly string _username;

        public Username(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new CannotBeEmptyException(Fields.Username);
            }

            var regex = @"^[a-zA-Z-0-9]*$";
            var match = Regex.Match(username, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                throw new AlphanumericCharactersException(Fields.Username);
            }

            if (username.Length > 14)
            {
                throw new MaximunCharactersException(14, Fields.Username);
            }

            this._username = username;
        }

        public override string ToString()
        {
            return _username;
        }
    }
}
