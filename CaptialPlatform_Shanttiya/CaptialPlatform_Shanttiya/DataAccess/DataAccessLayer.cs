using CaptialPlatform_Shanttiya.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CaptialPlatform_Shanttiya.DataAccess
{
    public class DataAccessLayer
    {

        public string InsertData(Account objAcct)

        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("CRUD_FUNCTIONS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", objAcct.AccountNumber);
                cmd.Parameters.AddWithValue("@AccountHolder", objAcct.AccountHolder);
                cmd.Parameters.AddWithValue("@CurrentBalance", objAcct.CurrentBalance);
                cmd.Parameters.AddWithValue("@BankName", objAcct.BankName);
                cmd.Parameters.AddWithValue("@OpeningDate", objAcct.OpeningDate);
                cmd.Parameters.AddWithValue("@IsActive", objAcct.IsActive);
                cmd.Parameters.AddWithValue("@Function", "INSERT");

                con.Open();

                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }

        }
        public string UpdateData(Account objAcct)

        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("CRUD_FUNCTIONS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", objAcct.AccountNumber);
                cmd.Parameters.AddWithValue("@AccountHolder", objAcct.AccountHolder);
                cmd.Parameters.AddWithValue("@CurrentBalance", objAcct.CurrentBalance);
                cmd.Parameters.AddWithValue("@BankName", objAcct.BankName);
                cmd.Parameters.AddWithValue("@OpeningDate", objAcct.OpeningDate);
                cmd.Parameters.AddWithValue("@IsActive", objAcct.IsActive);
                cmd.Parameters.AddWithValue("@Function", "UPDATE");
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }

        }
        public string DeleteData(Account objAcct)

        {
            SqlConnection con = null;
            string result = "";
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("CRUD_FUNCTIONS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", objAcct.AccountNumber);
                cmd.Parameters.AddWithValue("@AccountHolder", "");
                cmd.Parameters.AddWithValue("@CurrentBalance", "");
                cmd.Parameters.AddWithValue("@BankName", "");
                cmd.Parameters.AddWithValue("@OpeningDate", "");
                cmd.Parameters.AddWithValue("@IsActive", "");
                cmd.Parameters.AddWithValue("@Function", "DELETE");
                con.Open();
                result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch
            {
                return result = "";
            }
            finally
            {
                con.Close();
            }

        }
        public List<Account> Selectalldata()

        {

            SqlConnection con = null;
            DataSet ds = null;
            List<Account> Acctlist = null;
            try

            {

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("CRUD_FUNCTIONS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", "");
                cmd.Parameters.AddWithValue("@AccountHolder", "");
                cmd.Parameters.AddWithValue("@CurrentBalance", "");
                cmd.Parameters.AddWithValue("@BankName", "");
                cmd.Parameters.AddWithValue("@OpeningDate", "");
                cmd.Parameters.AddWithValue("@IsActive", "");
                cmd.Parameters.AddWithValue("@Function", "SELECT");

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);

                Acctlist = new List<Account>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)

                {

                    Account cobj = new Account();
                    cobj.AccountNumber = ds.Tables[0].Rows[i]["AccountNumber"].ToString();
                    cobj.AccountHolder = ds.Tables[0].Rows[i]["AccountHolder"].ToString();
                    cobj.CurrentBalance = Convert.ToDecimal(ds.Tables[0].Rows[i]["CurrentBalance"].ToString());
                    cobj.BankName = ds.Tables[0].Rows[i]["BankName"].ToString();
                    cobj.OpeningDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["OpeningDate"].ToString());
                    cobj.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"].ToString());

                    Acctlist.Add(cobj);
                }
                return Acctlist;
            }
            catch
            {
                return Acctlist;
            }

            finally
            {
                con.Close();
            }
        }
        public Account SelectDatabyAccNumber(string AccountNumber)

        {
            SqlConnection con = null;
            DataSet ds = null;
            Account cobj = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
                SqlCommand cmd = new SqlCommand("CRUD_FUNCTIONS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                cmd.Parameters.AddWithValue("@AccountHolder", "");
                cmd.Parameters.AddWithValue("@CurrentBalance", "");
                cmd.Parameters.AddWithValue("@BankName", "");
                cmd.Parameters.AddWithValue("@OpeningDate", "");
                cmd.Parameters.AddWithValue("@IsActive", "");
                cmd.Parameters.AddWithValue("@Function", "SELECTBYID");

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)

                {
                    cobj = new Account();
                    cobj.AccountNumber = ds.Tables[0].Rows[i]["AccountNumber"].ToString();
                    cobj.AccountHolder = ds.Tables[0].Rows[i]["AccountHolder"].ToString();
                    cobj.CurrentBalance = Convert.ToDecimal(ds.Tables[0].Rows[i]["CurrentBalance"].ToString());
                    cobj.BankName = ds.Tables[0].Rows[i]["BankName"].ToString();
                    cobj.OpeningDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["OpeningDate"].ToString());
                    cobj.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[i]["IsActive"].ToString());
                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }

        }

    }
}