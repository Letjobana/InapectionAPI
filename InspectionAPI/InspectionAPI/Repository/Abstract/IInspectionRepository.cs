using InspectionAPI.Models;
using System.Collections.Generic;

namespace InspectionAPI.Repository.Abstract
{
    public interface IInspectionRepository
    {
        IEnumerable<Inspection> GetAllInspections();
        Inspection GetInspectionById(int id);
        Inspection AddInspection(Inspection inspection);
        bool DeleteInspection(int id);
        bool UpdateInspection(Inspection inspection);
    }
}
