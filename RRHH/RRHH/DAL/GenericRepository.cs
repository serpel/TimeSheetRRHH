﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RRHH.Models;
using System.Data.Entity;

namespace RRHH.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private TimeSheetContext context;
        private DbSet<T> table;

        public GenericRepository():this(new TimeSheetContext()){ }

        public GenericRepository(TimeSheetContext context)
        {
            this.table = context.Set<T>();
            this.context = context;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public DbSet<T> GetDbSet()
        {
            return table;
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public T SelectById(object id)
        {
            return table.Find(id);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}