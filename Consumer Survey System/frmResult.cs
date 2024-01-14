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
    public partial class frmResult : Form
    {
        public frmResult()
        {
            InitializeComponent();
        }

        // Database connection string
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\Consumer Survey System\Consumer Survey System\database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;

        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        private void frmResult_Load(object sender, EventArgs e)
        {
            // Open database connection
            con.Open();
            // Retrieve selected survey from 'survey table
            cmd = new SqlCommand("SELECT * FROM survey WHERE id= '" + frmAdminMain.surveyID + "'", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            // Store retrieved results in datatable
            da.Fill(dt);
            // Retrieve survey name
            lblSurveyName.Text = dt.Rows[0]["name"].ToString();
            // Set survey name to upper case
            lblSurveyName.Text.ToUpper();
            // Close database connection
            con.Close();

            // Open database connection
            con.Open();
            // Retrieve results of selected survey
            cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "'", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            // Store results in dataset
            da.Fill(ds);
            // Close connection string
            con.Close();

            // If dataset does not contain any row (data)
            if (ds.Tables[0].Rows.Count == 0)
            {
                // Display error message
                MessageBox.Show("There are currently no results for this survey. Please select a different survey.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Open database connection
                con.Open();
                // Retrieve questions for selected survey
                cmd = new SqlCommand("SELECT * FROM question WHERE survey_id= '" + frmAdminMain.surveyID + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                // Store retrieved results in dataset
                da.Fill(dt);
                // Close connection string
                con.Close();

                // Show results for question 1
                if (dt.Rows.Count > 0)
                {
                    lblDescription1.Text = dt.Rows[0]["description"].ToString();

                    if (dt.Rows[0]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo1.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes1.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo1.Text = count;

                    }
                    if (dt.Rows[0]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale1.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q1.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q1.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q1.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q1.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q1.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q1.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q1.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q1.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q1.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q1.Text = count;
                    }
                    if (dt.Rows[0]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert1.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree1.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree1.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral1.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree1.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[0]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree1.Text = count;

                    }
                }

                // Show results for question 2
                if (dt.Rows.Count > 1)
                {
                    gbxQuestion2.Visible = true;

                    lblDescription2.Text = dt.Rows[1]["description"].ToString();

                    if (dt.Rows[1]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo2.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes2.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo2.Text = count;
                    }
                    if (dt.Rows[1]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale2.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q2.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q2.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q2.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q2.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q2.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q2.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q2.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q2.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q2.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q2.Text = count;
                    }
                    if (dt.Rows[1]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert2.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree2.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree2.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral2.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree2.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[1]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree2.Text = count;
                    }
                }

                // Show results for question 3
                if (dt.Rows.Count > 2)
                {
                    gbxQuestion3.Visible = true;

                    lblDescription3.Text = dt.Rows[2]["description"].ToString();

                    if (dt.Rows[2]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo3.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes3.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo3.Text = count;
                    }
                    if (dt.Rows[2]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale3.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q3.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q3.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q3.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q3.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q3.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q3.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q3.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q3.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q3.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q3.Text = count;
                    }
                    if (dt.Rows[2]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert3.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree3.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree3.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral3.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree3.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[2]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree3.Text = count;
                    }
                }

                // Show results for question 4
                if (dt.Rows.Count > 3)
                {
                    gbxQuestion4.Visible = true;

                    lblDescription4.Text = dt.Rows[3]["description"].ToString();

                    if (dt.Rows[3]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo4.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes4.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo4.Text = count;
                    }
                    if (dt.Rows[3]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale4.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q4.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q4.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q4.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q4.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q4.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q4.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q4.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q4.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q4.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q4.Text = count;
                    }
                    if (dt.Rows[3]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert4.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree4.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree4.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral4.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree4.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[3]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree4.Text = count;
                    }
                }

                // Show results for question 5
                if (dt.Rows.Count > 4)
                {
                    gbxQuestion5.Visible = true;

                    lblDescription5.Text = dt.Rows[4]["description"].ToString();

                    if (dt.Rows[4]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo5.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes5.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo5.Text = count;
                    }
                    if (dt.Rows[4]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale5.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q5.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q5.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q5.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q5.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q5.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q5.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q5.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q5.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q5.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q5.Text = count;
                    }
                    if (dt.Rows[4]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert5.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree5.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree5.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral5.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree5.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[4]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree5.Text = count;
                    }
                }

                // Show results for question 6
                if (dt.Rows.Count > 5)
                {
                    gbxQuestion6.Visible = true;

                    lblDescription6.Text = dt.Rows[5]["description"].ToString();

                    if (dt.Rows[5]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo6.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes6.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo6.Text = count;
                    }
                    if (dt.Rows[5]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale6.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q6.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q6.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q6.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q6.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q6.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q6.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q6.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q6.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q6.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q6.Text = count;
                    }
                    if (dt.Rows[5]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert6.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree6.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree6.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral6.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree6.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[5]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree6.Text = count;
                    }
                }

                // Show results for question 7
                if (dt.Rows.Count > 6)
                {
                    gbxQuestion7.Visible = true;

                    lblDescription7.Text = dt.Rows[6]["description"].ToString();

                    if (dt.Rows[6]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo7.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes7.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo7.Text = count;
                    }
                    if (dt.Rows[6]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale7.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q7.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q7.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q7.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q7.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q7.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q7.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q7.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q7.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q7.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q7.Text = count;
                    }
                    if (dt.Rows[6]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert7.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree7.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree7.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral7.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree7.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[6]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree7.Text = count;
                    }
                }

                // Show results for question 8
                if (dt.Rows.Count > 7)
                {
                    gbxQuestion8.Visible = true;

                    lblDescription8.Text = dt.Rows[7]["description"].ToString();

                    if (dt.Rows[7]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo8.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes8.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo8.Text = count;
                    }
                    if (dt.Rows[7]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale8.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q8.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q8.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q8.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q8.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q8.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q8.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q8.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q8.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q8.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q8.Text = count;
                    }
                    if (dt.Rows[7]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert8.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree8.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree8.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral8.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree8.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[7]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree8.Text = count;
                    }
                }

                // Show results for question 9
                if (dt.Rows.Count > 8)
                {
                    gbxQuestion9.Visible = true;

                    lblDescription9.Text = dt.Rows[8]["description"].ToString();

                    if (dt.Rows[8]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo9.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes9.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo9.Text = count;
                    }
                    if (dt.Rows[8]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale9.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q9.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q9.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q9.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q9.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q9.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q9.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q9.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q9.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q9.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q9.Text = count;
                    }
                    if (dt.Rows[8]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert9.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree9.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree9.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral9.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree9.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[8]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree9.Text = count;
                    }
                }

                // Show results for question 10
                if (dt.Rows.Count > 9)
                {
                    gbxQuestion10.Visible = true;

                    lblDescription10.Text = dt.Rows[9]["description"].ToString();

                    if (dt.Rows[9]["question_format"].ToString() == "Yes or No")
                    {
                        pnlYesNo10.Visible = true;

                        string count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND yes = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Yes: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Yes: 1 person";
                        }
                        else
                        {
                            count = "Yes: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblYes10.Text = count;

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND no = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "No: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "No: 1 person";
                        }
                        else
                        {
                            count = "No: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNo10.Text = count;
                    }
                    if (dt.Rows[9]["question_format"].ToString() == "1-10 Rating Scale")
                    {
                        pnlRatingScale10.Visible = true;

                        string count;

                        // One / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND one = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "1: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "1: 1 person";
                        }
                        else
                        {
                            count = "1: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore1Q10.Text = count;

                        // Two / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND two = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "2: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "2: 1 person";
                        }
                        else
                        {
                            count = "2: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore2Q10.Text = count;

                        // Three / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND three = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "3: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "3: 1 person";
                        }
                        else
                        {
                            count = "3: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore3Q10.Text = count;

                        // Four / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND four = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "4: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "4: 1 person";
                        }
                        else
                        {
                            count = "4: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore4Q10.Text = count;

                        // Five / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND five = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "5: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "5: 1 person";
                        }
                        else
                        {
                            count = "5: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore5Q10.Text = count;

                        // Six / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND six = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "6: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "6: 1 person";
                        }
                        else
                        {
                            count = "6: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore6Q10.Text = count;

                        // Seven / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND seven = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "7: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "7: 1 person";
                        }
                        else
                        {
                            count = "7: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore7Q10.Text = count;

                        // Eight / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND eight = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "8: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "8: 1 person";
                        }
                        else
                        {
                            count = "8: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore8Q10.Text = count;

                        // Nine / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND nine = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "9: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "9: 1 person";
                        }
                        else
                        {
                            count = "9: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore9Q10.Text = count;

                        // Ten / Ten

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND ten = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "10: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "10: 1 person";
                        }
                        else
                        {
                            count = "10: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblScore10Q10.Text = count;
                    }
                    if (dt.Rows[9]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                    {
                        pnlFivePointLikert10.Visible = true;

                        string count;

                        // Strongly Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND strongly_agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Agree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyAgree10.Text = count;

                        // Agree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND agree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Agree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Agree: 1 person";
                        }
                        else
                        {
                            count = "Agree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblAgree10.Text = count;

                        // Neutral

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND neutral = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Neutral: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Neutral: 1 person";
                        }
                        else
                        {
                            count = "Neutral: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblNeutral10.Text = count;

                        // Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Disagree: 1 person";
                        }
                        else
                        {
                            count = "Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblDisagree10.Text = count;

                        // Strongly Disagree

                        con.Open();
                        cmd = new SqlCommand("SELECT * FROM result WHERE survey_id= '" + frmAdminMain.surveyID + "' AND question_id= '" + dt.Rows[9]["id"].ToString() + "' AND strongly_disagree = 1", con);
                        da = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        da.Fill(ds);
                        con.Close();
                        if (ds.Tables[0].Rows.Count == 0)
                        {
                            count = "Strongly Disagree: 0 people";
                        }
                        else if (ds.Tables[0].Rows.Count == 1)
                        {
                            count = "Strongly Disagree: 1 person";
                        }
                        else
                        {
                            count = "Strongly Disagree: " + ds.Tables[0].Rows.Count.ToString() + " people";
                        }
                        lblStronglyDisagree10.Text = count;
                    }
                }
            }
        }

        // When 'Back' button is clicked
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Close current form to display main form
            this.Close();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {

        }
    }
}