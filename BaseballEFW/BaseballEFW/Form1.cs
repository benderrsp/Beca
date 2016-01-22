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
            numericUpDown1.Value = limitesanos[1];
            dataGridView1.Rows[0].Selected = true;
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
            List<Master> listajugadores= CargarJugadores(equipo.teamID, Convert.ToInt32(numericUpDown1.Value));
            foreach(Master jugador in listajugadores)
            {
                jugador.nombrecompleto = jugador.nameFirst + " " + jugador.nameLast+" ("+jugador.nameLast+")";
            }
            listBox2.DataSource =listajugadores;
            listBox2.DisplayMember = "nombrecompleto";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
                    
            mostrarEquipos();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            mostrarJugadores();
            Teams equipo = (Teams)listBox1.SelectedItem;
            dataGridView1.Rows.Clear();
            List<string[]>salarios=historicoSalarios(equipo.teamID);
            foreach(string[] item in salarios)
            {
                dataGridView1.Rows.Add(item[0], item[1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Master jugador = (Master)listBox2.SelectedItem;
            FormularioModificar modif = new FormularioModificar(jugador.playerID);
            modif.ShowDialog();
            mostrarJugadores();
        }

        private List<string[]>  historicoSalarios(string idequipo)
        {
            List<string[]> listasalarios=new List<string[]>();
            
            using (BaseballEntities contexto = new BaseballEntities())
            {

                var salariosvar = from salarios in contexto.Salaries
                                  where salarios.teamID == idequipo
                                  group salarios by salarios.yearID into g
                                  select new { ano = g.Key , suma= g.Select(suma => suma.salary).Sum()};
                int cont = 0;
                
                foreach (var item in salariosvar)
                {
                    string[] salariosx = new string[2];
                    salariosx[0] = item.ano.ToString();
                    salariosx[1] = item.suma.ToString();
                    listasalarios.Add(salariosx);
                    
                }
                                  
            }
            
            return listasalarios;


        }
        public List<string[]> desgloseSalarios(string equipoID, int año)
        {
            List<string[]> listadesglose = new List<string[]>();
            using (BaseballEntities contexto = new BaseballEntities())
            {
              
                var desglose = from salarios in contexto.Salaries
                               join jugadores in contexto.Master
                               on salarios.playerID equals jugadores.playerID
                               where salarios.teamID == equipoID & salarios.yearID == año
                               select new { nombre = jugadores.nameFirst, apellido = 
                               jugadores.nameLast, salario = salarios.salary };

                foreach(var item in desglose)
                {
                    string[] registro = new string[3];
                    registro[0] = item.nombre;
                    registro[1] = item.apellido;
                    registro[2] = item.salario.ToString();
                    listadesglose.Add(registro);
                }
            }
            return listadesglose;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                if(dataGridView1.SelectedCells[0]==null||listBox1.Items==null||numericUpDown1.Value==null)
                {
                }
                else
                {
                   
                    dataGridView2.Rows.Clear();
                    Teams equipo = (Teams)listBox1.SelectedItem;
                    string equipox = equipo.teamID;
                    int año = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                    List<string[]> desglose = desgloseSalarios(equipox, año);
                        foreach (string[] registro in desglose)
                          {
                              dataGridView2.Rows.Add(registro[0], registro[1], registro[2]);
                          }
                }
            }
            catch
            {
                
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
