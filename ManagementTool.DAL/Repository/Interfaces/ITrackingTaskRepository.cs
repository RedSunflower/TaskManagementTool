using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementTool.DAL.Models;

namespace ManagementTool.DAL.Repository.Interfaces
{
    public interface ITrackingTaskRepository
    {
        void Insert(TrackingTask item);
        TrackingTask GetById(int id);
        void Update(TrackingTask modifiedTask);
        void Delete(int id);
        IEnumerable<TrackingTask> GetAll();
    }
}
