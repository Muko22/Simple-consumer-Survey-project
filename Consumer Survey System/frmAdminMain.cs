using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Consumer_Survey_System
{
    public partial class frmAdminMain : Form
    {
        public frmAdminMain()
        {
            InitializeComponent();
        }

        // Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\Consumer Survey System\Consumer Survey System\database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;

        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        // Variable to store secondary form
        private Form activeForm = null;

        // Public variables to store survey ID and survey name
        public static int surveyID;
        public static string surveyName;

        // 'BindSource' function retrieves all surveys from the 'survey' data and stores then in a datatable
        public DataTable BindSource()
        {
            // Open database connection
            con.Open();
            // Retrieve all surveys from 'survey' table
            cmd = new SqlCommand("SELECT * FROM survey", con);
            da = new SqlDataAdapter(cmd);
            // Clear existing dataset if any
            ds.Clear();
            // Store retrived surveys in dataset
            da.Fill(ds);
            // Store dataset table in datatable
            dt = ds.Tables[0];
            // Close database connection
            con.Close();
            // Check if the query returns any rows 
            if (dt.Rows.Count > 0)
            {
                // Populate data grid with returned rows
                dgvSurveys.DataSource = dt;
                dgvSurveys.Columns["id"].HeaderText = "No.";
                dgvSurveys.Columns["name"].HeaderText = "Survey";
                // Enable 'Delete Survey' button
                btnDeleteSurvey.Enabled = true;
                // Enable 'View Results' button
                btnResults.Enabled = true;
                // Call 'autosize' function to autosize data grid
                autosize();
            }
            // If query did not return any rows
            else
            {
                // Disable 'Delete Survey' button 
                btnDeleteSurvey.Enabled = false;
                // Disable 'View Results' button
                btnResults.Enabled = false;
                // Display message telling admin that there are no surveys available
                MessageBox.Show("There are currently no surveys available. You can create a new survey by clicking the 'New Survey' button.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Return datatable
            return dt;
        }

        private void frmAdminMain_Load(object sender, EventArgs e)
        {
            // Call 'BindSource' function to retrieve surveys from 'survey' table
            BindSource();       
        }

        // Function to autosize data grid
        private void autosize()
        {
            for (int i = 0; i < dgvSurveys.Columns.Count - 1; i++)
            {
                dgvSurveys.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvSurveys.Columns[dgvSurveys.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dgvSurveys.Columns.Count; i++)
            {
                int colw = dgvSurveys.Columns[i].Width;
                dgvSurveys.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvSurveys.Columns[i].Width = colw;
            }
        }

        // Function of open a secondary form inside the main form
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(childForm);
            pnlContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // When the user clicks the 'New Survey' button
        private void btnNewSurvey_Click(object sender, EventArgs e)
        {
            // Call the 'openChildForm' function to open the 'New Survey' form
            openChildForm(new frmNewSurvey());
            btnSurveys.BackColor = Color.FromArgb(129, 29, 94);
        }

        // When the user clicks the 'Delete Survey' button
        private void btnDeleteSurvey_Click(object sender, EventArgs e)
        {
            // Display confirmation message
            if (MessageBox.Show("Are you sure you want to delete this survey?",
                               "Consumer Survey System",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // If the user clicks 'Yes' -
                
                // Retrieve ID of selected survey
                int surveyID = Convert.ToInt32(dgvSurveys.CurrentRow.Cells["id"].Value);

                // Delete results of selected survey from 'result' table
                cmd = new SqlCommand("DELETE FROM result WHERE survey_id = '" + surveyID + "'", con);
                // Open database connection
                con.Open();
                // Execute query
                cmd.ExecuteNonQuery();
                // Close database connection
                con.Close();

                // Delete question of selected survey from 'question' table
                cmd = new SqlCommand("DELETE FROM question WHERE survey_id = '" + surveyID + "'", con);
                // Open database connection
                con.Open();
                // Execute query
                cmd.ExecuteNonQuery();
                // Close database connection
                con.Close();

                // Delete selected survey from 'survey' table
                cmd = new SqlCommand("DELETE FROM survey WHERE id = '" + surveyID + "'", con);
                // Open database connection
                con.Open();
                // Execute query
                cmd.ExecuteNonQuery();
                // Close database connection
                con.Close();

                // Call 'BindSource' function to refresh data grid
                BindSource();
            }
            else
            {
                // Close confirmation message if user clicks 'No'
                return;
            }
        }

        // When user clicks 'Edit Survey' button
        private void btnEditSurvey_Click(object sender, EventArgs e)
        {
            // Retrieve and store ID of selected survey
            surveyID = Convert.ToInt32(dgvSurveys.CurrentRow.Cells["id"].Value);
            // Open 'Edit Survey' form as secondary form
            openChildForm(new frmEditSurvey());
        }

        // When user clicks 'Surveys' button on side panel
        private void btnSurveys_Click(object sender, EventArgs e)
        {
            // If secondary form is open
            if (activeForm != null)
                // Close secondary form to display main form
                activeForm.Close();
            btnSurveys.BackColor = Color.FromArgb(89, 9, 61);
        }

        // When 'Refresh' button is clicked
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Call 'BindSource' function to refresh data grid
            BindSource();
        }

        // When 'View Results' button is clicked
        private void btnResults_Click(object sender, EventArgs e)
        {
            // Retrieve and store ID of selected survey
            surveyID = Convert.ToInt32(dgvSurveys.CurrentRow.Cells["id"].Value);
            // Retrieve and store name of selected survey
            surveyName = Convert.ToString(dgvSurveys.CurrentRow.Cells["name"].Value);
            btnSurveys.BackColor = Color.FromArgb(129, 29, 94);
            // Open 'Results' form as secondary form
            openChildForm(new frmResult());
        }

        // When 'Logout' button is clicked
        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Display confirmation message
            if (MessageBox.Show("Are you sure want to logout?",
                               "Consumer Survey System",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // If user clicks 'Yes' -

                // Create instance of login form
                frmLogin fl = new frmLogin();
                // Show login form
                fl.Show();
                // Hide current form
                this.Hide();
            }
            // If user clicks 'No'
            else
            {
                // Close confirmation message
                return;
            }
        }

        // When the 'Close' button is clicked
        private void frmAdminMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Display confirmation message
            if (MessageBox.Show("Are you sure want to exit?",
                   "Consumer Survey System",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information) == DialogResult.OK)
            {
                // Exit the application if user clicks 'Yes'
                Environment.Exit(0);
            }
            else
            {
                // Close confirmation message if user clicks 'No'
                e.Cancel = true;
            }
        }
    }
}