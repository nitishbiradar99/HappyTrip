using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HappyTrip.Data.Repository;
using System.Data.Entity;
using System.Data;
using HappyTrip.Models;

namespace HappyTrip.Data.EFRepository
{
    internal class GenericEFRepository<TObject> : IRepository<TObject> where TObject : class
    {
        protected DbContext _context = null;
        protected DbSet<TObject> _entitySet = null;

        public GenericEFRepository()
        {
            //this._context = new HappyTripDBEntity();
            this._context = new HappyTripDBCon();
            this._entitySet = this._context.Set<TObject>();
        }

        public GenericEFRepository(DbContext Context)
        {
            this._context = Context;
            this._entitySet = Context.Set<TObject>();
        }

        protected DbSet<TObject> DbSet
        {
            get
            { return _entitySet; }
        }

        public virtual IEnumerable<TObject> All()
        {
            return DbSet.AsEnumerable<TObject>();
        }

        public virtual IEnumerable<TObject> Get(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate).AsEnumerable<TObject>();
        }

        public virtual IEnumerable<TObject> Get(Expression<Func<TObject, bool>> predicate, string includeProperties = "")
        {
            IQueryable<TObject> query = DbSet;
            query = query.Where(predicate);
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            { query = query.Include(includeProperty); }
            return query.ToList();
        }

        public virtual TObject Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual TObject Find(Expression<Func<TObject, bool>> predicate, string includeProperties = "")
        {
            IQueryable<TObject> query = DbSet;
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            { query = query.Include(includeProperty); }
            return query.FirstOrDefault(predicate);
        }

        public virtual TObject Create(TObject entry)
        {
            DbSet.Attach(entry);
            var newEntry = DbSet.Add(entry);
            SaveChanges();
            return newEntry;
        }

        public virtual void Update(TObject entry)
        {
            DbSet.Attach(entry);
            _context.Entry(entry).State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Delete(object id)
        {
            TObject entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TObject entry)
        {
            if (_context.Entry(entry).State == EntityState.Detached)
            {
                DbSet.Attach(entry);
            }
            DbSet.Remove(entry);
            SaveChanges();
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
