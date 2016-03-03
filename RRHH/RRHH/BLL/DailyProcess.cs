using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RRHH.Models;
using RRHH.DAL;

namespace RRHH.BLL
{
    public class DailyProcess
    {
        private TimeSheetContext context;
        private EmployeeRepository eRepository;
        private ShiftTimeRepository sRepository;
        private AttendanceRecordsRepository aRepository;
        private TimeSheetRepository tRepository;

        public DailyProcess():this(new TimeSheetContext()) { }

        public DailyProcess(TimeSheetContext context)
        {
            this.context = context;
            eRepository = new EmployeeRepository(context);
            sRepository = new ShiftTimeRepository(context);
            aRepository = new AttendanceRecordsRepository(context);
            tRepository = new TimeSheetRepository(context);
        }

        public void GenerateEmployeeTimeSheetByDate(DateTime date)
        {
            tRepository.DeleteByDate(date);
            tRepository.Save();

            var employees = eRepository.GetAll().Where(w => w.IsActive == true);

            foreach(var employee in employees)
            {
                //func expresion para filtrar una fecha especifica
                Func<AttendanceRecord, bool> filter = f => f.Date.Year == date.Year && f.Date.Month == date.Month && f.Date.Day == date.Day;
                var attendances = aRepository.GetAttendaceByEmployee(employee.EmployeeId).Where(filter);
                var shifttime = sRepository.GetListByShiftIdAndDayNumber(employee.ShiftId, ((int)date.DayOfWeek + 1));

                //si tiene marcas hay que repararlas, si no hay que agregar la fecha 
                if(attendances.Count() > 0)
                {
                    var employeeTimesheet = attendances
                             .GroupBy(x => x.EmployeeId)
                             .Select(s => new TimeSheet()
                             {
                                 EmployeeId = s.Key,
                                 Date = date,
                                 In = s.FirstOrDefault().Date,
                                 Out = s.LastOrDefault().Date,
                                 IsManualIn = false,
                                 IsManualOut = false,
                                 InsertedAt = DateTime.Now,
                                 UpdatedAt = DateTime.Now,
                                 IsActive = true
                             }).FirstOrDefault();
                    //El tiempo para considerar una marca es de una hora si no se reemplaza por la que tiene el turno
                    TimeSpan overtime = TimeSpan.FromHours(1);
                    TimeSpan checkin = employeeTimesheet.In.Value.TimeOfDay;
                    TimeSpan checkout = employeeTimesheet.Out.Value.TimeOfDay;

                    //arreglo las horas de entrada y salida basado en el turno del empleado
                    if (!(checkin <= (shifttime.StartTime + overtime)))
                    {
                        employeeTimesheet.In = new DateTime(
                        employeeTimesheet.In.Value.Year,
                        employeeTimesheet.In.Value.Month,
                        employeeTimesheet.In.Value.Day,
                        shifttime.StartTime.Hours,
                        shifttime.StartTime.Minutes,
                        shifttime.StartTime.Seconds);
                        employeeTimesheet.UpdatedAt = DateTime.Now;
                        employeeTimesheet.IsManualIn = true;
                    }

                    //checkout <= (shiftday.EndTime + overtime) &&
                    if (!(checkout >= (shifttime.EndTime - overtime)))
                    {
                        employeeTimesheet.Out = new DateTime(employeeTimesheet.Out.Value.Year,
                        employeeTimesheet.Out.Value.Month,
                        employeeTimesheet.Out.Value.Day,
                        shifttime.EndTime.Hours,
                        shifttime.EndTime.Minutes,
                        shifttime.EndTime.Seconds);
                        employeeTimesheet.UpdatedAt = DateTime.Now;
                        employeeTimesheet.IsManualOut = true;
                    }

                    tRepository.Insert(employeeTimesheet);
                }
                else
                {
                    TimeSheet timesheet = new TimeSheet()
                    {
                        EmployeeId = employee.EmployeeId,
                        Date = date,
                        IsManualIn = true,
                        IsManualOut = true,
                        InsertedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true
                    };
                    tRepository.Insert(timesheet);
                }

                tRepository.Save();
            }
        }

    }
}