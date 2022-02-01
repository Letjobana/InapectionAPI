using InspectionAPI.Models;
using InspectionAPI.Persistance;
using InspectionAPI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InspectionAPI.Repository.Concrete
{
    public class InspectionRepository : IInspectionRepository
    {
        private readonly DataContext context;

        public InspectionRepository(DataContext context)
        {
            this.context = context;
        }
        public Inspection AddInspection(Inspection inspection)
        {
            if (inspection == null)
                throw new ArgumentNullException("status cannot be null");
            context.Inspections.Add(inspection);
            context.SaveChanges();
            return inspection;
        }

        public bool DeleteInspection(int id)
        {
            var inspectionId = context.Inspections.FirstOrDefault(x => x.Id == id);
            if (inspectionId == null)
                throw new ArgumentNullException("Invalid status");
            context.Inspections.Remove(inspectionId);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Inspection> GetAllInspections()
        {
            return context.Inspections.ToList();
        }

        public Inspection GetInspectionById(int id)
        {
            return context.Inspections.Find(id);
        }

        public bool UpdateInspection(Inspection inspection)
        {
            if (inspection == null)
                throw new ArgumentNullException("Status cannot be null");
            var updateInspection = context.Inspections.FirstOrDefault(x => x.Id == inspection.Id);

            updateInspection.Status = inspection.Status;
            updateInspection.Comments = inspection.Comments;
            updateInspection.InspectionTypeId = inspection.InspectionTypeId;

            context.SaveChanges();
            return true;
        }
    }
}
