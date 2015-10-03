using Fall2015.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fall2015.Repositories
{
    public class CompetenciesRepository

        
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Competency> All
        {
            get { return db.Competencies; }
        }

        public IQueryable<Competency> AllIncluding(params Expression<Func<Competency, object>>[] includeProperties)
        {
            IQueryable<Competency> query = db.Competencies;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public List<Competency> ToList()
        {
            return db.Competencies.ToList();
        }

        public Competency Find(int competencyId)
        {
            return db.Competencies.Find(competencyId);
        }

        private void Save()
        {
            db.SaveChanges();
        }
        public void InsertOrUpdate(Competency competency)
        {
            if (competency.CompetencyId == 0)
            {
                db.Competencies.Add(competency);
                
            }
            else
            {
                db.Entry(competency).State = EntityState.Modified;
                

            }
            Save();

        }

        public void Delete(int id)
        {
            Competency competency = Find(id);
            db.Entry(competency).State = EntityState.Deleted;
            db.Entry(Find(id)).State = EntityState.Deleted;
            Save();
        }
             

    }


}
