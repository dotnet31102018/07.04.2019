using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0704
{
    interface IRegionDAO
    {
        object GetCountryAndItsCapitalCityName(int countryId);
        object GetCountryAndItsCapitalCityDetails(int countryId);
        object GetCountryAndItsCapitalCityName(string countryName);
        object GetCountryAndItsCapitalCityDetails(string countryName);

        List<object> AllCountriesFromFirstLetter(string FirstLetter);
    }
}
