using System;
using System.Linq;
using TIPP.Server.Domain;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    public class MilestoneSQLService : IMileStoneService
    {
        private readonly tipp_DBContext context;

        public MilestoneSQLService()
        {
            this.context = new tipp_DBContext();
        }



        public bool CreateMilestone(Milestone milestone)
        {
            try
            {
                context.Milestones.Add(milestone);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            return true;
        }

        public bool DeleteMilestone(Milestone milestone)
        {
            Milestone milestoneToDelete;
            try
            {
                milestoneToDelete = context.Milestones.Where(x => x.Id.Equals(milestone.Id)).FirstOrDefault();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            context.Milestones.Remove(milestoneToDelete);
            return true;
        }

        public object GetMilestones()
        {
            return new { Items = context.Milestones };
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
                milestoneToUpdate.TimeSpent = milestone.TimeSpent;
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
