using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IAboutDal: IGenericDal<About>
    {
        /*
         Artık IGenaricDal'dan miras aldığımız için bu metotlara gerek yok.

        void Insert(About a);
        void Update(About a);
        void Delete(About a);
        List<About> GetListAll();
        About GetByID(int id);

        */


    }
}
