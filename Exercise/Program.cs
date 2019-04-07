using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise0704
{
    class Program
    {
        static List<object> GetEmployeesAdnDepartment()
        {

            string dbName = @"c:\itay\0407.db";

            List<object> results = new List<object>();
            using (var connection = new SQLiteConnection($"Data Source = {dbName}; Version=3;"))
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT E.ID, E.NAME AS EMP_NAME, D.NAME AS DEP_NAME FROM EMPLOYEE E JOIN DEPARTMENT D ON E.DEPARTMENT_ID=D.ID", 
                    connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new
                            {
                                Employee_Id = (Int64)reader["ID"],
                                Employee_Name = (string)reader["EMP_NAME"],
                                Department_Name = (string)reader["DEP_NAME"],
                            };
                            results.Add(obj);
                        }
                    }
                }
            }
            return results;

        }
        static void Main(string[] args)
        {
            var employees = GetEmployeesAdnDepartment();

            // Etgar - how to read anonymous object?
            // answer: dynamic
            foreach (var e in employees)
            {
                var eId = ((dynamic)e).Employee_Id;
                var eName = ((dynamic)e).Employee_Name;
                var eDepName = ((dynamic)e).Department_Name;

                Console.WriteLine($"{eId} {eName} {eDepName}");
            }
            Console.WriteLine();
        }
    }
}
