using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    public class MilestoneProgressionSQLService : IMilestoneProgressionService
    {
        private readonly tipp_DBContext context;

        public MilestoneProgressionSQLService(tipp_DBContext context)
        {
            this.context = context;
        }

        public bool CreateMilestone(MilestoneProgression milestone)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMilestoneProgression(MilestoneProgression milestone)
        {
            throw new NotImplementedException();
        }

        public object GetMilestoneProgession()
        {
            throw new NotImplementedException();
        }

        public MilestoneProgressionDTO ReadMilestoneProgression(MilestoneProgression milestone)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMilestoneProgression(MilestoneProgression milestone)
        {
            throw new NotImplementedException();
        }


        // GET ACTIVITIES FROM PROJECT
        // GET MILESTONES FROM THAT ACTIVITY THAT ARE OF THE USER
        // GET MILESTONES WITH ONLY THE 'TIJD' TYPE
        // GET THE PROGRESSION FROM THOSE MILESTONES
        // SEND TO FRONTEND AND SORT IT THERE

        public List<MilestoneProgression> GetProjectProgressionWithUserId(UserDTO dto)
        {
            Console.WriteLine("Getting activities");
            List<Activity> activities = context.Activities.Where(x => x.ProjectId.Equals(dto.ProjectID)).ToList();
            List<Milestone> milestones = new List<Milestone>();

            Console.WriteLine("Getting milestones from activities");
            foreach (Activity activity in activities)
            {
                List<Milestone> activityMilestones = context.Milestones.Where(x => x.ActivityId.Equals(activity.Id)&&x.UserId.Equals(dto.Id)&&x.Type.Equals(MilestoneType.Tijd)).ToList();

                milestones.AddRange(activityMilestones);
            }
            foreach (var milestone in milestones)
            {
                Console.WriteLine($"{milestone.Id} {milestone.Name}");
            }

            Console.WriteLine("Getting progression from milestones");
            List<MilestoneProgression> milestoneProgressions = new List<MilestoneProgression>();
            List<MilestoneProgression> all = context.MilestoneProgressions.ToList();
            foreach(MilestoneProgression progression in all)
            {
                
                Console.WriteLine($"{progression.MilestoneId}");
            }
            foreach (Milestone milestone in milestones)
            {
                
                List<MilestoneProgression> progressions = context.MilestoneProgressions.Where(x => x.MilestoneId.Equals(milestone.Id)).ToList();

                milestoneProgressions.AddRange(progressions);
            }

            foreach(var milestoneprogression in milestoneProgressions)
            {
                Console.WriteLine($"{milestoneprogression.Id} {milestoneprogression.Id}");
            }

            return milestoneProgressions;
        }
    }
}
