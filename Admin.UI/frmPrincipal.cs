using Admin.DL.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin.UI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void personajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmPersonaje frm = new frmAdmPersonaje();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ActualizarPrincipal(frmLogin.TypeModo Modo,
                                            Usuario objUsuario)
        {
            if (Modo == frmLogin.TypeModo.Salir)
                this.Close();
            else if (Modo == frmLogin.TypeModo.Ingresar)
            {
                this.Hide(); ;
                if (objUsuario.Rol == "ADM")
                {

                }
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.objDelegado += ActualizarPrincipal;
            frm.ShowDialog();
        }
    }
}
