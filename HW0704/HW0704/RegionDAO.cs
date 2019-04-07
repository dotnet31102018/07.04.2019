using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace HW0704
{
    class RegionDAO : IRegionDAO
    {
        static SQLiteConnection connection;
        public static string dbName = @"e:\sqlite\3.db";

        static RegionDAO()
        {
            connection = new SQLiteConnection($"Data Source = {dbName}; Version=3;");
            connection.Open();
        }
        public static void Close()
        {
            connection.Close();
        }

        public List<object> AllCountriesFromFirstLetter(string FirstLetter)
        {
            //SELECT * FROM table WHERE name = "%k"
            List<object> list = new List<object>();
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM COUNTRY JOIN CapitalCity ON COUNTRY.CAPITALCITY_ID = CapitalCity.ID WHERE COUNTRY.NAME Like '{FirstLetter}%'", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country CurrentCountry = new Country
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["NAME"],
                            Size_km = (int)reader["SIZE_KM"],
                            Birth_Year = (int)reader["BIRTH_YEAR"],
                            CapitalCityId = (int)reader["CAPITALCITY_ID"]
                        };

                        CapitalCity CurrentCity = new CapitalCity
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["NAME"],
                            NumCitizens = (int)reader["NUMCITIZENS"],
                            CountryId = (int)reader["COUNTRY_ID"]
                        };

                        var result = new
                        {
                            Country_Id = CurrentCountry.Id,
                            Country_Name = CurrentCountry.Name,
                            Capital_Name = CurrentCity.Name                            
                        };

                        list.Add(result);                        
                    }
                }
            }
            return list;
        }

        public object GetCountryAndItsCapitalCityDetails(int countryId)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT *, COUNTRY.NAME as COUNTRY_NAME, CAPITALCITY.NAME as CITY_NAME FROM COUNTRY JOIN CapitalCity ON COUNTRY.CAPITALCITY_ID = CapitalCity.ID WHERE COUNTRY.ID = {countryId}", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country CurrentCountry = new Country
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["COUNTRY_NAME"],
                            Size_km = (int)reader["SIZE_KM"],
                            Birth_Year = (int)reader["BIRTH_YEAR"],
                            CapitalCityId = (int)reader["CAPITALCITY_ID"]
                        };

                        CapitalCity CurrentCity = new CapitalCity
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["CITY_NAME"],
                            NumCitizens = (int)reader["NUMCITIZENS"],
                            CountryId = (int)reader["COUNTRY_ID"]
                        };

                        var result = new
                        {
                            Country_Id = CurrentCountry.Id,
                            Country_Name = CurrentCountry.Name,
                            Capital_Name = CurrentCity.Name,
                            Capital_Citizens = CurrentCity.NumCitizens,
                            Capital_Id = CurrentCountry.Id,
                        };
                        return result;
                    }
                }
            }
            return null;
        }

        public object GetCountryAndItsCapitalCityDetails(string countryName)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT *, COUNTRY.NAME as COUNTRY_NAME, CAPITALCITY.NAME as CITY_NAME FROM COUNTRY JOIN CapitalCity ON COUNTRY.CAPITALCITY_ID = CapitalCity.ID WHERE COUNTRY.NAME = '{countryName}'", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country CurrentCountry = new Country
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["COUNTRY_NAME"],
                            Size_km = (int)reader["SIZE_KM"],
                            Birth_Year = (int)reader["BIRTH_YEAR"],
                            CapitalCityId = (int)reader["CAPITALCITY_ID"]
                        };

                        CapitalCity CurrentCity = new CapitalCity
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["CITY_NAME"],
                            NumCitizens = (int)reader["NUMCITIZENS"],
                            CountryId = (int)reader["COUNTRY_ID"]
                        };

                        var result = new
                        {
                            Country_Id = CurrentCountry.Id,
                            Country_Name = CurrentCountry.Name,
                            Capital_Name = CurrentCity.Name,
                            Capital_NumCitizens = CurrentCity.NumCitizens,
                            Capital_Id = CurrentCity.CountryId
                        };
                        return result;
                    }
                }
            }
            return null;
        }

        public object GetCountryAndItsCapitalCityName(int countryId)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT *, COUNTRY.NAME as COUNTRY_NAME, CAPITALCITY.NAME as CITY_NAME FROM COUNTRY JOIN CapitalCity ON COUNTRY.CAPITALCITY_ID == CapitalCity.ID WHERE COUNTRY.ID == {countryId}", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country CurrentCountry = new Country
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["COUNTRY_NAME"],
                            Size_km = (int)reader["SIZE_KM"],
                            Birth_Year = (int)reader["BIRTH_YEAR"],
                            CapitalCityId = (int)reader["CAPITALCITY_ID"]
                        };

                        CapitalCity CurrentCity = new CapitalCity
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["CITY_NAME"],
                            NumCitizens = (int)reader["NUMCITIZENS"],
                            CountryId = (int)reader["COUNTRY_ID"]
                        };

                        var result = new
                        {
                            Country_Id = CurrentCountry.Id,
                            Country_Name = CurrentCountry.Name,
                            Capital_name = CurrentCity.Name
                        };
                        return result;
                    }
                }
            }
            return null;
        }

        public object GetCountryAndItsCapitalCityName(string countryName)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"SELECT *, COUNTRY.NAME as COUNTRY_NAME, CAPITALCITY.NAME as CITY_NAME FROM COUNTRY JOIN CapitalCity ON COUNTRY.CAPITALCITY_ID == CapitalCity.ID WHERE COUNTRY.NAME == '{countryName}'", connection))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Country CurrentCountry = new Country
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["COUNTRY_NAME"],
                            Size_km = (int)reader["SIZE_KM"],
                            Birth_Year = (int)reader["BIRTH_YEAR"],
                            CapitalCityId = (int)reader["CAPITALCITY_ID"]
                        };

                        CapitalCity CurrentCity = new CapitalCity
                        {
                            Id = (int)reader["ID"],
                            Name = (string)reader["CITY_NAME"],
                            NumCitizens = (int)reader["NUMCITIZENS"],
                            CountryId = (int)reader["COUNTRY_ID"]
                        };

                        var result = new
                        {
                            Country_Id = CurrentCountry.Id,
                            Country_Name = CurrentCountry.Name,
                            Capital_Name = CurrentCity.Name
                        };
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
