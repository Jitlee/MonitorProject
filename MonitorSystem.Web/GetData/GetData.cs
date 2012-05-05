using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class GetData
{
	// Change this connection string your need.
   // private const string connectionString = @"server=.;database=MonitorDemo2;uid=sa;pwd=sa";
    
	//private const string connectionString = @"Data Source=LOCALHOST;Initial Catalog=AdventureWorks;Integrated Security=True;";		
	[OperationContract]
	public DataSetData GetDataSetData(string ConnStr,string SQL, out CustomException ServiceError)
	{
		try
		{
            DataSet ds = GetDataSet(ConnStr,SQL);
            ServiceError = null;
            return DataSetData.FromDataSet(ds);
		}
		catch(Exception ex)
		{
			ServiceError = new CustomException(ex);		
		}
		return null;
	}

    //[OperationContract]
    //public bool Update(DataSetData d, out CustomException ServiceError)
    //{
    //    try
    //    {
    //        DataSet ds = DataSetData.ToDataSet(d);
    //        UpdataDataSet(ds);
    //        ServiceError = null;
    //        return true;
    //    }
    //    catch(Exception ex)
    //    {
    //        ServiceError = new CustomException(ex);	
    //    }
    //    return false;
    //}


    //private void UpdataDataSet(DataSet ds)
    //{
    //    try
    //    {
    //        //You need to Implement UpdataDataSet the way you want it. 
    //    }      
    //    catch (Exception e)
    //    {
    //        throw new Exception("Update DataSata Failed", e);
    //    }
    //}
   
	private DataSet GetDataSet(string connectionString,string SQL)
	{		        
		DataSet ds;
		SqlConnection Connection = new SqlConnection(connectionString);
		try
		{
			Connection.Open();
			SqlDataAdapter adapter = new SqlDataAdapter();
			adapter.SelectCommand = new SqlCommand(SQL);
			adapter.SelectCommand.Connection = Connection;			
			
			ds = new DataSet();         
			adapter.Fill(ds);
           
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
