using Nexu_SMS.Entity;
using Nexu_SMS.Models;
using System.Text.RegularExpressions;

namespace Nexu_SMS.Repository
{
    public class DisplayAttendance
    {
        private readonly ContextClass _contextClass;

        public DisplayAttendance(ContextClass contextClass)
        {
            _contextClass = contextClass;
        }
        
        public DisplayTotalAttendance DisplayTeacherAttendances(string id,DateTime startdt,DateTime enddt) 
        {
            var result = from attendance in _contextClass.tattendances
                         where attendance.teacherId == id && attendance.date >= startdt && attendance.date <= enddt

                         select attendance;
            int total_days=result.Count();
            int total_present=result.Where(a=>a.status == true).Count();
            int total_absent=result.Where(a=>a.status == false).Count();
            var item = new DisplayTotalAttendance()
            {
                presentDays = total_present,

                absentDays = total_absent,
                totalWorking = total_days,
            };
            return item;
        }
        public DisplayTotalAttendance DisplayStudentAttendances(string id, DateTime startdt, DateTime enddt)
        {
            var result = from attendance in _contextClass.sattendances
                         where attendance.studentId == id && attendance.date >= startdt && attendance.date <= enddt

                         select attendance;
            int total_days = result.Count();
            int total_present = result.Where(a => a.status == true).Count();
            int total_absent = result.Where(a => a.status == false).Count();
            var item = new DisplayTotalAttendance()
            {
                presentDays = total_present,

                absentDays = total_absent,
                totalWorking = total_days,
            };
            return item;
        }


        public List<DisplayTotalAttendance> DisplayAllTeacherAttendances(DateTime startdt, DateTime enddt)
        {
            var result = from attendance in _contextClass.tattendances
                         where attendance.date >= startdt && attendance.date <= enddt
                         group attendance by attendance.teacherId into groupedAttendenceofTeacher
                         select new DisplayTotalAttendance()
                         {
                             teacherId = groupedAttendenceofTeacher.Key,
                             presentDays = groupedAttendenceofTeacher.Count(a => a.status == true),
                             absentDays = groupedAttendenceofTeacher.Count(a => a.status == false),
                             totalWorking = groupedAttendenceofTeacher.Count(),
                         };

            return result.ToList();
        }
        public List<DisplayTotalAttendance> DisplayAllStudentAttendances(DateTime startdt, DateTime enddt)
        {
            var result = from attendance in _contextClass.sattendances
                         where attendance.date >= startdt && attendance.date <= enddt
                         group attendance by attendance.studentId into groupedAttendenceofStudent
                         select new DisplayTotalAttendance()
                         {
                             studentId = groupedAttendenceofStudent.Key,
                             presentDays = groupedAttendenceofStudent.Count(a => a.status == true),
                             absentDays = groupedAttendenceofStudent.Count(a => a.status == false),
                             totalWorking = groupedAttendenceofStudent.Count(),
                         };

            return result.ToList();
        }
    }
}
