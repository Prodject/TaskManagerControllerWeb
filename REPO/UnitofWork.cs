using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using DAL;
using DAL.DAL;

using System.Activities.Statements;

using REPO.Interfaces;
using System.Data;
using System.Transactions;
namespace REPO
{
    public class UnitOfWork : IOperations
    {
        private bool _disposed = false;
        private DBContextUsage context = new DAL.DBContextUsage();
        private SimpleRepo<Login> _LoginRepository;
        private SimpleRepo<Uygulamalar> _UygulamalarRepository;
        public SimpleRepo<Login> LoginRepository
        {
            get
            {
                if (_LoginRepository == null)
                {
                    _LoginRepository = new SimpleRepo<Login>(context);
                }
                return _LoginRepository;
            }
        }
        public SimpleRepo<Uygulamalar> UygulamalarRepositor
        {
            get
            {
                if (_UygulamalarRepository == null)
                {
                    _UygulamalarRepository = new SimpleRepo<Uygulamalar>(context);
                }
                return _UygulamalarRepository;
            }
        }
        public void Save()
        {
            using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
            {
                context.SaveChanges();
                scope.Complete();
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
