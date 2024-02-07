using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class SAttendanceRepo : IRepositoty<SAttendance>
    {
       private readonly ContextClass contextClass;

        public SAttendanceRepo(ContextClass contextClass)
        {
            this.contextClass = contextClass;
        }

        public void Add(SAttendance attendance)
        {
            var stdAtn = from s in contextClass.students
                         where s.id == attendance.studentId
                         select s;
            if (stdAtn != null)
            {
                contextClass.sattendances.Add(attendance);
                contextClass.SaveChanges();
            }
           

        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public SAttendance Get(string id)
        {
            return contextClass.sattendances.Find(id);
        }

        public List<SAttendance> GetAll()
        {
           return contextClass.sattendances.ToList();
        }

        public void Update(SAttendance attendance)
        {
            contextClass.sattendances.Update(attendance);
            contextClass.SaveChanges();
        }
    }
}
