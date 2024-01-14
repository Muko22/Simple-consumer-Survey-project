using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumer_Survey_System
{
    public partial class frmForgotPassword : Form
    {

        // Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\Consumer Survey System\Consumer Survey System\database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;

        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void linklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Create instance of login form
            var loginform = new frmLogin();
            // Display login form
            loginform.Show();
            // Hide current form
            this.Hide();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNRC.Text))
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
            else if (String.IsNullOrEmpty(txtNewPassword.Text))
            {
                // Display error message if user leaves the password text field empty
                MessageBox.Show("Please enter a password.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the password text field so that the user can type their input
                txtNewPassword.Focus();
                // Terminate the event handler
                return;
            }
            else if (!Regex.Match(txtNewPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$").Success)
            {
                // Display an error message if the user enters a password that is less than 8 characters long
                MessageBox.Show("The password you entered is too weak. Your password should contain between 8 and 32 characters, at least one digit, at least one uppercase letter, at least one lowercase letter and at least one special character.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the password text field so that the user can retype their input
                txtNewPassword.Focus();
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

            else if (txtNewPassword.Text != txtRepeatPassword.Text)
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
                /* CHECK IF USER ALREADY EXISTS USING NRC NUMBER */

                // Open database connection
                con.Open();
                // Select all users with a email that matches the user's input
                cmd = new SqlCommand("SELECT * FROM users WHERE nrc='" + txtNRC.Text + "'", con);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int i = dt.Rows.Count;
                // Close database connection
                con.Close();
                // Check if there is a matching record in the 'users' table
                if (i > 0)
                {
                    // Call password hashing class to hash password 
                    var password = SecurePasswordHasher.Hash(txtNewPassword.Text);

                    // Update consumer password into 'users' table
                    cmd = new SqlCommand("UPDATE users SET password='"+ password +"'", con); //DELETE FROM table_name WHERE condition;
                    // Open database connection
                    con.Open();
                    // Execute query
                    cmd.ExecuteNonQuery();
                    // Close database connection
                    con.Close();

                    // Check if user account is disabled
                    con.Open(); // Open database connection
                    cmd = new SqlCommand("SELECT * FROM disabled WHERE email='" + dt.Rows[0]["email"].ToString() + "'", con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dtt = new DataTable();
                    da.Fill(dtt);
                    i = dtt.Rows.Count;
                    // Close database connection
                    con.Close();

                    if (i > 0)
                    {
                        // Remove user account from disabled list
                        cmd = new SqlCommand("DELETE FROM disabled WHERE email='" + dt.Rows[0]["email"].ToString() + "'", con);
                        // Open database connection
                        con.Open();
                        // Execute query
                        cmd.ExecuteNonQuery();
                        // Close database connection
                        con.Close();
                    }
                    // Display success message
                    MessageBox.Show("Your password reset was succesful!", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Hide forgot password form
                    this.Hide();
                    // Create instance of login form
                    var loginform = new frmLogin();
                    // Display login form
                    loginform.Show();
                }
                else
                {
                    // If the record search is positive, display an error message
                    MessageBox.Show("There is no user that exists with this NRC number. Please try again, or register if you are a new user.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // When 'View Password' icon is clicked
        private void pbxViewPassword_Click(object sender, EventArgs e)
        {
            // Change the password characters to normal format
            txtNewPassword.PasswordChar = '\0';
            txtRepeatPassword.PasswordChar = '\0';
            pbxViewPassword.Visible = false;
            pbxHidePassword.Visible = true;
        }

        // When 'Hide Password' icon is clicked
        private void pbxHidePassword_Click(object sender, EventArgs e)
        {
            // Change the password characters to hidden format
            txtNewPassword.PasswordChar = '•';
            txtRepeatPassword.PasswordChar = '•';
            pbxHidePassword.Visible = false;
            pbxViewPassword.Visible = true;
        }
    }
}
