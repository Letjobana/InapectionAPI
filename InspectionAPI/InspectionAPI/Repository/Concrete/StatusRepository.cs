using InspectionAPI.Models;
using InspectionAPI.Persistance;
using InspectionAPI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InspectionAPI.Repository.Concrete
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DataContext context;

        public StatusRepository(DataContext context)
        {
            this.context = context;
        }
        public Status AddStatus(Status status)
        {
            if (status == null)
                throw new ArgumentNullException("status cannot be null");
            context.Statuses.Add(status);
            context.SaveChanges();
            return status;
        }

        public bool DeleteStatus(int id)
        {
            var productId = context.Statuses.FirstOrDefault(x => x.Id == id);
            if (productId == null)
                throw new ArgumentNullException("Invalid status");
            context.Statuses.Remove(productId);
            context.SaveChanges();
            return true;
        }

        public IEnumerable<Status> GetAllStatuses()
        {
            return context.Statuses.ToList();
        }

        public Status GetStatusById(int id)
        {
            return context.Statuses.Find(id);
        }
        public bool UpdateStatus(Status status)
        {
            if (status == null)
                throw new ArgumentNullException("Status cannot be null");
            var updateStatus = context.Statuses.FirstOrDefault(x => x.Id == status.Id);
            updateStatus.StatusOption = status.StatusOption;
            context.SaveChanges();
            return true;
        }
    }
}
