using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IH07_Country_ReChildDal"/>
    /// </summary>
    public partial class H07_Country_ReChildDal : IH07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a H07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The Country ID2.</param>
        /// <returns>A data reader to the H07_Country_ReChild.</returns>
        public IDataReader Fetch(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetH07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new H07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        public void Insert(int country_ID2, string country_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddH07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the H07_Country_ReChild object.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        public void Update(int country_ID2, string country_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateH07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("H07_Country_ReChild");
                }
            }
        }

        /// <summary>
        /// Deletes the H07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        public void Delete(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteH07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
