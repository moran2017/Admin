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

namespace Admin.UI
{
    public partial class frmAdmPersonaje : Form
    {
        public frmAdmPersonaje()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            PersonajeBC objPersonajeBC = new PersonajeBC();
            dgvPersonaje.DataSource = objPersonajeBC.PersonajeListar(txtFiltro.Text);
            dgvPersonajeConfigurar();
        }

        private void ConfigurarComponentes()
        {
            dgvPersonaje.MultiSelect = false;
            dgvPersonaje.AllowUserToAddRows = false;
            dgvPersonaje.AllowUserToDeleteRows = false;
            dgvPersonaje.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvPersonajeConfigurar()
        {
            dgvPersonaje.Columns["Nombre"].DisplayIndex = 0;
            dgvPersonaje.Columns["Nombre"].Width = 150;
            dgvPersonaje.Columns["X"].DisplayIndex = 1;
            dgvPersonaje.Columns["X"].Width = 80;
            dgvPersonaje.Columns["Y"].DisplayIndex = 2;
            dgvPersonaje.Columns["Y"].Width = 80;
            dgvPersonaje.Columns["PersonajeId"].Visible = false;
            dgvPersonaje.Columns["Imagen"].Visible = false;
            dgvPersonaje.Columns["Movimiento"].Visible = false;
        }

        private void frmAdmPersonaje_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarComponentes();
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmPersonaje frm = new frmPersonaje();
                frm.Modo = frmPersonaje.TypeModo.Registrar;
                frm.objDelegado += CargarDatos;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPersonaje.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccionar el elemento.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int Id = Convert.ToInt32(dgvPersonaje.SelectedRows[0]
                    .Cells["PersonajeId"].Value);
                frmPersonaje frm = new frmPersonaje();
                frm.Modo = frmPersonaje.TypeModo.Editar;
                frm.Id = Id;
                frm.objDelegado += CargarDatos;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
