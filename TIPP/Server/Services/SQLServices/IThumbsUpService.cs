using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    public interface IThumbsUpService
    {
        object GetThumbsUps();
        bool CreateThumbsUp(ThumbsUp ThumbsUp);
        ThumbsUpDTO ReadThumbsUp(ThumbsUp ThumbsUp);
        List<ThumbsUp> GetThumbsUpsByProjectAndUserId(int projectid, int userid);
        bool UpdateThumbsUp(ThumbsUp ThumbsUp);
        bool DeleteThumbsUp(ThumbsUp ThumbsUp);

    }
}
