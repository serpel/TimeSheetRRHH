using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RRHH.Models;

namespace RRHH.DAL
{
    public class ShiftTimeRepository : IShiftTimeRepository, IDisposable
    {
        private TimeSheetContext context;

        public ShiftTimeRepository()
        {
            context = new TimeSheetContext();
        }

        public ShiftTimeRepository(TimeSheetContext timesheet)
        {
            this.context = timesheet;
        }

        public void Delete(int shiftTimeId)
        {
            throw new NotImplementedException();
        }

        public IList<ShiftTime> GetListByShiftId(int shiftId)
        {
            return context.ShiftTime.Where(w => w.ShiftId == shiftId).ToList();
        }

        public void Insert(ShiftTime shiftTime)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ShiftTime shiftTime)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ShiftTime GetListByShiftIdAndDayNumber(int shiftId, int day)
        {
            return context.ShiftTime.Where(w => w.ShiftId == shiftId && w.DayNumber == day).FirstOrDefault();
        }
        #endregion
    }
}