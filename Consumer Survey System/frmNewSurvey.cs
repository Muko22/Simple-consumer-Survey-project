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

namespace Consumer_Survey_System
{
    public partial class frmNewSurvey : Form
    {
        public frmNewSurvey()
        {
            InitializeComponent();
        }

        // Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\Consumer Survey System\Consumer Survey System\database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;

        private void frmNewSurvey_Load(object sender, EventArgs e)
        {
            // Set selected index of dropdowns to zero(blank) by default
            cbxFormat1.SelectedIndex = 0;
            cbxFormat2.SelectedIndex = 0;
            cbxFormat3.SelectedIndex = 0;
            cbxFormat4.SelectedIndex = 0;
            cbxFormat5.SelectedIndex = 0;
            cbxFormat6.SelectedIndex = 0;
            cbxFormat7.SelectedIndex = 0;
            cbxFormat8.SelectedIndex = 0;
            cbxFormat9.SelectedIndex = 0;
            cbxFormat10.SelectedIndex = 0;
        }

        // When user clicks the add button on question 1, display input fields for question 2
        private void btnAddQuestion2_Click(object sender, EventArgs e)
        {
            btnAddQuestion2.Visible = false;
            gbxQuestion2.Visible = true;
            btnAddQuestion3.Visible = true;
            btnRemoveQuestion2.Visible = true;
            txtDescription2.Focus();
        }

        // When user clicks the add button on question 2, display input fields for question 3
        private void btnAddQuestion3_Click(object sender, EventArgs e)
        {
            btnAddQuestion3.Visible = false;
            btnRemoveQuestion2.Visible = false;
            gbxQuestion3.Visible = true;
            btnAddQuestion4.Visible = true;
            btnRemoveQuestion3.Visible = true;
            txtDescription3.Focus();
        }

        // When user clicks the remove button on question 2, delete question 2
        private void btnRemoveQuestion2_Click(object sender, EventArgs e)
        {
            btnAddQuestion2.Visible = true;
            gbxQuestion2.Visible = false;
            btnAddQuestion3.Visible = false;
            btnRemoveQuestion2.Visible = false;
            txtDescription1.Focus();
        }

        // When user clicks the add button on question 3, display input fields for question 4
        private void btnAddQuestion4_Click(object sender, EventArgs e)
        {
            btnAddQuestion4.Visible = false;
            btnRemoveQuestion3.Visible = false;
            gbxQuestion4.Visible = true;
            btnAddQuestion5.Visible = true;
            btnRemoveQuestion4.Visible = true;
            txtDescription4.Focus();
        }

        // When user clicks the remove button on question 3, delete question 3
        private void btnRemoveQuestion3_Click(object sender, EventArgs e)
        {
            btnAddQuestion3.Visible = true;
            gbxQuestion3.Visible = false;
            btnAddQuestion4.Visible = false;
            btnRemoveQuestion3.Visible = false;
            btnRemoveQuestion2.Visible = true;
            txtDescription2.Focus();
        }

        // When user clicks the add button on question 4, display input fields for question 5
        private void btnAddQuestion5_Click(object sender, EventArgs e)
        {
            btnAddQuestion5.Visible = false;
            btnRemoveQuestion4.Visible = false;
            gbxQuestion5.Visible = true;
            btnAddQuestion6.Visible = true;
            btnRemoveQuestion5.Visible = true;
            txtDescription5.Focus();
        }

        // When user clicks the remove button on question 4, delete question 4
        private void btnRemoveQuestion4_Click(object sender, EventArgs e)
        {
            btnAddQuestion4.Visible = true;
            gbxQuestion4.Visible = false;
            btnAddQuestion5.Visible = false;
            btnRemoveQuestion4.Visible = false;
            btnRemoveQuestion3.Visible = true;
            txtDescription3.Focus();
        }

        // When user clicks the add button on question 5, display input fields for question 6
        private void btnAddQuestion6_Click(object sender, EventArgs e)
        {
            btnAddQuestion6.Visible = false;
            btnRemoveQuestion5.Visible = false;
            gbxQuestion6.Visible = true;
            btnAddQuestion7.Visible = true;
            btnRemoveQuestion6.Visible = true;
            txtDescription6.Focus();
        }

        // When user clicks the remove button on question 5, delete question 5
        private void btnRemoveQuestion5_Click(object sender, EventArgs e)
        {
            btnAddQuestion5.Visible = true;
            gbxQuestion5.Visible = false;
            btnAddQuestion6.Visible = false;
            btnRemoveQuestion5.Visible = false;
            btnRemoveQuestion4.Visible = true;
            txtDescription4.Focus();
        }

        // When user clicks the add button on question 6, display input fields for question 7
        private void btnAddQuestion7_Click(object sender, EventArgs e)
        {
            btnAddQuestion7.Visible = false;
            btnRemoveQuestion6.Visible = false;
            gbxQuestion7.Visible = true;
            btnAddQuestion8.Visible = true;
            btnRemoveQuestion7.Visible = true;
            txtDescription7.Focus();
        }

        // When user clicks the remove button on question 6, delete question 6
        private void btnRemoveQuestion6_Click(object sender, EventArgs e)
        {
            btnAddQuestion6.Visible = true;
            gbxQuestion6.Visible = false;
            btnAddQuestion7.Visible = false;
            btnRemoveQuestion6.Visible = false;
            btnRemoveQuestion5.Visible = true;
            txtDescription5.Focus();
        }

        // When user clicks the add button on question 7, display input fields for question 8
        private void btnAddQuestion8_Click(object sender, EventArgs e)
        {
            btnAddQuestion8.Visible = false;
            btnRemoveQuestion7.Visible = false;
            gbxQuestion8.Visible = true;
            btnAddQuestion9.Visible = true;
            btnRemoveQuestion8.Visible = true;
            txtDescription8.Focus();
        }

        // When user clicks the remove button on question 7, delete question 7
        private void btnRemoveQuestion7_Click(object sender, EventArgs e)
        {
            btnAddQuestion7.Visible = true;
            gbxQuestion7.Visible = false;
            btnAddQuestion8.Visible = false;
            btnRemoveQuestion7.Visible = false;
            btnRemoveQuestion6.Visible = true;
            txtDescription6.Focus();
        }

        // When user clicks the add button on question 8, display input fields for question 9
        private void btnAddQuestion9_Click(object sender, EventArgs e)
        {
            btnAddQuestion9.Visible = false;
            btnRemoveQuestion8.Visible = false;
            gbxQuestion9.Visible = true;
            btnAddQuestion10.Visible = true;
            btnRemoveQuestion9.Visible = true;
            txtDescription9.Focus();
        }

        // When user clicks the remove button on question 8, delete question 8
        private void btnRemoveQuestion8_Click(object sender, EventArgs e)
        {
            btnAddQuestion8.Visible = true;
            gbxQuestion8.Visible = false;
            btnAddQuestion9.Visible = false;
            btnRemoveQuestion8.Visible = false;
            btnRemoveQuestion7.Visible = true;
            txtDescription7.Focus();
        }

        // When user clicks the add button on question 9, display input fields for question 10
        private void btnAddQuestion10_Click(object sender, EventArgs e)
        {
            btnAddQuestion10.Visible = false;
            btnRemoveQuestion9.Visible = false;
            gbxQuestion10.Visible = true;
            btnRemoveQuestion10.Visible = true;
            txtDescription10.Focus();
        }

        // When user clicks the remove button on question 9, delete question 9
        private void btnRemoveQuestion9_Click(object sender, EventArgs e)
        {
            btnAddQuestion9.Visible = true;
            gbxQuestion9.Visible = false;
            btnAddQuestion10.Visible = false;
            btnRemoveQuestion9.Visible = false;
            btnRemoveQuestion8.Visible = true;
            txtDescription8.Focus();
        }

        // When user clicks the remove button on question 10, delete question 10
        private void btnRemoveQuestion10_Click(object sender, EventArgs e)
        {
            btnAddQuestion10.Visible = true;
            btnRemoveQuestion9.Visible = true;
            gbxQuestion10.Visible = false;
            btnRemoveQuestion10.Visible = false;
            txtDescription9.Focus();
        }

        // When 'Submit' button is clicked
        private void btnCreateSurvey_Click(object sender, EventArgs e)
        {
            // VALIDATION

            // If 'Survey Name' text field is empty
            if (String.IsNullOrEmpty(txtSurveyName.Text))
            {
                // Display error message prompting user to enter a survey name
                MessageBox.Show("Please enter a survey name", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Survey Name' text field
                txtSurveyName.Focus();
                // Return to form
                return;
            }
            /* QUESTION 1 */
            // If user did not enter a question description for question 1
            else if (String.IsNullOrEmpty(txtDescription1.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 1", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription1.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 1
            else if (String.IsNullOrEmpty(cbxFormat1.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 1", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat1.Focus();
                // Return to form
                return;
            }
            /* QUESTION 2 */
            // If user did not enter a question description for question 2
            else if (gbxQuestion2.Visible == true & String.IsNullOrEmpty(txtDescription2.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 2", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription2.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 2
            else if (gbxQuestion2.Visible == true & String.IsNullOrEmpty(cbxFormat2.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 2", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat2.Focus();
                // Return to form
                return;
            }
            /* QUESTION 3 */
            // If user did not enter a question description for question 3
            else if (gbxQuestion3.Visible == true & String.IsNullOrEmpty(txtDescription3.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 3", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription3.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 3
            else if (gbxQuestion3.Visible == true & String.IsNullOrEmpty(cbxFormat3.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 3", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat3.Focus();
                // Return to form
                return;
            }
            /* QUESTION 4 */
            // If user did not enter a question description for question 4
            else if (gbxQuestion4.Visible == true & String.IsNullOrEmpty(txtDescription4.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 4", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription4.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 4
            else if (gbxQuestion4.Visible == true & String.IsNullOrEmpty(cbxFormat4.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 4", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat4.Focus();
                // Return to form
                return;
            }
            /* QUESTION 5 */
            // If user did not enter a question description for question 5
            else if (gbxQuestion5.Visible == true & String.IsNullOrEmpty(txtDescription5.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 5", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription5.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 5
            else if (gbxQuestion5.Visible == true & String.IsNullOrEmpty(cbxFormat5.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 5", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat5.Focus();
                // Return to form
                return;
            }
            /* QUESTION 6 */
            // If user did not enter a question description for question 6
            else if (gbxQuestion6.Visible == true & String.IsNullOrEmpty(txtDescription6.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 6", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription6.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 6
            else if (gbxQuestion6.Visible == true & String.IsNullOrEmpty(cbxFormat6.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 6", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat6.Focus();
                // Return to form
                return;
            }
            /* QUESTION 7 */
            // If user did not enter a question description for question 7
            else if (gbxQuestion7.Visible == true & String.IsNullOrEmpty(txtDescription7.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 7", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription7.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 7
            else if (gbxQuestion7.Visible == true & String.IsNullOrEmpty(cbxFormat7.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 7", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat7.Focus();
                // Return to form
                return;
            }
            /* QUESTION 8 */
            // If user did not enter a question description for question 8
            else if (gbxQuestion8.Visible == true & String.IsNullOrEmpty(txtDescription8.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 8", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription8.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 8
            else if (gbxQuestion8.Visible == true & String.IsNullOrEmpty(cbxFormat8.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 8", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat8.Focus();
                // Return to form
                return;
            }
            /* QUESTION 9 */
            // If user did not enter a question description for question 9
            else if (gbxQuestion9.Visible == true & String.IsNullOrEmpty(txtDescription9.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 9", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription9.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 9
            else if (gbxQuestion9.Visible == true & String.IsNullOrEmpty(cbxFormat9.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 9", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat9.Focus();
                // Return to form
                return;
            }
            /* QUESTION 10 */
            // If user did not enter a question description for question 10
            else if (gbxQuestion10.Visible == true & String.IsNullOrEmpty(txtDescription10.Text))
            {
                // Display error message prompting user to enter a question description
                MessageBox.Show("Please enter a question description for Question 10", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Description' text field
                txtDescription10.Focus();
                // Return to form
                return;
            }
            // If user did not select a question format for question 10
            else if (gbxQuestion10.Visible == true & String.IsNullOrEmpty(cbxFormat10.Text))
            {
                // Display error message prompting user to select a question format
                MessageBox.Show("Please select a question format for Question 10", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus to 'Question Format' dropdown
                cbxFormat10.Focus();
                // Return to form
                return;
            }
            else
            {
                // Open database connection
                con.Open();
                // Check if survey name already exists
                cmd = new SqlCommand("SELECT * FROM survey WHERE name='" + txtSurveyName.Text + "'", con);
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                con.Close();
                if (i > 0)
                {
                    // Display message if survey name already exists
                    MessageBox.Show("A survey with this name already exists. Please choose a different name.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Set focus to 'Survey Name' text field
                    txtSurveyName.Focus();
                    // Return to form
                    return;
                }
                // If survey name doesn't exist
                else
                {
                    // Insert survey into 'survey' table
                    cmd = new SqlCommand("INSERT INTO survey (name) VALUES ('" + txtSurveyName.Text + "'); SELECT SCOPE_IDENTITY()", con);
                    // Open database connection
                    con.Open();
                    // Store created ID
                    int surveyID = Convert.ToInt32(cmd.ExecuteScalar());
                    // Insert question 1 into 'question' table
                    cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription1.Text + "', '" + cbxFormat1.Text + "', '" + 1 +"')", con);
                    // Execute query
                    cmd.ExecuteNonQuery();
                    // Close database connection
                    con.Close();

                    // If question 2 was added
                    if (gbxQuestion2.Visible == true)
                    {
                        // Insert question 2 into 'question' table
                        cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription2.Text + "', '" +cbxFormat2.Text+ "', '" + 2 + "')", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // If question 3 was added
                    if (gbxQuestion3.Visible == true)
                    {
                        // Insert question 3 into 'question' table
                        cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription3.Text + "', '" + cbxFormat3.Text + "', '" + 3 + "')", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // If question 4 was added
                    if (gbxQuestion4.Visible == true)
                    {
                        // Insert question 4 into 'question' table
                        cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription4.Text + "', '" + cbxFormat4.Text + "', '" + 4 + "')", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // If question 5 was added
                    if (gbxQuestion5.Visible == true)
                    {
                        // Insert question 5 into 'question' table
                        cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription5.Text + "', '" + cbxFormat5.Text + "', '" + 5 + "')", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // If question 6 was added
                    if (gbxQuestion6.Visible == true)
                    {
                        // Insert question 6 into 'question' table
                        cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription6.Text + "', '" + cbxFormat6.Text + "', '" + 6 + "')", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // If question 7 was added
                    if (gbxQuestion7.Visible == true)
                    {
                        // Insert question 7 into 'question' table
                        cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription7.Text + "', '" + cbxFormat7.Text + "', '" + 7 + "')", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // If question 8 was added
                    if (gbxQuestion8.Visible == true)
                    {
                        // Insert question 8 into 'question' table
                        cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription8.Text + "', '" + cbxFormat8.Text + "', '" + 8 + "')", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // If question 9 was added
                    if (gbxQuestion9.Visible == true)
                    {
                        // Insert question 9 into 'question' table
                        cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription9.Text + "', '" + cbxFormat9.Text + "', '" + 9 + "')", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // If question 10 was added
                    if (gbxQuestion10.Visible == true)
                    {
                        // Insert question 10 into 'question' table
                        cmd = new SqlCommand("INSERT INTO question (survey_id, description, question_format, question_number) VALUES ('" + surveyID.ToString() + "', '" + txtDescription10.Text + "', '" + cbxFormat10.Text + "', '" + 10 + "')", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // Display success message and return user to main form
                    MessageBox.Show("The survey has been created succesfully. Click the 'Refresh' button to update the data.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Close current form
                    this.Close();

                }
            }
        }

        // When 'Back' button is clicked
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Close current form to display main form
            this.Close();
        }
    }
}
