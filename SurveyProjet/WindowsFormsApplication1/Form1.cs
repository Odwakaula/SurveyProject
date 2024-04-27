using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class SurveyForm : Form
    {
        DatabaseAccess dbAccess = new DatabaseAccess();
        int ratingMovies, ratingRadio, ratingEatOut, ratingTV;
        int food1, food2, food3, food4;

        public SurveyForm()
        {
            InitializeComponent();
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Declaring variables
            String fullNames = txtFullNames.Text;
            String email = txtEmail.Text;
            DateTime dateOfBirth = dateTimePicker1.Value;
            String contactNum = txtContactNo.Text;
            Boolean pizza = chkPizza.Checked;
            Boolean pasta = chkPasta.Checked;
            Boolean papAndWors = chkPapAndWors.Checked;
            Boolean other = chkOther.Checked;
            Boolean movies1 = radMovies1.Checked;
            Boolean movies2 = radMovies2.Checked;
            Boolean movies3 = radMovies3.Checked;
            Boolean movies4 = radMovies4.Checked;
            Boolean movies5 = radMovies5.Checked;
            Boolean radio1 = radRadio1.Checked;
            Boolean radio2 = radRadio2.Checked;
            Boolean radio3 = radRadio3.Checked;
            Boolean radio4 = radRadio4.Checked;
            Boolean radio5 = radRadio5.Checked;
            Boolean eatOut1 = radEatOut1.Checked;
            Boolean eatOut2 = radEatOut2.Checked;
            Boolean eatOut3 = radEatOut3.Checked;
            Boolean eatOut4 = radEatOut4.Checked;
            Boolean eatOut5 = radEatOut5.Checked;
            Boolean tv1 = radTV1.Checked;
            Boolean tv2 = radTV2.Checked;
            Boolean tv3 = radTV3.Checked;
            Boolean tv4 = radTV4.Checked;
            Boolean tv5 = radTV5.Checked;

            //Declaring age and subtract current date to the enter date of birth
            int age = DateTime.Today.Year - dateOfBirth.Year;
            
            //Validating if all the textbox fields are properly filled

            if (fullNames.Equals(""))
            {
                MessageBox.Show("Please fill in your full names", "Required Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFullNames.Focus();
                return;
            }

            else if (!Regex.IsMatch(fullNames, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Invalid name. Name must not contain nambers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullNames.Focus();
                return;
            }

            else if (email.Equals(""))
            {
                MessageBox.Show("Please fill in your Email", "Required Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            else if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&’*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&’*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Invalid email. Please enter correct Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            else if (dateOfBirth >= DateTime.Today)
            {
                MessageBox.Show("Date of Birth cannot be in present or in future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (DateTime.Today.Year - dateOfBirth.Year < 5 || DateTime.Today.Year - dateOfBirth.Year > 120)
            {
                MessageBox.Show("You must be between 5 years and 120 years to take this survey", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (contactNum.Equals(""))
            {
                MessageBox.Show("Please fill in your full contact number", "Required Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContactNo.Focus();
                return;
            }

            else if (!Regex.IsMatch(contactNum, @"^[0-9]+$"))
            {
                MessageBox.Show("Invalid contact number. Contact number must not contain alphabet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }

            else if (contactNum.Length < 10 || contactNum.Length > 10)
            {
                MessageBox.Show("Contact number must not be greater or less than 10 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }

            else if (pizza.Equals(false) && pasta.Equals(false) && papAndWors.Equals(false) && other.Equals(false))
            {
                MessageBox.Show("Plese select atleast one option for favourite food", "Required Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (movies1.Equals(false) && movies2.Equals(false) && movies3.Equals(false) && movies4.Equals(false) && movies5.Equals(false))
            {
                MessageBox.Show("Plese rate if you like to watch movies", "Required Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (radio1.Equals(false) && radio2.Equals(false) && radio3.Equals(false) && radio4.Equals(false) && radio5.Equals(false))
            {
                MessageBox.Show("Plese rate if you like to listen to radio", "Required Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (eatOut1.Equals(false) && eatOut2.Equals(false) && eatOut3.Equals(false) && eatOut4.Equals(false) && eatOut5.Equals(false))
            {
                MessageBox.Show("Plese rate if you like to eat out", "Required Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (tv1.Equals(false) && tv2.Equals(false) && tv3.Equals(false) && tv4.Equals(false) && tv5.Equals(false))
            {
                MessageBox.Show("Plese rate if you like to watch TV", "Required Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into SurveyInfo(Names, Email, DOB, Age, Contacts, Pizza, Pasta, Pap_n_Wors, Other, Movies, Radio, Eat_Out, TV) values(@fullNames, @email, @dateOfBirth, @age, @contactNum, @food1, @food2, @food3, @food4, @ratingMovies, @ratingRadio, @ratingEatOut, @ratingTV)");

                insertCommand.Parameters.AddWithValue("@fullNames", fullNames);
                insertCommand.Parameters.AddWithValue("@email", email);
                insertCommand.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                insertCommand.Parameters.AddWithValue("@age", age);
                insertCommand.Parameters.AddWithValue("@contactNum", contactNum);
                insertCommand.Parameters.AddWithValue("@food1", food1);
                insertCommand.Parameters.AddWithValue("@food2", food2);
                insertCommand.Parameters.AddWithValue("@food3", food3);
                insertCommand.Parameters.AddWithValue("@food4", food4);
                insertCommand.Parameters.AddWithValue("@ratingMovies", ratingMovies);
                insertCommand.Parameters.AddWithValue("@ratingRadio", ratingRadio);
                insertCommand.Parameters.AddWithValue("@ratingEatOut", ratingEatOut);
                insertCommand.Parameters.AddWithValue("@ratingTV", ratingTV);

                int row = dbAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show("Well done. You have successffuly completed the survey", "Survey Completed", MessageBoxButtons.OK, MessageBoxIcon.None);

                    txtFullNames.Clear();
                    txtEmail.Clear();
                    txtContactNo.Clear();
                    dateOfBirth = DateTime.Today;

                    txtFullNames.Focus();
                }
                else
                {
                    MessageBox.Show("Error uccured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void radMovies1_CheckedChanged(object sender, EventArgs e)
        {
            if (radMovies1.Checked == true)
            {
                ratingMovies = 1;
                radMovies2.Checked = false; radMovies3.Checked = false; radMovies4.Checked = false; radMovies5.Checked = false;
            }
        }

        private void SurveyForm_Load(object sender, EventArgs e)
        {
            txtFullNames.Focus();
        }

        private void radMovies2_CheckedChanged(object sender, EventArgs e)
        {
            if (radMovies2.Checked == true)
            {
                ratingMovies = 2;
                radMovies1.Checked = false; radMovies3.Checked = false; radMovies4.Checked = false; radMovies5.Checked = false;  
            }
        }

        private void radMovies3_CheckedChanged(object sender, EventArgs e)
        {
            if (radMovies3.Checked == true)
            {
                ratingMovies = 3;
                radMovies1.Checked = false; radMovies2.Checked = false; radMovies4.Checked = false; radMovies5.Checked = false;
            }
        }

        private void radMovies4_CheckedChanged(object sender, EventArgs e)
        {
            if (radMovies4.Checked == true)
            {
                ratingMovies = 4;
                radMovies1.Checked = false; radMovies2.Checked = false; radMovies3.Checked = false; radMovies5.Checked = false;
            }
        }

        private void radMovies5_CheckedChanged(object sender, EventArgs e)
        {
            if (radMovies5.Checked == true)
            {
                ratingMovies = 5;
                radMovies1.Checked = false; radMovies2.Checked = false; radMovies3.Checked = false; radMovies4.Checked = false;   
            }
        }

        private void radRadio1_CheckedChanged(object sender, EventArgs e)
        {
            if (radRadio1.Checked == true)
            {
                radRadio2.Checked = false; radRadio3.Checked = false; radRadio4.Checked = false; radRadio5.Checked = false;
                ratingRadio = 1;
            }
        }

        private void radRadio2_CheckedChanged(object sender, EventArgs e)
        {
            if (radRadio2.Checked == true)
            {
                radRadio1.Checked = false; radRadio3.Checked = false; radRadio4.Checked = false; radRadio5.Checked = false;
                ratingRadio = 2;
            }          
        }

        private void radRadio3_CheckedChanged(object sender, EventArgs e)
        {
            if (radRadio3.Checked == true)
            {
                radRadio1.Checked = false; radRadio2.Checked = false; radRadio4.Checked = false; radRadio5.Checked = false;
                ratingRadio = 3;
            }
        }

        private void radRadio4_CheckedChanged(object sender, EventArgs e)
        {
            if (radRadio4.Checked == true)
            {
                radRadio1.Checked = false; radRadio2.Checked = false; radRadio3.Checked = false; radRadio5.Checked = false;
                ratingRadio = 4;
            }
        }

        private void radRadio5_CheckedChanged(object sender, EventArgs e)
        {
            if (radRadio5.Checked == true)
            {
                radRadio1.Checked = false; radRadio2.Checked = false; radRadio3.Checked = false; radRadio4.Checked = false;
                ratingRadio = 5;
            }
        }

        private void radEatOut1_CheckedChanged(object sender, EventArgs e)
        {
            if (radEatOut1.Checked == true)
            {
                radEatOut2.Checked = false; radEatOut3.Checked = false; radEatOut4.Checked = false; radEatOut5.Checked = false;
                ratingEatOut = 1;
            }
        }

        private void radEatOut2_CheckedChanged(object sender, EventArgs e)
        {
            if (radEatOut2.Checked == true)
            {
                radEatOut1.Checked = false; radEatOut3.Checked = false; radEatOut4.Checked = false; radEatOut5.Checked = false;
                ratingEatOut = 2;
            }
        }

        private void radEatOut3_CheckedChanged(object sender, EventArgs e)
        {
            if (radEatOut3.Checked == true)
            {
                radEatOut1.Checked = false; radEatOut2.Checked = false; radEatOut4.Checked = false; radEatOut5.Checked = false;
                ratingEatOut = 3;
            }
        }

        private void radEatOut4_CheckedChanged(object sender, EventArgs e)
        {
            if (radEatOut4.Checked == true)
            {
                radEatOut1.Checked = false; radEatOut2.Checked = false; radEatOut3.Checked = false; radEatOut5.Checked = false;
                ratingEatOut = 4;
            }
        }

        private void radEatOut5_CheckedChanged(object sender, EventArgs e)
        {
            if (radEatOut5.Checked == true)
            {
                radEatOut1.Checked = false; radEatOut2.Checked = false; radEatOut3.Checked = false; radEatOut4.Checked = false;
                ratingEatOut = 5;
            }
        }

        private void radTV1_CheckedChanged(object sender, EventArgs e)
        {
            if (radTV1.Checked == true)
            {
                radTV2.Checked = false; radTV3.Checked = false; radTV4.Checked = false; radTV5.Checked = false;
                ratingTV = 1;
            }
        }

        private void radTV2_CheckedChanged(object sender, EventArgs e)
        {
            if (radTV2.Checked == true)
            {
                radTV1.Checked = false; radTV3.Checked = false; radTV4.Checked = false; radTV5.Checked = false;
                ratingTV = 2;
            }
        }

        private void radTV3_CheckedChanged(object sender, EventArgs e)
        {
            if (radTV3.Checked == true)
            {
                radTV1.Checked = false; radTV2.Checked = false; radTV4.Checked = false; radTV5.Checked = false;
                ratingTV = 3;
            }
        }

        

        private void radTV4_CheckedChanged(object sender, EventArgs e)
        {
            if (radTV4.Checked == true)
            {
                radTV1.Checked = false; radTV2.Checked = false; radTV3.Checked = false; radTV5.Checked = false;
                ratingTV = 4;
            }
        }

        private void radTV5_CheckedChanged(object sender, EventArgs e)
        {
            if (radTV5.Checked == true)
            {
                radTV1.Checked = false; radTV2.Checked = false; radTV3.Checked = false; radTV4.Checked = false;
                ratingTV = 5;
            }
        }

        private void chkPizza_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPizza.Checked.Equals(true))
            {
                food1 = 1;
            }
        }

        private void chkPasta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPasta.Checked.Equals(true))
            {
                food2 = 1;
            }
        }

        private void chkPapAndWors_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPapAndWors.Checked.Equals(true))
            {
                food3 = 1;
            }
        }

        private void chkOther_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOther.Checked.Equals(true))
            {
                food4 = 1;
            }
        }
        private void lnkViewSurveyResults_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 survey_Results = new Form2();

            survey_Results.BringToFront();
            survey_Results.Show();
            this.Hide();     
        }
    }
}
