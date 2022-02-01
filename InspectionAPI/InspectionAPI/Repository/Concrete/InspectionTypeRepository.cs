using InspectionAPI.Models;
using InspectionAPI.Persistance;
using InspectionAPI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InspectionAPI.Repository.Concrete
{
    public class InspectionTypeRepository : IInspectionTypeRepository
    {
        private readonly DataContext context;

        public InspectionTypeRepository(DataContext context)
        {
            this.context = context;
        }
        public InspectionType AddInspectionType(InspectionType inspectionType)
        {
            if (inspectionType == null)
                throw new ArgumentNullException("status cannot be null");
            context.InspectionTypes.Add(inspectionType);
            context.SaveChanges();
            return inspectionType;
        }

        public bool DeleteInspectionType(int id)
        {
            var inspectionTypeId = context.InspectionTypes.FirstOrDefault(x => x.Id == id);
            if (inspectionTypeId == null)
                throw new ArgumentNullException("Invalid inspection type");
            context.InspectionTypes.Remove(inspectionTypeId);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<InspectionType> GetAllInspectionTypes()
        {
            return context.InspectionTypes.ToList();
        }

        public InspectionType GetInspectionTypeById(int id)
        {
            return context.InspectionTypes.Find(id);
        }

        public bool UpdateInspectionType(InspectionType inspectionType)
        {
            if (inspectionType == null)
                throw new ArgumentNullException("Status cannot be null");
            var updateInspectionType = context.InspectionTypes.FirstOrDefault(x => x.Id == inspectionType.Id);

            updateInspectionType.InspectionName = inspectionType.InspectionName;
            context.SaveChanges();
            return true;
        }
    }
}
