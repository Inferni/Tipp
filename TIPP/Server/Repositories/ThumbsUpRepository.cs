using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class ThumbsUpRepository : IThumbsUpRepository
    {
        private readonly IThumbsUpService service;

        public ThumbsUpRepository(tipp_DBContext context)
        {
            service = new ThumbsUpSQLService(context);
        }

        public bool CreateThumbsUp(ThumbsUpDTO ThumbsUp)
        {
            try
            {
                service.CreateThumbsUp(new Shared.ThumbsUp(ThumbsUp));
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteThumbsUp(ThumbsUpDTO ThumbsUp)
        {
            throw new NotImplementedException();
        }

        public object GetThumbsUps()
        {
            throw new NotImplementedException();
        }

        public List<ThumbsUpDTO> GetThumbsUpsByProjectAndUserId(int projectid, int userid)
        {
            List<ThumbsUp> thumbsUps = service.GetThumbsUpsByProjectAndUserId(projectid, userid);
            List<ThumbsUpDTO> dtos = new List<ThumbsUpDTO>();
            foreach (var thumbsUp in thumbsUps)
            {
                ThumbsUpDTO dto = new ThumbsUpDTO(thumbsUp);
                dtos.Add(dto);
            }
            return dtos;
        }

        public ThumbsUpDTO ReadThumbsUp(ThumbsUpDTO ThumbsUp)
        {
            throw new NotImplementedException();
        }

        public bool UpdateThumbsUp(ThumbsUpDTO ThumbsUp)
        {
            return service.UpdateThumbsUp(new ThumbsUp(ThumbsUp));
        }
    }
}
