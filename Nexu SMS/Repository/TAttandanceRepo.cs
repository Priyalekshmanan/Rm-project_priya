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
            DateTime today = DateTime.Now;
            Guid gid = Guid.NewGuid();

            var TcrAtn = from t in contextClass.teachers
                         where t.teacherId == attendance.teacherId
                         select t;
            if (TcrAtn != null)
            {
                attendance.date = today;
                attendance.attendanceId = gid;
                contextClass.tattendances.Add(attendance);
                contextClass.SaveChanges();
            }
           
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public TAttendance Get(string id)
        {
            return contextClass.tattendances.SingleOrDefault(x => x.teacherId == id);
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
    }
}
