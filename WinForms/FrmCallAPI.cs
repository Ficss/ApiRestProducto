using ApiRestProducto.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class FrmCallAPI : Form
    {
        
        public FrmCallAPI()
        {
            InitializeComponent();
        }

        private async void FrmCallAPI_Load(object sender, EventArgs e)
        {
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44332/api/Marca");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await RestHelper.GetAll("subcategoria");

            //string respuesta = await GetHttp();
            List<Subcategoria> lst = JsonConvert.DeserializeObject<List<Subcategoria>>(response);
            dataGridView1.DataSource = lst;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            var response = await RestHelper.GetId("subcategoria", id);

            //string respuesta = await GetHttp();
            Subcategoria model = JsonConvert.DeserializeObject<Subcategoria>(response);


            dataGridView1.DataSource = model;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var response = await RestHelper.Post("subcategoria",textBox2.Text);
            List<Subcategoria> lst = JsonConvert.DeserializeObject<List<Subcategoria>>(response);
            dataGridView1.DataSource = lst;
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
    }
}
