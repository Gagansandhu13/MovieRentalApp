using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;


namespace MovieRentalApp
{
     public class database
    {


        //CreateConnectionandCommand,andanAdapter.
        private SqlConnection Connection = new SqlConnection();
        private SqlCommand Command = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();
        public string connectionString;

        //THECONSTRUCTORSETSTHEDEFAULTSUPONLOADINGTHECLASS
        public database()
        {
            //changetheconnectionstringtorunfromyourownmusicdb
           connectionString = @"Data Source=LAPTOP-RSH35OIC\sqlexpress;Initial Catalog=MovieRental;Integrated Security=True";
            Connection.ConnectionString = connectionString;
            Command.Connection = Connection;
          
            
        }
        public DataTable Customer()
        {
            //createadatatableasweonlyhaveonetable,theOwner
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from Customer ", Connection))
            {
                //connectintotheDBandgettheSQL
                Connection.Open();
                //openaconnectiontotheDB
                da.Fill(dt);

                //fillthedatatablefromtheSQL
                Connection.Close();  //closetheconnection
            }
            return dt; //passthedatatabledatatotheDataGridView

        }

        public DataTable MovieRental()
        {
            //createadatatableasweonlyhaveonetable,theOwner
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from MovieRental ", Connection))
            {
                //connectintotheDBandgettheSQL
                Connection.Open();
                //openaconnectiontotheDB
                da.Fill(dt);

                //fillthedatatablefromtheSQL

                Connection.Close();  //closetheconnection
            }
            return dt; //passthedatatabledatatotheDataGridView

        }
        public DataTable Movies()
        {
            //createadatatableasweonlyhaveonetable,theOwner
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from Movies ", Connection))
            {
                //connectintotheDBandgettheSQL
                Connection.Open();
                //openaconnectiontotheDB
                da.Fill(dt);

                //fillthedatatablefromtheSQL
                Connection.Close();  //closetheconnection
            }
            return dt; //passthedatatabledatatotheDataGridView

        }

        public DataTable GetTable(string columns, string tablename)
        {

            //createadatatableasweonlyhaveonetable,theOwner
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("SELECT" + columns + "FROM" + tablename, Connection))
            {
                //connectintotheDBandgettheSQL
                Connection.Open();
                //openaconnectiontotheDB    
                da.Fill(dt);

                //fillthedatatablefromtheSQL
                Connection.Close();  //closetheconnection
            }
            return dt; //passthedatatabledatatotheDataGridView

        }


    }

    }

                        