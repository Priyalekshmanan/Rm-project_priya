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
            Result result = contextclass.results.SingleOrDefault(r => r.ResultId == id);
            contextclass.results.Remove(result);
            contextclass.SaveChanges();
        }

        public List<Result> GetBYID(string id)
        {

            return contextclass.results.Where(x=>x.studentId==id).ToList();
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



        public List<Models.PublishResult> GetResults(string id, string sem)
        {
            var fullres = from res in contextclass.results
                          join student in contextclass.students
                          on res.studentId equals student.id
                          where res.studentId == id && res.semName == sem
                          group res by new { res.semName, res.examId } into groupResult
                          select new Models.PublishResult()
                          {
                              stu_id = id, // Assuming stu_id is the same for all results in the group
                              examId = groupResult.Key.examId, // Take the examId from the group key
                              subjectResults = groupResult.Select(r => new SubjectResult
                              {
                                  sub_Id = r.subjectId,
                                  marks = r.marks
                              }).ToList(),
                              totalMarks = (int)groupResult.Sum(r => r.marks)

                          };

            return fullres.ToList();
        }


        Result IRepositoty<Result>.Get(string id)
        {
            throw new NotImplementedException();
        }


    }
}