using ManagementTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTool.BLL
{
    public interface ITrackingTaskBusinessLogic
    {
        void Add(TrackingTask task);
        TrackingTask GetById(int id);
        void Update(TrackingTask task);
        void Delete(int id);
        IEnumerable<TrackingTask> GetAll();
    }
}
