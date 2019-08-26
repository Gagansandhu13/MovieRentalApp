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
    public partial class Form1 : Form
    {
        int customerID, movieID, RMID ;
        //createaninstanceoftheDatabaseclass
        database myDatabase = new database();
        SqlConnection Connection = new SqlConnection(@"Data Source=LAPTOP-RSH35OIC\SQLEXPRESS;Initial Catalog=MovieRental;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();

            loadDB();
        }
        public void loadDB()
        {//loadtheownerdgvDisplayDataGridViewOwner();}
         //LOADTHEOWNERDATAGRIDprivatevoidDisplayDataGridViewOwner()
            {//clearouttheolddataDGVOwner.DataSource=null;
                try
                {
                    dgv1.DataSource = myDatabase.Customer();
                    dgv2.DataSource = myDatabase.MovieRental();
                    dgv3.DataSource = myDatabase.Movies();
                    //passthedatatabledatatotheDataGridView
                    dgv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {
                    //showthedataintheDGVinthetextboxes
                    string newvalue = dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //showtheoutputontheheader
                    this.Text = "Row:" + e.RowIndex.ToString() + "Col:" +
                    e.ColumnIndex.ToString() + "Value=" + newvalue;
                    //passdatatothetextboxes

                    txtCustID.Text = dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtFN.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtLN.Text = dgv1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtAddress.Text = dgv1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtPhone.Text = dgv1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    customerID = Convert.ToInt32(txtCustID);
                }
                catch { }
            }
        }



        private void UpdateCustomer(object sender, EventArgs e)
        {

            //thisupdatesexistingdatainthedatabasewheretheIDofthedataequalstheIDinthetextbox
            string updatestatement = "Update Customer set FirstName=@FirstName,LastName=@LastName,Address=@Address,Phone=@Phone where CustID = @CustID ";
            SqlCommand update = new SqlCommand(updatestatement, Connection);
            update.Parameters.Clear();
            //createtheparametersandpassthedatafromthetextboxes
            Connection.Open();
            update.Parameters.AddWithValue("@CustID", txtCustID.Text);
            update.Parameters.AddWithValue("@FirstName", txtFN.Text);
            update.Parameters.AddWithValue("@LastName", txtLN.Text);
            update.Parameters.AddWithValue("@Address", txtAddress.Text);
            update.Parameters.AddWithValue("@Phone", txtPhone.Text);

            update.Connection = Connection;

            //itsNONQueryasdataisonlygoingup
            update.ExecuteNonQuery();
            Connection.Close();
            loadDB();
            update.Parameters.Clear();

        }

        private void DeleteCustomer(object sender, EventArgs e)
        {
            {
                string DeleteCommand = "Delete Customer where CustID = @CustID";
                SqlCommand DeleteData = new SqlCommand(DeleteCommand, Connection);
                DeleteData.Parameters.AddWithValue("@CustID", txtCustID.Text);
                Connection.Open();

                DeleteData.ExecuteNonQuery();
                Connection.Close();
                loadDB();
            }
        }

        



        private void Dgv3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            {
                try
                {
                    //showthedataintheDGVinthetextboxes
                    string newvalue = dgv3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    //showtheoutputontheheader
                    this.Text = "Row:" + e.RowIndex.ToString() + "Col:" +
                    e.ColumnIndex.ToString() + "Value=" + newvalue;
                    //passdatatothetextboxes
                    txtMovieID.Text = dgv3.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtRating.Text = dgv3.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtTitle.Text = dgv3.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtYear.Text = dgv3.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtRental_Cost.Text = dgv3.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtCopies.Text = dgv3.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtPlot.Text = dgv3.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtGenre.Text = dgv3.Rows[e.RowIndex].Cells[4].Value.ToString();
                    movieID = Convert.ToInt32(txtMovieID);
                }
                catch { }
            }
        }

    
      

      

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'movieRentalDataSet5.MovieRental' table. You can move, or remove it, as needed.
            this.movieRentalTableAdapter1.Fill(this.movieRentalDataSet5.MovieRental);

        }

       

        public string addCust(string name, string last, string address, string phone)
        {
            string NewEntry = "INSERT INTO Customer(FirstName, LastName, Address, Phone) VALUES(@FirstName, @LastName, @Address, @Phone)";
            using (SqlCommand update = new SqlCommand(NewEntry, Connection))
            {

                update.Parameters.AddWithValue("@FirstName", name);
                update.Parameters.AddWithValue("@LastName", last);
                update.Parameters.AddWithValue("@Address", address);
                update.Parameters.AddWithValue("@Phone", phone);

                Connection.Open();
                //openaconnectiontothedatabase//itsaNONQueryasitdoesn'treturnanydataitsonlygoinguptotheserver
                update.ExecuteNonQuery();
                //RuntheQuery
                Connection.Close();
                //Close aconnectiontothedatabase//ahappymessagebox
                return "Data has been Inserted!!";
            }
        }
        private void IssueMovie_Click(object sender, EventArgs e)
        {
            {
                string rentdate = DateTime.Now.ToString();
                MessageBox.Show(rentdate);
                lblrentdate.Text = rentdate;
                //lblfirstname.Text = txtFN.Text;

                string Issue = "insert into MovieRental  (FirstName,LastName,Title,DateRented,DateReturned) values(@FirstName,@LastName,@Title,@DateRented,@DateReturned)";
                SqlCommand Issuedata = new SqlCommand(Issue, Connection);
                Issuedata.Parameters.AddWithValue("@FirstName", txtFN.Text);
                Issuedata.Parameters.AddWithValue("@LastName", txtLN.Text);
                Issuedata.Parameters.AddWithValue("@Title", txtTitle.Text);
                //Issuedata.Parameters.AddWithValue("@MovieID", txtMovieID.Text);
                //Issuedata.Parameters.AddWithValue("@CustID", txtCustID.Text);
                Issuedata.Parameters.AddWithValue("@DateRented", lblrentdate.Text);
                Issuedata.Parameters.AddWithValue("@DateReturned", "");

                Connection.Open();

                Issuedata.ExecuteNonQuery();
                Connection.Close();
                loadDB();
            }
        }


        private void AddMovie(object sender, EventArgs e)
        {
            {
                string NewEntry = "INSERT INTO Movies(MovieID, Rating, Title, Year,Rental_Cost, Copies, Plot, Genre) VALUES(@MovieID, @Rating, @Title, @Year, @Rental_Cost, @Copies, @Plot, @Genre)";
                using (SqlCommand update = new SqlCommand(NewEntry, Connection))
                {

                    update.Parameters.AddWithValue("@MovieID", txtMovieID.Text);
                    update.Parameters.AddWithValue("@Rating", txtRating.Text);
                    update.Parameters.AddWithValue("@Title", txtTitle.Text);
                    update.Parameters.AddWithValue("@Year", txtYear.Text);
                    update.Parameters.AddWithValue("@Rental_Cost", txtRental_Cost.Text);
                    update.Parameters.AddWithValue("@Copies", txtCopies.Text);
                    update.Parameters.AddWithValue("@Plot", txtPlot.Text);
                    update.Parameters.AddWithValue("@Genre", txtGenre.Text);

                    Connection.Open();
                    //openaconnectiontothedatabase//itsaNONQueryasitdoesn'treturnanydataitsonlygoinguptotheserver
                    update.ExecuteNonQuery();
                    //RuntheQuery
                    Connection.Close();
                    //Close aconnectiontothedatabase//ahappymessagebox
                    MessageBox.Show("Data has been Inserted!!");
                }
                //RuntheLoadDatabasemethodwemadeearlertoseethenewdata.
                loadDB();
            }
        }

        private void DeleteMovie(object sender, EventArgs e)
        {
            string DeleteCommand = "Delete Movies where MovieID = @MovieID";
            SqlCommand DeleteData = new SqlCommand(DeleteCommand, Connection);
            DeleteData.Parameters.AddWithValue("@MovieID", txtMovieID.Text);
            Connection.Open();

            DeleteData.ExecuteNonQuery();
            Connection.Close();
            loadDB();

        }

        private void Dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //passdatatothetextboxes
            RMID = Convert.ToInt32(dgv2.Rows[e.RowIndex].Cells[0].Value);
        }

        private void Return(object sender, EventArgs e)
        {
            string returndate = DateTime.Now.ToString();
            lblreturndate.Text = returndate;
            MessageBox.Show(returndate);

            string Return = "Update MovieRental set DateReturned = @DateReturned where RMID =@RMID";
            SqlCommand Returndata = new SqlCommand(Return, Connection);

            Returndata.Parameters.AddWithValue("@DateReturned", lblreturndate.Text);
            Returndata.Parameters.AddWithValue("@RMID", RMID);

            Connection.Open();

            Returndata.ExecuteNonQuery();
            Connection.Close();
            loadDB();
        }




    }
}