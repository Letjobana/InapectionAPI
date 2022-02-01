using InspectionAPI.Models;
using System.Collections.Generic;

namespace InspectionAPI.Repository.Abstract
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAllStatuses();
        Status GetStatusById(int id);
        Status AddStatus(Status status);
        bool DeleteStatus(int id);
        bool UpdateStatus(Status status);
    }
}
