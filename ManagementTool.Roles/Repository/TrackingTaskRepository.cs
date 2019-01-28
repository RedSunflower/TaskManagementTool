using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementTool.Roles.Models;
using ManagementTool.Roles.Repository.Interfaces;

namespace ManagementTool.Roles.Repository
{
    public class TrackingTaskRepository : IRepository
    {
        private readonly ApplicationDbContext _context;
        public TrackingTaskRepository()
        {
             _context = new ApplicationDbContext();
        }
        public void Delete(int id)
        {
            foreach (TrackingTask item in _context.Tasks)
            {
                if (item != null && item.ParentId == id)
                {
                    _context.Tasks.Remove(item);
                }
                if (item.Id == id)
                {
                    _context.Tasks.Remove(item);
                }
            }

            _context.SaveChanges();
        }

        public IEnumerable<TrackingTask> GetAll()
        {
            IEnumerable<TrackingTask> taskList = _context.Tasks.ToList();
            return taskList;
        }

        public TrackingTask GetById(int id)
        {
            var task = _context.Tasks.Find(id);
            return task;
        }

        public void Insert(TrackingTask item)
        {
            _context.Tasks.Add(item);
            _context.SaveChanges();
        }

        public void Update(TrackingTask modifiedTask)
        {
            var oldTask = _context.Tasks.Find(modifiedTask.Id);
            oldTask.ProjectName = modifiedTask.ProjectName;
            oldTask.TaskName = modifiedTask.TaskName;
            oldTask.TaskDescription = modifiedTask.TaskDescription;
            oldTask.StartDate = modifiedTask.StartDate;
            oldTask.TillDate = modifiedTask.TillDate;
            oldTask.Status = modifiedTask.Status;
            oldTask.Priority = modifiedTask.Priority;
            oldTask.Progress = modifiedTask.Progress;
            _context.SaveChanges();
        }
        public void UpdateUser(TrackingTask modifiedTask)
        {
            var oldTask = _context.Tasks.Find(modifiedTask.Id);
            oldTask.ProjectName = modifiedTask.ProjectName;
            oldTask.TaskName = modifiedTask.TaskName;
            oldTask.TaskDescription = modifiedTask.TaskDescription;
            oldTask.StartDate = modifiedTask.StartDate;
            oldTask.TillDate = modifiedTask.TillDate;
            oldTask.Status = modifiedTask.Status;
            oldTask.Priority = modifiedTask.Priority;
            oldTask.Progress = modifiedTask.Progress;
            oldTask.ApplicationUserDetails = modifiedTask.ApplicationUserDetails;
            oldTask.UserId = modifiedTask.UserId;
            _context.SaveChanges();
        }
    }
}
