using Nexu_SMS.Entity;
using System.Linq;

namespace Nexu_SMS.Repository
{
    public class ClassManagementRepo : IRepositoty<ClassManagement>
    {
        public readonly ContextClass contextClass;
        public ClassManagementRepo(ContextClass contextClass)
        {

            this.contextClass = contextClass;
        }
    

        public void Add(ClassManagement classManagement)
        {
            
            var tchr = from t in contextClass.teachers
                       where t.teacherId == classManagement.Teacherid
                       select t;

            if (tchr!= null)
            {
            contextClass.classes.Add(classManagement);
            contextClass.SaveChanges();
            }
        }

        public ClassManagement Get(string id)
        {
            return contextClass.classes.SingleOrDefault(c => c.ClassId == id);
        }

        public List<ClassManagement> GetAll()
        {
            return contextClass.classes.ToList();
        }

 

        public void Update(ClassManagement  classManagement)
        {
           contextClass.Update(classManagement);
            contextClass.SaveChanges();
        }

       
        public void Delete(string id)
        {
            ClassManagement cls = contextClass.classes.Find(id);
            contextClass.classes.Remove(cls);
            contextClass.SaveChanges();
        }
    }


}
