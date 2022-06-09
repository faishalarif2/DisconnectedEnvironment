using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisconnectedEnvironment
{
    public partial class Form1 : Form
    {
        DataTable dt;
        DataRow dr;
        string code;
        public Form1()
        {
            InitializeComponent();

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'prodiTIDataSet.DisconnectedEnvironment' table. You can move, or remove it, as needed.
            this.disconnectedEnvironmentTableAdapter.Fill(this.prodiTIDataSet.DisconnectedEnvironment);
            // TODO: This line of code loads data into the 'prodiTIDataSet1.Mahasiswa' table. You can move, or remove it, as needed.
            this.disconnectedEnvironmentTableAdapter.Fill(this.prodiTIDataSet.DisconnectedEnvironment);
            // TODO: This line of code loads data into the 'prodiTIDataSet1.HRDataSet' table. You can move, or remove it, as needed.
            this.disconnectedEnvironmentTableAdapter.Fill(this.prodiTIDataSet.DisconnectedEnvironment);
            // TODO: This line of code loads data into the 'prodiTIDataSet.Mahasiswa' table. You can move, or remove it, as needed.
            this.disconnectedEnvironmentTableAdapter.Fill(this.prodiTIDataSet.DisconnectedEnvironment);
            // TOFO:This line of code loads data into the 'hRDataSet.empdetails' table.
            //you da move, or remove it, as needed
            this.disconnectedEnvironmentTableAdapter.Fill(this.prodiTIDataSet.DisconnectedEnvironment);

            this.disconnectedEnvironmentTableAdapter.Fill(this.prodiTIDataSet.DisconnectedEnvironment);
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            CbDesignation.Enabled = false;
            CbDepartment.Enabled = false;
            CbDesignation.Items.Add("MANAGER");
            CbDesignation.Items.Add("EMPLOYEE");
            CbDepartment.Items.Add("FINANCE");
            CbDepartment.Items.Add("FINANCE");
            cmdSave.Enabled = false;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            cmdSave.Enabled = true;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtState.Enabled = true;
            txtCountry.Enabled = true;
            CbDesignation.Enabled = true;
            CbDepartment.Enabled = true;
            txtName.Text = "";
            txtAddress.Text = "";
            txtState.Text = "";
            txtCountry.Text = "";
            CbDesignation.Text = "";
            CbDepartment.Text = "";
            int ctr, len;
            string codeval;
            dt = prodiTIDataSet.Tables["HRDataSet"];
            len = dt.Rows.Count - 1;
            dr = dt.Rows[len];
            code = dr["ccode"].ToString();
            codeval = code.Substring(1, 3);
            ctr = Convert.ToInt32(codeval);
            if ((ctr > 1) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtCode.Text = "coo" + ctr;
            }
            else if ((ctr >= 1) && (ctr < 9))
            {
                ctr = ctr + 1;
                txtCode.Text = "C0" + ctr;
            }
            cmdAdd.Enabled = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dt = prodiTIDataSet.Tables["HRDataSet"];
            dr = dt.NewRow();
            dr[0] = txtCode.Text;
            dr[1] = txtName.Text;
            dr[2] = txtAddress.Text;
            dr[3] = txtState.Text;
            dr[4] = txtCountry.Text;
            dr[5] = CbDesignation.SelectedItem;
            dr[6] = CbDepartment.SelectedItem;
            dt.Rows.Add(dr);
            this.disconnectedEnvironmentTableAdapter.Update(prodiTIDataSet);
            txtCode.Text = System.Convert.ToString(dr[0]);
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtState.Enabled = false;
            txtCountry.Enabled = false;
            CbDesignation.Enabled = false;
            CbDepartment.Enabled = false;
            this.disconnectedEnvironmentTableAdapter.Fill(this.prodiTIDataSet.DisconnectedEnvironment);
            cmdAdd.Enabled = true;
            cmdSave.Enabled = false;
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            string code;
            code = txtCode.Text;
            dr = prodiTIDataSet.Tables["HRDataSet"].Rows.Find(code);
            dr.Delete();
            disconnectedEnvironmentTableAdapter.Update(prodiTIDataSet);
        }
    }
}
