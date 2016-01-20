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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ServiceReference1.ServiceBaseballClient cliente = new ServiceReference1.ServiceBaseballClient();
            numericUpDown1.Minimum = cliente.GetAñoInicio();
            numericUpDown1.Maximum= cliente.GetAñoFin();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ServiceReference1.ServiceBaseballClient cliente = new ServiceReference1.ServiceBaseballClient();
            int año = Convert.ToInt16(numericUpDown1.Value);
            List<Equipo> equipos = (cliente.GetEquiposAño(año)).ToList();
            listBox1.DataSource = equipos;
            listBox1.DisplayMember = "name";
        }
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarJugadores();
        }
        public void ActualizarJugadores()
        {
            ServiceReference1.ServiceBaseballClient cliente = new ServiceReference1.ServiceBaseballClient();
            int año = Convert.ToInt16(numericUpDown1.Value);
            Equipo equipo = (Equipo)listBox1.SelectedItem;

            List<Jugador> jugadores = (cliente.GetJugadoresEquipo(equipo.teamID, año)).ToList();
            listBox2.DataSource = jugadores;
            listBox2.DisplayMember = "NombreCompleto";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jugador jugador = (Jugador)listBox2.SelectedItem;
            Equipo equipo = (Equipo)listBox1.SelectedItem;
            JuagadorModificar modificar = new JuagadorModificar(jugador.playerID, true, (int)numericUpDown1.Value, equipo.teamID.ToString());

            
            modificar.ShowDialog();
            this.ActualizarJugadores();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarJugadores();
        }
    }
}
