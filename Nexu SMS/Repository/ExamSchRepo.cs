using Microsoft.EntityFrameworkCore;
using Nexu_SMS.Entity;
using Nexu_SMS.Migrations;
using System.Linq;

namespace Nexu_SMS.Repository
{
    public class ExamSchRepo : IExamSchRepo
    {
        private readonly ContextClass _context;

        public ExamSchRepo(ContextClass context)
        {
            _context = context;
        }

        public void Add(ExamSchdule examSchdule)
        {
            _context.Add(examSchdule);
            _context.SaveChanges();
        }

        public List<ExamSchdule> GetAll()
        {
            return _context.exams.ToList();
        }

        public List<ExamSchdule> GetByDate(DateTime date)
        {
            return _context.exams.Where(x => x.Exam_date == date).ToList();
        }

        public ExamSchdule GetById(string id)
        {
            return _context.exams.Find(id);
        }

        public ExamSchdule GetByName(string Exam_name)
        {
            return _context.exams.Find(Exam_name);
        }

        public void Update(ExamSchdule examSchdule)
        {
            _context.Update(examSchdule);
            _context.SaveChanges();
        }
    }
}