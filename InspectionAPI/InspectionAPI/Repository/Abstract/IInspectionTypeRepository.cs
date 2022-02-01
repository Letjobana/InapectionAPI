using InspectionAPI.Models;
using System.Collections.Generic;

namespace InspectionAPI.Repository.Abstract
{
    public interface IInspectionTypeRepository
    {
        IEnumerable<InspectionType> GetAllInspectionTypes();
        InspectionType GetInspectionTypeById(int id);
        InspectionType AddInspectionType(InspectionType inspectionType);
        bool DeleteInspectionType(int id);
        bool UpdateInspectionType(InspectionType inspectionType);
    }
}
