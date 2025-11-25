using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    /*
     Burada repository pattern kullanılarak,
        GenericRepository<T> sınıfı, IGenericDal<T> arayüzünü uygulayarak temel CRUD işlemlerini sağlar.
        Bu sınıf, herhangi bir varlık türü (T) için kullanılabilir ve veri erişim kodunu merkezi bir şekilde yönetir.
        Bu sayede, veri erişim kodu iş mantığından ayrılmış olur ve kodun daha temiz, test edilebilir ve sürdürülebilir olması sağlanır.

     */
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return c.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)
        {
           
            using var c = new Context();
            return c.Set<T>().Find(id);

        }

        public List<T> GetList()
        {
            using var c = new Context();
            return c.Set<T>().ToList();

        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();

        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();

        }
    }
}
