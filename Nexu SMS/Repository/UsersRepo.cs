using Microsoft.EntityFrameworkCore;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class UsersRepo : IRepositoty<Users>
    {
        private readonly ContextClass _context;

        public UsersRepo(ContextClass context)
        {
            _context = context;
        }

        

        public void Add(Users entity)
        {
            string tempPass = "Password@123";
            /*string tempUname= (from s in _context.students
                               join u in _context.users on s.id equals u.userId
                               select s.fName).SingleOrDefault();*/
            string tempUname=(from s in _context.students
                            where s.id==entity.userId
                            select s.fName).FirstOrDefault();
            entity.password = tempPass;
            if(entity.role == "student")
            {
                entity.userName = "snex" + tempUname;
            }
            else if (entity.role == "teacher")
            {
                entity.userName = "tnex" + tempUname;
            }
            _context.users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            Users user = _context.users.Find(id);
            _context.users.Remove(user);
            _context.SaveChanges();
        }

        public Users Get(string id)
        {
            Users user = _context.users.Find(id);
            return user;
        }

        public List<Users> GetAll()
        {
            return _context.users.ToList();
        }

        public void Update(Users entity)
        {
            if (entity.role == "student")
            {
                string tempUname = (from s in _context.students
                                join u in _context.users on s.id equals u.userId
                                select s.fName).SingleOrDefault();
           
                entity.userName = "snex" + tempUname;
            }
            else if (entity.role == "teacher")
            {
                string tempUname = (from t in _context.teachers
                                    join u in _context.users on t.teacherId equals u.userId
                                    where t.teacherId==u.userId
                                 
                            
                                    select t.teacherFirstName).SingleOrDefault();
                entity.userName = "tnex" + tempUname;
            }
            /*List<StudentMarks> studentMarks = (from s in _context.Students
                                               join m in _context.Marks
                                               on s.Id equals m.StudentId
                                               where s.Id == id
                                               select new StudentMarks()
                                               {
                                                   Id = s.Id,
                                                   Name = s.Name,
                                                   Std = s.Std,
                                                   Section = s.Section,
                                                   TotalMarks = m.TotalMarks,
                                                   Exam = m.Exam
                                               }).ToList();*/
            _context.users.Update(entity);
            _context.SaveChanges();
        }
    }
}
