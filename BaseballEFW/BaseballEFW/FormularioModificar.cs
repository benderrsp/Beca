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
    public partial class FormularioModificar : Form
    {
        public FormularioModificar(string id)
        {

            InitializeComponent();
            Master jugador = jugadorCargar(id);
            mostrarJugador(jugador);

        }
        public Master jugadorCargar (string idjugador)
        {
            Master jugador;
            using (BaseballEntities contexto = new BaseballEntities())
            {

                var varjugador = (from jugadores in contexto.Master
                           where jugadores.playerID == idjugador
                           select jugadores).First();

                jugador = (Master)varjugador;

            }
            
            return jugador;
        }
        public void mostrarJugador(Master jugador)
        {

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


        

            textBox1.Text = jugador.playerID;
            textBox2.Text = jugador.nameFirst;
            textBox3.Text = jugador.nameLast;
            textBox10.Text = jugador.nameGiven;
            textBox4.Text = jugador.birthCountry;
            textBox5.Text = jugador.birthState;
            textBox6.Text = jugador.birthCity;
            if (jugador.birthYear == 0 || jugador.birthMonth == 0 || jugador.birthDay == 0)
            {
                label21.Text = "Error fecha";
                label21.ForeColor = Color.Red;
            }
            else
            {
                DateTime fechanac = new DateTime((int)jugador.birthYear, (int)jugador.birthMonth, (int)jugador.birthDay);
                dateTimePicker1.Value = fechanac;
            }


            textBox9.Text = jugador.deathCountry;
            textBox8.Text = jugador.deathState;
            textBox7.Text = jugador.deathCity;

            if (jugador.deathYear == 0 || jugador.deathMonth == 0 || jugador.deathDay == 0)
            {
                label20.Text = "No es fiambre";
                label20.ForeColor = Color.Green;
                nofiambre();

            }
            else
            {
                DateTime fechamuert = new DateTime((int)jugador.deathYear, (int)jugador.deathMonth, (int)jugador.deathDay);
                dateTimePicker2.Value = fechamuert;
                label20.Text = "Es fiambre";
                label20.ForeColor = Color.Red;
                fiambre();

            }

            numericUpDown1.Value = (int)jugador.weight;
            numericUpDown2.Value = (Decimal)jugador.height;
            comboBox1.SelectedItem = jugador.bats.ToString();
            comboBox2.SelectedItem = jugador.throws.ToString();
            List<Salaries>listasalarios = obtenerSalarios(jugador.playerID);
           
            foreach (Salaries salario in listasalarios)
            {
                dataGridView1.Rows.Add(salario.yearID,salario.teamID,salario.salary);
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

        private void button1_Click(object sender, EventArgs e)
        {
            insertarJugador();
            this.Close();
            

        }
        public void insertarJugador()
        {
            Master jugador = new Master();

            jugador.playerID = textBox1.Text;
            jugador.nameFirst = textBox2.Text;
            jugador.nameLast = textBox3.Text;
            jugador.nameGiven = textBox10.Text;
            jugador.birthCountry = textBox4.Text;
            jugador.birthState = textBox5.Text;
            jugador.birthCity = textBox6.Text;
            jugador.birthDay = dateTimePicker1.Value.Day;
            jugador.birthMonth = dateTimePicker1.Value.Month;
            jugador.birthYear = dateTimePicker1.Value.Year;
            

            
            using (BaseballEntities contexto = new BaseballEntities())
            {

                var varjugador = (from jugadores in contexto.Master
                                 where jugadores.playerID == jugador.playerID
                                 select jugadores).First();

                varjugador.nameFirst = jugador.nameFirst;
                varjugador.nameLast = jugador.nameLast;
                varjugador.nameGiven = jugador.nameGiven;
                varjugador.birthCity = jugador.birthCity;
                varjugador.birthCountry = jugador.birthCountry;

                contexto.SaveChanges();
               
            }
        }
        private List<Salaries> obtenerSalarios(string idjugador)
        {
            List<Salaries> listasalarios;
            using (BaseballEntities contexto = new BaseballEntities())
            {

                var salariosvar = from salarios in contexto.Salaries
                                  where salarios.playerID == idjugador
                                  select salarios;
                listasalarios = salariosvar.ToList();

            }
            return listasalarios;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
            {
                textBox9.Enabled = false;
                textBox8.Enabled = false;
                textBox7.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                textBox9.Enabled = true;
                textBox8.Enabled = true;
                textBox7.Enabled = true;
                dateTimePicker2.Enabled = true;
            }

        }
    }
}
