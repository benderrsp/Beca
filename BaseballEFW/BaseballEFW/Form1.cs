using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BaseballEFW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();

            int[] limitesanos = CargarAños();
            numericUpDown1.Minimum = limitesanos[0];
            numericUpDown1.Maximum = limitesanos[1];

        }

        public int[] CargarAños()
        {
            int[] limitesanos = new int[2];
            using (BaseballEntities contexto = new BaseballEntities())
            {                
                var anomin = (contexto.Teams.Select(año => año.yearID)).Min();
                limitesanos[0] = anomin;

                var anomax= (contexto.Teams.Select(año => año.yearID)).Max();
                limitesanos[1] = anomax;
            }
            return limitesanos;
        }

        public List<Teams> CargarEquipos(int año)
        {

            List<Teams> listaequipos;
            using (BaseballEntities contexto = new BaseballEntities())
            {                
                var equip = from equipos in contexto.Teams where equipos.yearID == año select equipos;
                listaequipos = equip.ToList();               
            }
            
            return listaequipos;
                      
        }

        public List<Master> CargarJugadores(string equipoID, int año)
        {
            List<Master> listajugadores;
            using (BaseballEntities contexto = new BaseballEntities())
            {
      
                var varjugadores = from apariciones in contexto.Appearances
                                   join jugadores in contexto.Master 
                                   on apariciones.playerID equals jugadores.playerID
                                   where apariciones.teamID==equipoID & apariciones.yearID==año
                                   select  jugadores;

                listajugadores = varjugadores.ToList();

            }
      
            return listajugadores;

        }

        private void mostrarEquipos()
        {
            
            listBox1.DataSource = CargarEquipos(Convert.ToInt32(numericUpDown1.Value));
            listBox1.DisplayMember = "name";
        }

        private void mostrarJugadores()
        {
            Teams equipo = (Teams)listBox1.SelectedItem;
            listBox2.DataSource = CargarJugadores(equipo.teamID, Convert.ToInt32(numericUpDown1.Value));
            listBox2.DisplayMember = "nameFirst";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
                    
            mostrarEquipos();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            mostrarJugadores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Master jugador = (Master)listBox2.SelectedItem;
            FormularioModificar modif = new FormularioModificar(jugador.playerID);
            modif.ShowDialog();
            mostrarJugadores();
        }

    }
}
