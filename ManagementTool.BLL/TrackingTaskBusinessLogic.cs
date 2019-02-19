using System;
using System.Collections.Generic;
using ManagementTool.DAL.Models;
using ManagementTool.DAL.Repository.Interfaces;

namespace ManagementTool.BLL
{
    public class TrackingTaskBusinessLogic : ITrackingTaskBusinessLogic
    {
        private readonly ITrackingTaskRepository repository;
        public TrackingTaskBusinessLogic(ITrackingTaskRepository trackingTaskRepository)
        {
            repository = trackingTaskRepository;
        }
        public TrackingTaskBusinessLogic()
        {
           
        }

        public void Add(TrackingTask task)
        {
            try
            {
                repository.Insert(task);
            }catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            
        }

        public void Delete(int id)
        {
            try
            {
                repository.Delete(id);
            } catch (Exception e)
            {
                throw new Exception(e.Message,e.InnerException);
            }
            
        }

        public IEnumerable<TrackingTask> GetAll()
        {
            try
            {
                var tasks = repository.GetAll();
                return tasks;
            } catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            
        }

        public TrackingTask GetById(int id)
        {
            try
            {
                var task = repository.GetById(id);
                return task;
            } catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            
        }

        public void Update(TrackingTask task)
        {
            try
            {
                repository.Update(task);
            } catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
            
        }
    }
}
