using As.Posterr.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace As.Posterr.Domain.ValueObjects
{
    public readonly struct TextPost
    {
        private readonly string _text;

        public TextPost(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new CannotBeEmptyException(Fields.TextPost);
            }
            if (text.Length > 777)
            {
                throw new MaximunCharactersException(777, Fields.TextPost);
            }

            this._text = text;
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
