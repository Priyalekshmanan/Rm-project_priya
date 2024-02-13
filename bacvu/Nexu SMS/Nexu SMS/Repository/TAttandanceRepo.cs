using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class TAttandanceRepo : IRepositoty<TAttendance>
    {
        private readonly ContextClass contextClass;

        public TAttandanceRepo(ContextClass contextClass)
        {
            this.contextClass = contextClass;
        }

        public void Add(TAttendance attendance)
        {
            var TcrAtn = from t in contextClass.teachers
                         where t.teacherId == attendance.teacherId
                         select t;
            if (TcrAtn != null)
            {
                attendance.attendanceId = Guid.NewGuid();
                contextClass.tattendances.Add(attendance);
                contextClass.SaveChanges();
            }
           
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<TAttendance> Get(string id)
        {
            return contextClass.tattendances.Where(x=>x.teacherId==id).ToList();
        }

        public List<TAttendance> GetAll()
        {
            return contextClass.tattendances.ToList();
        }

        public void Update(TAttendance attendance)
        {
            contextClass.tattendances.Update(attendance);
            contextClass.SaveChanges();
        }

        TAttendance IRepositoty<TAttendance>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
