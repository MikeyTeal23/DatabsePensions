using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Mapper;
using PensionsConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionsConsoleApp
{
    public class ORMAccess
    {
        private readonly string connectionString =
      new SqlConnectionStringBuilder
      {
          DataSource = "localhost",
          IntegratedSecurity = true,
          InitialCatalog = "Pensions"
      }.ConnectionString;

        public IEnumerable<PensionFund> GetAllPensions()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<PensionFund, Employee, JobPosition>("SELECT * FROM PensionFunds " +
                    "JOIN Employees ON Employees.Id = PensionFunds.EmployeeNo " +
                    "JOIN JobPositions ON Employees.JobPositionNo = JobPositions.Id");
            }
        }

        public void UpdatePension(PensionFund fund)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Update<PensionFund>(fund);
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Employee>("SELECT * FROM Employees");
            }
        }

    }
}
