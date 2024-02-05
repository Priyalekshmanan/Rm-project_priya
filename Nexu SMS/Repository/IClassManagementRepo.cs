using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public interface IClassManagementRepo<T> where T : class
    {
        List<T> GetClasses();
        T GetClassById(int id);
  
        void AssignTeacher(int id, string teacher);
   
        void UpdateClass(T updatedModel);
   
        void DeleteClass(int id);
    }
}
