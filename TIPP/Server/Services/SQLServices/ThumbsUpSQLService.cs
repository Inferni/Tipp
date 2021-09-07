using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    public class ThumbsUpSQLService : IThumbsUpService
    {
        private readonly tipp_DBContext context;

        public ThumbsUpSQLService(tipp_DBContext context)
        {
            this.context = context;
        }

        public bool CreateThumbsUp(ThumbsUp ThumbsUp)
        {
            ThumbsUp.Seen = false;
            ThumbsUp.Username = context.Users.Where(x => x.Id.Equals(ThumbsUp.UserId)).FirstOrDefault().Username;
            ThumbsUp.MilestoneName = context.Milestones.Where(x => x.Id.Equals(ThumbsUp.MilestoneId)).FirstOrDefault().Name;
            try
            {
                context.ThumbsUp.Add(ThumbsUp);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            
            throw new NotImplementedException();
        }

        public bool DeleteThumbsUp(ThumbsUp ThumbsUp)
        {
            throw new NotImplementedException();
        }

        public object GetThumbsUps()
        {
            throw new NotImplementedException();
        }

        public List<ThumbsUp> GetThumbsUpsByProjectAndUserId(int projectid, int userid)
        {
            List<Activity> activities = context.Activities.Where(x => x.ProjectId.Equals(projectid)).ToList();
            List<Milestone> milestonesInActivity;
            List<Milestone> completedMilestonesInActivity = new List<Milestone>();
            foreach (var activity in activities)
            {
                milestonesInActivity = context.Milestones.Where(x => x.ActivityId.Equals(activity.Id) && x.UserId.Equals(userid) && x.Completed == true).ToList();
                completedMilestonesInActivity.AddRange(milestonesInActivity);
            }

            List<ThumbsUp> thumbsUps = new List<ThumbsUp>();
            foreach(var milestone in completedMilestonesInActivity)
            {
                thumbsUps.AddRange(context.ThumbsUp.Where(x=>x.MilestoneId.Equals(milestone.Id)&& x.Seen==false));
            }

            return thumbsUps;

        }

        public ThumbsUpDTO ReadThumbsUp(ThumbsUp ThumbsUp)
        {
            throw new NotImplementedException();
        }

        public bool UpdateThumbsUp(ThumbsUp thumbsUp)
        {
            ThumbsUp thumbsUpToUpdate = context.ThumbsUp.Where(x => x.Id.Equals(thumbsUp.Id)).FirstOrDefault();

            try
            {
                thumbsUpToUpdate.MilestoneId = thumbsUp.MilestoneId;
                thumbsUpToUpdate.MilestoneName = thumbsUp.MilestoneName;
                thumbsUpToUpdate.UserId = thumbsUp.UserId;
                thumbsUpToUpdate.Username = thumbsUp.Username;
                thumbsUpToUpdate.Seen = thumbsUp.Seen;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            //Project projectToUpdate;
            //try
            //{
            //    projectToUpdate = context.Projects.Where(x => x.Id.Equals(project.Id)).FirstOrDefault();
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex);
            //    return false;
            //}

            //try
            //{
            //    projectToUpdate.Id = project.Id;
            //    projectToUpdate.Name = project.Name;
            //    projectToUpdate.Completed = project.Completed;
            //    projectToUpdate.Activities = project.Activities;
            //    context.SaveChanges();
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    return false;
            //    throw;
            //}
            //return false;
        }
    }
}
