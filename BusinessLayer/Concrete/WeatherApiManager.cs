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
    public class WeatherApiManager : IWeatherApiService
    {
        IWeatherApiDal _weatherApi;

        public WeatherApiManager(IWeatherApiDal weatherApi)
        {
            _weatherApi = weatherApi;
        }

        public void TAdd(WeatherApi t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(WeatherApi t)
        {
            throw new NotImplementedException();
        }

        public List<WeatherApi> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public WeatherApi TGetByID(int id)
        {
           return _weatherApi.GetByID(id);
        }

        public List<WeatherApi> TGetList()
        {
            return _weatherApi.GetList();
        }

        public void TUpdate(WeatherApi t)
        {
            throw new NotImplementedException();
        }
    }
}
