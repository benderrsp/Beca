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
        //public Form1 form1 { get; set; }
        public string idJugador { get; set; }
        public JuagadorModificar(string id)
        {
            InitializeComponent();
            ServiceReference2.ServiceBaseball2Client cliente = new ServiceReference2.ServiceBaseball2Client();
            Jugador jugador = cliente.jugador(id);
            textBox1.Text = jugador.playerID;
            textBox2.Text = jugador.nameFirst;
            textBox3.Text = jugador.nameLast;
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
            //form1.ActualizarJugadores();
            


        }

        private void JuagadorModificar_Load(object sender, EventArgs e)
        {

        }
    }
}
