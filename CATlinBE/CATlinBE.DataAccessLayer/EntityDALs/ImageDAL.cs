using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class ImageDAL : BaseDAL, IImageDAL
    {
        public Image GetImageById(long id)
        {
            var SQL = "SELECT * FROM Images WHERE Id = @id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var image = new Image();
            while (reader.Read())
            {
                image.Id = Convert.ToInt64(reader["Id"].ToString());
                image.Url = reader["Url"].ToString();
                image.PublicId = reader["PublicId"].ToString();
            }

            return image;
        }

        public void InsertImage(Image image)
        {
            var SQL = "INSERT INTO Images (Url, PublicId) VALUES (@Url, @PublicId)";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = image.Url;
            sqlCmd.Parameters.Add("@PublicId", SqlDbType.NVarChar).Value = image.PublicId;

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public long GetIdByUrl(string url)
        {
            var SQL = "SELECT Id FROM Images WHERE PublicId = @url";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("url", SqlDbType.VarChar).Value = url;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            long id = 0;
            while (reader.Read())
            {
                id = Convert.ToInt64(reader["Id"].ToString());
            }

            sqlConn.Close();
            return id;
        }
    }
}
