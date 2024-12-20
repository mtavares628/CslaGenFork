using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadRO.DataAccess;
using SelfLoadRO.DataAccess.ERLevel;

namespace SelfLoadRO.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IC11_CityRoadCollDal"/>
    /// </summary>
    public partial class C11_CityRoadCollDal : IC11_CityRoadCollDal
    {
        /// <summary>
        /// Loads a C11_CityRoadColl collection from the database.
        /// </summary>
        /// <param name="parent_City_ID">The Parent City ID.</param>
        /// <returns>A data reader to the C11_CityRoadColl.</returns>
        public IDataReader Fetch(int parent_City_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetC11_CityRoadColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", parent_City_ID).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }
    }
}
