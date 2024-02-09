using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class DisplayAttendanceRepo
    {
        private readonly ContextClass _contextClass;

        public DisplayAttendanceRepo(ContextClass contextClass)
        {
            _contextClass = contextClass;
        }
        public List<TAttendance> TDisplay(string id, DateTime startdt, DateTime enddt)
        {
            var res1 = _contextClass.tattendances
                .Where(d => d.teacherId == id && d.status == true && d.date >= startdt && d.date <= enddt).ToList();
            return res1;
        }
        public List<SAttendance> SDisplay(string id, DateTime startdt, DateTime enddt)
        {
            var res2 = _contextClass.sattendances
                .Where(d => d.studentId == id && d.status == true && d.date >= startdt && d.date <= enddt).ToList();
            return res2;
        }
    }
}