using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Ventanas
{
    public partial class JuagadorModificar : Form
    {

        public JuagadorModificar(string id, bool editando, int año, string equipo)
        {

            InitializeComponent();

            if (editando == true)
            {
                CargarJugador(id,año,equipo);
               
            }

        }
        
        private void CargarJugador(string id, int año, string equipo)
        {

            //Rangos y valores de numericUpDown y Combobox
            
            dateTimePicker1.MinDate = new DateTime(1800, 1, 1);
            dateTimePicker2.MinDate = new DateTime(1800, 1, 1);

            comboBox1.Items.Add("R");
            comboBox1.Items.Add("L");
            comboBox1.Items.Add("B");

            comboBox2.Items.Add("R");
            comboBox2.Items.Add("L");
            comboBox2.Items.Add("B");

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 3000;

            numericUpDown2.Minimum = 0;
            numericUpDown2.Maximum = 3000;

            textBox1.ReadOnly = true;


            ServiceReference2.ServiceBaseball2Client cliente = new ServiceReference2.ServiceBaseball2Client();
            Jugador jugador = cliente.jugador(id, año, equipo);
      
            textBox1.Text = jugador.playerID;
            textBox2.Text = jugador.nameFirst;
            textBox3.Text = jugador.nameLast;
            textBox10.Text = jugador.nameGiven;
            textBox4.Text = jugador.birthCountry;
            textBox5.Text = jugador.birthState;
            textBox6.Text = jugador.birthCity;
            if(jugador.birthYear==0||jugador.birthMonth==0||jugador.birthDay==0)
            {
                label21.Text = "Error fecha";
                label21.ForeColor = Color.Red;
            }
            else
            {
                DateTime fechanac = new DateTime(jugador.birthYear, jugador.birthMonth, jugador.birthDay);
                dateTimePicker1.Value = fechanac;
            }
           
            
            textBox9.Text = jugador.deathCountry;
            textBox8.Text = jugador.deathState;
            textBox7.Text = jugador.deathCity;

            if(jugador.esfiambre==false)
            {
                label20.Text = "No es fiambre";                
                label20.ForeColor = Color.Green;
                nofiambre();
                
            }
            else
            { 
            DateTime fechamuert = new DateTime(jugador.deathYear, jugador.deathMonth, jugador.deathDay);
            dateTimePicker2.Value = fechamuert;
                label20.Text = "Es fiambre";
                label20.ForeColor = Color.Red;
                fiambre();
                
            }
            
            numericUpDown1.Value = jugador.weight;
            numericUpDown2.Value = (Decimal)jugador.height;
            comboBox1.SelectedItem = jugador.bats.ToString();
            comboBox2.SelectedItem = jugador.throws.ToString();
            
            //SALARIOS

            List<string[]> salarios = (cliente.ObtenerSalarios(jugador.playerID)).ToList();
            foreach (string[] registro in salarios)
            {
                dataGridView1.Rows.Add(registro);
            }
          

        }


        private void button1_Click(object sender, EventArgs e)
        {

            ServiceReference2.ServiceBaseball2Client cliente = new ServiceReference2.ServiceBaseball2Client();
            Jugador jugador = new Jugador();
            
            jugador.playerID = textBox1.Text;
            jugador.nameFirst = textBox2.Text;
            jugador.nameLast = textBox3.Text;
            jugador.nameGiven = textBox10.Text;
            jugador.birthCountry = textBox4.Text;
            jugador.birthState = textBox5.Text;
            jugador.birthCity = textBox6.Text;
            jugador.birthDay = dateTimePicker1.Value.Day;
            jugador.birthMonth= dateTimePicker1.Value.Month;
            jugador.birthYear = dateTimePicker1.Value.Year;
            cliente.RellenarJugador(jugador);
           
            this.Close();
           
        }

        private void JuagadorModificar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
            {
                nofiambre();
            }
            else if(checkBox1.Checked == true)
            {
                fiambre();
            }
        }
        private void fiambre()
        {
            textBox9.Enabled = true;
            textBox8.Enabled = true;
            textBox7.Enabled = true;
            dateTimePicker2.Enabled = true;
            checkBox1.Checked = true;


        }
        private void nofiambre()
        {
            textBox9.Enabled = false;
            textBox8.Enabled = false;
            textBox7.Enabled = false;
            dateTimePicker2.Enabled = false;
            checkBox1.Checked = false;
        }
    }
}
