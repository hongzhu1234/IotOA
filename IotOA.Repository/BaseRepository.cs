using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IotOA.Repository
{
    public class BaseRepository<T> where T:class, new()
    {
        //实例化数据库上下文类
        OAContext db = new OAContext();

        public T Get(Expression<Func<T,bool>> lambam)
        {
            return db.Set<T>().Where(lambam).FirstOrDefault();
        }

        public int Add(T t)
        {
            db.Set<T>().Add(t);

            return db.SaveChanges();
        }
    }
}
