using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Fall2015.Models;

namespace Fall2015.Repositories
{
    class CompetencyHeaderRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<CompetencyHeader> All
        {
            get { return db.CompetencyHeaders; }
        }

        public IQueryable<CompetencyHeader> AllIncluding(params Expression<Func<CompetencyHeader, object>>[] includeProperties)
        {
            IQueryable<CompetencyHeader> query = db.CompetencyHeaders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public List<CompetencyHeader> ToList()
        {
            return db.CompetencyHeaders.ToList();
        }

        public CompetencyHeader Find(int competencyHeaderId)
        {
            return db.CompetencyHeaders.Find(competencyHeaderId);
        }

        private void Save()
        {
            db.SaveChanges();
        }
        public void InsertOrUpdate(CompetencyHeader competencyHeader)
        {
            if (competencyHeader.CompetencyHeaderId == 0)
            {
                db.CompetencyHeaders.Add(competencyHeader);

            }
            else
            {
                db.Entry(competencyHeader).State = EntityState.Modified;


            }
            Save();

        }

        private void delete(int competencyHeaderId)
        {
            db.Entry(Find(competencyHeaderId)).State = EntityState.Deleted;
        }


    }
}

