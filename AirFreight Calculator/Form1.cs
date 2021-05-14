using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AirFreight_Calculator
{
    public partial class Form1 : Form
    {
        MySqlConnection Conn;

        public Form1()
        {
            InitializeComponent();
            this.Conn = Connect.InitDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CloseUCs();
            Clear_PackingList();
        }


        private void Bn_GenUser_Click(object sender, EventArgs e)
        {
            CloseAllControls();
            this.uC_CargoItem1.Visible = true;
        }

        private void CloseUCs()
        {
            foreach (Control item in this.Controls)
            {
                if (item is UserControl)
                    item.Visible = false;
                if (item is Button)
                    item.Visible = true;
                if (item is Label)
                    item.Visible = true;
                if (item is MenuStrip)
                    item .Visible = true;
            }
        }

        private void CloseAllControls()
        {
            foreach (Control item in this.Controls)
            {
                item.Visible = false;
                if (item is MenuStrip)
                    item.Visible = true;
            }
        }

        private void Clear_PackingList()
        {
            string sql = "CALL pr_Clear_PackingList();";
            MySqlCommand cmd = new MySqlCommand(sql, this.Conn);
            this.Conn.Open();
            cmd.ExecuteNonQuery();
            this.Conn.Close();
        }

        private void TSMI_CargoItem_Click(object sender, EventArgs e)
        {
            uC_CargoItem1.ClearCargoItem();
            uC_CargoItem1.ClearCargoItemRows();
            Clear_PackingList();
            this.uC_AirCargo1.ResetDestinations();
            this.uC_AirCargo1.ResetAirCargo();
            this.uC_AirCargo1.Visible = false;
            foreach (Control item in this.Controls)
            {
                if (item is UserControl)
                    item.Visible = false;
                if (item is Button)
                    (item as Button).Visible = false;
                if (item is Label)
                    (item as Label).Visible = false;
            }
            this.uC_CargoItem1.Visible = true;
        }

        private void TSMI_AirCargo_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is UserControl)
                    item.Visible = false;
                if (item is Button)
                    (item as Button).Visible = false;
                if (item is Label)
                    (item as Label).Visible = false;
            }
            this.uC_AirCargo1.Visible = true;
            this.uC_AirCargo1.ResetBn_PackingList();

        }

        private void TSMI_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clear_PackingList();
        }
    }
}
