using As.Posterr.Domain.Exceptions;
using As.Posterr.Domain.Profiles;
using As.Posterr.Domain.Users;
using As.Posterr.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Posts
{
    public class Post
    {
        public Guid Id { get; protected set; }
        public TextPost? Text { get; protected set; }
        public Guid ProfileId { get; protected set; }
        public Post Repost { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public List<string> Keywords { get; protected set; }
        public bool IsQuotePost { get; protected set; }

        internal Post(string text, Profile profile, Post repost)
        {
            this.Id = Guid.NewGuid();
            this.Text = string.IsNullOrEmpty(text) ? null : new TextPost(text);
            this.ProfileId = profile.Id;
            this.Repost = repost;
            this.IsQuotePost = this.Repost != null && !string.IsNullOrEmpty(text);
            this.CreatedDate = DateTime.UtcNow;
            this.Keywords = this.Text?.Keywords;
            this.Validate();
        }

        private void Validate()
        {
            if (!this.Text.HasValue && this.Repost == null)
            {
                throw new InvalidPostException();
            }
        }
    }
}
