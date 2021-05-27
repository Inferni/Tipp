﻿using TIPP.Server.Domain;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class MilestoneRepository : IMilestoneRepository
    {
        private IMileStoneService service;
        public MilestoneRepository(tipp_DBContext context)
        {
            service = new MilestoneSQLService(context);
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
