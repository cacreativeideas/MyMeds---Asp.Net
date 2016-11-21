using BusinessLayer.Dao;

namespace BusinessLayer.BO
{
    internal class BaseBO
    {
        
        protected SqlServerDao Dao { get; set; }

        protected BaseBO(SqlServerDao dao)
        {
            Dao = dao;
        }
        
    }
}
