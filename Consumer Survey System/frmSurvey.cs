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
    public partial class frmSurvey : Form
    {
        public frmSurvey()
        {
            InitializeComponent();
        }

        // Database connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\Consumer Survey System\Consumer Survey System\database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;

        private DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        // Strings to store question formats
        public string question_format_1;
        public string question_format_2;
        public string question_format_3;
        public string question_format_4;
        public string question_format_5;
        public string question_format_6;
        public string question_format_7;
        public string question_format_8;
        public string question_format_9;
        public string question_format_10;

        // Integers to store question IDs
        public int question_id_1;
        public int question_id_2;
        public int question_id_3;
        public int question_id_4;
        public int question_id_5;
        public int question_id_6;
        public int question_id_7;
        public int question_id_8;
        public int question_id_9;
        public int question_id_10;

        private void frmSurvey_Load(object sender, EventArgs e)
        {
            // Open database connection
            con.Open();
            // Retrieve selected survey from 'survey' table
            cmd = new SqlCommand("SELECT * FROM survey WHERE id= '" + frmConsumerMain.surveyID + "'", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            // Store retrived data in datatable
            da.Fill(dt);
            lblSurveyName.Text = dt.Rows[0]["name"].ToString();
            // Set survey name to upper case
            lblSurveyName.Text.ToUpper();
            // Close databse connection
            con.Close();

            // Open database connection
            con.Open();
            // Retrieve survey question from 'question' table
            cmd = new SqlCommand("SELECT * FROM question WHERE survey_id= '" + frmConsumerMain.surveyID + "'", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            // Store retrived data in datatable
            da.Fill(dt);            

            // Display question 1 details if number of questions retrieved is more than 0
            if (dt.Rows.Count > 0)
            {
                lblDescription1.Text = dt.Rows[0]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[0]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo1.Visible = true;
                    question_format_1 = dt.Rows[0]["question_format"].ToString();
                    question_id_1 = Convert.ToInt32(dt.Rows[0]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[0]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale1.Visible = true;
                    question_format_1 = dt.Rows[0]["question_format"].ToString();
                    question_id_1 = Convert.ToInt32(dt.Rows[0]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[0]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert1.Visible = true;
                    question_format_1 = dt.Rows[0]["question_format"].ToString();
                    question_id_1 = Convert.ToInt32(dt.Rows[0]["id"]);
                }
            }

            // Display question 2 details if number of questions retrieved is more than 1
            if (dt.Rows.Count > 1)
            {
                gbxQuestion2.Visible = true;

                lblDescription2.Text = dt.Rows[1]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[1]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo2.Visible = true;
                    question_format_2 = dt.Rows[1]["question_format"].ToString();
                    question_id_2 = Convert.ToInt32(dt.Rows[1]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[1]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale2.Visible = true;
                    question_format_2 = dt.Rows[1]["question_format"].ToString();
                    question_id_2 = Convert.ToInt32(dt.Rows[1]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[1]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert2.Visible = true;
                    question_format_2 = dt.Rows[1]["question_format"].ToString();
                    question_id_2 = Convert.ToInt32(dt.Rows[1]["id"]);
                }
            }

            // Display question 3 details if number of questions retrieved is more than 2
            if (dt.Rows.Count > 2)
            {
                gbxQuestion3.Visible = true;

                lblDescription3.Text = dt.Rows[2]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[2]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo3.Visible = true;
                    question_format_3 = dt.Rows[2]["question_format"].ToString();
                    question_id_3 = Convert.ToInt32(dt.Rows[2]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[2]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale3.Visible = true;
                    question_format_3 = dt.Rows[2]["question_format"].ToString();
                    question_id_3 = Convert.ToInt32(dt.Rows[2]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[2]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert3.Visible = true;
                    question_format_3 = dt.Rows[2]["question_format"].ToString();
                    question_id_3 = Convert.ToInt32(dt.Rows[2]["id"]);
                }
            }

            // Display question 4 details if number of questions retrieved is more than 3
            if (dt.Rows.Count > 3)
            {
                gbxQuestion4.Visible = true;

                lblDescription4.Text = dt.Rows[3]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[3]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo4.Visible = true;
                    question_format_4 = dt.Rows[3]["question_format"].ToString();
                    question_id_4 = Convert.ToInt32(dt.Rows[3]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[3]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale4.Visible = true;
                    question_format_4 = dt.Rows[3]["question_format"].ToString();
                    question_id_4 = Convert.ToInt32(dt.Rows[3]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[3]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert4.Visible = true;
                    question_format_4 = dt.Rows[3]["question_format"].ToString();
                    question_id_4 = Convert.ToInt32(dt.Rows[3]["id"]);
                }
            }

            // Display question 5 details if number of questions retrieved is more than 4
            if (dt.Rows.Count > 4)
            {
                gbxQuestion5.Visible = true;

                lblDescription5.Text = dt.Rows[4]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[4]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo5.Visible = true;
                    question_format_5 = dt.Rows[4]["question_format"].ToString();
                    question_id_5 = Convert.ToInt32(dt.Rows[4]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[4]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale5.Visible = true;
                    question_format_5 = dt.Rows[4]["question_format"].ToString();
                    question_id_5 = Convert.ToInt32(dt.Rows[4]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[4]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert5.Visible = true;
                    question_format_5 = dt.Rows[4]["question_format"].ToString();
                    question_id_5 = Convert.ToInt32(dt.Rows[4]["id"]);
                }
            }

            // Display question 6 details if number of questions retrieved is more than 5
            if (dt.Rows.Count > 5)
            {
                gbxQuestion6.Visible = true;

                lblDescription6.Text = dt.Rows[5]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[5]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo6.Visible = true;
                    question_format_6 = dt.Rows[5]["question_format"].ToString();
                    question_id_6 = Convert.ToInt32(dt.Rows[5]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[5]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale6.Visible = true;
                    question_format_6 = dt.Rows[5]["question_format"].ToString();
                    question_id_6 = Convert.ToInt32(dt.Rows[5]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[5]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert6.Visible = true;
                    question_format_6 = dt.Rows[5]["question_format"].ToString();
                    question_id_6 = Convert.ToInt32(dt.Rows[5]["id"]);
                }
            }

            // Display question 7 details if number of questions retrieved is more than 6
            if (dt.Rows.Count > 6)
            {
                gbxQuestion7.Visible = true;

                lblDescription7.Text = dt.Rows[6]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[6]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo7.Visible = true;
                    question_format_7 = dt.Rows[6]["question_format"].ToString();
                    question_id_7 = Convert.ToInt32(dt.Rows[6]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[6]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale7.Visible = true;
                    question_format_7 = dt.Rows[6]["question_format"].ToString();
                    question_id_7 = Convert.ToInt32(dt.Rows[6]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[6]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert7.Visible = true;
                    question_format_7 = dt.Rows[6]["question_format"].ToString();
                    question_id_7 = Convert.ToInt32(dt.Rows[6]["id"]);
                }
            }

            // Display question 8 details if number of questions retrieved is more than 7
            if (dt.Rows.Count > 7)
            {
                gbxQuestion8.Visible = true;

                lblDescription8.Text = dt.Rows[7]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[7]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo8.Visible = true;
                    question_format_8 = dt.Rows[7]["question_format"].ToString();
                    question_id_8 = Convert.ToInt32(dt.Rows[7]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[7]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale8.Visible = true;
                    question_format_8 = dt.Rows[7]["question_format"].ToString();
                    question_id_8 = Convert.ToInt32(dt.Rows[7]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[7]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert8.Visible = true;
                    question_format_8 = dt.Rows[7]["question_format"].ToString();
                    question_id_8 = Convert.ToInt32(dt.Rows[7]["id"]);
                }
            }

            // Display question 9 details if number of questions retrieved is more than 8
            if (dt.Rows.Count > 8)
            {
                gbxQuestion9.Visible = true;

                lblDescription9.Text = dt.Rows[8]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[8]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo9.Visible = true;
                    question_format_9 = dt.Rows[8]["question_format"].ToString();
                    question_id_9 = Convert.ToInt32(dt.Rows[8]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[8]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale9.Visible = true;
                    question_format_9 = dt.Rows[8]["question_format"].ToString();
                    question_id_9 = Convert.ToInt32(dt.Rows[8]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[8]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert9.Visible = true;
                    question_format_9 = dt.Rows[8]["question_format"].ToString();
                    question_id_9 = Convert.ToInt32(dt.Rows[8]["id"]);
                }
            }

            // Display question 10 details if number of questions retrieved is more than 9
            if (dt.Rows.Count > 9)
            {
                gbxQuestion10.Visible = true;

                lblDescription10.Text = dt.Rows[9]["description"].ToString();

                // Display 'Yes or No' panel if question format is 'Yes or No'
                if (dt.Rows[9]["question_format"].ToString() == "Yes or No")
                {
                    pnlYesNo10.Visible = true;
                    question_format_10 = dt.Rows[9]["question_format"].ToString();
                    question_id_10 = Convert.ToInt32(dt.Rows[9]["id"]);
                }
                // Display '1-10 Rating Scale' panel if question format is '1-10 Rating Scale'
                if (dt.Rows[9]["question_format"].ToString() == "1-10 Rating Scale")
                {
                    pnlRatingScale10.Visible = true;
                    question_format_10 = dt.Rows[9]["question_format"].ToString();
                    question_id_10 = Convert.ToInt32(dt.Rows[9]["id"]);
                }
                // Display 'Likert Scale' if question format is '5-point Likert Scale'
                if (dt.Rows[9]["question_format"].ToString() == "Agree/Disagree 5-point Likert Scale")
                {
                    pnlFivePointLikert10.Visible = true;
                    question_format_10 = dt.Rows[9]["question_format"].ToString();
                    question_id_10 = Convert.ToInt32(dt.Rows[9]["id"]);
                }
            }

            // Close database connection
            con.Close();

        }

        private void btnSubmitSurvey_Click(object sender, EventArgs e)
        {
            // Display confirmation message when user clicks 'Submit' button
            if (MessageBox.Show("Are you sure you want to submit this survey?",
                               "Consumer Survey System",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Information) == DialogResult.OK)
            {
                // STORE QUESTION ANSWERS IN 'RESULT' TABLE
                
                // Question 1
                if (question_format_1 == "Yes or No")
                {
                    if (rbtnYes1.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo1.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 1", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_1 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree1.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree1.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral1.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree1.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree1.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 1", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_1 == "1-10 Rating Scale")
                {
                    if (lblScore1Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "',  '" + question_id_1 + "','" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q1.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription1.Text + "', '" + question_format_1 + "', '" + question_id_1 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 1", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Question 2
                if (question_format_2 == "Yes or No")
                {
                    if (rbtnYes2.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo2.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 2", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_2 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree2.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree2.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral2.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree2.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree2.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 2", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_2 == "1-10 Rating Scale")
                {
                    if (lblScore1Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q2.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription2.Text + "', '" + question_format_2 + "', '" + question_id_2 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 2", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Question 3
                if (question_format_3 == "Yes or No")
                {
                    if (rbtnYes3.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo3.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 3", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_3 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree3.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree3.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral3.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree3.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree3.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 3", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_3 == "1-10 Rating Scale")
                {
                    if (lblScore1Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q3.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription3.Text + "', '" + question_format_3 + "', '" + question_id_3 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 3", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Question 4
                if (question_format_4 == "Yes or No")
                {
                    if (rbtnYes4.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo4.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 4", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_4 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree4.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree4.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral4.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "',  '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree4.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "',  '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree4.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "',  '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 4", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_4 == "1-10 Rating Scale")
                {
                    if (lblScore1Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q4.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription4.Text + "', '" + question_format_4 + "', '" + question_id_4 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 4", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Question 5
                if (question_format_5 == "Yes or No")
                {
                    if (rbtnYes5.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo5.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 3", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_5 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree5.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree5.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral5.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree5.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree5.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 3", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_5 == "1-10 Rating Scale")
                {
                    if (lblScore1Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q5.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) " + " VALUES (@surveyID, @description, @questionFormat, @questionID, @value)", con);
                        cmd.Parameters.AddWithValue("@surveyID", frmConsumerMain.surveyID.ToString());
                        cmd.Parameters.AddWithValue("@description", lblDescription5.Text);
                        cmd.Parameters.AddWithValue("@questionFormat", question_format_5);
                        cmd.Parameters.AddWithValue("@questionID", question_id_5);
                        cmd.Parameters.AddWithValue("@value", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 5", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Question 6
                if (question_format_6 == "Yes or No")
                {
                    if (rbtnYes6.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo6.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 6", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_6 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree6.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree6.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral6.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "',  '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree6.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "',  '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree6.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "',  '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 6", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_6 == "1-10 Rating Scale")
                {
                    if (lblScore1Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q6.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription6.Text + "', '" + question_format_6 + "', '" + question_id_6 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 6", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Question 7
                if (question_format_7 == "Yes or No")
                {
                    if (rbtnYes7.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo7.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 7", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_7 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree7.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree7.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral7.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree7.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree7.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 7", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_7 == "1-10 Rating Scale")
                {
                    if (lblScore1Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q7.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription7.Text + "', '" + question_format_7 + "', '" + question_id_7 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 7", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Question 8
                if (question_format_8 == "Yes or No")
                {
                    if (rbtnYes8.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo8.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 8", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_8 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree8.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree8.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral8.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree8.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree8.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 8", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_8 == "1-10 Rating Scale")
                {
                    if (lblScore1Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q8.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription8.Text + "', '" + question_format_8 + "', '" + question_id_8 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 8", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Question 9
                if (question_format_9 == "Yes or No")
                {
                    if (rbtnYes9.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo9.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 9", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_9 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree9.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree9.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral9.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree9.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree9.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 9", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_9 == "1-10 Rating Scale")
                {
                    if (lblScore1Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q9.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription9.Text + "', '" + question_format_9 + "', '" + question_id_9 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 9", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Question 10
                if (question_format_10 == "Yes or No")
                {
                    if (rbtnYes10.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, yes) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNo10.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, no) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 10", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_10 == "Agree/Disagree 5-point Likert Scale")
                {
                    if (rbtnStronglyDisagree10.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnDisagree10.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, disagree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnNeutral10.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, neutral) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnAgree10.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (rbtnStronglyAgree10.Checked == true)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, strongly_agree) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 10", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (question_format_10 == "1-10 Rating Scale")
                {
                    if (lblScore1Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, one) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore2Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, two) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore3Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, three) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore4Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, four) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore5Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, five) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore6Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, six) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore7Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, seven) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore8Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, eight) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore9Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, nine) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (lblScore10Q10.BackColor == Color.Black)
                    {
                        cmd = new SqlCommand("INSERT INTO result (survey_id, description, question_format, question_id, ten) VALUES ('" + frmConsumerMain.surveyID.ToString() + "','" + lblDescription10.Text + "', '" + question_format_10 + "', '" + question_id_10 + "', '" + 1 + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please select an option for Question 10", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Dsiplay success message and return user to home page
                MessageBox.Show("Thank for participating in this survey.", "Consumer Survey System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                return;
            }   

        }

        // THE FOLLOWING LINES OF CODE HIGHLIGHT THE SELECTED RATING ON THE LIKERT SCALE 

        // Question 1 Likert Scale Highlighting

        private void lblScore1Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = Color.White;
            lblScore1Q1.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q1.ForeColor = SystemColors.ControlText;
            lblScore2Q1.BackColor = SystemColors.Control;
            lblScore3Q1.ForeColor = SystemColors.ControlText;
            lblScore3Q1.BackColor = SystemColors.Control;
            lblScore4Q1.ForeColor = SystemColors.ControlText;
            lblScore4Q1.BackColor = SystemColors.Control;
            lblScore5Q1.ForeColor = SystemColors.ControlText;
            lblScore5Q1.BackColor = SystemColors.Control;
            lblScore6Q1.ForeColor = SystemColors.ControlText;
            lblScore6Q1.BackColor = SystemColors.Control;
            lblScore7Q1.ForeColor = SystemColors.ControlText;
            lblScore7Q1.BackColor = SystemColors.Control;
            lblScore8Q1.ForeColor = SystemColors.ControlText;
            lblScore8Q1.BackColor = SystemColors.Control;
            lblScore9Q1.ForeColor = SystemColors.ControlText;
            lblScore9Q1.BackColor = SystemColors.Control;
            lblScore10Q1.ForeColor = SystemColors.ControlText;
            lblScore10Q1.BackColor = SystemColors.Control;
        }

        private void lblScore2Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = SystemColors.ControlText;
            lblScore1Q1.BackColor = SystemColors.Control;
            lblScore2Q1.ForeColor = Color.White;
            lblScore2Q1.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q1.ForeColor = SystemColors.ControlText;
            lblScore3Q1.BackColor = SystemColors.Control;
            lblScore4Q1.ForeColor = SystemColors.ControlText;
            lblScore4Q1.BackColor = SystemColors.Control;
            lblScore5Q1.ForeColor = SystemColors.ControlText;
            lblScore5Q1.BackColor = SystemColors.Control;
            lblScore6Q1.ForeColor = SystemColors.ControlText;
            lblScore6Q1.BackColor = SystemColors.Control;
            lblScore7Q1.ForeColor = SystemColors.ControlText;
            lblScore7Q1.BackColor = SystemColors.Control;
            lblScore8Q1.ForeColor = SystemColors.ControlText;
            lblScore8Q1.BackColor = SystemColors.Control;
            lblScore9Q1.ForeColor = SystemColors.ControlText;
            lblScore9Q1.BackColor = SystemColors.Control;
            lblScore10Q1.ForeColor = SystemColors.ControlText;
            lblScore10Q1.BackColor = SystemColors.Control;
        }

        private void lblScore3Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = SystemColors.ControlText;
            lblScore1Q1.BackColor = SystemColors.Control;
            lblScore2Q1.ForeColor = SystemColors.ControlText;
            lblScore2Q1.BackColor = SystemColors.Control;
            lblScore3Q1.ForeColor = Color.White;
            lblScore3Q1.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q1.ForeColor = SystemColors.ControlText;
            lblScore4Q1.BackColor = SystemColors.Control;
            lblScore5Q1.ForeColor = SystemColors.ControlText;
            lblScore5Q1.BackColor = SystemColors.Control;
            lblScore6Q1.ForeColor = SystemColors.ControlText;
            lblScore6Q1.BackColor = SystemColors.Control;
            lblScore7Q1.ForeColor = SystemColors.ControlText;
            lblScore7Q1.BackColor = SystemColors.Control;
            lblScore8Q1.ForeColor = SystemColors.ControlText;
            lblScore8Q1.BackColor = SystemColors.Control;
            lblScore9Q1.ForeColor = SystemColors.ControlText;
            lblScore9Q1.BackColor = SystemColors.Control;
            lblScore10Q1.ForeColor = SystemColors.ControlText;
            lblScore10Q1.BackColor = SystemColors.Control;
        }

        private void lblScore4Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = SystemColors.ControlText;
            lblScore1Q1.BackColor = SystemColors.Control;
            lblScore2Q1.ForeColor = SystemColors.ControlText;
            lblScore2Q1.BackColor = SystemColors.Control;
            lblScore3Q1.ForeColor = SystemColors.ControlText;
            lblScore3Q1.BackColor = SystemColors.Control;
            lblScore4Q1.ForeColor = Color.White;
            lblScore4Q1.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q1.ForeColor = SystemColors.ControlText;
            lblScore5Q1.BackColor = SystemColors.Control;
            lblScore6Q1.ForeColor = SystemColors.ControlText;
            lblScore6Q1.BackColor = SystemColors.Control;
            lblScore7Q1.ForeColor = SystemColors.ControlText;
            lblScore7Q1.BackColor = SystemColors.Control;
            lblScore8Q1.ForeColor = SystemColors.ControlText;
            lblScore8Q1.BackColor = SystemColors.Control;
            lblScore9Q1.ForeColor = SystemColors.ControlText;
            lblScore9Q1.BackColor = SystemColors.Control;
            lblScore10Q1.ForeColor = SystemColors.ControlText;
            lblScore10Q1.BackColor = SystemColors.Control;
        }

        private void lblScore5Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = SystemColors.ControlText;
            lblScore1Q1.BackColor = SystemColors.Control;
            lblScore2Q1.ForeColor = SystemColors.ControlText;
            lblScore2Q1.BackColor = SystemColors.Control;
            lblScore3Q1.ForeColor = SystemColors.ControlText;
            lblScore3Q1.BackColor = SystemColors.Control;
            lblScore4Q1.ForeColor = SystemColors.ControlText;
            lblScore4Q1.BackColor = SystemColors.Control;
            lblScore5Q1.ForeColor = Color.White;
            lblScore5Q1.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q1.ForeColor = SystemColors.ControlText;
            lblScore6Q1.BackColor = SystemColors.Control;
            lblScore7Q1.ForeColor = SystemColors.ControlText;
            lblScore7Q1.BackColor = SystemColors.Control;
            lblScore8Q1.ForeColor = SystemColors.ControlText;
            lblScore8Q1.BackColor = SystemColors.Control;
            lblScore9Q1.ForeColor = SystemColors.ControlText;
            lblScore9Q1.BackColor = SystemColors.Control;
            lblScore10Q1.ForeColor = SystemColors.ControlText;
            lblScore10Q1.BackColor = SystemColors.Control;
        }

        private void lblScore6Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = SystemColors.ControlText;
            lblScore1Q1.BackColor = SystemColors.Control;
            lblScore2Q1.ForeColor = SystemColors.ControlText;
            lblScore2Q1.BackColor = SystemColors.Control;
            lblScore3Q1.ForeColor = SystemColors.ControlText;
            lblScore3Q1.BackColor = SystemColors.Control;
            lblScore4Q1.ForeColor = SystemColors.ControlText;
            lblScore4Q1.BackColor = SystemColors.Control;
            lblScore5Q1.ForeColor = SystemColors.ControlText;
            lblScore5Q1.BackColor = SystemColors.Control;
            lblScore6Q1.ForeColor = Color.White;
            lblScore6Q1.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q1.ForeColor = SystemColors.ControlText;
            lblScore7Q1.BackColor = SystemColors.Control;
            lblScore8Q1.ForeColor = SystemColors.ControlText;
            lblScore8Q1.BackColor = SystemColors.Control;
            lblScore9Q1.ForeColor = SystemColors.ControlText;
            lblScore9Q1.BackColor = SystemColors.Control;
            lblScore10Q1.ForeColor = SystemColors.ControlText;
            lblScore10Q1.BackColor = SystemColors.Control;
        }

        private void lblScore7Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = SystemColors.ControlText;
            lblScore1Q1.BackColor = SystemColors.Control;
            lblScore2Q1.ForeColor = SystemColors.ControlText;
            lblScore2Q1.BackColor = SystemColors.Control;
            lblScore3Q1.ForeColor = SystemColors.ControlText;
            lblScore3Q1.BackColor = SystemColors.Control;
            lblScore4Q1.ForeColor = SystemColors.ControlText;
            lblScore4Q1.BackColor = SystemColors.Control;
            lblScore5Q1.ForeColor = SystemColors.ControlText;
            lblScore5Q1.BackColor = SystemColors.Control;
            lblScore6Q1.ForeColor = SystemColors.ControlText;
            lblScore6Q1.BackColor = SystemColors.Control;
            lblScore7Q1.ForeColor = Color.White;
            lblScore7Q1.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q1.ForeColor = SystemColors.ControlText;
            lblScore8Q1.BackColor = SystemColors.Control;
            lblScore9Q1.ForeColor = SystemColors.ControlText;
            lblScore9Q1.BackColor = SystemColors.Control;
            lblScore10Q1.ForeColor = SystemColors.ControlText;
            lblScore10Q1.BackColor = SystemColors.Control;
        }

        private void lblScore8Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = SystemColors.ControlText;
            lblScore1Q1.BackColor = SystemColors.Control;
            lblScore2Q1.ForeColor = SystemColors.ControlText;
            lblScore2Q1.BackColor = SystemColors.Control;
            lblScore3Q1.ForeColor = SystemColors.ControlText;
            lblScore3Q1.BackColor = SystemColors.Control;
            lblScore4Q1.ForeColor = SystemColors.ControlText;
            lblScore4Q1.BackColor = SystemColors.Control;
            lblScore5Q1.ForeColor = SystemColors.ControlText;
            lblScore5Q1.BackColor = SystemColors.Control;
            lblScore6Q1.ForeColor = SystemColors.ControlText;
            lblScore6Q1.BackColor = SystemColors.Control;
            lblScore7Q1.ForeColor = SystemColors.ControlText;
            lblScore7Q1.BackColor = SystemColors.Control;
            lblScore8Q1.ForeColor = Color.White;
            lblScore8Q1.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q1.ForeColor = SystemColors.ControlText;
            lblScore9Q1.BackColor = SystemColors.Control;
            lblScore10Q1.ForeColor = SystemColors.ControlText;
            lblScore10Q1.BackColor = SystemColors.Control;
        }

        private void lblScore9Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = SystemColors.ControlText;
            lblScore1Q1.BackColor = SystemColors.Control;
            lblScore2Q1.ForeColor = SystemColors.ControlText;
            lblScore2Q1.BackColor = SystemColors.Control;
            lblScore3Q1.ForeColor = SystemColors.ControlText;
            lblScore3Q1.BackColor = SystemColors.Control;
            lblScore4Q1.ForeColor = SystemColors.ControlText;
            lblScore4Q1.BackColor = SystemColors.Control;
            lblScore5Q1.ForeColor = SystemColors.ControlText;
            lblScore5Q1.BackColor = SystemColors.Control;
            lblScore6Q1.ForeColor = SystemColors.ControlText;
            lblScore6Q1.BackColor = SystemColors.Control;
            lblScore7Q1.ForeColor = SystemColors.ControlText;
            lblScore7Q1.BackColor = SystemColors.Control;
            lblScore8Q1.ForeColor = SystemColors.ControlText;
            lblScore8Q1.BackColor = SystemColors.Control;
            lblScore9Q1.ForeColor = Color.White;
            lblScore9Q1.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q1.ForeColor = SystemColors.ControlText;
            lblScore10Q1.BackColor = SystemColors.Control;
        }

        private void lblScore10Q1_Click(object sender, EventArgs e)
        {
            lblScore1Q1.ForeColor = SystemColors.ControlText;
            lblScore1Q1.BackColor = SystemColors.Control;
            lblScore2Q1.ForeColor = SystemColors.ControlText;
            lblScore2Q1.BackColor = SystemColors.Control;
            lblScore3Q1.ForeColor = SystemColors.ControlText;
            lblScore3Q1.BackColor = SystemColors.Control;
            lblScore4Q1.ForeColor = SystemColors.ControlText;
            lblScore4Q1.BackColor = SystemColors.Control;
            lblScore5Q1.ForeColor = SystemColors.ControlText;
            lblScore5Q1.BackColor = SystemColors.Control;
            lblScore6Q1.ForeColor = SystemColors.ControlText;
            lblScore6Q1.BackColor = SystemColors.Control;
            lblScore7Q1.ForeColor = SystemColors.ControlText;
            lblScore7Q1.BackColor = SystemColors.Control;
            lblScore8Q1.ForeColor = SystemColors.ControlText;
            lblScore8Q1.BackColor = SystemColors.Control;
            lblScore9Q1.ForeColor = SystemColors.ControlText;
            lblScore9Q1.BackColor = SystemColors.Control;
            lblScore10Q1.ForeColor = Color.White;
            lblScore10Q1.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Question 2 Likert Scale Highlighting

        private void lblScore1Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = Color.White;
            lblScore1Q2.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q2.ForeColor = SystemColors.ControlText;
            lblScore2Q2.BackColor = SystemColors.Control;
            lblScore3Q2.ForeColor = SystemColors.ControlText;
            lblScore3Q2.BackColor = SystemColors.Control;
            lblScore4Q2.ForeColor = SystemColors.ControlText;
            lblScore4Q2.BackColor = SystemColors.Control;
            lblScore5Q2.ForeColor = SystemColors.ControlText;
            lblScore5Q2.BackColor = SystemColors.Control;
            lblScore6Q2.ForeColor = SystemColors.ControlText;
            lblScore6Q2.BackColor = SystemColors.Control;
            lblScore7Q2.ForeColor = SystemColors.ControlText;
            lblScore7Q2.BackColor = SystemColors.Control;
            lblScore8Q2.ForeColor = SystemColors.ControlText;
            lblScore8Q2.BackColor = SystemColors.Control;
            lblScore9Q2.ForeColor = SystemColors.ControlText;
            lblScore9Q2.BackColor = SystemColors.Control;
            lblScore10Q2.ForeColor = SystemColors.ControlText;
            lblScore10Q2.BackColor = SystemColors.Control;
        }

        private void lblScore2Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = SystemColors.ControlText;
            lblScore1Q2.BackColor = SystemColors.Control;
            lblScore2Q2.ForeColor = Color.White;
            lblScore2Q2.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q2.ForeColor = SystemColors.ControlText;
            lblScore3Q2.BackColor = SystemColors.Control;
            lblScore4Q2.ForeColor = SystemColors.ControlText;
            lblScore4Q2.BackColor = SystemColors.Control;
            lblScore5Q2.ForeColor = SystemColors.ControlText;
            lblScore5Q2.BackColor = SystemColors.Control;
            lblScore6Q2.ForeColor = SystemColors.ControlText;
            lblScore6Q2.BackColor = SystemColors.Control;
            lblScore7Q2.ForeColor = SystemColors.ControlText;
            lblScore7Q2.BackColor = SystemColors.Control;
            lblScore8Q2.ForeColor = SystemColors.ControlText;
            lblScore8Q2.BackColor = SystemColors.Control;
            lblScore9Q2.ForeColor = SystemColors.ControlText;
            lblScore9Q2.BackColor = SystemColors.Control;
            lblScore10Q2.ForeColor = SystemColors.ControlText;
            lblScore10Q2.BackColor = SystemColors.Control;
        }

        private void lblScore3Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = SystemColors.ControlText;
            lblScore1Q2.BackColor = SystemColors.Control;
            lblScore2Q2.ForeColor = SystemColors.ControlText;
            lblScore2Q2.BackColor = SystemColors.Control;
            lblScore3Q2.ForeColor = Color.White;
            lblScore3Q2.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q2.ForeColor = SystemColors.ControlText;
            lblScore4Q2.BackColor = SystemColors.Control;
            lblScore5Q2.ForeColor = SystemColors.ControlText;
            lblScore5Q2.BackColor = SystemColors.Control;
            lblScore6Q2.ForeColor = SystemColors.ControlText;
            lblScore6Q2.BackColor = SystemColors.Control;
            lblScore7Q2.ForeColor = SystemColors.ControlText;
            lblScore7Q2.BackColor = SystemColors.Control;
            lblScore8Q2.ForeColor = SystemColors.ControlText;
            lblScore8Q2.BackColor = SystemColors.Control;
            lblScore9Q2.ForeColor = SystemColors.ControlText;
            lblScore9Q2.BackColor = SystemColors.Control;
            lblScore10Q2.ForeColor = SystemColors.ControlText;
            lblScore10Q2.BackColor = SystemColors.Control;
        }

        private void lblScore4Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = SystemColors.ControlText;
            lblScore1Q2.BackColor = SystemColors.Control;
            lblScore2Q2.ForeColor = SystemColors.ControlText;
            lblScore2Q2.BackColor = SystemColors.Control;
            lblScore3Q2.ForeColor = SystemColors.ControlText;
            lblScore3Q2.BackColor = SystemColors.Control;
            lblScore4Q2.ForeColor = Color.White;
            lblScore4Q2.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q2.ForeColor = SystemColors.ControlText;
            lblScore5Q2.BackColor = SystemColors.Control;
            lblScore6Q2.ForeColor = SystemColors.ControlText;
            lblScore6Q2.BackColor = SystemColors.Control;
            lblScore7Q2.ForeColor = SystemColors.ControlText;
            lblScore7Q2.BackColor = SystemColors.Control;
            lblScore8Q2.ForeColor = SystemColors.ControlText;
            lblScore8Q2.BackColor = SystemColors.Control;
            lblScore9Q2.ForeColor = SystemColors.ControlText;
            lblScore9Q2.BackColor = SystemColors.Control;
            lblScore10Q2.ForeColor = SystemColors.ControlText;
            lblScore10Q2.BackColor = SystemColors.Control;
        }

        private void lblScore5Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = SystemColors.ControlText;
            lblScore1Q2.BackColor = SystemColors.Control;
            lblScore2Q2.ForeColor = SystemColors.ControlText;
            lblScore2Q2.BackColor = SystemColors.Control;
            lblScore3Q2.ForeColor = SystemColors.ControlText;
            lblScore3Q2.BackColor = SystemColors.Control;
            lblScore4Q2.ForeColor = SystemColors.ControlText;
            lblScore4Q2.BackColor = SystemColors.Control;
            lblScore5Q2.ForeColor = Color.White;
            lblScore5Q2.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q2.ForeColor = SystemColors.ControlText;
            lblScore6Q2.BackColor = SystemColors.Control;
            lblScore7Q2.ForeColor = SystemColors.ControlText;
            lblScore7Q2.BackColor = SystemColors.Control;
            lblScore8Q2.ForeColor = SystemColors.ControlText;
            lblScore8Q2.BackColor = SystemColors.Control;
            lblScore9Q2.ForeColor = SystemColors.ControlText;
            lblScore9Q2.BackColor = SystemColors.Control;
            lblScore10Q2.ForeColor = SystemColors.ControlText;
            lblScore10Q2.BackColor = SystemColors.Control;
        }

        private void lblScore6Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = SystemColors.ControlText;
            lblScore1Q2.BackColor = SystemColors.Control;
            lblScore2Q2.ForeColor = SystemColors.ControlText;
            lblScore2Q2.BackColor = SystemColors.Control;
            lblScore3Q2.ForeColor = SystemColors.ControlText;
            lblScore3Q2.BackColor = SystemColors.Control;
            lblScore4Q2.ForeColor = SystemColors.ControlText;
            lblScore4Q2.BackColor = SystemColors.Control;
            lblScore5Q2.ForeColor = SystemColors.ControlText;
            lblScore5Q2.BackColor = SystemColors.Control;
            lblScore6Q2.ForeColor = Color.White;
            lblScore6Q2.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q2.ForeColor = SystemColors.ControlText;
            lblScore7Q2.BackColor = SystemColors.Control;
            lblScore8Q2.ForeColor = SystemColors.ControlText;
            lblScore8Q2.BackColor = SystemColors.Control;
            lblScore9Q2.ForeColor = SystemColors.ControlText;
            lblScore9Q2.BackColor = SystemColors.Control;
            lblScore10Q2.ForeColor = SystemColors.ControlText;
            lblScore10Q2.BackColor = SystemColors.Control;
        }

        private void lblScore7Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = SystemColors.ControlText;
            lblScore1Q2.BackColor = SystemColors.Control;
            lblScore2Q2.ForeColor = SystemColors.ControlText;
            lblScore2Q2.BackColor = SystemColors.Control;
            lblScore3Q2.ForeColor = SystemColors.ControlText;
            lblScore3Q2.BackColor = SystemColors.Control;
            lblScore4Q2.ForeColor = SystemColors.ControlText;
            lblScore4Q2.BackColor = SystemColors.Control;
            lblScore5Q2.ForeColor = SystemColors.ControlText;
            lblScore5Q2.BackColor = SystemColors.Control;
            lblScore6Q2.ForeColor = SystemColors.ControlText;
            lblScore6Q2.BackColor = SystemColors.Control;
            lblScore7Q2.ForeColor = Color.White;
            lblScore7Q2.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q2.ForeColor = SystemColors.ControlText;
            lblScore8Q2.BackColor = SystemColors.Control;
            lblScore9Q2.ForeColor = SystemColors.ControlText;
            lblScore9Q2.BackColor = SystemColors.Control;
            lblScore10Q2.ForeColor = SystemColors.ControlText;
            lblScore10Q2.BackColor = SystemColors.Control;
        }

        private void lblScore8Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = SystemColors.ControlText;
            lblScore1Q2.BackColor = SystemColors.Control;
            lblScore2Q2.ForeColor = SystemColors.ControlText;
            lblScore2Q2.BackColor = SystemColors.Control;
            lblScore3Q2.ForeColor = SystemColors.ControlText;
            lblScore3Q2.BackColor = SystemColors.Control;
            lblScore4Q2.ForeColor = SystemColors.ControlText;
            lblScore4Q2.BackColor = SystemColors.Control;
            lblScore5Q2.ForeColor = SystemColors.ControlText;
            lblScore5Q2.BackColor = SystemColors.Control;
            lblScore6Q2.ForeColor = SystemColors.ControlText;
            lblScore6Q2.BackColor = SystemColors.Control;
            lblScore7Q2.ForeColor = SystemColors.ControlText;
            lblScore7Q2.BackColor = SystemColors.Control;
            lblScore8Q2.ForeColor = Color.White;
            lblScore8Q2.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q2.ForeColor = SystemColors.ControlText;
            lblScore9Q2.BackColor = SystemColors.Control;
            lblScore10Q2.ForeColor = SystemColors.ControlText;
            lblScore10Q2.BackColor = SystemColors.Control;
        }

        private void lblScore9Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = SystemColors.ControlText;
            lblScore1Q2.BackColor = SystemColors.Control;
            lblScore2Q2.ForeColor = SystemColors.ControlText;
            lblScore2Q2.BackColor = SystemColors.Control;
            lblScore3Q2.ForeColor = SystemColors.ControlText;
            lblScore3Q2.BackColor = SystemColors.Control;
            lblScore4Q2.ForeColor = SystemColors.ControlText;
            lblScore4Q2.BackColor = SystemColors.Control;
            lblScore5Q2.ForeColor = SystemColors.ControlText;
            lblScore5Q2.BackColor = SystemColors.Control;
            lblScore6Q2.ForeColor = SystemColors.ControlText;
            lblScore6Q2.BackColor = SystemColors.Control;
            lblScore7Q2.ForeColor = SystemColors.ControlText;
            lblScore7Q2.BackColor = SystemColors.Control;
            lblScore8Q2.ForeColor = SystemColors.ControlText;
            lblScore8Q2.BackColor = SystemColors.Control;
            lblScore9Q2.ForeColor = Color.White;
            lblScore9Q2.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q2.ForeColor = SystemColors.ControlText;
            lblScore10Q2.BackColor = SystemColors.Control;
        }

        private void lblScore10Q2_Click(object sender, EventArgs e)
        {
            lblScore1Q2.ForeColor = SystemColors.ControlText;
            lblScore1Q2.BackColor = SystemColors.Control;
            lblScore2Q2.ForeColor = SystemColors.ControlText;
            lblScore2Q2.BackColor = SystemColors.Control;
            lblScore3Q2.ForeColor = SystemColors.ControlText;
            lblScore3Q2.BackColor = SystemColors.Control;
            lblScore4Q2.ForeColor = SystemColors.ControlText;
            lblScore4Q2.BackColor = SystemColors.Control;
            lblScore5Q2.ForeColor = SystemColors.ControlText;
            lblScore5Q2.BackColor = SystemColors.Control;
            lblScore6Q2.ForeColor = SystemColors.ControlText;
            lblScore6Q2.BackColor = SystemColors.Control;
            lblScore7Q2.ForeColor = SystemColors.ControlText;
            lblScore7Q2.BackColor = SystemColors.Control;
            lblScore8Q2.ForeColor = SystemColors.ControlText;
            lblScore8Q2.BackColor = SystemColors.Control;
            lblScore9Q2.ForeColor = SystemColors.ControlText;
            lblScore9Q2.BackColor = SystemColors.Control;
            lblScore10Q2.ForeColor = Color.White;
            lblScore10Q2.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Question 3 Likert Scale Highlighting

        private void lblScore1Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = Color.White;
            lblScore1Q3.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q3.ForeColor = SystemColors.ControlText;
            lblScore2Q3.BackColor = SystemColors.Control;
            lblScore3Q3.ForeColor = SystemColors.ControlText;
            lblScore3Q3.BackColor = SystemColors.Control;
            lblScore4Q3.ForeColor = SystemColors.ControlText;
            lblScore4Q3.BackColor = SystemColors.Control;
            lblScore5Q3.ForeColor = SystemColors.ControlText;
            lblScore5Q3.BackColor = SystemColors.Control;
            lblScore6Q3.ForeColor = SystemColors.ControlText;
            lblScore6Q3.BackColor = SystemColors.Control;
            lblScore7Q3.ForeColor = SystemColors.ControlText;
            lblScore7Q3.BackColor = SystemColors.Control;
            lblScore8Q3.ForeColor = SystemColors.ControlText;
            lblScore8Q3.BackColor = SystemColors.Control;
            lblScore9Q3.ForeColor = SystemColors.ControlText;
            lblScore9Q3.BackColor = SystemColors.Control;
            lblScore10Q3.ForeColor = SystemColors.ControlText;
            lblScore10Q3.BackColor = SystemColors.Control;
        }

        private void lblScore2Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = SystemColors.ControlText;
            lblScore1Q3.BackColor = SystemColors.Control;
            lblScore2Q3.ForeColor = Color.White;
            lblScore2Q3.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q3.ForeColor = SystemColors.ControlText;
            lblScore3Q3.BackColor = SystemColors.Control;
            lblScore4Q3.ForeColor = SystemColors.ControlText;
            lblScore4Q3.BackColor = SystemColors.Control;
            lblScore5Q3.ForeColor = SystemColors.ControlText;
            lblScore5Q3.BackColor = SystemColors.Control;
            lblScore6Q3.ForeColor = SystemColors.ControlText;
            lblScore6Q3.BackColor = SystemColors.Control;
            lblScore7Q3.ForeColor = SystemColors.ControlText;
            lblScore7Q3.BackColor = SystemColors.Control;
            lblScore8Q3.ForeColor = SystemColors.ControlText;
            lblScore8Q3.BackColor = SystemColors.Control;
            lblScore9Q3.ForeColor = SystemColors.ControlText;
            lblScore9Q3.BackColor = SystemColors.Control;
            lblScore10Q3.ForeColor = SystemColors.ControlText;
            lblScore10Q3.BackColor = SystemColors.Control;
        }

        private void lblScore3Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = SystemColors.ControlText;
            lblScore1Q3.BackColor = SystemColors.Control;
            lblScore2Q3.ForeColor = SystemColors.ControlText;
            lblScore2Q3.BackColor = SystemColors.Control;
            lblScore3Q3.ForeColor = Color.White;
            lblScore3Q3.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q3.ForeColor = SystemColors.ControlText;
            lblScore4Q3.BackColor = SystemColors.Control;
            lblScore5Q3.ForeColor = SystemColors.ControlText;
            lblScore5Q3.BackColor = SystemColors.Control;
            lblScore6Q3.ForeColor = SystemColors.ControlText;
            lblScore6Q3.BackColor = SystemColors.Control;
            lblScore7Q3.ForeColor = SystemColors.ControlText;
            lblScore7Q3.BackColor = SystemColors.Control;
            lblScore8Q3.ForeColor = SystemColors.ControlText;
            lblScore8Q3.BackColor = SystemColors.Control;
            lblScore9Q3.ForeColor = SystemColors.ControlText;
            lblScore9Q3.BackColor = SystemColors.Control;
            lblScore10Q3.ForeColor = SystemColors.ControlText;
            lblScore10Q3.BackColor = SystemColors.Control;
        }

        private void lblScore4Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = SystemColors.ControlText;
            lblScore1Q3.BackColor = SystemColors.Control;
            lblScore2Q3.ForeColor = SystemColors.ControlText;
            lblScore2Q3.BackColor = SystemColors.Control;
            lblScore3Q3.ForeColor = SystemColors.ControlText;
            lblScore3Q3.BackColor = SystemColors.Control;
            lblScore4Q3.ForeColor = Color.White;
            lblScore4Q3.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q3.ForeColor = SystemColors.ControlText;
            lblScore5Q3.BackColor = SystemColors.Control;
            lblScore6Q3.ForeColor = SystemColors.ControlText;
            lblScore6Q3.BackColor = SystemColors.Control;
            lblScore7Q3.ForeColor = SystemColors.ControlText;
            lblScore7Q3.BackColor = SystemColors.Control;
            lblScore8Q3.ForeColor = SystemColors.ControlText;
            lblScore8Q3.BackColor = SystemColors.Control;
            lblScore9Q3.ForeColor = SystemColors.ControlText;
            lblScore9Q3.BackColor = SystemColors.Control;
            lblScore10Q3.ForeColor = SystemColors.ControlText;
            lblScore10Q3.BackColor = SystemColors.Control;
        }

        private void lblScore5Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = SystemColors.ControlText;
            lblScore1Q3.BackColor = SystemColors.Control;
            lblScore2Q3.ForeColor = SystemColors.ControlText;
            lblScore2Q3.BackColor = SystemColors.Control;
            lblScore3Q3.ForeColor = SystemColors.ControlText;
            lblScore3Q3.BackColor = SystemColors.Control;
            lblScore4Q3.ForeColor = SystemColors.ControlText;
            lblScore4Q3.BackColor = SystemColors.Control;
            lblScore5Q3.ForeColor = Color.White;
            lblScore5Q3.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q3.ForeColor = SystemColors.ControlText;
            lblScore6Q3.BackColor = SystemColors.Control;
            lblScore7Q3.ForeColor = SystemColors.ControlText;
            lblScore7Q3.BackColor = SystemColors.Control;
            lblScore8Q3.ForeColor = SystemColors.ControlText;
            lblScore8Q3.BackColor = SystemColors.Control;
            lblScore9Q3.ForeColor = SystemColors.ControlText;
            lblScore9Q3.BackColor = SystemColors.Control;
            lblScore10Q3.ForeColor = SystemColors.ControlText;
            lblScore10Q3.BackColor = SystemColors.Control;
        }

        private void lblScore6Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = SystemColors.ControlText;
            lblScore1Q3.BackColor = SystemColors.Control;
            lblScore2Q3.ForeColor = SystemColors.ControlText;
            lblScore2Q3.BackColor = SystemColors.Control;
            lblScore3Q3.ForeColor = SystemColors.ControlText;
            lblScore3Q3.BackColor = SystemColors.Control;
            lblScore4Q3.ForeColor = SystemColors.ControlText;
            lblScore4Q3.BackColor = SystemColors.Control;
            lblScore5Q3.ForeColor = SystemColors.ControlText;
            lblScore5Q3.BackColor = SystemColors.Control;
            lblScore6Q3.ForeColor = Color.White;
            lblScore6Q3.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q3.ForeColor = SystemColors.ControlText;
            lblScore7Q3.BackColor = SystemColors.Control;
            lblScore8Q3.ForeColor = SystemColors.ControlText;
            lblScore8Q3.BackColor = SystemColors.Control;
            lblScore9Q3.ForeColor = SystemColors.ControlText;
            lblScore9Q3.BackColor = SystemColors.Control;
            lblScore10Q3.ForeColor = SystemColors.ControlText;
            lblScore10Q3.BackColor = SystemColors.Control;
        }

        private void lblScore7Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = SystemColors.ControlText;
            lblScore1Q3.BackColor = SystemColors.Control;
            lblScore2Q3.ForeColor = SystemColors.ControlText;
            lblScore2Q3.BackColor = SystemColors.Control;
            lblScore3Q3.ForeColor = SystemColors.ControlText;
            lblScore3Q3.BackColor = SystemColors.Control;
            lblScore4Q3.ForeColor = SystemColors.ControlText;
            lblScore4Q3.BackColor = SystemColors.Control;
            lblScore5Q3.ForeColor = SystemColors.ControlText;
            lblScore5Q3.BackColor = SystemColors.Control;
            lblScore6Q3.ForeColor = SystemColors.ControlText;
            lblScore6Q3.BackColor = SystemColors.Control;
            lblScore7Q3.ForeColor = Color.White;
            lblScore7Q3.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q3.ForeColor = SystemColors.ControlText;
            lblScore8Q3.BackColor = SystemColors.Control;
            lblScore9Q3.ForeColor = SystemColors.ControlText;
            lblScore9Q3.BackColor = SystemColors.Control;
            lblScore10Q3.ForeColor = SystemColors.ControlText;
            lblScore10Q3.BackColor = SystemColors.Control;
        }

        private void lblScore8Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = SystemColors.ControlText;
            lblScore1Q3.BackColor = SystemColors.Control;
            lblScore2Q3.ForeColor = SystemColors.ControlText;
            lblScore2Q3.BackColor = SystemColors.Control;
            lblScore3Q3.ForeColor = SystemColors.ControlText;
            lblScore3Q3.BackColor = SystemColors.Control;
            lblScore4Q3.ForeColor = SystemColors.ControlText;
            lblScore4Q3.BackColor = SystemColors.Control;
            lblScore5Q3.ForeColor = SystemColors.ControlText;
            lblScore5Q3.BackColor = SystemColors.Control;
            lblScore6Q3.ForeColor = SystemColors.ControlText;
            lblScore6Q3.BackColor = SystemColors.Control;
            lblScore7Q3.ForeColor = SystemColors.ControlText;
            lblScore7Q3.BackColor = SystemColors.Control;
            lblScore8Q3.ForeColor = Color.White;
            lblScore8Q3.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q3.ForeColor = SystemColors.ControlText;
            lblScore9Q3.BackColor = SystemColors.Control;
            lblScore10Q3.ForeColor = SystemColors.ControlText;
            lblScore10Q3.BackColor = SystemColors.Control;
        }

        private void lblScore9Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = SystemColors.ControlText;
            lblScore1Q3.BackColor = SystemColors.Control;
            lblScore2Q3.ForeColor = SystemColors.ControlText;
            lblScore2Q3.BackColor = SystemColors.Control;
            lblScore3Q3.ForeColor = SystemColors.ControlText;
            lblScore3Q3.BackColor = SystemColors.Control;
            lblScore4Q3.ForeColor = SystemColors.ControlText;
            lblScore4Q3.BackColor = SystemColors.Control;
            lblScore5Q3.ForeColor = SystemColors.ControlText;
            lblScore5Q3.BackColor = SystemColors.Control;
            lblScore6Q3.ForeColor = SystemColors.ControlText;
            lblScore6Q3.BackColor = SystemColors.Control;
            lblScore7Q3.ForeColor = SystemColors.ControlText;
            lblScore7Q3.BackColor = SystemColors.Control;
            lblScore8Q3.ForeColor = SystemColors.ControlText;
            lblScore8Q3.BackColor = SystemColors.Control;
            lblScore9Q3.ForeColor = Color.White;
            lblScore9Q3.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q3.ForeColor = SystemColors.ControlText;
            lblScore10Q3.BackColor = SystemColors.Control;
        }

        private void lblScore10Q3_Click(object sender, EventArgs e)
        {
            lblScore1Q3.ForeColor = SystemColors.ControlText;
            lblScore1Q3.BackColor = SystemColors.Control;
            lblScore2Q3.ForeColor = SystemColors.ControlText;
            lblScore2Q3.BackColor = SystemColors.Control;
            lblScore3Q3.ForeColor = SystemColors.ControlText;
            lblScore3Q3.BackColor = SystemColors.Control;
            lblScore4Q3.ForeColor = SystemColors.ControlText;
            lblScore4Q3.BackColor = SystemColors.Control;
            lblScore5Q3.ForeColor = SystemColors.ControlText;
            lblScore5Q3.BackColor = SystemColors.Control;
            lblScore6Q3.ForeColor = SystemColors.ControlText;
            lblScore6Q3.BackColor = SystemColors.Control;
            lblScore7Q3.ForeColor = SystemColors.ControlText;
            lblScore7Q3.BackColor = SystemColors.Control;
            lblScore8Q3.ForeColor = SystemColors.ControlText;
            lblScore8Q3.BackColor = SystemColors.Control;
            lblScore9Q3.ForeColor = SystemColors.ControlText;
            lblScore9Q3.BackColor = SystemColors.Control;
            lblScore10Q3.ForeColor = Color.White;
            lblScore10Q3.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Question 4 Likert Scale Highlighting

        private void lblScore1Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = Color.White;
            lblScore1Q4.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q4.ForeColor = SystemColors.ControlText;
            lblScore2Q4.BackColor = SystemColors.Control;
            lblScore3Q4.ForeColor = SystemColors.ControlText;
            lblScore3Q4.BackColor = SystemColors.Control;
            lblScore4Q4.ForeColor = SystemColors.ControlText;
            lblScore4Q4.BackColor = SystemColors.Control;
            lblScore5Q4.ForeColor = SystemColors.ControlText;
            lblScore5Q4.BackColor = SystemColors.Control;
            lblScore6Q4.ForeColor = SystemColors.ControlText;
            lblScore6Q4.BackColor = SystemColors.Control;
            lblScore7Q4.ForeColor = SystemColors.ControlText;
            lblScore7Q4.BackColor = SystemColors.Control;
            lblScore8Q4.ForeColor = SystemColors.ControlText;
            lblScore8Q4.BackColor = SystemColors.Control;
            lblScore9Q4.ForeColor = SystemColors.ControlText;
            lblScore9Q4.BackColor = SystemColors.Control;
            lblScore10Q4.ForeColor = SystemColors.ControlText;
            lblScore10Q4.BackColor = SystemColors.Control;
        }

        private void lblScore2Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = SystemColors.ControlText;
            lblScore1Q4.BackColor = SystemColors.Control;
            lblScore2Q4.ForeColor = Color.White;
            lblScore2Q4.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q4.ForeColor = SystemColors.ControlText;
            lblScore3Q4.BackColor = SystemColors.Control;
            lblScore4Q4.ForeColor = SystemColors.ControlText;
            lblScore4Q4.BackColor = SystemColors.Control;
            lblScore5Q4.ForeColor = SystemColors.ControlText;
            lblScore5Q4.BackColor = SystemColors.Control;
            lblScore6Q4.ForeColor = SystemColors.ControlText;
            lblScore6Q4.BackColor = SystemColors.Control;
            lblScore7Q4.ForeColor = SystemColors.ControlText;
            lblScore7Q4.BackColor = SystemColors.Control;
            lblScore8Q4.ForeColor = SystemColors.ControlText;
            lblScore8Q4.BackColor = SystemColors.Control;
            lblScore9Q4.ForeColor = SystemColors.ControlText;
            lblScore9Q4.BackColor = SystemColors.Control;
            lblScore10Q4.ForeColor = SystemColors.ControlText;
            lblScore10Q4.BackColor = SystemColors.Control;
        }

        private void lblScore3Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = SystemColors.ControlText;
            lblScore1Q4.BackColor = SystemColors.Control;
            lblScore2Q4.ForeColor = SystemColors.ControlText;
            lblScore2Q4.BackColor = SystemColors.Control;
            lblScore3Q4.ForeColor = Color.White;
            lblScore3Q4.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q4.ForeColor = SystemColors.ControlText;
            lblScore4Q4.BackColor = SystemColors.Control;
            lblScore5Q4.ForeColor = SystemColors.ControlText;
            lblScore5Q4.BackColor = SystemColors.Control;
            lblScore6Q4.ForeColor = SystemColors.ControlText;
            lblScore6Q4.BackColor = SystemColors.Control;
            lblScore7Q4.ForeColor = SystemColors.ControlText;
            lblScore7Q4.BackColor = SystemColors.Control;
            lblScore8Q4.ForeColor = SystemColors.ControlText;
            lblScore8Q4.BackColor = SystemColors.Control;
            lblScore9Q4.ForeColor = SystemColors.ControlText;
            lblScore9Q4.BackColor = SystemColors.Control;
            lblScore10Q4.ForeColor = SystemColors.ControlText;
            lblScore10Q4.BackColor = SystemColors.Control;
        }

        private void lblScore4Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = SystemColors.ControlText;
            lblScore1Q4.BackColor = SystemColors.Control;
            lblScore2Q4.ForeColor = SystemColors.ControlText;
            lblScore2Q4.BackColor = SystemColors.Control;
            lblScore3Q4.ForeColor = SystemColors.ControlText;
            lblScore3Q4.BackColor = SystemColors.Control;
            lblScore4Q4.ForeColor = Color.White;
            lblScore4Q4.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q4.ForeColor = SystemColors.ControlText;
            lblScore5Q4.BackColor = SystemColors.Control;
            lblScore6Q4.ForeColor = SystemColors.ControlText;
            lblScore6Q4.BackColor = SystemColors.Control;
            lblScore7Q4.ForeColor = SystemColors.ControlText;
            lblScore7Q4.BackColor = SystemColors.Control;
            lblScore8Q4.ForeColor = SystemColors.ControlText;
            lblScore8Q4.BackColor = SystemColors.Control;
            lblScore9Q4.ForeColor = SystemColors.ControlText;
            lblScore9Q4.BackColor = SystemColors.Control;
            lblScore10Q4.ForeColor = SystemColors.ControlText;
            lblScore10Q4.BackColor = SystemColors.Control;
        }

        private void lblScore5Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = SystemColors.ControlText;
            lblScore1Q4.BackColor = SystemColors.Control;
            lblScore2Q4.ForeColor = SystemColors.ControlText;
            lblScore2Q4.BackColor = SystemColors.Control;
            lblScore3Q4.ForeColor = SystemColors.ControlText;
            lblScore3Q4.BackColor = SystemColors.Control;
            lblScore4Q4.ForeColor = SystemColors.ControlText;
            lblScore4Q4.BackColor = SystemColors.Control;
            lblScore5Q4.ForeColor = Color.White;
            lblScore5Q4.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q4.ForeColor = SystemColors.ControlText;
            lblScore6Q4.BackColor = SystemColors.Control;
            lblScore7Q4.ForeColor = SystemColors.ControlText;
            lblScore7Q4.BackColor = SystemColors.Control;
            lblScore8Q4.ForeColor = SystemColors.ControlText;
            lblScore8Q4.BackColor = SystemColors.Control;
            lblScore9Q4.ForeColor = SystemColors.ControlText;
            lblScore9Q4.BackColor = SystemColors.Control;
            lblScore10Q4.ForeColor = SystemColors.ControlText;
            lblScore10Q4.BackColor = SystemColors.Control;
        }

        private void lblScore6Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = SystemColors.ControlText;
            lblScore1Q4.BackColor = SystemColors.Control;
            lblScore2Q4.ForeColor = SystemColors.ControlText;
            lblScore2Q4.BackColor = SystemColors.Control;
            lblScore3Q4.ForeColor = SystemColors.ControlText;
            lblScore3Q4.BackColor = SystemColors.Control;
            lblScore4Q4.ForeColor = SystemColors.ControlText;
            lblScore4Q4.BackColor = SystemColors.Control;
            lblScore5Q4.ForeColor = SystemColors.ControlText;
            lblScore5Q4.BackColor = SystemColors.Control;
            lblScore6Q4.ForeColor = Color.White;
            lblScore6Q4.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q4.ForeColor = SystemColors.ControlText;
            lblScore7Q4.BackColor = SystemColors.Control;
            lblScore8Q4.ForeColor = SystemColors.ControlText;
            lblScore8Q4.BackColor = SystemColors.Control;
            lblScore9Q4.ForeColor = SystemColors.ControlText;
            lblScore9Q4.BackColor = SystemColors.Control;
            lblScore10Q4.ForeColor = SystemColors.ControlText;
            lblScore10Q4.BackColor = SystemColors.Control;
        }

        private void lblScore7Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = SystemColors.ControlText;
            lblScore1Q4.BackColor = SystemColors.Control;
            lblScore2Q4.ForeColor = SystemColors.ControlText;
            lblScore2Q4.BackColor = SystemColors.Control;
            lblScore3Q4.ForeColor = SystemColors.ControlText;
            lblScore3Q4.BackColor = SystemColors.Control;
            lblScore4Q4.ForeColor = SystemColors.ControlText;
            lblScore4Q4.BackColor = SystemColors.Control;
            lblScore5Q4.ForeColor = SystemColors.ControlText;
            lblScore5Q4.BackColor = SystemColors.Control;
            lblScore6Q4.ForeColor = SystemColors.ControlText;
            lblScore6Q4.BackColor = SystemColors.Control;
            lblScore7Q4.ForeColor = Color.White;
            lblScore7Q4.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q4.ForeColor = SystemColors.ControlText;
            lblScore8Q4.BackColor = SystemColors.Control;
            lblScore9Q4.ForeColor = SystemColors.ControlText;
            lblScore9Q4.BackColor = SystemColors.Control;
            lblScore10Q4.ForeColor = SystemColors.ControlText;
            lblScore10Q4.BackColor = SystemColors.Control;
        }

        private void lblScore8Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = SystemColors.ControlText;
            lblScore1Q4.BackColor = SystemColors.Control;
            lblScore2Q4.ForeColor = SystemColors.ControlText;
            lblScore2Q4.BackColor = SystemColors.Control;
            lblScore3Q4.ForeColor = SystemColors.ControlText;
            lblScore3Q4.BackColor = SystemColors.Control;
            lblScore4Q4.ForeColor = SystemColors.ControlText;
            lblScore4Q4.BackColor = SystemColors.Control;
            lblScore5Q4.ForeColor = SystemColors.ControlText;
            lblScore5Q4.BackColor = SystemColors.Control;
            lblScore6Q4.ForeColor = SystemColors.ControlText;
            lblScore6Q4.BackColor = SystemColors.Control;
            lblScore7Q4.ForeColor = SystemColors.ControlText;
            lblScore7Q4.BackColor = SystemColors.Control;
            lblScore8Q4.ForeColor = Color.White;
            lblScore8Q4.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q4.ForeColor = SystemColors.ControlText;
            lblScore9Q4.BackColor = SystemColors.Control;
            lblScore10Q4.ForeColor = SystemColors.ControlText;
            lblScore10Q4.BackColor = SystemColors.Control;
        }

        private void lblScore9Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = SystemColors.ControlText;
            lblScore1Q4.BackColor = SystemColors.Control;
            lblScore2Q4.ForeColor = SystemColors.ControlText;
            lblScore2Q4.BackColor = SystemColors.Control;
            lblScore3Q4.ForeColor = SystemColors.ControlText;
            lblScore3Q4.BackColor = SystemColors.Control;
            lblScore4Q4.ForeColor = SystemColors.ControlText;
            lblScore4Q4.BackColor = SystemColors.Control;
            lblScore5Q4.ForeColor = SystemColors.ControlText;
            lblScore5Q4.BackColor = SystemColors.Control;
            lblScore6Q4.ForeColor = SystemColors.ControlText;
            lblScore6Q4.BackColor = SystemColors.Control;
            lblScore7Q4.ForeColor = SystemColors.ControlText;
            lblScore7Q4.BackColor = SystemColors.Control;
            lblScore8Q4.ForeColor = SystemColors.ControlText;
            lblScore8Q4.BackColor = SystemColors.Control;
            lblScore9Q4.ForeColor = Color.White;
            lblScore9Q4.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q4.ForeColor = SystemColors.ControlText;
            lblScore10Q4.BackColor = SystemColors.Control;
        }

        private void lblScore10Q4_Click(object sender, EventArgs e)
        {
            lblScore1Q4.ForeColor = SystemColors.ControlText;
            lblScore1Q4.BackColor = SystemColors.Control;
            lblScore2Q4.ForeColor = SystemColors.ControlText;
            lblScore2Q4.BackColor = SystemColors.Control;
            lblScore3Q4.ForeColor = SystemColors.ControlText;
            lblScore3Q4.BackColor = SystemColors.Control;
            lblScore4Q4.ForeColor = SystemColors.ControlText;
            lblScore4Q4.BackColor = SystemColors.Control;
            lblScore5Q4.ForeColor = SystemColors.ControlText;
            lblScore5Q4.BackColor = SystemColors.Control;
            lblScore6Q4.ForeColor = SystemColors.ControlText;
            lblScore6Q4.BackColor = SystemColors.Control;
            lblScore7Q4.ForeColor = SystemColors.ControlText;
            lblScore7Q4.BackColor = SystemColors.Control;
            lblScore8Q4.ForeColor = SystemColors.ControlText;
            lblScore8Q4.BackColor = SystemColors.Control;
            lblScore9Q4.ForeColor = SystemColors.ControlText;
            lblScore9Q4.BackColor = SystemColors.Control;
            lblScore10Q4.ForeColor = Color.White;
            lblScore10Q4.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Question 5 Likert Scale Highlighting

        private void lblScore1Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = Color.White;
            lblScore1Q5.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q5.ForeColor = SystemColors.ControlText;
            lblScore2Q5.BackColor = SystemColors.Control;
            lblScore3Q5.ForeColor = SystemColors.ControlText;
            lblScore3Q5.BackColor = SystemColors.Control;
            lblScore4Q5.ForeColor = SystemColors.ControlText;
            lblScore4Q5.BackColor = SystemColors.Control;
            lblScore5Q5.ForeColor = SystemColors.ControlText;
            lblScore5Q5.BackColor = SystemColors.Control;
            lblScore6Q5.ForeColor = SystemColors.ControlText;
            lblScore6Q5.BackColor = SystemColors.Control;
            lblScore7Q5.ForeColor = SystemColors.ControlText;
            lblScore7Q5.BackColor = SystemColors.Control;
            lblScore8Q5.ForeColor = SystemColors.ControlText;
            lblScore8Q5.BackColor = SystemColors.Control;
            lblScore9Q5.ForeColor = SystemColors.ControlText;
            lblScore9Q5.BackColor = SystemColors.Control;
            lblScore10Q5.ForeColor = SystemColors.ControlText;
            lblScore10Q5.BackColor = SystemColors.Control;
        }

        private void lblScore2Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = SystemColors.ControlText;
            lblScore1Q5.BackColor = SystemColors.Control;
            lblScore2Q5.ForeColor = Color.White;
            lblScore2Q5.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q5.ForeColor = SystemColors.ControlText;
            lblScore3Q5.BackColor = SystemColors.Control;
            lblScore4Q5.ForeColor = SystemColors.ControlText;
            lblScore4Q5.BackColor = SystemColors.Control;
            lblScore5Q5.ForeColor = SystemColors.ControlText;
            lblScore5Q5.BackColor = SystemColors.Control;
            lblScore6Q5.ForeColor = SystemColors.ControlText;
            lblScore6Q5.BackColor = SystemColors.Control;
            lblScore7Q5.ForeColor = SystemColors.ControlText;
            lblScore7Q5.BackColor = SystemColors.Control;
            lblScore8Q5.ForeColor = SystemColors.ControlText;
            lblScore8Q5.BackColor = SystemColors.Control;
            lblScore9Q5.ForeColor = SystemColors.ControlText;
            lblScore9Q5.BackColor = SystemColors.Control;
            lblScore10Q5.ForeColor = SystemColors.ControlText;
            lblScore10Q5.BackColor = SystemColors.Control;
        }

        private void lblScore3Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = SystemColors.ControlText;
            lblScore1Q5.BackColor = SystemColors.Control;
            lblScore2Q5.ForeColor = SystemColors.ControlText;
            lblScore2Q5.BackColor = SystemColors.Control;
            lblScore3Q5.ForeColor = Color.White;
            lblScore3Q5.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q5.ForeColor = SystemColors.ControlText;
            lblScore4Q5.BackColor = SystemColors.Control;
            lblScore5Q5.ForeColor = SystemColors.ControlText;
            lblScore5Q5.BackColor = SystemColors.Control;
            lblScore6Q5.ForeColor = SystemColors.ControlText;
            lblScore6Q5.BackColor = SystemColors.Control;
            lblScore7Q5.ForeColor = SystemColors.ControlText;
            lblScore7Q5.BackColor = SystemColors.Control;
            lblScore8Q5.ForeColor = SystemColors.ControlText;
            lblScore8Q5.BackColor = SystemColors.Control;
            lblScore9Q5.ForeColor = SystemColors.ControlText;
            lblScore9Q5.BackColor = SystemColors.Control;
            lblScore10Q5.ForeColor = SystemColors.ControlText;
            lblScore10Q5.BackColor = SystemColors.Control;
        }

        private void lblScore4Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = SystemColors.ControlText;
            lblScore1Q5.BackColor = SystemColors.Control;
            lblScore2Q5.ForeColor = SystemColors.ControlText;
            lblScore2Q5.BackColor = SystemColors.Control;
            lblScore3Q5.ForeColor = SystemColors.ControlText;
            lblScore3Q5.BackColor = SystemColors.Control;
            lblScore4Q5.ForeColor = Color.White;
            lblScore4Q5.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q5.ForeColor = SystemColors.ControlText;
            lblScore5Q5.BackColor = SystemColors.Control;
            lblScore6Q5.ForeColor = SystemColors.ControlText;
            lblScore6Q5.BackColor = SystemColors.Control;
            lblScore7Q5.ForeColor = SystemColors.ControlText;
            lblScore7Q5.BackColor = SystemColors.Control;
            lblScore8Q5.ForeColor = SystemColors.ControlText;
            lblScore8Q5.BackColor = SystemColors.Control;
            lblScore9Q5.ForeColor = SystemColors.ControlText;
            lblScore9Q5.BackColor = SystemColors.Control;
            lblScore10Q5.ForeColor = SystemColors.ControlText;
            lblScore10Q5.BackColor = SystemColors.Control;
        }

        private void lblScore5Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = SystemColors.ControlText;
            lblScore1Q5.BackColor = SystemColors.Control;
            lblScore2Q5.ForeColor = SystemColors.ControlText;
            lblScore2Q5.BackColor = SystemColors.Control;
            lblScore3Q5.ForeColor = SystemColors.ControlText;
            lblScore3Q5.BackColor = SystemColors.Control;
            lblScore4Q5.ForeColor = SystemColors.ControlText;
            lblScore4Q5.BackColor = SystemColors.Control;
            lblScore5Q5.ForeColor = Color.White;
            lblScore5Q5.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q5.ForeColor = SystemColors.ControlText;
            lblScore6Q5.BackColor = SystemColors.Control;
            lblScore7Q5.ForeColor = SystemColors.ControlText;
            lblScore7Q5.BackColor = SystemColors.Control;
            lblScore8Q5.ForeColor = SystemColors.ControlText;
            lblScore8Q5.BackColor = SystemColors.Control;
            lblScore9Q5.ForeColor = SystemColors.ControlText;
            lblScore9Q5.BackColor = SystemColors.Control;
            lblScore10Q5.ForeColor = SystemColors.ControlText;
            lblScore10Q5.BackColor = SystemColors.Control;
        }

        private void lblScore6Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = SystemColors.ControlText;
            lblScore1Q5.BackColor = SystemColors.Control;
            lblScore2Q5.ForeColor = SystemColors.ControlText;
            lblScore2Q5.BackColor = SystemColors.Control;
            lblScore3Q5.ForeColor = SystemColors.ControlText;
            lblScore3Q5.BackColor = SystemColors.Control;
            lblScore4Q5.ForeColor = SystemColors.ControlText;
            lblScore4Q5.BackColor = SystemColors.Control;
            lblScore5Q5.ForeColor = SystemColors.ControlText;
            lblScore5Q5.BackColor = SystemColors.Control;
            lblScore6Q5.ForeColor = Color.White;
            lblScore6Q5.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q5.ForeColor = SystemColors.ControlText;
            lblScore7Q5.BackColor = SystemColors.Control;
            lblScore8Q5.ForeColor = SystemColors.ControlText;
            lblScore8Q5.BackColor = SystemColors.Control;
            lblScore9Q5.ForeColor = SystemColors.ControlText;
            lblScore9Q5.BackColor = SystemColors.Control;
            lblScore10Q5.ForeColor = SystemColors.ControlText;
            lblScore10Q5.BackColor = SystemColors.Control;
        }

        private void lblScore7Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = SystemColors.ControlText;
            lblScore1Q5.BackColor = SystemColors.Control;
            lblScore2Q5.ForeColor = SystemColors.ControlText;
            lblScore2Q5.BackColor = SystemColors.Control;
            lblScore3Q5.ForeColor = SystemColors.ControlText;
            lblScore3Q5.BackColor = SystemColors.Control;
            lblScore4Q5.ForeColor = SystemColors.ControlText;
            lblScore4Q5.BackColor = SystemColors.Control;
            lblScore5Q5.ForeColor = SystemColors.ControlText;
            lblScore5Q5.BackColor = SystemColors.Control;
            lblScore6Q5.ForeColor = SystemColors.ControlText;
            lblScore6Q5.BackColor = SystemColors.Control;
            lblScore7Q5.ForeColor = Color.White;
            lblScore7Q5.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q5.ForeColor = SystemColors.ControlText;
            lblScore8Q5.BackColor = SystemColors.Control;
            lblScore9Q5.ForeColor = SystemColors.ControlText;
            lblScore9Q5.BackColor = SystemColors.Control;
            lblScore10Q5.ForeColor = SystemColors.ControlText;
            lblScore10Q5.BackColor = SystemColors.Control;
        }

        private void lblScore8Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = SystemColors.ControlText;
            lblScore1Q5.BackColor = SystemColors.Control;
            lblScore2Q5.ForeColor = SystemColors.ControlText;
            lblScore2Q5.BackColor = SystemColors.Control;
            lblScore3Q5.ForeColor = SystemColors.ControlText;
            lblScore3Q5.BackColor = SystemColors.Control;
            lblScore4Q5.ForeColor = SystemColors.ControlText;
            lblScore4Q5.BackColor = SystemColors.Control;
            lblScore5Q5.ForeColor = SystemColors.ControlText;
            lblScore5Q5.BackColor = SystemColors.Control;
            lblScore6Q5.ForeColor = SystemColors.ControlText;
            lblScore6Q5.BackColor = SystemColors.Control;
            lblScore7Q5.ForeColor = SystemColors.ControlText;
            lblScore7Q5.BackColor = SystemColors.Control;
            lblScore8Q5.ForeColor = Color.White;
            lblScore8Q5.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q5.ForeColor = SystemColors.ControlText;
            lblScore9Q5.BackColor = SystemColors.Control;
            lblScore10Q5.ForeColor = SystemColors.ControlText;
            lblScore10Q5.BackColor = SystemColors.Control;
        }

        private void lblScore9Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = SystemColors.ControlText;
            lblScore1Q5.BackColor = SystemColors.Control;
            lblScore2Q5.ForeColor = SystemColors.ControlText;
            lblScore2Q5.BackColor = SystemColors.Control;
            lblScore3Q5.ForeColor = SystemColors.ControlText;
            lblScore3Q5.BackColor = SystemColors.Control;
            lblScore4Q5.ForeColor = SystemColors.ControlText;
            lblScore4Q5.BackColor = SystemColors.Control;
            lblScore5Q5.ForeColor = SystemColors.ControlText;
            lblScore5Q5.BackColor = SystemColors.Control;
            lblScore6Q5.ForeColor = SystemColors.ControlText;
            lblScore6Q5.BackColor = SystemColors.Control;
            lblScore7Q5.ForeColor = SystemColors.ControlText;
            lblScore7Q5.BackColor = SystemColors.Control;
            lblScore8Q5.ForeColor = SystemColors.ControlText;
            lblScore8Q5.BackColor = SystemColors.Control;
            lblScore9Q5.ForeColor = Color.White;
            lblScore9Q5.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q5.ForeColor = SystemColors.ControlText;
            lblScore10Q5.BackColor = SystemColors.Control;
        }

        private void lblScore10Q5_Click(object sender, EventArgs e)
        {
            lblScore1Q5.ForeColor = SystemColors.ControlText;
            lblScore1Q5.BackColor = SystemColors.Control;
            lblScore2Q5.ForeColor = SystemColors.ControlText;
            lblScore2Q5.BackColor = SystemColors.Control;
            lblScore3Q5.ForeColor = SystemColors.ControlText;
            lblScore3Q5.BackColor = SystemColors.Control;
            lblScore4Q5.ForeColor = SystemColors.ControlText;
            lblScore4Q5.BackColor = SystemColors.Control;
            lblScore5Q5.ForeColor = SystemColors.ControlText;
            lblScore5Q5.BackColor = SystemColors.Control;
            lblScore6Q5.ForeColor = SystemColors.ControlText;
            lblScore6Q5.BackColor = SystemColors.Control;
            lblScore7Q5.ForeColor = SystemColors.ControlText;
            lblScore7Q5.BackColor = SystemColors.Control;
            lblScore8Q5.ForeColor = SystemColors.ControlText;
            lblScore8Q5.BackColor = SystemColors.Control;
            lblScore9Q5.ForeColor = SystemColors.ControlText;
            lblScore9Q5.BackColor = SystemColors.Control;
            lblScore10Q5.ForeColor = Color.White;
            lblScore10Q5.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Question 6 Likert Scale Highlighting

        private void lblScore1Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = Color.White;
            lblScore1Q6.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q6.ForeColor = SystemColors.ControlText;
            lblScore2Q6.BackColor = SystemColors.Control;
            lblScore3Q6.ForeColor = SystemColors.ControlText;
            lblScore3Q6.BackColor = SystemColors.Control;
            lblScore4Q6.ForeColor = SystemColors.ControlText;
            lblScore4Q6.BackColor = SystemColors.Control;
            lblScore5Q6.ForeColor = SystemColors.ControlText;
            lblScore5Q6.BackColor = SystemColors.Control;
            lblScore6Q6.ForeColor = SystemColors.ControlText;
            lblScore6Q6.BackColor = SystemColors.Control;
            lblScore7Q6.ForeColor = SystemColors.ControlText;
            lblScore7Q6.BackColor = SystemColors.Control;
            lblScore8Q6.ForeColor = SystemColors.ControlText;
            lblScore8Q6.BackColor = SystemColors.Control;
            lblScore9Q6.ForeColor = SystemColors.ControlText;
            lblScore9Q6.BackColor = SystemColors.Control;
            lblScore10Q6.ForeColor = SystemColors.ControlText;
            lblScore10Q6.BackColor = SystemColors.Control;
        }

        private void lblScore2Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = SystemColors.ControlText;
            lblScore1Q6.BackColor = SystemColors.Control;
            lblScore2Q6.ForeColor = Color.White;
            lblScore2Q6.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q6.ForeColor = SystemColors.ControlText;
            lblScore3Q6.BackColor = SystemColors.Control;
            lblScore4Q6.ForeColor = SystemColors.ControlText;
            lblScore4Q6.BackColor = SystemColors.Control;
            lblScore5Q6.ForeColor = SystemColors.ControlText;
            lblScore5Q6.BackColor = SystemColors.Control;
            lblScore6Q6.ForeColor = SystemColors.ControlText;
            lblScore6Q6.BackColor = SystemColors.Control;
            lblScore7Q6.ForeColor = SystemColors.ControlText;
            lblScore7Q6.BackColor = SystemColors.Control;
            lblScore8Q6.ForeColor = SystemColors.ControlText;
            lblScore8Q6.BackColor = SystemColors.Control;
            lblScore9Q6.ForeColor = SystemColors.ControlText;
            lblScore9Q6.BackColor = SystemColors.Control;
            lblScore10Q6.ForeColor = SystemColors.ControlText;
            lblScore10Q6.BackColor = SystemColors.Control;
        }

        private void lblScore3Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = SystemColors.ControlText;
            lblScore1Q6.BackColor = SystemColors.Control;
            lblScore2Q6.ForeColor = SystemColors.ControlText;
            lblScore2Q6.BackColor = SystemColors.Control;
            lblScore3Q6.ForeColor = Color.White;
            lblScore3Q6.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q6.ForeColor = SystemColors.ControlText;
            lblScore4Q6.BackColor = SystemColors.Control;
            lblScore5Q6.ForeColor = SystemColors.ControlText;
            lblScore5Q6.BackColor = SystemColors.Control;
            lblScore6Q6.ForeColor = SystemColors.ControlText;
            lblScore6Q6.BackColor = SystemColors.Control;
            lblScore7Q6.ForeColor = SystemColors.ControlText;
            lblScore7Q6.BackColor = SystemColors.Control;
            lblScore8Q6.ForeColor = SystemColors.ControlText;
            lblScore8Q6.BackColor = SystemColors.Control;
            lblScore9Q6.ForeColor = SystemColors.ControlText;
            lblScore9Q6.BackColor = SystemColors.Control;
            lblScore10Q6.ForeColor = SystemColors.ControlText;
            lblScore10Q6.BackColor = SystemColors.Control;
        }

        private void lblScore4Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = SystemColors.ControlText;
            lblScore1Q6.BackColor = SystemColors.Control;
            lblScore2Q6.ForeColor = SystemColors.ControlText;
            lblScore2Q6.BackColor = SystemColors.Control;
            lblScore3Q6.ForeColor = SystemColors.ControlText;
            lblScore3Q6.BackColor = SystemColors.Control;
            lblScore4Q6.ForeColor = Color.White;
            lblScore4Q6.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q6.ForeColor = SystemColors.ControlText;
            lblScore5Q6.BackColor = SystemColors.Control;
            lblScore6Q6.ForeColor = SystemColors.ControlText;
            lblScore6Q6.BackColor = SystemColors.Control;
            lblScore7Q6.ForeColor = SystemColors.ControlText;
            lblScore7Q6.BackColor = SystemColors.Control;
            lblScore8Q6.ForeColor = SystemColors.ControlText;
            lblScore8Q6.BackColor = SystemColors.Control;
            lblScore9Q6.ForeColor = SystemColors.ControlText;
            lblScore9Q6.BackColor = SystemColors.Control;
            lblScore10Q6.ForeColor = SystemColors.ControlText;
            lblScore10Q6.BackColor = SystemColors.Control;
        }

        private void lblScore5Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = SystemColors.ControlText;
            lblScore1Q6.BackColor = SystemColors.Control;
            lblScore2Q6.ForeColor = SystemColors.ControlText;
            lblScore2Q6.BackColor = SystemColors.Control;
            lblScore3Q6.ForeColor = SystemColors.ControlText;
            lblScore3Q6.BackColor = SystemColors.Control;
            lblScore4Q6.ForeColor = SystemColors.ControlText;
            lblScore4Q6.BackColor = SystemColors.Control;
            lblScore5Q6.ForeColor = Color.White;
            lblScore5Q6.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q6.ForeColor = SystemColors.ControlText;
            lblScore6Q6.BackColor = SystemColors.Control;
            lblScore7Q6.ForeColor = SystemColors.ControlText;
            lblScore7Q6.BackColor = SystemColors.Control;
            lblScore8Q6.ForeColor = SystemColors.ControlText;
            lblScore8Q6.BackColor = SystemColors.Control;
            lblScore9Q6.ForeColor = SystemColors.ControlText;
            lblScore9Q6.BackColor = SystemColors.Control;
            lblScore10Q6.ForeColor = SystemColors.ControlText;
            lblScore10Q6.BackColor = SystemColors.Control;
        }

        private void lblScore6Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = SystemColors.ControlText;
            lblScore1Q6.BackColor = SystemColors.Control;
            lblScore2Q6.ForeColor = SystemColors.ControlText;
            lblScore2Q6.BackColor = SystemColors.Control;
            lblScore3Q6.ForeColor = SystemColors.ControlText;
            lblScore3Q6.BackColor = SystemColors.Control;
            lblScore4Q6.ForeColor = SystemColors.ControlText;
            lblScore4Q6.BackColor = SystemColors.Control;
            lblScore5Q6.ForeColor = SystemColors.ControlText;
            lblScore5Q6.BackColor = SystemColors.Control;
            lblScore6Q6.ForeColor = Color.White;
            lblScore6Q6.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q6.ForeColor = SystemColors.ControlText;
            lblScore7Q6.BackColor = SystemColors.Control;
            lblScore8Q6.ForeColor = SystemColors.ControlText;
            lblScore8Q6.BackColor = SystemColors.Control;
            lblScore9Q6.ForeColor = SystemColors.ControlText;
            lblScore9Q6.BackColor = SystemColors.Control;
            lblScore10Q6.ForeColor = SystemColors.ControlText;
            lblScore10Q6.BackColor = SystemColors.Control;
        }

        private void lblScore7Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = SystemColors.ControlText;
            lblScore1Q6.BackColor = SystemColors.Control;
            lblScore2Q6.ForeColor = SystemColors.ControlText;
            lblScore2Q6.BackColor = SystemColors.Control;
            lblScore3Q6.ForeColor = SystemColors.ControlText;
            lblScore3Q6.BackColor = SystemColors.Control;
            lblScore4Q6.ForeColor = SystemColors.ControlText;
            lblScore4Q6.BackColor = SystemColors.Control;
            lblScore5Q6.ForeColor = SystemColors.ControlText;
            lblScore5Q6.BackColor = SystemColors.Control;
            lblScore6Q6.ForeColor = SystemColors.ControlText;
            lblScore6Q6.BackColor = SystemColors.Control;
            lblScore7Q6.ForeColor = Color.White;
            lblScore7Q6.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q6.ForeColor = SystemColors.ControlText;
            lblScore8Q6.BackColor = SystemColors.Control;
            lblScore9Q6.ForeColor = SystemColors.ControlText;
            lblScore9Q6.BackColor = SystemColors.Control;
            lblScore10Q6.ForeColor = SystemColors.ControlText;
            lblScore10Q6.BackColor = SystemColors.Control;
        }

        private void lblScore8Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = SystemColors.ControlText;
            lblScore1Q6.BackColor = SystemColors.Control;
            lblScore2Q6.ForeColor = SystemColors.ControlText;
            lblScore2Q6.BackColor = SystemColors.Control;
            lblScore3Q6.ForeColor = SystemColors.ControlText;
            lblScore3Q6.BackColor = SystemColors.Control;
            lblScore4Q6.ForeColor = SystemColors.ControlText;
            lblScore4Q6.BackColor = SystemColors.Control;
            lblScore5Q6.ForeColor = SystemColors.ControlText;
            lblScore5Q6.BackColor = SystemColors.Control;
            lblScore6Q6.ForeColor = SystemColors.ControlText;
            lblScore6Q6.BackColor = SystemColors.Control;
            lblScore7Q6.ForeColor = SystemColors.ControlText;
            lblScore7Q6.BackColor = SystemColors.Control;
            lblScore8Q6.ForeColor = Color.White;
            lblScore8Q6.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q6.ForeColor = SystemColors.ControlText;
            lblScore9Q6.BackColor = SystemColors.Control;
            lblScore10Q6.ForeColor = SystemColors.ControlText;
            lblScore10Q6.BackColor = SystemColors.Control;
        }

        private void lblScore9Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = SystemColors.ControlText;
            lblScore1Q6.BackColor = SystemColors.Control;
            lblScore2Q6.ForeColor = SystemColors.ControlText;
            lblScore2Q6.BackColor = SystemColors.Control;
            lblScore3Q6.ForeColor = SystemColors.ControlText;
            lblScore3Q6.BackColor = SystemColors.Control;
            lblScore4Q6.ForeColor = SystemColors.ControlText;
            lblScore4Q6.BackColor = SystemColors.Control;
            lblScore5Q6.ForeColor = SystemColors.ControlText;
            lblScore5Q6.BackColor = SystemColors.Control;
            lblScore6Q6.ForeColor = SystemColors.ControlText;
            lblScore6Q6.BackColor = SystemColors.Control;
            lblScore7Q6.ForeColor = SystemColors.ControlText;
            lblScore7Q6.BackColor = SystemColors.Control;
            lblScore8Q6.ForeColor = SystemColors.ControlText;
            lblScore8Q6.BackColor = SystemColors.Control;
            lblScore9Q6.ForeColor = Color.White;
            lblScore9Q6.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q6.ForeColor = SystemColors.ControlText;
            lblScore10Q6.BackColor = SystemColors.Control;
        }

        private void lblScore10Q6_Click(object sender, EventArgs e)
        {
            lblScore1Q6.ForeColor = SystemColors.ControlText;
            lblScore1Q6.BackColor = SystemColors.Control;
            lblScore2Q6.ForeColor = SystemColors.ControlText;
            lblScore2Q6.BackColor = SystemColors.Control;
            lblScore3Q6.ForeColor = SystemColors.ControlText;
            lblScore3Q6.BackColor = SystemColors.Control;
            lblScore4Q6.ForeColor = SystemColors.ControlText;
            lblScore4Q6.BackColor = SystemColors.Control;
            lblScore5Q6.ForeColor = SystemColors.ControlText;
            lblScore5Q6.BackColor = SystemColors.Control;
            lblScore6Q6.ForeColor = SystemColors.ControlText;
            lblScore6Q6.BackColor = SystemColors.Control;
            lblScore7Q6.ForeColor = SystemColors.ControlText;
            lblScore7Q6.BackColor = SystemColors.Control;
            lblScore8Q6.ForeColor = SystemColors.ControlText;
            lblScore8Q6.BackColor = SystemColors.Control;
            lblScore9Q6.ForeColor = SystemColors.ControlText;
            lblScore9Q6.BackColor = SystemColors.Control;
            lblScore10Q6.ForeColor = Color.White;
            lblScore10Q6.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Question 7 Likert Scale Highlighting

        private void lblScore1Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = Color.White;
            lblScore1Q7.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q7.ForeColor = SystemColors.ControlText;
            lblScore2Q7.BackColor = SystemColors.Control;
            lblScore3Q7.ForeColor = SystemColors.ControlText;
            lblScore3Q7.BackColor = SystemColors.Control;
            lblScore4Q7.ForeColor = SystemColors.ControlText;
            lblScore4Q7.BackColor = SystemColors.Control;
            lblScore5Q7.ForeColor = SystemColors.ControlText;
            lblScore5Q7.BackColor = SystemColors.Control;
            lblScore6Q7.ForeColor = SystemColors.ControlText;
            lblScore6Q7.BackColor = SystemColors.Control;
            lblScore7Q7.ForeColor = SystemColors.ControlText;
            lblScore7Q7.BackColor = SystemColors.Control;
            lblScore8Q7.ForeColor = SystemColors.ControlText;
            lblScore8Q7.BackColor = SystemColors.Control;
            lblScore9Q7.ForeColor = SystemColors.ControlText;
            lblScore9Q7.BackColor = SystemColors.Control;
            lblScore10Q7.ForeColor = SystemColors.ControlText;
            lblScore10Q7.BackColor = SystemColors.Control;
        }

        private void lblScore2Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = SystemColors.ControlText;
            lblScore1Q7.BackColor = SystemColors.Control;
            lblScore2Q7.ForeColor = Color.White;
            lblScore2Q7.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q7.ForeColor = SystemColors.ControlText;
            lblScore3Q7.BackColor = SystemColors.Control;
            lblScore4Q7.ForeColor = SystemColors.ControlText;
            lblScore4Q7.BackColor = SystemColors.Control;
            lblScore5Q7.ForeColor = SystemColors.ControlText;
            lblScore5Q7.BackColor = SystemColors.Control;
            lblScore6Q7.ForeColor = SystemColors.ControlText;
            lblScore6Q7.BackColor = SystemColors.Control;
            lblScore7Q7.ForeColor = SystemColors.ControlText;
            lblScore7Q7.BackColor = SystemColors.Control;
            lblScore8Q7.ForeColor = SystemColors.ControlText;
            lblScore8Q7.BackColor = SystemColors.Control;
            lblScore9Q7.ForeColor = SystemColors.ControlText;
            lblScore9Q7.BackColor = SystemColors.Control;
            lblScore10Q7.ForeColor = SystemColors.ControlText;
            lblScore10Q7.BackColor = SystemColors.Control;
        }

        private void lblScore3Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = SystemColors.ControlText;
            lblScore1Q7.BackColor = SystemColors.Control;
            lblScore2Q7.ForeColor = SystemColors.ControlText;
            lblScore2Q7.BackColor = SystemColors.Control;
            lblScore3Q7.ForeColor = Color.White;
            lblScore3Q7.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q7.ForeColor = SystemColors.ControlText;
            lblScore4Q7.BackColor = SystemColors.Control;
            lblScore5Q7.ForeColor = SystemColors.ControlText;
            lblScore5Q7.BackColor = SystemColors.Control;
            lblScore6Q7.ForeColor = SystemColors.ControlText;
            lblScore6Q7.BackColor = SystemColors.Control;
            lblScore7Q7.ForeColor = SystemColors.ControlText;
            lblScore7Q7.BackColor = SystemColors.Control;
            lblScore8Q7.ForeColor = SystemColors.ControlText;
            lblScore8Q7.BackColor = SystemColors.Control;
            lblScore9Q7.ForeColor = SystemColors.ControlText;
            lblScore9Q7.BackColor = SystemColors.Control;
            lblScore10Q7.ForeColor = SystemColors.ControlText;
            lblScore10Q7.BackColor = SystemColors.Control;
        }

        private void lblScore4Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = SystemColors.ControlText;
            lblScore1Q7.BackColor = SystemColors.Control;
            lblScore2Q7.ForeColor = SystemColors.ControlText;
            lblScore2Q7.BackColor = SystemColors.Control;
            lblScore3Q7.ForeColor = SystemColors.ControlText;
            lblScore3Q7.BackColor = SystemColors.Control;
            lblScore4Q7.ForeColor = Color.White;
            lblScore4Q7.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q7.ForeColor = SystemColors.ControlText;
            lblScore5Q7.BackColor = SystemColors.Control;
            lblScore6Q7.ForeColor = SystemColors.ControlText;
            lblScore6Q7.BackColor = SystemColors.Control;
            lblScore7Q7.ForeColor = SystemColors.ControlText;
            lblScore7Q7.BackColor = SystemColors.Control;
            lblScore8Q7.ForeColor = SystemColors.ControlText;
            lblScore8Q7.BackColor = SystemColors.Control;
            lblScore9Q7.ForeColor = SystemColors.ControlText;
            lblScore9Q7.BackColor = SystemColors.Control;
            lblScore10Q7.ForeColor = SystemColors.ControlText;
            lblScore10Q7.BackColor = SystemColors.Control;
        }

        private void lblScore5Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = SystemColors.ControlText;
            lblScore1Q7.BackColor = SystemColors.Control;
            lblScore2Q7.ForeColor = SystemColors.ControlText;
            lblScore2Q7.BackColor = SystemColors.Control;
            lblScore3Q7.ForeColor = SystemColors.ControlText;
            lblScore3Q7.BackColor = SystemColors.Control;
            lblScore4Q7.ForeColor = SystemColors.ControlText;
            lblScore4Q7.BackColor = SystemColors.Control;
            lblScore5Q7.ForeColor = Color.White;
            lblScore5Q7.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q7.ForeColor = SystemColors.ControlText;
            lblScore6Q7.BackColor = SystemColors.Control;
            lblScore7Q7.ForeColor = SystemColors.ControlText;
            lblScore7Q7.BackColor = SystemColors.Control;
            lblScore8Q7.ForeColor = SystemColors.ControlText;
            lblScore8Q7.BackColor = SystemColors.Control;
            lblScore9Q7.ForeColor = SystemColors.ControlText;
            lblScore9Q7.BackColor = SystemColors.Control;
            lblScore10Q7.ForeColor = SystemColors.ControlText;
            lblScore10Q7.BackColor = SystemColors.Control;
        }

        private void lblScore6Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = SystemColors.ControlText;
            lblScore1Q7.BackColor = SystemColors.Control;
            lblScore2Q7.ForeColor = SystemColors.ControlText;
            lblScore2Q7.BackColor = SystemColors.Control;
            lblScore3Q7.ForeColor = SystemColors.ControlText;
            lblScore3Q7.BackColor = SystemColors.Control;
            lblScore4Q7.ForeColor = SystemColors.ControlText;
            lblScore4Q7.BackColor = SystemColors.Control;
            lblScore5Q7.ForeColor = SystemColors.ControlText;
            lblScore5Q7.BackColor = SystemColors.Control;
            lblScore6Q7.ForeColor = Color.White;
            lblScore6Q7.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q7.ForeColor = SystemColors.ControlText;
            lblScore7Q7.BackColor = SystemColors.Control;
            lblScore8Q7.ForeColor = SystemColors.ControlText;
            lblScore8Q7.BackColor = SystemColors.Control;
            lblScore9Q7.ForeColor = SystemColors.ControlText;
            lblScore9Q7.BackColor = SystemColors.Control;
            lblScore10Q7.ForeColor = SystemColors.ControlText;
            lblScore10Q7.BackColor = SystemColors.Control;
        }

        private void lblScore7Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = SystemColors.ControlText;
            lblScore1Q7.BackColor = SystemColors.Control;
            lblScore2Q7.ForeColor = SystemColors.ControlText;
            lblScore2Q7.BackColor = SystemColors.Control;
            lblScore3Q7.ForeColor = SystemColors.ControlText;
            lblScore3Q7.BackColor = SystemColors.Control;
            lblScore4Q7.ForeColor = SystemColors.ControlText;
            lblScore4Q7.BackColor = SystemColors.Control;
            lblScore5Q7.ForeColor = SystemColors.ControlText;
            lblScore5Q7.BackColor = SystemColors.Control;
            lblScore6Q7.ForeColor = SystemColors.ControlText;
            lblScore6Q7.BackColor = SystemColors.Control;
            lblScore7Q7.ForeColor = Color.White;
            lblScore7Q7.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q7.ForeColor = SystemColors.ControlText;
            lblScore8Q7.BackColor = SystemColors.Control;
            lblScore9Q7.ForeColor = SystemColors.ControlText;
            lblScore9Q7.BackColor = SystemColors.Control;
            lblScore10Q7.ForeColor = SystemColors.ControlText;
            lblScore10Q7.BackColor = SystemColors.Control;
        }

        private void lblScore8Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = SystemColors.ControlText;
            lblScore1Q7.BackColor = SystemColors.Control;
            lblScore2Q7.ForeColor = SystemColors.ControlText;
            lblScore2Q7.BackColor = SystemColors.Control;
            lblScore3Q7.ForeColor = SystemColors.ControlText;
            lblScore3Q7.BackColor = SystemColors.Control;
            lblScore4Q7.ForeColor = SystemColors.ControlText;
            lblScore4Q7.BackColor = SystemColors.Control;
            lblScore5Q7.ForeColor = SystemColors.ControlText;
            lblScore5Q7.BackColor = SystemColors.Control;
            lblScore6Q7.ForeColor = SystemColors.ControlText;
            lblScore6Q7.BackColor = SystemColors.Control;
            lblScore7Q7.ForeColor = SystemColors.ControlText;
            lblScore7Q7.BackColor = SystemColors.Control;
            lblScore8Q7.ForeColor = Color.White;
            lblScore8Q7.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q7.ForeColor = SystemColors.ControlText;
            lblScore9Q7.BackColor = SystemColors.Control;
            lblScore10Q7.ForeColor = SystemColors.ControlText;
            lblScore10Q7.BackColor = SystemColors.Control;
        }

        private void lblScore9Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = SystemColors.ControlText;
            lblScore1Q7.BackColor = SystemColors.Control;
            lblScore2Q7.ForeColor = SystemColors.ControlText;
            lblScore2Q7.BackColor = SystemColors.Control;
            lblScore3Q7.ForeColor = SystemColors.ControlText;
            lblScore3Q7.BackColor = SystemColors.Control;
            lblScore4Q7.ForeColor = SystemColors.ControlText;
            lblScore4Q7.BackColor = SystemColors.Control;
            lblScore5Q7.ForeColor = SystemColors.ControlText;
            lblScore5Q7.BackColor = SystemColors.Control;
            lblScore6Q7.ForeColor = SystemColors.ControlText;
            lblScore6Q7.BackColor = SystemColors.Control;
            lblScore7Q7.ForeColor = SystemColors.ControlText;
            lblScore7Q7.BackColor = SystemColors.Control;
            lblScore8Q7.ForeColor = SystemColors.ControlText;
            lblScore8Q7.BackColor = SystemColors.Control;
            lblScore9Q7.ForeColor = Color.White;
            lblScore9Q7.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q7.ForeColor = SystemColors.ControlText;
            lblScore10Q7.BackColor = SystemColors.Control;
        }

        private void lblScore10Q7_Click(object sender, EventArgs e)
        {
            lblScore1Q7.ForeColor = SystemColors.ControlText;
            lblScore1Q7.BackColor = SystemColors.Control;
            lblScore2Q7.ForeColor = SystemColors.ControlText;
            lblScore2Q7.BackColor = SystemColors.Control;
            lblScore3Q7.ForeColor = SystemColors.ControlText;
            lblScore3Q7.BackColor = SystemColors.Control;
            lblScore4Q7.ForeColor = SystemColors.ControlText;
            lblScore4Q7.BackColor = SystemColors.Control;
            lblScore5Q7.ForeColor = SystemColors.ControlText;
            lblScore5Q7.BackColor = SystemColors.Control;
            lblScore6Q7.ForeColor = SystemColors.ControlText;
            lblScore6Q7.BackColor = SystemColors.Control;
            lblScore7Q7.ForeColor = SystemColors.ControlText;
            lblScore7Q7.BackColor = SystemColors.Control;
            lblScore8Q7.ForeColor = SystemColors.ControlText;
            lblScore8Q7.BackColor = SystemColors.Control;
            lblScore9Q7.ForeColor = SystemColors.ControlText;
            lblScore9Q7.BackColor = SystemColors.Control;
            lblScore10Q7.ForeColor = Color.White;
            lblScore10Q7.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Question 8 Likert Scale Highlighting
        private void lblScore1Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = Color.White;
            lblScore1Q8.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q8.ForeColor = SystemColors.ControlText;
            lblScore2Q8.BackColor = SystemColors.Control;
            lblScore3Q8.ForeColor = SystemColors.ControlText;
            lblScore3Q8.BackColor = SystemColors.Control;
            lblScore4Q8.ForeColor = SystemColors.ControlText;
            lblScore4Q8.BackColor = SystemColors.Control;
            lblScore5Q8.ForeColor = SystemColors.ControlText;
            lblScore5Q8.BackColor = SystemColors.Control;
            lblScore6Q8.ForeColor = SystemColors.ControlText;
            lblScore6Q8.BackColor = SystemColors.Control;
            lblScore7Q8.ForeColor = SystemColors.ControlText;
            lblScore7Q8.BackColor = SystemColors.Control;
            lblScore8Q8.ForeColor = SystemColors.ControlText;
            lblScore8Q8.BackColor = SystemColors.Control;
            lblScore9Q8.ForeColor = SystemColors.ControlText;
            lblScore9Q8.BackColor = SystemColors.Control;
            lblScore10Q8.ForeColor = SystemColors.ControlText;
            lblScore10Q8.BackColor = SystemColors.Control;
        }

        private void lblScore2Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = SystemColors.ControlText;
            lblScore1Q8.BackColor = SystemColors.Control;
            lblScore2Q8.ForeColor = Color.White;
            lblScore2Q8.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q8.ForeColor = SystemColors.ControlText;
            lblScore3Q8.BackColor = SystemColors.Control;
            lblScore4Q8.ForeColor = SystemColors.ControlText;
            lblScore4Q8.BackColor = SystemColors.Control;
            lblScore5Q8.ForeColor = SystemColors.ControlText;
            lblScore5Q8.BackColor = SystemColors.Control;
            lblScore6Q8.ForeColor = SystemColors.ControlText;
            lblScore6Q8.BackColor = SystemColors.Control;
            lblScore7Q8.ForeColor = SystemColors.ControlText;
            lblScore7Q8.BackColor = SystemColors.Control;
            lblScore8Q8.ForeColor = SystemColors.ControlText;
            lblScore8Q8.BackColor = SystemColors.Control;
            lblScore9Q8.ForeColor = SystemColors.ControlText;
            lblScore9Q8.BackColor = SystemColors.Control;
            lblScore10Q8.ForeColor = SystemColors.ControlText;
            lblScore10Q8.BackColor = SystemColors.Control;
        }

        private void lblScore3Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = SystemColors.ControlText;
            lblScore1Q8.BackColor = SystemColors.Control;
            lblScore2Q8.ForeColor = SystemColors.ControlText;
            lblScore2Q8.BackColor = SystemColors.Control;
            lblScore3Q8.ForeColor = Color.White;
            lblScore3Q8.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q8.ForeColor = SystemColors.ControlText;
            lblScore4Q8.BackColor = SystemColors.Control;
            lblScore5Q8.ForeColor = SystemColors.ControlText;
            lblScore5Q8.BackColor = SystemColors.Control;
            lblScore6Q8.ForeColor = SystemColors.ControlText;
            lblScore6Q8.BackColor = SystemColors.Control;
            lblScore7Q8.ForeColor = SystemColors.ControlText;
            lblScore7Q8.BackColor = SystemColors.Control;
            lblScore8Q8.ForeColor = SystemColors.ControlText;
            lblScore8Q8.BackColor = SystemColors.Control;
            lblScore9Q8.ForeColor = SystemColors.ControlText;
            lblScore9Q8.BackColor = SystemColors.Control;
            lblScore10Q8.ForeColor = SystemColors.ControlText;
            lblScore10Q8.BackColor = SystemColors.Control;
        }

        private void lblScore4Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = SystemColors.ControlText;
            lblScore1Q8.BackColor = SystemColors.Control;
            lblScore2Q8.ForeColor = SystemColors.ControlText;
            lblScore2Q8.BackColor = SystemColors.Control;
            lblScore3Q8.ForeColor = SystemColors.ControlText;
            lblScore3Q8.BackColor = SystemColors.Control;
            lblScore4Q8.ForeColor = Color.White;
            lblScore4Q8.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q8.ForeColor = SystemColors.ControlText;
            lblScore5Q8.BackColor = SystemColors.Control;
            lblScore6Q8.ForeColor = SystemColors.ControlText;
            lblScore6Q8.BackColor = SystemColors.Control;
            lblScore7Q8.ForeColor = SystemColors.ControlText;
            lblScore7Q8.BackColor = SystemColors.Control;
            lblScore8Q8.ForeColor = SystemColors.ControlText;
            lblScore8Q8.BackColor = SystemColors.Control;
            lblScore9Q8.ForeColor = SystemColors.ControlText;
            lblScore9Q8.BackColor = SystemColors.Control;
            lblScore10Q8.ForeColor = SystemColors.ControlText;
            lblScore10Q8.BackColor = SystemColors.Control;
        }

        private void lblScore5Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = SystemColors.ControlText;
            lblScore1Q8.BackColor = SystemColors.Control;
            lblScore2Q8.ForeColor = SystemColors.ControlText;
            lblScore2Q8.BackColor = SystemColors.Control;
            lblScore3Q8.ForeColor = SystemColors.ControlText;
            lblScore3Q8.BackColor = SystemColors.Control;
            lblScore4Q8.ForeColor = SystemColors.ControlText;
            lblScore4Q8.BackColor = SystemColors.Control;
            lblScore5Q8.ForeColor = Color.White;
            lblScore5Q8.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q8.ForeColor = SystemColors.ControlText;
            lblScore6Q8.BackColor = SystemColors.Control;
            lblScore7Q8.ForeColor = SystemColors.ControlText;
            lblScore7Q8.BackColor = SystemColors.Control;
            lblScore8Q8.ForeColor = SystemColors.ControlText;
            lblScore8Q8.BackColor = SystemColors.Control;
            lblScore9Q8.ForeColor = SystemColors.ControlText;
            lblScore9Q8.BackColor = SystemColors.Control;
            lblScore10Q8.ForeColor = SystemColors.ControlText;
            lblScore10Q8.BackColor = SystemColors.Control;
        }

        private void lblScore6Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = SystemColors.ControlText;
            lblScore1Q8.BackColor = SystemColors.Control;
            lblScore2Q8.ForeColor = SystemColors.ControlText;
            lblScore2Q8.BackColor = SystemColors.Control;
            lblScore3Q8.ForeColor = SystemColors.ControlText;
            lblScore3Q8.BackColor = SystemColors.Control;
            lblScore4Q8.ForeColor = SystemColors.ControlText;
            lblScore4Q8.BackColor = SystemColors.Control;
            lblScore5Q8.ForeColor = SystemColors.ControlText;
            lblScore5Q8.BackColor = SystemColors.Control;
            lblScore6Q8.ForeColor = Color.White;
            lblScore6Q8.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q8.ForeColor = SystemColors.ControlText;
            lblScore7Q8.BackColor = SystemColors.Control;
            lblScore8Q8.ForeColor = SystemColors.ControlText;
            lblScore8Q8.BackColor = SystemColors.Control;
            lblScore9Q8.ForeColor = SystemColors.ControlText;
            lblScore9Q8.BackColor = SystemColors.Control;
            lblScore10Q8.ForeColor = SystemColors.ControlText;
            lblScore10Q8.BackColor = SystemColors.Control;
        }

        private void lblScore7Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = SystemColors.ControlText;
            lblScore1Q8.BackColor = SystemColors.Control;
            lblScore2Q8.ForeColor = SystemColors.ControlText;
            lblScore2Q8.BackColor = SystemColors.Control;
            lblScore3Q8.ForeColor = SystemColors.ControlText;
            lblScore3Q8.BackColor = SystemColors.Control;
            lblScore4Q8.ForeColor = SystemColors.ControlText;
            lblScore4Q8.BackColor = SystemColors.Control;
            lblScore5Q8.ForeColor = SystemColors.ControlText;
            lblScore5Q8.BackColor = SystemColors.Control;
            lblScore6Q8.ForeColor = SystemColors.ControlText;
            lblScore6Q8.BackColor = SystemColors.Control;
            lblScore7Q8.ForeColor = Color.White;
            lblScore7Q8.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q8.ForeColor = SystemColors.ControlText;
            lblScore8Q8.BackColor = SystemColors.Control;
            lblScore9Q8.ForeColor = SystemColors.ControlText;
            lblScore9Q8.BackColor = SystemColors.Control;
            lblScore10Q8.ForeColor = SystemColors.ControlText;
            lblScore10Q8.BackColor = SystemColors.Control;
        }

        private void lblScore8Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = SystemColors.ControlText;
            lblScore1Q8.BackColor = SystemColors.Control;
            lblScore2Q8.ForeColor = SystemColors.ControlText;
            lblScore2Q8.BackColor = SystemColors.Control;
            lblScore3Q8.ForeColor = SystemColors.ControlText;
            lblScore3Q8.BackColor = SystemColors.Control;
            lblScore4Q8.ForeColor = SystemColors.ControlText;
            lblScore4Q8.BackColor = SystemColors.Control;
            lblScore5Q8.ForeColor = SystemColors.ControlText;
            lblScore5Q8.BackColor = SystemColors.Control;
            lblScore6Q8.ForeColor = SystemColors.ControlText;
            lblScore6Q8.BackColor = SystemColors.Control;
            lblScore7Q8.ForeColor = SystemColors.ControlText;
            lblScore7Q8.BackColor = SystemColors.Control;
            lblScore8Q8.ForeColor = Color.White;
            lblScore8Q8.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q8.ForeColor = SystemColors.ControlText;
            lblScore9Q8.BackColor = SystemColors.Control;
            lblScore10Q8.ForeColor = SystemColors.ControlText;
            lblScore10Q8.BackColor = SystemColors.Control;
        }

        private void lblScore9Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = SystemColors.ControlText;
            lblScore1Q8.BackColor = SystemColors.Control;
            lblScore2Q8.ForeColor = SystemColors.ControlText;
            lblScore2Q8.BackColor = SystemColors.Control;
            lblScore3Q8.ForeColor = SystemColors.ControlText;
            lblScore3Q8.BackColor = SystemColors.Control;
            lblScore4Q8.ForeColor = SystemColors.ControlText;
            lblScore4Q8.BackColor = SystemColors.Control;
            lblScore5Q8.ForeColor = SystemColors.ControlText;
            lblScore5Q8.BackColor = SystemColors.Control;
            lblScore6Q8.ForeColor = SystemColors.ControlText;
            lblScore6Q8.BackColor = SystemColors.Control;
            lblScore7Q8.ForeColor = SystemColors.ControlText;
            lblScore7Q8.BackColor = SystemColors.Control;
            lblScore8Q8.ForeColor = SystemColors.ControlText;
            lblScore8Q8.BackColor = SystemColors.Control;
            lblScore9Q8.ForeColor = Color.White;
            lblScore9Q8.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q8.ForeColor = SystemColors.ControlText;
            lblScore10Q8.BackColor = SystemColors.Control;
        }

        private void lblScore10Q8_Click(object sender, EventArgs e)
        {
            lblScore1Q8.ForeColor = SystemColors.ControlText;
            lblScore1Q8.BackColor = SystemColors.Control;
            lblScore2Q8.ForeColor = SystemColors.ControlText;
            lblScore2Q8.BackColor = SystemColors.Control;
            lblScore3Q8.ForeColor = SystemColors.ControlText;
            lblScore3Q8.BackColor = SystemColors.Control;
            lblScore4Q8.ForeColor = SystemColors.ControlText;
            lblScore4Q8.BackColor = SystemColors.Control;
            lblScore5Q8.ForeColor = SystemColors.ControlText;
            lblScore5Q8.BackColor = SystemColors.Control;
            lblScore6Q8.ForeColor = SystemColors.ControlText;
            lblScore6Q8.BackColor = SystemColors.Control;
            lblScore7Q8.ForeColor = SystemColors.ControlText;
            lblScore7Q8.BackColor = SystemColors.Control;
            lblScore8Q8.ForeColor = SystemColors.ControlText;
            lblScore8Q8.BackColor = SystemColors.Control;
            lblScore9Q8.ForeColor = SystemColors.ControlText;
            lblScore9Q8.BackColor = SystemColors.Control;
            lblScore10Q8.ForeColor = Color.White;
            lblScore10Q8.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Question 9 Likert Scale Highlighting

        private void lblScore1Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = Color.White;
            lblScore1Q9.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q9.ForeColor = SystemColors.ControlText;
            lblScore2Q9.BackColor = SystemColors.Control;
            lblScore3Q9.ForeColor = SystemColors.ControlText;
            lblScore3Q9.BackColor = SystemColors.Control;
            lblScore4Q9.ForeColor = SystemColors.ControlText;
            lblScore4Q9.BackColor = SystemColors.Control;
            lblScore5Q9.ForeColor = SystemColors.ControlText;
            lblScore5Q9.BackColor = SystemColors.Control;
            lblScore6Q9.ForeColor = SystemColors.ControlText;
            lblScore6Q9.BackColor = SystemColors.Control;
            lblScore7Q9.ForeColor = SystemColors.ControlText;
            lblScore7Q9.BackColor = SystemColors.Control;
            lblScore8Q9.ForeColor = SystemColors.ControlText;
            lblScore8Q9.BackColor = SystemColors.Control;
            lblScore9Q9.ForeColor = SystemColors.ControlText;
            lblScore9Q9.BackColor = SystemColors.Control;
            lblScore10Q9.ForeColor = SystemColors.ControlText;
            lblScore10Q9.BackColor = SystemColors.Control;
        }

        private void lblScore2Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = SystemColors.ControlText;
            lblScore1Q9.BackColor = SystemColors.Control;
            lblScore2Q9.ForeColor = Color.White;
            lblScore2Q9.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q9.ForeColor = SystemColors.ControlText;
            lblScore3Q9.BackColor = SystemColors.Control;
            lblScore4Q9.ForeColor = SystemColors.ControlText;
            lblScore4Q9.BackColor = SystemColors.Control;
            lblScore5Q9.ForeColor = SystemColors.ControlText;
            lblScore5Q9.BackColor = SystemColors.Control;
            lblScore6Q9.ForeColor = SystemColors.ControlText;
            lblScore6Q9.BackColor = SystemColors.Control;
            lblScore7Q9.ForeColor = SystemColors.ControlText;
            lblScore7Q9.BackColor = SystemColors.Control;
            lblScore8Q9.ForeColor = SystemColors.ControlText;
            lblScore8Q9.BackColor = SystemColors.Control;
            lblScore9Q9.ForeColor = SystemColors.ControlText;
            lblScore9Q9.BackColor = SystemColors.Control;
            lblScore10Q9.ForeColor = SystemColors.ControlText;
            lblScore10Q9.BackColor = SystemColors.Control;
        }

        private void lblScore3Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = SystemColors.ControlText;
            lblScore1Q9.BackColor = SystemColors.Control;
            lblScore2Q9.ForeColor = SystemColors.ControlText;
            lblScore2Q9.BackColor = SystemColors.Control;
            lblScore3Q9.ForeColor = Color.White;
            lblScore3Q9.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q9.ForeColor = SystemColors.ControlText;
            lblScore4Q9.BackColor = SystemColors.Control;
            lblScore5Q9.ForeColor = SystemColors.ControlText;
            lblScore5Q9.BackColor = SystemColors.Control;
            lblScore6Q9.ForeColor = SystemColors.ControlText;
            lblScore6Q9.BackColor = SystemColors.Control;
            lblScore7Q9.ForeColor = SystemColors.ControlText;
            lblScore7Q9.BackColor = SystemColors.Control;
            lblScore8Q9.ForeColor = SystemColors.ControlText;
            lblScore8Q9.BackColor = SystemColors.Control;
            lblScore9Q9.ForeColor = SystemColors.ControlText;
            lblScore9Q9.BackColor = SystemColors.Control;
            lblScore10Q9.ForeColor = SystemColors.ControlText;
            lblScore10Q9.BackColor = SystemColors.Control;
        }

        private void lblScore4Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = SystemColors.ControlText;
            lblScore1Q9.BackColor = SystemColors.Control;
            lblScore2Q9.ForeColor = SystemColors.ControlText;
            lblScore2Q9.BackColor = SystemColors.Control;
            lblScore3Q9.ForeColor = SystemColors.ControlText;
            lblScore3Q9.BackColor = SystemColors.Control;
            lblScore4Q9.ForeColor = Color.White;
            lblScore4Q9.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q9.ForeColor = SystemColors.ControlText;
            lblScore5Q9.BackColor = SystemColors.Control;
            lblScore6Q9.ForeColor = SystemColors.ControlText;
            lblScore6Q9.BackColor = SystemColors.Control;
            lblScore7Q9.ForeColor = SystemColors.ControlText;
            lblScore7Q9.BackColor = SystemColors.Control;
            lblScore8Q9.ForeColor = SystemColors.ControlText;
            lblScore8Q9.BackColor = SystemColors.Control;
            lblScore9Q9.ForeColor = SystemColors.ControlText;
            lblScore9Q9.BackColor = SystemColors.Control;
            lblScore10Q9.ForeColor = SystemColors.ControlText;
            lblScore10Q9.BackColor = SystemColors.Control;
        }

        private void lblScore5Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = SystemColors.ControlText;
            lblScore1Q9.BackColor = SystemColors.Control;
            lblScore2Q9.ForeColor = SystemColors.ControlText;
            lblScore2Q9.BackColor = SystemColors.Control;
            lblScore3Q9.ForeColor = SystemColors.ControlText;
            lblScore3Q9.BackColor = SystemColors.Control;
            lblScore4Q9.ForeColor = SystemColors.ControlText;
            lblScore4Q9.BackColor = SystemColors.Control;
            lblScore5Q9.ForeColor = Color.White;
            lblScore5Q9.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q9.ForeColor = SystemColors.ControlText;
            lblScore6Q9.BackColor = SystemColors.Control;
            lblScore7Q9.ForeColor = SystemColors.ControlText;
            lblScore7Q9.BackColor = SystemColors.Control;
            lblScore8Q9.ForeColor = SystemColors.ControlText;
            lblScore8Q9.BackColor = SystemColors.Control;
            lblScore9Q9.ForeColor = SystemColors.ControlText;
            lblScore9Q9.BackColor = SystemColors.Control;
            lblScore10Q9.ForeColor = SystemColors.ControlText;
            lblScore10Q9.BackColor = SystemColors.Control;
        }

        private void lblScore6Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = SystemColors.ControlText;
            lblScore1Q9.BackColor = SystemColors.Control;
            lblScore2Q9.ForeColor = SystemColors.ControlText;
            lblScore2Q9.BackColor = SystemColors.Control;
            lblScore3Q9.ForeColor = SystemColors.ControlText;
            lblScore3Q9.BackColor = SystemColors.Control;
            lblScore4Q9.ForeColor = SystemColors.ControlText;
            lblScore4Q9.BackColor = SystemColors.Control;
            lblScore5Q9.ForeColor = SystemColors.ControlText;
            lblScore5Q9.BackColor = SystemColors.Control;
            lblScore6Q9.ForeColor = Color.White;
            lblScore6Q9.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q9.ForeColor = SystemColors.ControlText;
            lblScore7Q9.BackColor = SystemColors.Control;
            lblScore8Q9.ForeColor = SystemColors.ControlText;
            lblScore8Q9.BackColor = SystemColors.Control;
            lblScore9Q9.ForeColor = SystemColors.ControlText;
            lblScore9Q9.BackColor = SystemColors.Control;
            lblScore10Q9.ForeColor = SystemColors.ControlText;
            lblScore10Q9.BackColor = SystemColors.Control;
        }

        private void lblScore7Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = SystemColors.ControlText;
            lblScore1Q9.BackColor = SystemColors.Control;
            lblScore2Q9.ForeColor = SystemColors.ControlText;
            lblScore2Q9.BackColor = SystemColors.Control;
            lblScore3Q9.ForeColor = SystemColors.ControlText;
            lblScore3Q9.BackColor = SystemColors.Control;
            lblScore4Q9.ForeColor = SystemColors.ControlText;
            lblScore4Q9.BackColor = SystemColors.Control;
            lblScore5Q9.ForeColor = SystemColors.ControlText;
            lblScore5Q9.BackColor = SystemColors.Control;
            lblScore6Q9.ForeColor = SystemColors.ControlText;
            lblScore6Q9.BackColor = SystemColors.Control;
            lblScore7Q9.ForeColor = Color.White;
            lblScore7Q9.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q9.ForeColor = SystemColors.ControlText;
            lblScore8Q9.BackColor = SystemColors.Control;
            lblScore9Q9.ForeColor = SystemColors.ControlText;
            lblScore9Q9.BackColor = SystemColors.Control;
            lblScore10Q9.ForeColor = SystemColors.ControlText;
            lblScore10Q9.BackColor = SystemColors.Control;
        }

        private void lblScore8Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = SystemColors.ControlText;
            lblScore1Q9.BackColor = SystemColors.Control;
            lblScore2Q9.ForeColor = SystemColors.ControlText;
            lblScore2Q9.BackColor = SystemColors.Control;
            lblScore3Q9.ForeColor = SystemColors.ControlText;
            lblScore3Q9.BackColor = SystemColors.Control;
            lblScore4Q9.ForeColor = SystemColors.ControlText;
            lblScore4Q9.BackColor = SystemColors.Control;
            lblScore5Q9.ForeColor = SystemColors.ControlText;
            lblScore5Q9.BackColor = SystemColors.Control;
            lblScore6Q9.ForeColor = SystemColors.ControlText;
            lblScore6Q9.BackColor = SystemColors.Control;
            lblScore7Q9.ForeColor = SystemColors.ControlText;
            lblScore7Q9.BackColor = SystemColors.Control;
            lblScore8Q9.ForeColor = Color.White;
            lblScore8Q9.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q9.ForeColor = SystemColors.ControlText;
            lblScore9Q9.BackColor = SystemColors.Control;
            lblScore10Q9.ForeColor = SystemColors.ControlText;
            lblScore10Q9.BackColor = SystemColors.Control;
        }

        private void lblScore9Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = SystemColors.ControlText;
            lblScore1Q9.BackColor = SystemColors.Control;
            lblScore2Q9.ForeColor = SystemColors.ControlText;
            lblScore2Q9.BackColor = SystemColors.Control;
            lblScore3Q9.ForeColor = SystemColors.ControlText;
            lblScore3Q9.BackColor = SystemColors.Control;
            lblScore4Q9.ForeColor = SystemColors.ControlText;
            lblScore4Q9.BackColor = SystemColors.Control;
            lblScore5Q9.ForeColor = SystemColors.ControlText;
            lblScore5Q9.BackColor = SystemColors.Control;
            lblScore6Q9.ForeColor = SystemColors.ControlText;
            lblScore6Q9.BackColor = SystemColors.Control;
            lblScore7Q9.ForeColor = SystemColors.ControlText;
            lblScore7Q9.BackColor = SystemColors.Control;
            lblScore8Q9.ForeColor = SystemColors.ControlText;
            lblScore8Q9.BackColor = SystemColors.Control;
            lblScore9Q9.ForeColor = Color.White;
            lblScore9Q9.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q9.ForeColor = SystemColors.ControlText;
            lblScore10Q9.BackColor = SystemColors.Control;
        }

        private void lblScore10Q9_Click(object sender, EventArgs e)
        {
            lblScore1Q9.ForeColor = SystemColors.ControlText;
            lblScore1Q9.BackColor = SystemColors.Control;
            lblScore2Q9.ForeColor = SystemColors.ControlText;
            lblScore2Q9.BackColor = SystemColors.Control;
            lblScore3Q9.ForeColor = SystemColors.ControlText;
            lblScore3Q9.BackColor = SystemColors.Control;
            lblScore4Q9.ForeColor = SystemColors.ControlText;
            lblScore4Q9.BackColor = SystemColors.Control;
            lblScore5Q9.ForeColor = SystemColors.ControlText;
            lblScore5Q9.BackColor = SystemColors.Control;
            lblScore6Q9.ForeColor = SystemColors.ControlText;
            lblScore6Q9.BackColor = SystemColors.Control;
            lblScore7Q9.ForeColor = SystemColors.ControlText;
            lblScore7Q9.BackColor = SystemColors.Control;
            lblScore8Q9.ForeColor = SystemColors.ControlText;
            lblScore8Q9.BackColor = SystemColors.Control;
            lblScore9Q9.ForeColor = SystemColors.ControlText;
            lblScore9Q9.BackColor = SystemColors.Control;
            lblScore10Q9.ForeColor = Color.White;
            lblScore10Q9.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Question 10 Likert Scale Highlighting

        private void lblScore1Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = Color.White;
            lblScore1Q10.BackColor = Color.FromArgb(252, 3, 3);
            lblScore2Q10.ForeColor = SystemColors.ControlText;
            lblScore2Q10.BackColor = SystemColors.Control;
            lblScore3Q10.ForeColor = SystemColors.ControlText;
            lblScore3Q10.BackColor = SystemColors.Control;
            lblScore4Q10.ForeColor = SystemColors.ControlText;
            lblScore4Q10.BackColor = SystemColors.Control;
            lblScore5Q10.ForeColor = SystemColors.ControlText;
            lblScore5Q10.BackColor = SystemColors.Control;
            lblScore6Q10.ForeColor = SystemColors.ControlText;
            lblScore6Q10.BackColor = SystemColors.Control;
            lblScore7Q10.ForeColor = SystemColors.ControlText;
            lblScore7Q10.BackColor = SystemColors.Control;
            lblScore8Q10.ForeColor = SystemColors.ControlText;
            lblScore8Q10.BackColor = SystemColors.Control;
            lblScore9Q10.ForeColor = SystemColors.ControlText;
            lblScore9Q10.BackColor = SystemColors.Control;
            lblScore10Q10.ForeColor = SystemColors.ControlText;
            lblScore10Q10.BackColor = SystemColors.Control;
        }

        private void lblScore2Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = SystemColors.ControlText;
            lblScore1Q10.BackColor = SystemColors.Control;
            lblScore2Q10.ForeColor = Color.White;
            lblScore2Q10.BackColor = Color.FromArgb(252, 3, 3);
            lblScore3Q10.ForeColor = SystemColors.ControlText;
            lblScore3Q10.BackColor = SystemColors.Control;
            lblScore4Q10.ForeColor = SystemColors.ControlText;
            lblScore4Q10.BackColor = SystemColors.Control;
            lblScore5Q10.ForeColor = SystemColors.ControlText;
            lblScore5Q10.BackColor = SystemColors.Control;
            lblScore6Q10.ForeColor = SystemColors.ControlText;
            lblScore6Q10.BackColor = SystemColors.Control;
            lblScore7Q10.ForeColor = SystemColors.ControlText;
            lblScore7Q10.BackColor = SystemColors.Control;
            lblScore8Q10.ForeColor = SystemColors.ControlText;
            lblScore8Q10.BackColor = SystemColors.Control;
            lblScore9Q10.ForeColor = SystemColors.ControlText;
            lblScore9Q10.BackColor = SystemColors.Control;
            lblScore10Q10.ForeColor = SystemColors.ControlText;
            lblScore10Q10.BackColor = SystemColors.Control;
        }

        private void lblScore3Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = SystemColors.ControlText;
            lblScore1Q10.BackColor = SystemColors.Control;
            lblScore2Q10.ForeColor = SystemColors.ControlText;
            lblScore2Q10.BackColor = SystemColors.Control;
            lblScore3Q10.ForeColor = Color.White;
            lblScore3Q10.BackColor = Color.FromArgb(252, 78, 3);
            lblScore4Q10.ForeColor = SystemColors.ControlText;
            lblScore4Q10.BackColor = SystemColors.Control;
            lblScore5Q10.ForeColor = SystemColors.ControlText;
            lblScore5Q10.BackColor = SystemColors.Control;
            lblScore6Q10.ForeColor = SystemColors.ControlText;
            lblScore6Q10.BackColor = SystemColors.Control;
            lblScore7Q10.ForeColor = SystemColors.ControlText;
            lblScore7Q10.BackColor = SystemColors.Control;
            lblScore8Q10.ForeColor = SystemColors.ControlText;
            lblScore8Q10.BackColor = SystemColors.Control;
            lblScore9Q10.ForeColor = SystemColors.ControlText;
            lblScore9Q10.BackColor = SystemColors.Control;
            lblScore10Q10.ForeColor = SystemColors.ControlText;
            lblScore10Q10.BackColor = SystemColors.Control;
        }

        private void lblScore4Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = SystemColors.ControlText;
            lblScore1Q10.BackColor = SystemColors.Control;
            lblScore2Q10.ForeColor = SystemColors.ControlText;
            lblScore2Q10.BackColor = SystemColors.Control;
            lblScore3Q10.ForeColor = SystemColors.ControlText;
            lblScore3Q10.BackColor = SystemColors.Control;
            lblScore4Q10.ForeColor = Color.White;
            lblScore4Q10.BackColor = Color.FromArgb(252, 78, 3);
            lblScore5Q10.ForeColor = SystemColors.ControlText;
            lblScore5Q10.BackColor = SystemColors.Control;
            lblScore6Q10.ForeColor = SystemColors.ControlText;
            lblScore6Q10.BackColor = SystemColors.Control;
            lblScore7Q10.ForeColor = SystemColors.ControlText;
            lblScore7Q10.BackColor = SystemColors.Control;
            lblScore8Q10.ForeColor = SystemColors.ControlText;
            lblScore8Q10.BackColor = SystemColors.Control;
            lblScore9Q10.ForeColor = SystemColors.ControlText;
            lblScore9Q10.BackColor = SystemColors.Control;
            lblScore10Q10.ForeColor = SystemColors.ControlText;
            lblScore10Q10.BackColor = SystemColors.Control;
        }

        private void lblScore5Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = SystemColors.ControlText;
            lblScore1Q10.BackColor = SystemColors.Control;
            lblScore2Q10.ForeColor = SystemColors.ControlText;
            lblScore2Q10.BackColor = SystemColors.Control;
            lblScore3Q10.ForeColor = SystemColors.ControlText;
            lblScore3Q10.BackColor = SystemColors.Control;
            lblScore4Q10.ForeColor = SystemColors.ControlText;
            lblScore4Q10.BackColor = SystemColors.Control;
            lblScore5Q10.ForeColor = Color.White;
            lblScore5Q10.BackColor = Color.FromArgb(248, 252, 3);
            lblScore6Q10.ForeColor = SystemColors.ControlText;
            lblScore6Q10.BackColor = SystemColors.Control;
            lblScore7Q10.ForeColor = SystemColors.ControlText;
            lblScore7Q10.BackColor = SystemColors.Control;
            lblScore8Q10.ForeColor = SystemColors.ControlText;
            lblScore8Q10.BackColor = SystemColors.Control;
            lblScore9Q10.ForeColor = SystemColors.ControlText;
            lblScore9Q10.BackColor = SystemColors.Control;
            lblScore10Q10.ForeColor = SystemColors.ControlText;
            lblScore10Q10.BackColor = SystemColors.Control;
        }

        private void lblScore6Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = SystemColors.ControlText;
            lblScore1Q10.BackColor = SystemColors.Control;
            lblScore2Q10.ForeColor = SystemColors.ControlText;
            lblScore2Q10.BackColor = SystemColors.Control;
            lblScore3Q10.ForeColor = SystemColors.ControlText;
            lblScore3Q10.BackColor = SystemColors.Control;
            lblScore4Q10.ForeColor = SystemColors.ControlText;
            lblScore4Q10.BackColor = SystemColors.Control;
            lblScore5Q10.ForeColor = SystemColors.ControlText;
            lblScore5Q10.BackColor = SystemColors.Control;
            lblScore6Q10.ForeColor = Color.White;
            lblScore6Q10.BackColor = Color.FromArgb(248, 252, 3);
            lblScore7Q10.ForeColor = SystemColors.ControlText;
            lblScore7Q10.BackColor = SystemColors.Control;
            lblScore8Q10.ForeColor = SystemColors.ControlText;
            lblScore8Q10.BackColor = SystemColors.Control;
            lblScore9Q10.ForeColor = SystemColors.ControlText;
            lblScore9Q10.BackColor = SystemColors.Control;
            lblScore10Q10.ForeColor = SystemColors.ControlText;
            lblScore10Q10.BackColor = SystemColors.Control;
        }

        private void lblScore7Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = SystemColors.ControlText;
            lblScore1Q10.BackColor = SystemColors.Control;
            lblScore2Q10.ForeColor = SystemColors.ControlText;
            lblScore2Q10.BackColor = SystemColors.Control;
            lblScore3Q10.ForeColor = SystemColors.ControlText;
            lblScore3Q10.BackColor = SystemColors.Control;
            lblScore4Q10.ForeColor = SystemColors.ControlText;
            lblScore4Q10.BackColor = SystemColors.Control;
            lblScore5Q10.ForeColor = SystemColors.ControlText;
            lblScore5Q10.BackColor = SystemColors.Control;
            lblScore6Q10.ForeColor = SystemColors.ControlText;
            lblScore6Q10.BackColor = SystemColors.Control;
            lblScore7Q10.ForeColor = Color.White;
            lblScore7Q10.BackColor = Color.FromArgb(119, 252, 3);
            lblScore8Q10.ForeColor = SystemColors.ControlText;
            lblScore8Q10.BackColor = SystemColors.Control;
            lblScore9Q10.ForeColor = SystemColors.ControlText;
            lblScore9Q10.BackColor = SystemColors.Control;
            lblScore10Q10.ForeColor = SystemColors.ControlText;
            lblScore10Q10.BackColor = SystemColors.Control;
        }

        private void lblScore8Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = SystemColors.ControlText;
            lblScore1Q10.BackColor = SystemColors.Control;
            lblScore2Q10.ForeColor = SystemColors.ControlText;
            lblScore2Q10.BackColor = SystemColors.Control;
            lblScore3Q10.ForeColor = SystemColors.ControlText;
            lblScore3Q10.BackColor = SystemColors.Control;
            lblScore4Q10.ForeColor = SystemColors.ControlText;
            lblScore4Q10.BackColor = SystemColors.Control;
            lblScore5Q10.ForeColor = SystemColors.ControlText;
            lblScore5Q10.BackColor = SystemColors.Control;
            lblScore6Q10.ForeColor = SystemColors.ControlText;
            lblScore6Q10.BackColor = SystemColors.Control;
            lblScore7Q10.ForeColor = SystemColors.ControlText;
            lblScore7Q10.BackColor = SystemColors.Control;
            lblScore8Q10.ForeColor = Color.White;
            lblScore8Q10.BackColor = Color.FromArgb(119, 252, 3);
            lblScore9Q10.ForeColor = SystemColors.ControlText;
            lblScore9Q10.BackColor = SystemColors.Control;
            lblScore10Q10.ForeColor = SystemColors.ControlText;
            lblScore10Q10.BackColor = SystemColors.Control;
        }

        private void lblScore9Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = SystemColors.ControlText;
            lblScore1Q10.BackColor = SystemColors.Control;
            lblScore2Q10.ForeColor = SystemColors.ControlText;
            lblScore2Q10.BackColor = SystemColors.Control;
            lblScore3Q10.ForeColor = SystemColors.ControlText;
            lblScore3Q10.BackColor = SystemColors.Control;
            lblScore4Q10.ForeColor = SystemColors.ControlText;
            lblScore4Q10.BackColor = SystemColors.Control;
            lblScore5Q10.ForeColor = SystemColors.ControlText;
            lblScore5Q10.BackColor = SystemColors.Control;
            lblScore6Q10.ForeColor = SystemColors.ControlText;
            lblScore6Q10.BackColor = SystemColors.Control;
            lblScore7Q10.ForeColor = SystemColors.ControlText;
            lblScore7Q10.BackColor = SystemColors.Control;
            lblScore8Q10.ForeColor = SystemColors.ControlText;
            lblScore8Q10.BackColor = SystemColors.Control;
            lblScore9Q10.ForeColor = Color.White;
            lblScore9Q10.BackColor = Color.FromArgb(3, 252, 20);
            lblScore10Q10.ForeColor = SystemColors.ControlText;
            lblScore10Q10.BackColor = SystemColors.Control;
        }

        private void lblScore10Q10_Click(object sender, EventArgs e)
        {
            lblScore1Q10.ForeColor = SystemColors.ControlText;
            lblScore1Q10.BackColor = SystemColors.Control;
            lblScore2Q10.ForeColor = SystemColors.ControlText;
            lblScore2Q10.BackColor = SystemColors.Control;
            lblScore3Q10.ForeColor = SystemColors.ControlText;
            lblScore3Q10.BackColor = SystemColors.Control;
            lblScore4Q10.ForeColor = SystemColors.ControlText;
            lblScore4Q10.BackColor = SystemColors.Control;
            lblScore5Q10.ForeColor = SystemColors.ControlText;
            lblScore5Q10.BackColor = SystemColors.Control;
            lblScore6Q10.ForeColor = SystemColors.ControlText;
            lblScore6Q10.BackColor = SystemColors.Control;
            lblScore7Q10.ForeColor = SystemColors.ControlText;
            lblScore7Q10.BackColor = SystemColors.Control;
            lblScore8Q10.ForeColor = SystemColors.ControlText;
            lblScore8Q10.BackColor = SystemColors.Control;
            lblScore9Q10.ForeColor = SystemColors.ControlText;
            lblScore9Q10.BackColor = SystemColors.Control;
            lblScore10Q10.ForeColor = Color.White;
            lblScore10Q10.BackColor = Color.FromArgb(3, 252, 20);
        }

        // Back button
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Return to home page
            this.Close();
        }
    }
}
