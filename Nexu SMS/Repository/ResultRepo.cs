using Nexu_SMS.Entity;
using Nexu_SMS.Models;

namespace Nexu_SMS.Repository
{
    public class ResultRepo : IRepositoty<Result>
    {
        public readonly ContextClass contextclass;

        public ResultRepo(ContextClass contextclass)
        {
            this.contextclass = contextclass;
        }

        public void Add(Result entity)
        {
            var record = from e in contextclass.exams
                         from sb in contextclass.subjects
                         from s in contextclass.students
                         where e.examId == entity.examId && sb.sub_Id == entity.subjectId && s.id == entity.studentId
                         select e;
            if (record != null)
            {
                contextclass.Add(entity);
                contextclass.SaveChanges();
            }

        }

        public void Delete(string id)
        {
            Result result = contextclass.results.Find(id);
            contextclass.results.Remove(result);
        }

        public Result GetBYID(string id)
        {

            return contextclass.results.Find(id);
        }

        public List<Result> GetAll()
        {
            return contextclass.results.ToList();

        }

        public void Update(Result entity)
        {
            contextclass.results.Update(entity);
            contextclass.SaveChanges();
        }

        /* public List<PublishResult> GetResults()
         {
             var query = from result in contextclass.results
                         join student in contextclass.students
                         on result.studentId equals student.id
                         select new PublishResult()
                         {
                             stu_id = result.studentId,
                             examId = result.examId,
                             studentName = student.fName, // Assuming this is the property for student name in Students table
                             sub_Id = result.subjectId,
                             totalMarks = result.Sum(i => i.marks)
                         };
             return query.ToList();
         }*/
        public List<Models.PublishResult> GetResults()
        {
            var query = from result in contextclass.results
                        join student in contextclass.students
                        on result.studentId equals student.id
                        group result by new { result.studentId, result.examId, result.subjectId, student.fName } into g
                        select new Models.PublishResult()
                        {
                            stu_id = g.Key.studentId,
                            examId = g.Key.examId,
                            sub_Id = g.Key.subjectId,
                            studentName = g.Key.fName,
                            totalMarks = g.Sum(r => r.marks)
                        };
            return query.ToList();
        }

        Result IRepositoty<Result>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
