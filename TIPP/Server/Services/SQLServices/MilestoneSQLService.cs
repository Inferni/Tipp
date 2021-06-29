using System;
using System.Collections.Generic;
using System.Linq;
using TIPP.Server.Domain;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{

    public class MilestoneSQLService : IMileStoneService
    {
        private readonly tipp_DBContext context;

        public MilestoneSQLService(tipp_DBContext context)
        {
            this.context = context;
        }

        public Milestone CreateMilestone(Milestone milestone)
        {
            try
            {
                Milestone milestoneadded = context.Milestones.Add(milestone).Entity;
                context.SaveChanges();

                return milestoneadded;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        public bool DeleteMilestone(Milestone milestone)
        {
            Milestone milestoneToDelete;
            try
            {
                milestoneToDelete = context.Milestones.Where(x => x.Id.Equals(milestone.Id)).FirstOrDefault();
                context.Remove(milestoneToDelete);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public List<ColleagueMilestoneDTO> GetColleagueMilestonesByProjectID(int UserId, ProjectDTO dto)
        {
            List<Activity> activities = context.Activities.Where(x => x.ProjectId.Equals(dto.Id)).ToList();
            List < Milestone >  milestones= new List<Milestone>();
            List<Milestone> milestonesInActivity;
            foreach (var activity in activities)
            {
                //Find all milestones for every activity that does not match the userid (in other words all the others) and if the milestone has been completed
                milestonesInActivity = context.Milestones.Where(x => x.ActivityId.Equals(activity.Id) && !x.UserId.Equals(UserId) && x.Completed == true).ToList();
                milestones.AddRange(milestonesInActivity);
            }

            List<ColleagueMilestoneDTO> dtos = new List<ColleagueMilestoneDTO>();
            //For every milestone find the username that accompanies it, create DTOs from the informati
            foreach(var milestone in milestones)
            {
                string username = context.Users.Where(x => x.Id.Equals(milestone.UserId)).FirstOrDefault().Username;
                ColleagueMilestoneDTO colleagueMilestone = new ColleagueMilestoneDTO(milestone.Id, milestone.Name, username);
                dtos.Add(colleagueMilestone);
            }
            return dtos;
        }

        public Milestone GetMilestoneById(MilestoneDTO dto)
        {
            return context.Milestones.Where(x => x.Id.Equals(dto.Id)).FirstOrDefault();
        }

        public object GetMilestones()
        {
            return new { Items = context.Milestones };
        }

        public List<Milestone> GetMilestonesByActivityID(MilestoneDTO dto)
        {
            List<Milestone> milestones;
            try
            {
                milestones = context.Milestones.Where(x => x.ActivityId.Equals(dto.ActivityId) && x.Completed==false && x.UserId.Equals(dto.UserId)).ToList();
            }
            catch (Exception)
            {

                throw;
            }


            return milestones;
        }

        public MilestoneDTO ReadMilestone(Milestone milestone)
        {
            Milestone milestoneRetrieved;

            try
            {
                milestoneRetrieved = context.Milestones.Where(x => x.Id.Equals(milestone.Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return null;
            }
            return new MilestoneDTO(milestoneRetrieved);
            
        }

        public bool UpdateMilestone(Milestone milestone)
        {
            Milestone milestoneToUpdate;
            try
            {
                milestoneToUpdate = context.Milestones.Where(x => x.Id.Equals(milestone.Id)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                throw;
            }

            try
            {
                milestoneToUpdate.Name = milestone.Name;
                milestoneToUpdate.ActivityId = milestone.ActivityId;
                milestoneToUpdate.UserId = milestone.UserId;
                milestoneToUpdate.Value = milestone.Value;
                milestoneToUpdate.Completed = milestone.Completed;
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            return true;
        }
    }
}
