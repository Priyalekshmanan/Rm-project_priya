using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class ResultRepo : IRepositoty<Result>
    {
        private readonly ContextClass context;

        public ResultRepo(ContextClass context)
        {
            this.context = context;
        }
        public void Add(Result entity)
        {
           context.Add(entity);
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            Result result = context.results.Find(id);
            context.results.Remove(result);
            context.SaveChanges();
        }
        public List<ResultPublish> GetMarks(string id)
        {
            List<ResultPublish> studentMarks = (from s in context.results
                                                join m in context.students
                                               on s.stu_id equals m.id
                                                where s.stu_id == id
                                                select new ResultPublish()
                                                {
                                                    stu_id = s.stu_id,
                                                    studentName = m.fName,
                                                    examId = s.exam_Id,
                                                   /* sub_Id = s.sub_Id,*/
                                                    totalMarks = s.marks
                                                }).ToList();
            return studentMarks;
        }

        public Result Get(string id)
        {
            throw new NotImplementedException();
        }

        public List<Result> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Result entity)
        {
            context.Update(entity);
            context.SaveChanges();
    }    }

}
