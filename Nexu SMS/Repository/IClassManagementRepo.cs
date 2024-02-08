using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public interface IClassManagementRepo<T> where T : class
    {
        List<T> GetClasses();
        T GetClassById(string id);
  
        void AssignTeacher(string id, string teacher);
   
        void UpdateClass(T updatedModel);
   
        void DeleteClass(string id);
    }
}
