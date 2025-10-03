using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IContactDal: IGenericDal<Contact>
    {
        /*
         Artık IGenaricDal'dan miras aldığımız için bu metotlara gerek yok.

        void Insert(Contact c);
        void Update(Contact c);
        void Delete(Contact c);
        List<Contact> GetListAll();
        Contact GetByID(int id);

        
        */
    }
}
