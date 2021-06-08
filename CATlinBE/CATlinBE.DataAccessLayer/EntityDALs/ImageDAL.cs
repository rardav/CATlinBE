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
    }
}
