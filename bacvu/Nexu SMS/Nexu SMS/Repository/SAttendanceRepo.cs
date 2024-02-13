using Nexu_SMS.Entity;
using Nexu_SMS.Repository;

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
            attendance.attendanceId = Guid.NewGuid();
            contextClass.sattendances.Add(attendance);
            contextClass.SaveChanges();
        }


    }

    public void Delete(string id)
    {
        throw new NotImplementedException();
    }

    public List<SAttendance> Get(string id)
    {
        return contextClass.sattendances.Where(s => s.studentId == id).ToList();
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
    public List<SAttendance> GetAttByClaassId(string classID)
    {
        /* return contextClass.sattendances.Where(x=>x.classId == classID && x.classId)*/
        var result = (from attndance in contextClass.sattendances
                      from t_class in contextClass.classes
                      where attndance.classId == classID && t_class.ClassId == classID
                      select attndance).ToList();
        return result;
    }
}