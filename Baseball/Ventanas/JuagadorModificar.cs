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
            textBox11.Text = jugador.salarie;
            textBox1.Text = jugador.playerID;
            textBox2.Text = jugador.nameFirst;
            textBox3.Text = jugador.nameLast;
            textBox10.Text = jugador.nameGiven;
            textBox4.Text = jugador.birthCountry;
            textBox5.Text = jugador.birthState;
            textBox6.Text = jugador.birthCity;
            DateTime fechanac = new DateTime(jugador.birthYear, jugador.birthMonth, jugador.birthDay);
            dateTimePicker1.Value = fechanac;
            textBox9.Text = jugador.deathCountry;
            textBox8.Text = jugador.deathState;
            textBox7.Text = jugador.deathCity;
            if(jugador.deathMonth==0||jugador.deathYear==0||jugador.deathDay==0)
            {
                label20.Text = "No es fiambre";                
                label20.ForeColor = Color.Green;
            }
            else
            { 
            DateTime fechamuert = new DateTime(jugador.deathYear, jugador.deathMonth, jugador.deathDay);
            dateTimePicker2.Value = fechamuert;
                label20.Text = "Es fiambre";
                label20.ForeColor = Color.Red;
            }
            
            numericUpDown1.Value = jugador.weight;
            numericUpDown2.Value = (Decimal)jugador.height;
            comboBox1.SelectedItem = jugador.bats.ToString();
            comboBox2.SelectedItem = jugador.throws.ToString();
            if (jugador.salarie != null) {
            textBox11.Text = jugador.salarie.ToString();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {

            ServiceReference2.ServiceBaseball2Client cliente = new ServiceReference2.ServiceBaseball2Client();
            Jugador jugador = new Jugador();
            jugador.playerID = textBox1.Text;
            jugador.nameFirst = textBox2.Text;
            jugador.nameLast = textBox3.Text;
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
    }
}
