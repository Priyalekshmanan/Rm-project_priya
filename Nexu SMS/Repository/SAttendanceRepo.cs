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
                         from clasmanagemt in contextClass.classes
                         from t in contextClass.teachers
                         where s.id == attendance.studentId && clasmanagemt.ClassId == attendance.classId && t.teacherId == clasmanagemt.Teacherid
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

        public Student Get(string id)
        {
            return contextClass.students.Find(id);
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

        SAttendance IRepositoty<SAttendance>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
