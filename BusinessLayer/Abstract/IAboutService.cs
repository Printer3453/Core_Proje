using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        //IGenericService'den miras alır ve aşağıdakileri artık ayrı ayrı tanımlamaya gerek yok
        //void TAdd(About t);
        //void TDelete(About t);
        //void TUpdate(About t);
        //List<About> TGetList();
        //About TGetByID(int id);
    }
}
