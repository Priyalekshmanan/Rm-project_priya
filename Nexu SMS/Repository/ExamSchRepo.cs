using Microsoft.EntityFrameworkCore;
using Nexu_SMS.Entity;

using System.Linq;

namespace Nexu_SMS.Repository
{
    public class ExamSchRepo : IRepositoty<Exam>
    {
        private readonly ContextClass _context;

        public ExamSchRepo(ContextClass context)
        {
            _context = context;
        }

         public void Add(Exam entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            Exam exam = _context.exams.Find(id);
            _context.exams.Remove(exam);
            _context.SaveChanges();
        }

         public Exam Get(string id)
        {
            return _context.exams.Find(id);
        }

        public List<Exam> GetAll()
        {
            return _context.exams.ToList();
        }

        public void Update(Exam entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
