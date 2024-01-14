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
    public partial class frmEditSurvey : Form
    {
        public frmEditSurvey()
        {
            InitializeComponent();
        }

        // Database Connection
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\source\repos\Consumer Survey System\Consumer Survey System\database.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;

        private void frmEditSurvey_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT * FROM survey WHERE id= '" + frmAdminMain.surveyID + "'", con);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtSurveyName.Text = dt.Rows[0]["name"].ToString();
            con.Close();

            con.Open();
            cmd = new SqlCommand("SELECT * FROM question WHERE survey_id= '" + frmAdminMain.surveyID + "'", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
            }
            else if (dt.Rows.Count == 2)
            {
                btnAddQuestion2.Visible = false;
                gbxQuestion2.Visible = true;
                btnAddQuestion3.Visible = true;
                btnRemoveQuestion2.Visible = true;
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
                txtDescription2.Text = dt.Rows[1]["description"].ToString();
                cbxFormat2.Text = dt.Rows[1]["question_format"].ToString();
            }
            else if (dt.Rows.Count == 3)
            {
                btnAddQuestion2.Visible = false;
                gbxQuestion2.Visible = true;
                gbxQuestion3.Visible = true;
                btnAddQuestion4.Visible = true;
                btnRemoveQuestion3.Visible = true;
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
                txtDescription2.Text = dt.Rows[1]["description"].ToString();
                cbxFormat2.Text = dt.Rows[1]["question_format"].ToString();
                txtDescription3.Text = dt.Rows[2]["description"].ToString();
                cbxFormat3.Text = dt.Rows[2]["question_format"].ToString();
            }
            else if (dt.Rows.Count == 4)
            {
                btnAddQuestion2.Visible = false;
                gbxQuestion2.Visible = true;
                gbxQuestion3.Visible = true;
                gbxQuestion4.Visible = true;
                btnAddQuestion5.Visible = true;
                btnRemoveQuestion4.Visible = true;
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
                txtDescription2.Text = dt.Rows[1]["description"].ToString();
                cbxFormat2.Text = dt.Rows[1]["question_format"].ToString();
                txtDescription3.Text = dt.Rows[2]["description"].ToString();
                cbxFormat3.Text = dt.Rows[2]["question_format"].ToString();
                txtDescription3.Text = dt.Rows[3]["description"].ToString();
                cbxFormat3.Text = dt.Rows[3]["question_format"].ToString();
            }
            else if (dt.Rows.Count == 5)
            {
                btnAddQuestion2.Visible = false;
                gbxQuestion2.Visible = true;
                gbxQuestion3.Visible = true;
                gbxQuestion4.Visible = true;
                gbxQuestion5.Visible = true;
                btnAddQuestion6.Visible = true;
                btnRemoveQuestion5.Visible = true;
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
                txtDescription2.Text = dt.Rows[1]["description"].ToString();
                cbxFormat2.Text = dt.Rows[1]["question_format"].ToString();
                txtDescription3.Text = dt.Rows[2]["description"].ToString();
                cbxFormat3.Text = dt.Rows[2]["question_format"].ToString();
                txtDescription4.Text = dt.Rows[3]["description"].ToString();
                cbxFormat4.Text = dt.Rows[3]["question_format"].ToString();
                txtDescription5.Text = dt.Rows[4]["description"].ToString();
                cbxFormat5.Text = dt.Rows[4]["question_format"].ToString();
            }
            else if (dt.Rows.Count == 6)
            {
                btnAddQuestion2.Visible = false;
                gbxQuestion2.Visible = true;
                gbxQuestion3.Visible = true;
                gbxQuestion4.Visible = true;
                gbxQuestion5.Visible = true;
                gbxQuestion6.Visible = true;
                btnAddQuestion7.Visible = true;
                btnRemoveQuestion6.Visible = true;
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
                txtDescription2.Text = dt.Rows[1]["description"].ToString();
                cbxFormat2.Text = dt.Rows[1]["question_format"].ToString();
                txtDescription3.Text = dt.Rows[2]["description"].ToString();
                cbxFormat3.Text = dt.Rows[2]["question_format"].ToString();
                txtDescription4.Text = dt.Rows[3]["description"].ToString();
                cbxFormat4.Text = dt.Rows[3]["question_format"].ToString();
                txtDescription5.Text = dt.Rows[4]["description"].ToString();
                cbxFormat5.Text = dt.Rows[4]["question_format"].ToString();
                txtDescription6.Text = dt.Rows[5]["description"].ToString();
                cbxFormat6.Text = dt.Rows[5]["question_format"].ToString();
            }
            else if (dt.Rows.Count == 7)
            {
                btnAddQuestion2.Visible = false;
                gbxQuestion2.Visible = true;
                gbxQuestion3.Visible = true;
                gbxQuestion4.Visible = true;
                gbxQuestion5.Visible = true;
                gbxQuestion6.Visible = true;
                gbxQuestion7.Visible = true;
                btnAddQuestion8.Visible = true;
                btnRemoveQuestion7.Visible = true;
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
                txtDescription2.Text = dt.Rows[1]["description"].ToString();
                cbxFormat2.Text = dt.Rows[1]["question_format"].ToString();
                txtDescription3.Text = dt.Rows[2]["description"].ToString();
                cbxFormat3.Text = dt.Rows[2]["question_format"].ToString();
                txtDescription4.Text = dt.Rows[3]["description"].ToString();
                cbxFormat4.Text = dt.Rows[3]["question_format"].ToString();
                txtDescription5.Text = dt.Rows[4]["description"].ToString();
                cbxFormat5.Text = dt.Rows[4]["question_format"].ToString();
                txtDescription6.Text = dt.Rows[5]["description"].ToString();
                cbxFormat6.Text = dt.Rows[5]["question_format"].ToString();
                txtDescription7.Text = dt.Rows[6]["description"].ToString();
                cbxFormat7.Text = dt.Rows[6]["question_format"].ToString();
            }
            else if (dt.Rows.Count == 8)
            {
                btnAddQuestion2.Visible = false;
                gbxQuestion2.Visible = true;
                gbxQuestion3.Visible = true;
                gbxQuestion4.Visible = true;
                gbxQuestion5.Visible = true;
                gbxQuestion6.Visible = true;
                gbxQuestion7.Visible = true;
                gbxQuestion8.Visible = true;
                btnAddQuestion9.Visible = true;
                btnRemoveQuestion8.Visible = true;
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
                txtDescription2.Text = dt.Rows[1]["description"].ToString();
                cbxFormat2.Text = dt.Rows[1]["question_format"].ToString();
                txtDescription3.Text = dt.Rows[2]["description"].ToString();
                cbxFormat3.Text = dt.Rows[2]["question_format"].ToString();
                txtDescription4.Text = dt.Rows[3]["description"].ToString();
                cbxFormat4.Text = dt.Rows[3]["question_format"].ToString();
                txtDescription5.Text = dt.Rows[4]["description"].ToString();
                cbxFormat5.Text = dt.Rows[4]["question_format"].ToString();
                txtDescription6.Text = dt.Rows[5]["description"].ToString();
                cbxFormat6.Text = dt.Rows[5]["question_format"].ToString();
                txtDescription7.Text = dt.Rows[6]["description"].ToString();
                cbxFormat7.Text = dt.Rows[6]["question_format"].ToString();
                txtDescription8.Text = dt.Rows[7]["description"].ToString();
                cbxFormat8.Text = dt.Rows[7]["question_format"].ToString();
            }
            else if (dt.Rows.Count == 9)
            {
                btnAddQuestion2.Visible = false;
                gbxQuestion2.Visible = true;
                gbxQuestion3.Visible = true;
                gbxQuestion4.Visible = true;
                gbxQuestion5.Visible = true;
                gbxQuestion6.Visible = true;
                gbxQuestion7.Visible = true;
                gbxQuestion8.Visible = true;
                gbxQuestion9.Visible = true;
                btnAddQuestion10.Visible = true;
                btnRemoveQuestion9.Visible = true;
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
                txtDescription2.Text = dt.Rows[1]["description"].ToString();
                cbxFormat2.Text = dt.Rows[1]["question_format"].ToString();
                txtDescription3.Text = dt.Rows[2]["description"].ToString();
                cbxFormat3.Text = dt.Rows[2]["question_format"].ToString();
                txtDescription4.Text = dt.Rows[3]["description"].ToString();
                cbxFormat4.Text = dt.Rows[3]["question_format"].ToString();
                txtDescription5.Text = dt.Rows[4]["description"].ToString();
                cbxFormat5.Text = dt.Rows[4]["question_format"].ToString();
                txtDescription6.Text = dt.Rows[5]["description"].ToString();
                cbxFormat6.Text = dt.Rows[5]["question_format"].ToString();
                txtDescription7.Text = dt.Rows[6]["description"].ToString();
                cbxFormat7.Text = dt.Rows[6]["question_format"].ToString();
                txtDescription8.Text = dt.Rows[7]["description"].ToString();
                cbxFormat8.Text = dt.Rows[7]["question_format"].ToString();
                txtDescription9.Text = dt.Rows[8]["description"].ToString();
                cbxFormat9.Text = dt.Rows[8]["question_format"].ToString();
            }
            else if (dt.Rows.Count == 9)
            {
                btnAddQuestion2.Visible = false;
                gbxQuestion2.Visible = true;
                gbxQuestion3.Visible = true;
                gbxQuestion4.Visible = true;
                gbxQuestion5.Visible = true;
                gbxQuestion6.Visible = true;
                gbxQuestion7.Visible = true;
                gbxQuestion8.Visible = true;
                gbxQuestion9.Visible = true;
                gbxQuestion10.Visible = true;
                btnRemoveQuestion10.Visible = true;
                txtDescription1.Text = dt.Rows[0]["description"].ToString();
                cbxFormat1.Text = dt.Rows[0]["question_format"].ToString();
                txtDescription2.Text = dt.Rows[1]["description"].ToString();
                cbxFormat2.Text = dt.Rows[1]["question_format"].ToString();
                txtDescription3.Text = dt.Rows[2]["description"].ToString();
                cbxFormat3.Text = dt.Rows[2]["question_format"].ToString();
                txtDescription4.Text = dt.Rows[3]["description"].ToString();
                cbxFormat4.Text = dt.Rows[3]["question_format"].ToString();
                txtDescription5.Text = dt.Rows[4]["description"].ToString();
                cbxFormat5.Text = dt.Rows[4]["question_format"].ToString();
                txtDescription6.Text = dt.Rows[5]["description"].ToString();
                cbxFormat6.Text = dt.Rows[5]["question_format"].ToString();
                txtDescription7.Text = dt.Rows[6]["description"].ToString();
                cbxFormat7.Text = dt.Rows[6]["question_format"].ToString();
                txtDescription8.Text = dt.Rows[7]["description"].ToString();
                cbxFormat8.Text = dt.Rows[7]["question_format"].ToString();
                txtDescription9.Text = dt.Rows[8]["description"].ToString();
                cbxFormat9.Text = dt.Rows[8]["question_format"].ToString();
                txtDescription10.Text = dt.Rows[9]["description"].ToString();
                cbxFormat10.Text = dt.Rows[9]["question_format"].ToString();
            }

            con.Close();

        }
    }
}
