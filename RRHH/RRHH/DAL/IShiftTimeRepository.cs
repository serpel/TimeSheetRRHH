using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRHH.Models;

namespace RRHH.DAL
{
    interface IShiftTimeRepository
    {
        void Insert(ShiftTime shiftTime);
        void Update(ShiftTime shiftTime);
        void Delete(int shiftTimeId);
        void Save();
        IList<ShiftTime> GetListByShiftId(int shiftId);
        ShiftTime GetListByShiftIdAndDayNumber(int shiftId, int day);
    }
}
