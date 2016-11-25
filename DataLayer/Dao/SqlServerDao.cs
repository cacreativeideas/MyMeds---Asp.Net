using DataLayer.Migrations;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dao
{
    public abstract class SqlServerDao : DbContext
    {

        #region Construtores

        public SqlServerDao() : base("MyMeds")
        { }

        static SqlServerDao()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SqlServerDao, Configuration>());
        }

        #endregion
        
        public List<TBase> ListarTodos<TBase>() where TBase : Base
        {
            return Set<TBase>().ToList();
        }

        public List<TBase> Buscar<TBase>(Expression<Func<TBase, bool>> where) where TBase : Base
        {
            return Set<TBase>().Where(where).ToList();
        }

        public TBase BuscarPorId<TBase>(int id) where TBase : Base
        {
            return Set<TBase>().FirstOrDefault(e => e.Id == id);
        }

        public void Inserir<TBase>(TBase obj) where TBase : Base
        {
            obj.DataCriacao = DateTime.Now;
            obj.DataAtualizacao = DateTime.Now;
            Set<TBase>().Add(obj);
            //SaveChanges();
        }

        public List<TBase> BuscarComPaginacao<TBase>(Expression<Func<TBase, bool>> where, int take, int skip) where TBase : Base
        {
            return Set<TBase>()
                .Where(where)
                .OrderBy(o => o.Id)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public void Atualizar<TBase>(TBase obj) where TBase : Base
        {
            obj.DataAtualizacao = DateTime.Now;
            //SaveChanges();
        }

        public void Excluir<TBase>(TBase obj) where TBase : Base
        {
            Set<TBase>().Remove(obj);
            //SaveChanges();
        }

        public void Excluir<TBase>(Expression<Func<TBase, bool>> where) where TBase : Base
        {
            var lista = Set<TBase>().Where(where).ToList();
            Set<TBase>().RemoveRange(lista);
            //SaveChanges();
        }
    }
}
