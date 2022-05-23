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
        private readonly List<string> _keywords;
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

            var regex = new Regex(@"[A-z-0-9@#]+");
            var matches = regex.Matches(text);
            this._keywords = matches.Where(t => t.Length > 3).Select(k => k.Value.ToLower()).ToList();
            
            this._text = text;
        }

        public List<string> Keywords { get => _keywords; }
        public override string ToString()
        {
            return _text;
        }
    }
}
