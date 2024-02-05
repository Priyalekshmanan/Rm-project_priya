using Microsoft.EntityFrameworkCore;
using Nexu_SMS.Entity;

namespace Nexu_SMS.Repository
{
    public class TeacherRepo:ITeacherRepo<Teacher>
    {
        private readonly ContextClass _context;
        public TeacherRepo(ContextClass context)
        {
            _context = context;
        }
        public void AddTeacher(Teacher entity)
        {
            try
            {
                _context.teachers.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteTeacher(string teacherId)
        {
            try
            {
                Teacher teacher = _context.teachers.Find(teacherId);
                _context.teachers.Remove(teacher);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Teacher GetTeacherById(string teacherId)
        {
            try
            {
                return _context.teachers.Find(teacherId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Teacher> GetTeachers()
        {
            try
            {
                return _context.teachers.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Teacher> GetTeachersByClass(string teacherClass)
        {
            try
            {
                return _context.teachers.Where(x => x.teacherClass == teacherClass).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Teacher> GetTeachersBySubject(string teacherSubject)
        {
            try
            {
                return _context.teachers.Where(x => x.teacherSubjectTaught == teacherSubject).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateTeacher(Teacher entity)
        {
            try
            {
                _context.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
