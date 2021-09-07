using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public interface IThumbsUpRepository
    {
        object GetThumbsUps();
        bool CreateThumbsUp(ThumbsUpDTO ThumbsUp);
        ThumbsUpDTO ReadThumbsUp(ThumbsUpDTO ThumbsUp);
        List<ThumbsUpDTO> GetThumbsUpsByProjectAndUserId(int projectid, int userid);
        bool UpdateThumbsUp(ThumbsUpDTO ThumbsUp);
        bool DeleteThumbsUp(ThumbsUpDTO ThumbsUp);
    }
}
