using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Consumer_Survey_System
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        // Database Connection String
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\Consumer Survey System\Consumer Survey System\database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;

        // Variables to store the number of login attempts
        int count, email_attempt, password_attempt;

        // Public string to store username\
        public static string userName;

        // 'Disable' function to disable login form after number failed attempts is exceeded
        void disableForm()
        {
            // If number of failed login attempts equals three
            if (email_attempt == 5)
            {
                // Display message box notifying the user that the number of maximum login attempts has been exceeded
                MessageBox.Show("You have reached the maximum number of login attempts (5). Please try again after 60 seconds.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                email_attempt = 0;
                count = 60;

                // Enable countdown timer
                tmrLogin.Enabled = true;
                // Disable login button
                btnLogin.Enabled = false;
                // Disable email text field
                txtEmail.Enabled = false;
                // Disable password text field
                txtPassword.Enabled = false;
            }
        }

        void disableUser()
        {
            // If number of failed login attempts equals three
            if (password_attempt == 5)
            {
                // Insert user email into 'disabled' table
                cmd = new SqlCommand("INSERT INTO disabled (email) VALUES ('" + txtEmail.Text + "')", con);
                // Open database connection
                con.Open();
                // Execute query
                cmd.ExecuteNonQuery();
                // Close database connection
                con.Close();
                // Display message box notifying the user that the number of maximum login attempts has been exceeded
                MessageBox.Show("You have reached the maximum number of password attempts (5) and your account has been disabled. Please click the 'Forgot Password' link to reset your password or contact an administrator for assitance.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // When 'Login' button is clicked
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // VALIDATE FOR EMPTY FIELDS

            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                // Display error message if user leaves the email text field empty
                MessageBox.Show("Please enter your email address", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the email text field so that the user can type the input
                txtEmail.Focus();
                // Terminate the event handler
                return;
            }
            else if (String.IsNullOrEmpty(txtPassword.Text))
            {
                // Display error message if user leaves the password text field empty
                MessageBox.Show("Please enter your password", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Set focus back the password text field so that the user can type the input
                txtPassword.Focus();
                // Terminate the event handler
                return;
            }
            else
            {
                // Open database connection
                con.Open();
                // Check the users table for an email address matching that which the user entered
                cmd = new SqlCommand("SELECT * FROM users WHERE email='" + txtEmail.Text + "'", con);
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                // Store retrieved rows in datatable
                da.Fill(dt);
                // Close database connection
                con.Close();
                // Store number of rows
                int i = dt.Rows.Count;
                // Check if there is a matching record in the 'users' table
                if (i == 1)
                {
                    // Check if user account is disabled
                    con.Open(); // Open database connection
                    // Check the users table for an email address matching that which the user entered
                    cmd = new SqlCommand("SELECT * FROM disabled WHERE email='" + txtEmail.Text + "'", con);
                    da = new SqlDataAdapter(cmd);
                    DataTable dtt = new DataTable();
                    // Store retrieved rows in datatable
                    da.Fill(dtt);
                    // Close database connection
                    con.Close();
                    // Store number of rows
                    i = dtt.Rows.Count;
                    // If user account is disabled
                    if (i == 1)
                    {
                        // Display error message
                        MessageBox.Show("This account has been disabled. Please click the 'Forgot Password' link to reset your password or contact an administrator for assitance.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Verify password
                        if (SecurePasswordHasher.Verify(txtPassword.Text, dt.Rows[0]["password"].ToString()))
                        {
                            // If password is correct -

                            userName = dt.Rows[0]["first_name"].ToString() + " " + dt.Rows[0]["last_name"].ToString();

                            // Display a success message
                            MessageBox.Show("Login successful. Welcome " + userName + "!", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // If the user is a consumer, open the consumer form
                            if (dt.Rows[0]["user_type"].ToString() == "consumer")
                            {
                                // Open consumer form
                                frmConsumerMain fm = new frmConsumerMain();
                                fm.Show();
                                // Close database connection
                                con.Close();
                                // Hide login form
                                this.Hide();
                            }
                            // If the user is an administrator, open the administrator form
                            else if (dt.Rows[0]["user_type"].ToString() == "admin")
                            {
                                // Open administrator form
                                frmAdminMain fm = new frmAdminMain();
                                // Close database connection
                                con.Close();
                                fm.Show();
                                // Hide login form
                                this.Hide();
                            }
                        }
                        // If password is not correct
                        else
                        {
                            // Display error message
                            MessageBox.Show("The password you entered is incorrect. Please try again.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // Close database connection
                            con.Close();
                            // Clear the password field
                            txtPassword.Clear();
                            // Set focus to 'Password' text field so that the user can retype their input
                            txtPassword.Focus();
                            // Increment the number of login attempts by 1
                            password_attempt = password_attempt + 1;
                            // Call the 'disable' function to check if the number of failed attempts has been succeeded
                            disableUser();
                            // Terminate the event handler and return to login form
                            return;
                        }
                    }
                }
                else
                {
                    // If the records search is negative, display an error message
                    MessageBox.Show("The email address you entered is incorrect. Please try again. If are a new user, please click the 'Register' link.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Close database connection
                    con.Close();
                    // Clear the email address field
                    txtEmail.Clear();
                    // Clear the password field
                    txtPassword.Clear();
                    // Increment the number of login attempts by 1
                    email_attempt = email_attempt + 1;
                    // Call the 'disableForm' function to check if the number of failed attempts has been succeeded
                    disableForm();
                    // Set focus to 'Email' text field so that the user can retype their input
                    txtEmail.Focus();
                    // Terminate the event handler and return to login form
                    return;
                }
                // Close database connection
                con.Close();
            }
        }

        // When the 'Close' button is clicked
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
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

        // When the 'View Password' icon is clicked
        private void pbxViewPassword_Click(object sender, EventArgs e)
        {
            // Change the password characters to normal format
            txtPassword.PasswordChar = '\0';
            pbxViewPassword.Visible = false;
            pbxHidePassword.Visible = true;
        }

        // Countdown timer
        private void tmrLogin_Tick(object sender, EventArgs e)
        {
            // If countdown timer reaches zero
            if (count == 0)
            {
                // Disable timer
                tmrLogin.Enabled = false;
                // Enable 'Login' button
                btnLogin.Enabled = true;
                // Enable 'Email' text field
                txtEmail.Enabled = true;
                // Enable 'Password' text field
                txtPassword.Enabled = true;
                // Restore login button text
                btnLogin.Text = "Login";
                // Focus on the 'Email' field
                txtEmail.Focus();
            }
            // If count does not equal zero
            else
            {
                // Display countdown text on login button
                btnLogin.Text = "Log in " + count;
                count = count - 1;
            }
        }

        // When login form loads
        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Set number of login attempts to zero
            email_attempt = 0;
            password_attempt = 0;
        }

        // When register link is clicked
        private void linklblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Create instance of 'Register' form
            var registerform = new frmRegister();
            // Display 'Register' form
            registerform.Show();
            // Hide current form
            this.Hide();
        }

        private void lnklblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Create instance of 'Forgot Password' form
            var forgotForm = new frmForgotPassword();
            // Display 'Forgot Password' form
            forgotForm.Show();
            // Hide current form
            this.Hide();
        }

        // When the 'Hide Password' icon is clicked
        private void pbxHidePassword_Click(object sender, EventArgs e)
        {
            // Change the password characters to hidden format
            txtPassword.PasswordChar = '•';
            pbxHidePassword.Visible = false;
            pbxViewPassword.Visible = true;
        }

    }
}
