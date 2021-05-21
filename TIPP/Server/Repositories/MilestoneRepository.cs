using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;
using TIPP.Server.Services.SQLServices;

namespace TIPP.Server.Repositories
{
    public class MilestoneRepository : IMilestoneRepository
    {
        private static MilestoneRepository self;
        private IMileStoneService service;
        private MilestoneRepository()
        {
            service = new MilestoneSQLService();
        }

        public static MilestoneRepository GetMilestoneRepository()
        {
            if(self !=null)
            {
                return self;
            }
            else
            {
                self = new MilestoneRepository();
                return self;
            }
        }

        public bool CreateMilestone(MilestoneDTO dto)
        {
            Milestone milestone = new Milestone(dto);
            return service.CreateMilestone(milestone);
        }

        public bool DeleteMilestone(MilestoneDTO dto)
        {
            Milestone milestone = new Milestone(dto);
            return service.DeleteMilestone(milestone);
        }

        public object GetMilestones()
        {
            return service.GetMilestones();
        }

        public MilestoneDTO ReadMilestone(MilestoneDTO dto)
        {
            Milestone milestone = new Milestone(dto);
            return service.ReadMilestone(milestone);
        }

        public bool UpdateMilestone(MilestoneDTO dto)
        {
            Milestone milestone = new Milestone(dto);
            return service.UpdateMilestone(milestone);
        }
    }
}
