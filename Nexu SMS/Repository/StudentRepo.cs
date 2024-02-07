using Microsoft.AspNetCore.Http.HttpResults;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class StudentRepo:IRepositoty<Student>
    {
        public readonly ContextClass contextClass;
            public StudentRepo(ContextClass contextClass)
        {
            this.contextClass = contextClass;
        }

        public void Add(Student student)
        {
               
           contextClass.students.Add(student);

            contextClass.SaveChanges();
        }

        public void Delete(string id)
        {
            Student student = contextClass.students.Find(id);
           contextClass.students.Remove(student);
            contextClass.SaveChanges();
        }

        public Student Get(string id)
        {
            Student student = contextClass.students.Find(id);
            return student;
        }

        public List<Student> GetAll()
        {
           return contextClass.students.ToList();
        }

        public void Update(Student entity)
        {
           contextClass.students.Update(entity);
            contextClass.SaveChanges();
        }

        public string AddStudentVal(Student student)
        {
            AdmissionNo admission = contextClass.admissionNos.Find(student.id);
            if (admission != null)
            {
                contextClass.students.Add(student);
                contextClass.SaveChanges();
                return "Student added";
            }
            else
                return "id invalid";
        }

        public List<Student> GetStdByClass(int clss)
        {
            return contextClass.students.Where(x => x.clss == clss).ToList();
        }

        public List<Student> GetStdBySection(string sec)
        {
            return contextClass.students.Where(x => x.section == sec).ToList();
        }

        public List<Student> GetStdBySectionNclass(string sec, int cls)
        {
            return contextClass.students.Where(x => x.section == sec && x.clss == cls).ToList();
        }
    }
}
