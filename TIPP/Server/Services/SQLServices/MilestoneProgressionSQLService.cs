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


            List<MilestoneProgression> milestoneProgressions = new List<MilestoneProgression>();
            //List<MilestoneProgression> all = context.MilestoneProgressions.ToList();
            Console.WriteLine($"Getting progressions from {milestones.Count} milestones");
            foreach (Milestone milestone in milestones)
            {
                Console.WriteLine($"Milestone id: {milestone.Id}");
                List<MilestoneProgression> progressions = context.MilestoneProgressions.Where(x => x.MilestoneId.Equals(milestone.Id)).ToList();

                milestoneProgressions.AddRange(progressions);
            }



            return milestoneProgressions;
        }

        public List<ColleagueProgressionsDTO> GetColleagueProjectProgressionWithUserId(UserDTO dto)
        {
            //TODO OMZETTEN NAAR NIEUWE DTO (COLLEGAS OPHALEN UIT PROJECT, DOE ONDERSTAANDE VOOR ELKE COLLEAGUE, STEL DTO OP)

            //Retrieve all project users relative to the project and who are not the current user, in other words the colleagues
            List<ProjectUser> projectUsers = context.ProjectUsers.Where(x => x.Project.Equals(dto.ProjectID)&& !x.User.Equals(dto.Id)).ToList();
            List<Activity> activities = context.Activities.Where(x => x.ProjectId.Equals(dto.ProjectID)).ToList();
            List<ColleagueProgressionsDTO> colleagueProgressions = new List<ColleagueProgressionsDTO>();
            //For every colleague:
            // - create a milestone list
            // - retreive their time based milestones from the activities of the project
            // - Create a progressions list
            // - for every milestone retreive the progression
            // - create a colleaguemilestoneprogression and add it to the list
            // Return the list
            foreach (var projectuser in projectUsers)
            {
                User colleague = context.Users.Where(x => x.Id.Equals(projectuser.User)).FirstOrDefault();
                List<Milestone> milestones = new List<Milestone>();

                foreach (Activity activity in activities)
                {
                    List<Milestone> activityMilestones = context.Milestones.Where(x => x.ActivityId.Equals(activity.Id) && x.UserId.Equals(colleague.Id) && x.Type.Equals(MilestoneType.Time)).ToList();

                    milestones.AddRange(activityMilestones);
                }

                List<MilestoneProgression> milestoneProgressions = new List<MilestoneProgression>();
                //List<MilestoneProgression> all = context.MilestoneProgressions.ToList();
                Console.WriteLine($"Getting progressions from {milestones.Count} milestones");
                foreach (Milestone milestone in milestones)
                {
                    Console.WriteLine($"Milestone id: {milestone.Id}");
                    List<MilestoneProgression> progressions = context.MilestoneProgressions.Where(x => x.MilestoneId.Equals(milestone.Id)).ToList();

                    milestoneProgressions.AddRange(progressions);
                }
                ColleagueProgressionsDTO colleagueProgressionsDTO = new ColleagueProgressionsDTO(colleague, milestoneProgressions);
                colleagueProgressions.Add(colleagueProgressionsDTO);
            }

            return colleagueProgressions;
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
