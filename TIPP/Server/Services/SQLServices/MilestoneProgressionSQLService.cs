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
            try
            {
                context.MilestoneProgressions.Add(milestone);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            return true; 
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
            MilestoneProgression milestoneToUpdate;
            try
            {
                milestoneToUpdate = context.MilestoneProgressions.Where(x => x.MilestoneId.Equals(milestone.MilestoneId) && x.Week.Equals(milestone.Week)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                throw;
            }

            Console.WriteLine(milestoneToUpdate.Value);
            if(milestoneToUpdate != null)
            {
                try
                {
                    milestoneToUpdate.MilestoneId = milestone.MilestoneId;
                    milestoneToUpdate.Value += milestone.Value;
                    milestoneToUpdate.Week = milestone.Week;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Creating milestones");
                CreateMilestone(milestone);
            }
           

            return true;
        }

        public List<MilestoneProgression> GetProjectProgressionWithUserId(UserDTO dto)
        {
            List<Activity> activities = context.Activities.Where(x => x.ProjectId.Equals(dto.ProjectID)).ToList();
            List<Milestone> milestones = new List<Milestone>();
            
            foreach (Activity activity in activities)
            {
                List<Milestone> activityMilestones = context.Milestones.Where(x => x.ActivityId.Equals(activity.Id)&&x.UserId.Equals(dto.Id)&&x.Type.Equals(MilestoneType.Time)).ToList();

                milestones.AddRange(activityMilestones);
            }
            foreach (var milestone in milestones)
            {
                Console.WriteLine($"{milestone.Id} {milestone.Name}");
            }

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

        public List<MilestoneProgression> GetProgressionWithMilestoneId(MilestoneProgressionDTO dto)
        {
            Milestone milestone = context.Milestones.Where(x => x.Id.Equals(dto.MilestoneId)).FirstOrDefault();
            if(milestone.Completed == false)
            {
                List<MilestoneProgression> progressions = context.MilestoneProgressions.Where(x => x.MilestoneId.Equals(milestone.Id)).ToList();
                return progressions;
            }
            else
            {
                return null;
            }


        }
    }
}
