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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        //Accessing DatabaseAccess class
        DatabaseAccess dbAccess = new DatabaseAccess();
        DataTable dataT = new DataTable();

        public Form2()
        {
            InitializeComponent();
        }
        public void refreshSurveyData()
        {
            //Getting all the information from the database and do calculations

            //Counting number of rows using data adapter
            string queryId = "Select Id from SurveyInfo";
            dbAccess.readDatathroughAdapter(queryId, dataT);
            int total = dataT.Rows.Count;

            //Connecting to database with a string connection          
            string conn = "Data Source=DESKTOP-7J40056\\SQLEXPRESS;Initial Catalog=Surveys;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(conn))
            {
                //Getting number of rows in the database and display it on the form

                string queryTotal = "Select COUNT(*) from SurveyInfo";
                using (SqlCommand cmd = new SqlCommand(queryTotal, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/
                    if (total == 0)
                    {
                        lblTotalNumSurveys.Text = "No Surverys Available";
                    }
                    else
                    {
                        if (results == null)
                        {
                            lblTotalNumSurveys.Text = "No Surverys Available";
                        }
                        else
                        {
                            lblTotalNumSurveys.Text = results.ToString() + " Surveys";
                        }

                    }
                    connection.Close();
                }

                //Getting average age in the database and display it on the form

                string queryAge = "Select AVG(Age) from SurveyInfo";
                using (SqlCommand cmd = new SqlCommand(queryAge, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/
                    if (total == 0)
                    {
                        lblAvgAge.Text = "No Surveys Available";
                    }
                    else
                    {
                        if (results == null)
                        {
                            lblAvgAge.Text = "No Surveys Available";
                        }
                        else
                        {
                            lblAvgAge.Text = results.ToString() + " Years";
                        }
                    }

                    connection.Close();
                }

                //Getting maximum age in the database and display it on the form

                string queryMaxAge = "Select MAX(Age) from SurveyInfo";
                using (SqlCommand cmd = new SqlCommand(queryMaxAge, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/
                    if (total == 0)
                    {
                        lblMaxAge.Text = "No Surveys Available";
                    }
                    else
                    {
                        if (results == null)
                        {
                            lblMaxAge.Text = "No Surveys Available";
                        }
                        else
                        {
                            lblMaxAge.Text = results.ToString() + " Years";
                        }
                    }

                    connection.Close();
                }

                //Getting manimum age in the database and display it on the form

                string queryMinAge = "Select MIN(Age) from SurveyInfo";
                using (SqlCommand cmd1 = new SqlCommand(queryMinAge, connection))
                {
                    connection.Open();
                    var results = cmd1.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/
                    if (total == 0)
                    {
                        lblMinAge.Text = "No Surveys Available";
                    }
                    else
                    {
                        if (results == null)
                        {
                            lblMinAge.Text = "No Surveys Available";
                        }
                        else
                        {
                            lblMinAge.Text = results.ToString() + " Years";
                        }
                    }

                    connection.Close();
                }

                //Counting people who like Pizza and get the total number
                string queryPizza = "Select COUNT(Pizza) from SurveyInfo where Pizza = 1";
                using (SqlCommand cmd = new SqlCommand(queryPizza, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/

                    if (results == null)
                    {
                        lblPizza.Text = "No Surveys Available";
                    }
                    else
                    {
                        //Calculating the percentage of people that like Pizza and round the number to 1 decimal place
                        try
                        {
                            decimal pizzaPercentage = Math.Round((Convert.ToDecimal(results) / Convert.ToDecimal(total)) * Convert.ToDecimal(100), 1);

                            lblPizza.Text = pizzaPercentage.ToString() + " %";
                        }
                        catch
                        {
                            lblPizza.Text = "No Surveys Available";
                        }

                    }
                    connection.Close();
                }

                //Counting people who like Pasta and get the total number

                string queryPasta = "Select COUNT(Pasta) from SurveyInfo where Pasta = 1";
                using (SqlCommand cmd = new SqlCommand(queryPasta, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/

                    if (results == null)
                    {
                        lblPasta.Text = "No Surveys Available";
                    }
                    else
                    {
                        //Calculating the percentage of people that like Pasta and round the number to 1 decimal place
                        try
                        {
                            decimal pastaPercentage = Math.Round((Convert.ToDecimal(results) / Convert.ToDecimal(total)) * Convert.ToDecimal(100), 1);

                            lblPasta.Text = pastaPercentage.ToString() + " %";
                        }
                        catch
                        {
                            lblPasta.Text = "No Surveys Available";
                        }

                    }
                    connection.Close();
                }

                //Counting people who like Pap and Wors and get the total number

                string queryPapAndWors = "Select COUNT(Pap_n_Wors) from SurveyInfo where Pasta = 1";
                using (SqlCommand cmd = new SqlCommand(queryPapAndWors, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/

                    if (results == null)
                    {
                        lblPapAndWors.Text = "No Surveys Available";
                    }
                    else
                    {
                        //Calculating the percentage of people that like Pap and Wors and round the number to 1 decimal place
                        try
                        {
                            decimal papAndWorsPercentage = Math.Round((Convert.ToDecimal(results) / Convert.ToDecimal(total)) * Convert.ToDecimal(100), 1);

                            lblPapAndWors.Text = papAndWorsPercentage.ToString() + " %";
                        }
                        catch
                        {
                            lblPapAndWors.Text = "No Surveys Available";
                        }

                    }
                    connection.Close();
                }

                //Counting people who like to watch movies and get the total number

                string queryMovies = "Select COUNT(Movies) from SurveyInfo where Movies < 3";
                using (SqlCommand cmd = new SqlCommand(queryMovies, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/

                    if (results == null)
                    {
                        lblMovies.Text = "No Surveys Available";
                    }
                    else
                    {
                        //Calculating the averge rating of people that like to watch movies and round the number to 1 decimal place
                        try
                        {
                            decimal movieRating = Math.Round((Convert.ToDecimal(results) / Convert.ToDecimal(total)), 1);

                            lblMovies.Text = movieRating.ToString() + " Average Rating";
                        }
                        catch
                        {
                            lblMovies.Text = "No Surveys Available";
                        }

                    }
                    connection.Close();
                }

                //Counting people who like to listen to radio and get the total number

                string queryRadio = "Select COUNT(Radio) from SurveyInfo where Radio > 3";
                using (SqlCommand cmd = new SqlCommand(queryRadio, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/

                    if (results == null)
                    {
                        lblRadio.Text = "No Surveys Available";
                    }
                    else
                    {
                        //Calculating the averge rating of people that like to listen to radio and round the number to 1 decimal place
                        try
                        {
                            decimal radioRating = Math.Round((Convert.ToDecimal(results) / Convert.ToDecimal(total)), 1);

                            lblRadio.Text = radioRating.ToString() + " Average Rating";
                        }
                        catch
                        {
                            lblRadio.Text = "No Surveys Available";
                        }

                    }
                    connection.Close();
                }

                //Counting people who like to listen to eat out and get the total number

                string queryEatOut = "Select COUNT(Eat_Out) from SurveyInfo where Eat_Out < 3";
                using (SqlCommand cmd = new SqlCommand(queryEatOut, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/

                    if (results == null)
                    {
                        lblEatOut.Text = "No Surveys Available";
                    }
                    else
                    {
                        //Calculating the averge rating of people that like to eat out and round the number to 1 decimal place
                        try
                        {
                            decimal eatOutRating = Math.Round((Convert.ToDecimal(results) / Convert.ToDecimal(total)), 1);

                            lblEatOut.Text = eatOutRating.ToString() + " Average Rating";
                        }
                        catch
                        {
                            lblEatOut.Text = "No Surveys Available";
                        }

                    }
                    connection.Close();
                }

                //Counting people who like to listen to watch TV and get the total number

                string queryTV = "Select COUNT(TV) from SurveyInfo where TV < 3";
                using (SqlCommand cmd = new SqlCommand(queryTV, connection))
                {
                    connection.Open();
                    var results = cmd.ExecuteScalar();

                    /*Check if there are available rows int database table. If there are no rows diplay 
                    "No Surveys Available", If rows are available display the data*/

                    if (results == null)
                    {
                        lblTv.Text = "No Surveys Available";
                    }
                    else
                    {
                        //Calculating the averge rating of people that like to watch TV and round the number to 1 decimal place
                        try
                        {
                            decimal tvRating = Math.Round((Convert.ToDecimal(results) / Convert.ToDecimal(total)), 1);

                            lblTv.Text = tvRating.ToString() + " Average Rating";
                        }
                        catch
                        {
                            lblTv.Text = "No Surveys Available";
                        }

                    }
                    connection.Close();
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            refreshSurveyData();
            timer1.Start();
        }

        private void lnkFillOutSurvey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SurveyForm survey_Form = new SurveyForm();

            survey_Form.BringToFront();
            survey_Form.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshSurveyData();
            timer1.Start();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshSurveyData();
        }
    }
}
