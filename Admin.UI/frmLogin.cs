using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Admin.BL.BC;
using Admin.DL.DataModel;

namespace Admin.UI
{
    public partial class frmLogin : Form
    {
        public enum TypeModo { Salir, Ingresar }
        public delegate void dlgActualizarPrincipal(TypeModo Modo, 
                                            Usuario objUsuario);
        public dlgActualizarPrincipal objDelegado;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void ValidarComponentes()
        {
            lblCodigo.Visible = txtCodigo.Text.Length == 0;
            lblPassword.Visible = txtPassword.Text.Length == 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidarComponentes();

            if (lblCodigo.Visible || lblPassword.Visible)
                return;

            LoginBC objLoginBC = new LoginBC();
            Usuario objUsuario = objLoginBC.LoginValidar(txtCodigo.Text, 
                                                    txtPassword.Text);

            if (objUsuario == null)
            {
                MessageBox.Show("Usuario y/o contraseña incorrectas",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            objDelegado(TypeModo.Ingresar, objUsuario);
            this.Close();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            objDelegado(TypeModo.Salir, null);
        }

     
      
    }
}
