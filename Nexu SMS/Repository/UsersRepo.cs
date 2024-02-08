using Microsoft.EntityFrameworkCore;
using Nexu_SMS.Entity;
using Nexu_SMS.Models;

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
            /*string tempSUname = (from s in _context.students
                                 join u in _context.users on s.id equals u.userId
                                 select s.fName).SingleOrDefault();*/


            /*string tempTUname= (from t in _context.teachers
                                join u in _context.users on t.teacherId equals u.userId
                                where t.teacherId == u.userId
                                select t.teacherFirstName).SingleOrDefault();
*/
            string tempSUname = (from s in _context.students
                                 where s.id == entity.userId
                                 select s.fName).SingleOrDefault();
            string tempTUname = (from t in _context.teachers
                                 where t.teacherId == entity.userId
                                 select t.teacherFirstName).SingleOrDefault();
            if (entity.role == "Student")
            {
                entity.userName = "snex" + tempSUname;
                entity.password = tempPass;
                _context.users.Add(entity);
                _context.SaveChanges();

            }
            if (entity.role == "Teacher")
            {

                entity.userName = "tnex" + tempTUname;
                entity.password = tempPass;
                _context.users.Add(entity);
                _context.SaveChanges();


            }
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
            string tempSUname = (from s in _context.students
                                 join u in _context.users on s.id equals u.userId
                                 select s.fName).SingleOrDefault();

            /*string tempTUname= (from t in _context.teachers
                                join u in _context.users on t.teacherId equals u.userId
                                where t.teacherId == u.userId
                                select t.teacherFirstName).SingleOrDefault();
*/
            string tempTUname = (from t in _context.teachers
                                 where t.teacherId == entity.userId
                                 select t.teacherFirstName).SingleOrDefault();
            if (entity.role == "Student")
            {

                entity.userName = "snex" + tempSUname;
                _context.users.Update(entity);
                _context.SaveChanges();

            }
            if (entity.role == "Teacher")
            {
                entity.userName = "tnex" + tempTUname;
                _context.users.Update(entity);
                _context.SaveChanges();


            }
        }
        public Users Validate(Login login)
        {
            return _context.users.SingleOrDefault(x => x.userName == login.userName && x.password == login.password);
        }
    }
}