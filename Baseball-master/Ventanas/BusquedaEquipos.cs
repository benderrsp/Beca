using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventanas
{
    public partial class BusquedaEquipos : Form
    {
        public BusquedaEquipos()
        {
            InitializeComponent();
        }

        private void BusquedaEquipos_Load(object sender, EventArgs e)
        {
            SrvEquipos.SrvEquiposClient cliente = new SrvEquipos.SrvEquiposClient();
            
            nudAños.Minimum = cliente.GetAñoInicial();
            nudAños.Maximum = cliente.GetAñoFinal();
            nudAños.Value = nudAños.Maximum;
        }
    }
}
