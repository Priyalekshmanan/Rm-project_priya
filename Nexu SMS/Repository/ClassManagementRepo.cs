using Nexu_SMS.Entity;
using System.Linq;

namespace Nexu_SMS.Repository
{
    public class ClassManagementRepo : IClassManagementRepo<ClassModel>
    {
        public readonly ContextClass contextClass;
        public ClassManagementRepo(ContextClass contextClass)
        {

            this.contextClass = contextClass;
        }
    

        public void AssignTeacher(int id, string teacher)
        {
            {
                {
                    ClassModel model = contextClass.classModels.FirstOrDefault(c => c.ClassId == id);
                    if (model != null)
                    {
                        model.Teacherid = teacher;
                        contextClass.SaveChanges();
                    }
                }
            }
        }

 
    

        public void DeleteClass(int id)
        {
            {
                ClassModel model = contextClass.classModels.FirstOrDefault(c => c.ClassId == id);
                if (model != null)
                {
                    contextClass.classModels.Remove(model);
                }
            }
        }

        public ClassModel GetClassById(int id)
        {
            return contextClass.classModels.FirstOrDefault(c => c.ClassId == id);
        }

        public List<ClassModel> GetClasses()
        {
            return contextClass.classModels.ToList();
        }

 

        public void UpdateClass(ClassModel updatedModel)
        {
            {
                ClassModel model = contextClass.classModels.FirstOrDefault(c => c.ClassId == updatedModel.ClassId);
                if (model != null)
                {
                    model.ClassName = updatedModel.ClassName;
                    model.Schedule = updatedModel.Schedule;
                }

            }
        }
    }


}
