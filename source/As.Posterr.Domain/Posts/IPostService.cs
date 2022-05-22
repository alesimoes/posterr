using System;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Posts
{
    public interface IPostService
    {
        Task<bool> Post(string text, Guid? repostId);
    }
}