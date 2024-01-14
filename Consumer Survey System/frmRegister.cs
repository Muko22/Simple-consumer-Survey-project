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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Consumer_Survey_System
{
    public partial class frmRegister : Form
    {

        // Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\Consumer Survey System\Consumer Survey System\database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;

        public frmRegister()
        {
            InitializeComponent();
        }

        // When 'Login' link is clicked
        private void linklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Create instance of login form
            var loginform = new frmLogin();
            // Display login form
            loginform.Show();
            // Hide current form
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            /* VALIDATION FOR EMPTY FIELDS AND INVALID INPUTS */

            if (String.IsNullOrEmpty(txtFirstName.Text))
            {
                // Display error message if user leaves the 'First Name' text field empty
                MessageBox.Show("Please enter your first name.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the 'First Name' text field so that the user can type their input
                txtFirstName.Focus();
                // Terminate the event handler
                return;
            }
            else if (String.IsNullOrEmpty(txtLastName.Text))
            {
                // Display error message if user leaves the 'Last Name' text field empty
                MessageBox.Show("Please enter your last name.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the 'Last Name' text field so that the user can type their input
                txtLastName.Focus();
                // Terminate the event handler
                return;
            }
            else if (String.IsNullOrEmpty(txtEmail.Text))
            {
                // Display error message if user leaves the username text field empty
                MessageBox.Show("Please enter your email address.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the username text field so that the user can type their input
                txtEmail.Focus();
                // Terminate the event handler
                return;
            }
            else if (String.IsNullOrEmpty(txtNRC.Text))
            {
                // Display error message if user leaves the NRC text field empty
                MessageBox.Show("Please enter your NRC number.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the NRC text field so that the user can type their input
                txtNRC.Focus();
                // Terminate the event handler
                return;
            }
            else if (!Regex.Match(txtNRC.Text, @"^[0-9//]*$").Success)
            {
                // Display an error message if the user enters an invalid NRC number
                MessageBox.Show("The NRC number you entered is invalid. Please enter a valid NRC number in the format: xxxxxx/xx/x", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the NRC text field so that the user can retype their input
                txtNRC.Focus();
                // Terminate the event handler
                return;
            }
            else if (String.IsNullOrEmpty(txtPassword.Text))
            {
                // Display error message if user leaves the password text field empty
                MessageBox.Show("Please enter a password.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the password text field so that the user can type their input
                txtPassword.Focus();
                // Terminate the event handler
                return;
            }
            else if (!Regex.Match(txtPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$").Success)
            {
                // Display an error message if the user enters a password that is less than 8 characters long
                MessageBox.Show("The password you entered is too weak. Your password should contain between 8 and 32 characters, at least one digit, at least one uppercase letter, at least one lowercase letter and at least one special character.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the password text field so that the user can retype their input
                txtPassword.Focus();
                // Terminate the event handler
                return;
            }
            else if (String.IsNullOrEmpty(txtRepeatPassword.Text))
            {
                // Display error message if user leaves the repeat password text field empty
                MessageBox.Show("Please repeat your password.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the repeat password text field so that the user can type their input
                txtRepeatPassword.Focus();
                // Terminate the event handler
                return;
            }

            /* CHECK IF PASSWORDS MATCH */

            else if (txtPassword.Text != txtRepeatPassword.Text)
            {
                // Display an error message if the user enters a password that is less than 8 characters long
                MessageBox.Show("Your passwords do not match.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the repeat password text field so that the user can retype their input
                txtRepeatPassword.Focus();
                // Terminate the event handler
                return;
            }
            else
            {
                /* CHECK IF EMAIL ADDRESS ALREADY EXISTS IN USERS TABLE */

                // Open database connection
                con.Open();
                // Select all users with a email that matches the user's input
                cmd = new SqlCommand("SELECT * FROM users WHERE email='" + txtEmail.Text + "'", con);
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int i = ds.Tables[0].Rows.Count;
                // Close database connection
                con.Close();
                // Check if there is a matching record in the 'users' table
                if (i > 0)
                {
                    // If the record search is positive, display an error message
                    MessageBox.Show("A user with this email address already exists. If this is you, please navigate to the login screen.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Set focus back the username text field so that the user can retype their input
                    txtEmail.Focus();
                    // Terminate the event handler
                    return;
                }
                else
                {
                    // Call password hashing class to hash password 
                    var password = SecurePasswordHasher.Hash(txtPassword.Text);

                    // Insert consumer information into 'users' table
                    cmd = new SqlCommand("INSERT INTO users (first_name, last_name, email, nrc, user_type, password) VALUES ('" + txtFirstName.Text + "', '" + txtLastName.Text + "', '" + txtEmail.Text + "', '" + txtNRC.Text + "', 'consumer', '" + password + "')", con);
                    // Open database connection
                    con.Open();
                    // Execute query
                    cmd.ExecuteNonQuery();
                    // Close database connection
                    con.Close();
                    // Display success message
                    MessageBox.Show("Registration Successful!", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Hide registration form
                    this.Hide();
                    // Create instance of login form
                    var loginform = new frmLogin();
                    // Display login form
                    loginform.Show();
                }
            }
        }

        // When 'Hide Password' icon is clicked
        private void pbxHidePassword_Click(object sender, EventArgs e)
        {
            // Change the password characters to hidden format
            txtPassword.PasswordChar = '•';
            txtRepeatPassword.PasswordChar = '•';
            pbxHidePassword.Visible = false;
            pbxViewPassword.Visible = true;
        }

        // When 'View Password' icon is clicked
        private void pbxViewPassword_Click(object sender, EventArgs e)
        {
            // Change the password characters to normal format
            txtPassword.PasswordChar = '\0';
            txtRepeatPassword.PasswordChar = '\0';
            pbxViewPassword.Visible = false;
            pbxHidePassword.Visible = true;
        }

        // When the 'Close' button is clicked
        private void frmRegister_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
