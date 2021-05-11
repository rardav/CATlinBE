using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class InstitutionDAL : BaseDAL, IInstitutionDAL
    {
        public List<Institution> GetAllInstitutions()
        {
            var institutions = new List<Institution>();
            var SQL = "SELECT * FROM Institutions";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();

            while(reader.Read())
            {
                var institution = new Institution
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                };
                institutions.Add(institution);
            }

            return institutions;
        }

        public void InsertInstitution(string institutionName)
        {
            var SQL = "INSERT INTO Institutions VALUES (@Name)";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = institutionName;

            sqlCmd.ExecuteNonQuery();
        }
    }
}
