using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0704
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             CREATE TABLE COUNTRY(
            ID INT PRIMARY KEY NOT NULL,
            NAME TEXT NOT NULL,
            SIZE_KM INT,
            BIRTH_YEAR INT,
            CAPITALCITY_ID INT UNIQUE,
            FOREIGN KEY(CAPITALCITY_ID) REFERENCES CAPITALCITY(ID));

            CREATE TABLE CAPITALCITY(
            ID INT PRIMARY KEY NOT NULL,
            NAME TEXT NOT NULL,
            NUMCITIZENS INT,
            COUNTRY_ID INT UNIQUE,
            FOREIGN KEY(COUNTRY_ID) REFERENCES COUNTRY(ID));
            */

            IRegionDAO dao = new RegionDAO();
            var resultCCid = dao.GetCountryAndItsCapitalCityDetails(1);
            Console.WriteLine();

            var resultCCName = dao.GetCountryAndItsCapitalCityDetails("ISRAEL");
            Console.WriteLine();

            var resultCCidName = dao.GetCountryAndItsCapitalCityName(1);
            Console.WriteLine();

            var resultCCNameName = dao.GetCountryAndItsCapitalCityName("ISRAEL");
            Console.WriteLine();

            var res = dao.AllCountriesFromFirstLetter("I");
            Console.WriteLine();

        }
    }
}
