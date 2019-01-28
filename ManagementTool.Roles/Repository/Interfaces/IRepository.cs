using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementTool.Roles.Models;

namespace ManagementTool.Roles.Repository.Interfaces
{
    public interface IRepository
    {
        void Insert(TrackingTask item);
        TrackingTask GetById(int id);
        void Update(TrackingTask modifiedTask);
        void UpdateUser(TrackingTask modifiedTask);
        void Delete(int id);
        IEnumerable<TrackingTask> GetAll();
    }
}
