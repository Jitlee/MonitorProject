using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Hosting;
namespace MonitorSystem.Web.Servers
{

    [ServiceContract(Namespace = "")]
    [EnableClientAccess()]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GetData
    {
        // Change this connection string your need.
        private const string connectionString = @"Data Source=LOCALHOST;Initial Catalog=Northwind;Integrated Security=True;";

        //private const string connectionString = @"Data Source=LOCALHOST;Initial Catalog=AdventureWorks;Integrated Security=True;";		
        [OperationContract]
        public DataSetData GetDataSetData(string SQL, int PageNumber, int PageSize, out CustomException ServiceError)
        {
            try
            {
                DataSet ds = GetDataSet(SQL, PageNumber, PageSize);
                ServiceError = null;
                return DataSetData.FromDataSet(ds);
            }
            catch (Exception ex)
            {
                ServiceError = new CustomException(ex);
            }
            return null;
        }

        [OperationContract]
        public bool Update(DataSetData d, out CustomException ServiceError)
        {
            try
            {
                DataSet ds = DataSetData.ToDataSet(d);
                UpdataDataSet(ds);
                ServiceError = null;
                return true;
            }
            catch (Exception ex)
            {
                ServiceError = new CustomException(ex);
            }
            return false;
        }


        private void UpdataDataSet(DataSet ds)
        {
            try
            {
                //You need to Implement UpdataDataSet the way you want it. 
            }
            catch (Exception e)
            {
                throw new Exception("Update DataSata Failed", e);
            }
        }

        private DataSet GetDataSet(string SQL, int PageNumber, int PageSize)
        {
            DataSet ds;
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(SQL);
                adapter.SelectCommand.Connection = Connection;
                if (PageSize > 0)// Set rowcount =PageNumber * PageSize for best performance
                {
                    long RowCount = PageNumber * PageSize;
                    SqlCommand cmd = new SqlCommand("SET ROWCOUNT " + RowCount.ToString() + " SET NO_BROWSETABLE ON", (SqlConnection)Connection);
                    cmd.ExecuteNonQuery();
                }
                ds = new DataSet();
                adapter.Fill(ds, (PageNumber - 1) * PageSize, PageSize, "Data");
                adapter.FillSchema(ds, SchemaType.Mapped, "DataSchema");
                if (PageSize > 0) // Reset Rowcount back to 0
                {
                    SqlCommand cmd = new SqlCommand("SET ROWCOUNT 0 SET NO_BROWSETABLE OFF", (SqlConnection)Connection);
                    cmd.ExecuteNonQuery();
                }
                if (ds.Tables.Count > 1)
                {
                    DataTable data = ds.Tables["Data"];
                    DataTable schema = ds.Tables["DataSchema"];
                    data.Merge(schema);
                    ds.Tables.Remove(schema);
                }
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                Connection.Close();
            }
            return ds;
        }
    }
}