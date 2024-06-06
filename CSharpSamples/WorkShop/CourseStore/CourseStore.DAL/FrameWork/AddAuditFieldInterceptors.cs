using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.DAL.FrameWork
{
    public class AddAuditFieldInterceptors:SaveChangesInterceptor
    {

        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            SetShadowProperties(eventData);
            return base.SavedChanges(eventData, result);
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            SetShadowProperties(eventData);
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        private static void SetShadowProperties(SaveChangesCompletedEventData eventData)
        {
            var changeTracker = eventData.Context.ChangeTracker;
            var addedEntities = changeTracker.Entries().Where(c => c.State == Microsoft.EntityFrameworkCore.EntityState.Added);
            var modifiedEntities = changeTracker.Entries().Where(c => c.State == Microsoft.EntityFrameworkCore.EntityState.Modified);
            DateTime now = DateTime.Now;

            foreach (var entity in addedEntities)
            {
                entity.Property("CreateBy").CurrentValue = "admin";
                entity.Property("UpdateBy").CurrentValue = "admin";
                entity.Property("CreationDate").CurrentValue = now;
                entity.Property("UpdateDate").CurrentValue = now;
            }

            foreach (var entity in modifiedEntities)
            {
                entity.Property("UpdateBy").CurrentValue = "UpdateAdmin";
                entity.Property("UpdateDate").CurrentValue = now;
            }
        }
    }
}
