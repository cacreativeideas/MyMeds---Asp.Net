using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dao
{
    internal class SqlServerDao : DataLayer.Dao.SqlServerDao
    {
        protected DbSet<Pessoa> DbSetPessoa { get; set; }
        protected DbSet<Endereco> DbSetEndereco { get; set; }
        protected DbSet<Medicamento> DbSetMedicamento { get; set; }
        protected DbSet<Tratamento> DbSetTratamento { get; set; }
        protected DbSet<ItemTratamento> DbSetItemTratamento { get; set; }

    }
}
