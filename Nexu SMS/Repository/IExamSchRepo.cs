using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public interface IExamSchRepo
    {
        void Add(ExamSchdule examSchdule);
        void Update(ExamSchdule examSchdule);
        List<ExamSchdule> GetAllEx();
        ExamSchdule GetByExId(string id);
        ExamSchdule GetByExName(string Exam_name);
        List<ExamSchdule> GetByExDate(DateTime date);

    }
}
