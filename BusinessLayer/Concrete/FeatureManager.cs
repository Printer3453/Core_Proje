using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    /* Business Layer (İş Katmanı) nedir?
     * Business Layer, uygulamanın iş mantığını ve kurallarını içeren katmandır.
     * Bu katman, veri erişim katmanı (Data Access Layer) ile kullanıcı arayüzü katmanı (UI Layer) arasında bir köprü görevi görür.
     * İş katmanı, veri işlemlerini yönetir, iş kurallarını uygular ve uygulamanın genel iş akışını kontrol eder.
     * Amaç, uygulamanın iş mantığını merkezi bir yerde tutarak kodun daha modüler, bakımı kolay ve yeniden kullanılabilir olmasını sağlamaktır.
     * İş katmanı, genellikle servisler (services) veya yöneticiler (managers) olarak adlandırılan sınıflar içerir.
     * Bu sınıflar, veri erişim katmanından gelen verileri işler ve kullanıcı arayüzüne sunar.
     * İş katmanı, uygulamanın iş kurallarını ve mantığını kapsüller, 
     * böylece veri erişim katmanı ve kullanıcı arayüzü katmanı bu kurallardan bağımsız hale gelir.
     
    public class FeatureManager : IFeatureService
    ile 
    public class FeatureManager : IgenericService<Feature>

    arasındaki fark nedir?

     * IFeatureService, genellikle belirli bir varlık (entity) veya işlevsellik için özel olarak tanımlanmış bir arayüzdür.
     * Bu arayüz, o varlıkla ilgili özel iş kurallarını ve işlemleri içerebilir.
     * Örneğin, IFeatureService, özelliklerle (features) ilgili özel işlemleri tanımlayabilir.
     * IgenericService<Feature> ise, daha genel bir arayüzdür ve genellikle CRUD (Create, Read, Update, Delete) işlemlerini kapsar.
     * Bu arayüz, herhangi bir varlık türü için kullanılabilir ve belirli bir varlığa özgü iş kurallarını içermez.
     * IgenericService<Feature>, Feature varlığı için temel veri işlemlerini sağlar, ancak özel iş mantığını içermez.
     * Kısacası, IFeatureService daha spesifik ve özelleştirilmiş iken, IgenericService<Feature> daha genel ve yeniden kullanılabilir bir yapıya sahiptir.
     */

    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;
        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }
        public void TAdd(Feature t)
        {
            _featureDal.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _featureDal.Delete(t);
        }

        public List<Feature> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public Feature TGetByID(int id)
        {
            return _featureDal.GetByID(id);
        }

        public List<Feature> TGetList()
        {
            return _featureDal.GetList();
        }

        public void TUpdate(Feature t)
        {
            _featureDal.Update(t);
        }
    }
}



