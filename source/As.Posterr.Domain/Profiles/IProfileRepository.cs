using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.Domain.Profiles
{
    public interface IProfileRepository
    {
        Task<Profile> GetByUserId(Guid id);
        Task<Profile> Get(Guid id);
        Task Update(Profile profile);
        Task<List<Profile>> GetFollowing(Guid profileId, int pageIndex, int pageLength);
        Task<List<Profile>> GetFollowers(Guid profileId, int pageIndex, int pageLength);
        Task<Profile> GetFollowing(Guid followingProfileId, Guid followerProfileId);
    }
}
