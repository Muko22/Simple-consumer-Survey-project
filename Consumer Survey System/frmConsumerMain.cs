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
    public partial class frmConsumerMain : Form
    {
        public frmConsumerMain()
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

        // Public integer to store survey ID
        public static int surveyID;

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
            // Return datatable
            return dt;
        }

        private void frmConsumerMain_Load(object sender, EventArgs e)
        {
            // Display username
            lblUsername.Text = frmLogin.userName;
            // Call 'BindSource' function to retrieve surveys from 'survey' table
            BindSource();
            // Check if the query returns any rows 
            if (dt.Rows.Count > 0)
            {
                // Populate data grid with returned rows
                dgvSurveys.DataSource = dt;
                dgvSurveys.Columns["id"].Visible = false;
                dgvSurveys.Columns["name"].HeaderText = "Survey";
                // Enable the 'Answer Survey' button
                btnAnswerSurvey.Enabled = true;
                // Call 'autosize' function to autosize data grid
                autosize();
            }
            // If no rows are returned
            else
            {
                // Disable 'Answer Survey' button
                btnAnswerSurvey.Enabled = false;
                // Display message telling user that there are no surveys available
                MessageBox.Show("There are currently no surveys available. Please check again later.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        // When 'Answer Survey' button is clicked
        private void btnAnswerSurvey_Click(object sender, EventArgs e)
        {
            // Store survey ID in the public integer variable
            surveyID = Convert.ToInt32(dgvSurveys.CurrentRow.Cells["id"].Value);
            // Open the selected survey in a secondary form
            openChildForm(new frmSurvey());
        }

        // When the 'Close' button is clicked
        private void frmConsumerMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Display confirmation message
            if (MessageBox.Show("Are you sure want to exit?",
                   "Consumer Survey System",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Display confirmation message is user clicks the 'Logout' button
            if (MessageBox.Show("Are you sure want to logout?",
                               "Consumer Survey System",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                // If the user clicks 'Yes', return to login form
                // Create instance of login form
                frmLogin fl = new frmLogin();
                // Display login form
                fl.Show();
                // Hide this form
                this.Hide();
            }
            else
            {
                // Close confirmation message if the user clicks 'No'
                return;
            }
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
    }
}
