using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementTool.DAL.Models;
using ManagementTool.DAL.Repository.Interfaces;
using System.Data.Entity;

namespace ManagementTool.DAL.Repository
{
    public class TrackingTaskRepository : ITrackingTaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TrackingTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual void Delete(int id)
        {
            try
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
            }catch(Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            
        }
        public IEnumerable<TrackingTask> GetAll()
        {
            try
            {
                IEnumerable<TrackingTask> taskList = _context.Tasks.ToList();
                return taskList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            
        }

        public virtual TrackingTask GetById(int id)
        {
            try
            {
                var task = _context.Tasks.Find(id);
                return task;
            } catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            
        }

        public virtual void Insert(TrackingTask item)
        {
            try
            {
                _context.Tasks.Add(item);
                _context.SaveChanges();

            }catch(Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        public virtual void Update(TrackingTask modifiedTask)
        {
            try
            {
                var oldTask = _context.Tasks.Find(modifiedTask.Id);
                _context.Entry(oldTask).State = EntityState.Detached;
                _context.Entry(modifiedTask).State = EntityState.Modified;
                _context.SaveChanges();
            } catch(Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            
        }
    }
}


