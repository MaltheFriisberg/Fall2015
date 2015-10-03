using Fall2015.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Fall2015.Repositories
{
    public interface IStudentsRepository
    {
        IQueryable<Student> All { get; }
        IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties);
        Student Find(int id);
        void InsertOrUpdate(Student student);
        void Delete(int id);
        List<Student> ToList();
        void Save();
    }

    public class StudentsRepository : IStudentsRepository
    {
        private ApplicationDbContext db =
            new ApplicationDbContext();

        public IQueryable<Student> All
        {
            get { return db.Students; }
        }

        public IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties)
        {
            IQueryable<Student> query = db.Students;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Student Find(int id)
        {
            return db.Students.Find(id);
        }

        public void InsertOrUpdate(Student student)
        {
            if (student.StudentId == 0) //new : if no primary key is defined for the object
            {
                db.Students.Add(student);
                
                
            }
            else //edit
            {

                //student.SaveImage(image, Server.MapPath("~"), "/ProfileImages/");
                db.Entry(student).State = EntityState.Modified;
                
            }
            Save();
        }

        public void Delete(int id)
        {
            //Student student = db.Students.Find(id);
            db.Entry(Find(id)).State = EntityState.Deleted;
            Save();

        }

        public List<Student> ToList()
        {
            return db.Students.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }


    }
}