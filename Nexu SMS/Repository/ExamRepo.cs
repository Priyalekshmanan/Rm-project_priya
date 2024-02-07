using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class ExamRepo:IRepositoty<Exam>
    {
        public readonly ContextClass contextClass;

        public ExamRepo(ContextClass contextClass)
        {
            this.contextClass = contextClass;
        }

        public void Add(Exam entity)
        {
            var check = from s in contextClass.subjects
                        from c in contextClass.classes
                        where s.sub_Id == entity.subId && c.ClassId == entity.classId
                        select s;
            if (check != null)
            {
                contextClass.exams.Add(entity); 
                contextClass.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            Exam xam = contextClass.exams.Find(id);
            contextClass.exams.Remove(xam);
            contextClass.SaveChanges();
        }

        public Exam Get(string id)
        {
            return contextClass.exams.Find(id);
        }

        public List<Exam> GetAll()
        {
            return contextClass.exams.ToList();

        }

        public void Update(Exam entity)
        {
           contextClass.Update(entity);
            contextClass.SaveChanges();
        }
    }
}
