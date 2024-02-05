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
            string tempUname = (from s in _context.students
                                join u in _context.users on s.id equals u.userId
                                select s.fName).SingleOrDefault();
            if (entity.role == "student")
            {
                entity.userName = "snex" + tempUname;
            }
            else if (entity.role == "teacher")
            {
                entity.userName = "tnex" + tempUname;
            }
            _context.users.Update(entity);
            _context.SaveChanges();
        }
    }
}
