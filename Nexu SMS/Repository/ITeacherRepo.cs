namespace Nexu_SMS.Repository
{
    public interface ITeacherRepo<T>where T : class
    {
        void AddTeacher(T entity);
        void UpdateTeacher(T entity);
        void DeleteTeacher(string teacherId);
        T GetTeacherById(string teacherId);
        List<T> GetTeachers();
        List<T> GetTeachersByClass(string teacherClass);
        List<T> GetTeachersBySubject(string teacherSubject);
    }
}
