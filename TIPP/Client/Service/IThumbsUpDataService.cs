using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    interface IThumbsUpDataService
    {
        Task<object> GetAllThumbsUps();
        Task<ThumbsUp> GetThumbsUp(ThumbsUpDTO dto);
        Task CreateThumbsUp(ThumbsUpDTO dto);
        Task UpdateThumbsUp(ThumbsUpDTO dto);
        Task DeleteThumbsUp(ThumbsUpDTO dto);
        Task<IList<ThumbsUp>> GetThumbsUpsByProjectAndUserId(int projectid, int userid);
    }
}
