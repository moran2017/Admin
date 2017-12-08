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
    public partial class frmPersonaje : Form
    {
        public int Id { get; set; }
        public enum TypeModo { Registrar, Editar }
        public TypeModo Modo { get; set; }
        public delegate void ActualizarDatos();
        public ActualizarDatos objDelegado;
        private String MensajePregunta;
        private String MensajeRespuesta;

        public frmPersonaje()
        {
            InitializeComponent();
        }

        private void frmPersonaje_Load(object sender, EventArgs e)
        {
            try
            {
                if (Modo == TypeModo.Registrar)
                {
                    lblTitulo.Text = "REGISTRAR PERSONAJE";
                    MensajePregunta = "¿Está seguro de registrar el personaje?";
                    MensajeRespuesta = "El personaje se registró satisfactoriamente";
                }
                else if (Modo == TypeModo.Editar)
                {
                    lblTitulo.Text = "EDITAR PERSONAJE";
                    MensajePregunta = "¿Está seguro de editar el personaje?";
                    MensajeRespuesta = "El personaje se actualizó satisfactoriamente";

                    PersonajeBC objPersonajeBC = new PersonajeBC();
                    Personaje objPersonaje = objPersonajeBC.PersonajeObtener(Id);
                    txtNombre.Text = objPersonaje.Nombre;
                    txtImagen.Text = objPersonaje.Imagen;
                    nudX.Value = objPersonaje.X;
                    nudY.Value = objPersonaje.Y;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el sistema, por favor intente más tarde.", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarControles()
        {
            lblNombre.Visible = txtNombre.Text.Length == 0;
            lblImagen.Visible = txtImagen.Text.Length == 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidarControles();

            if (lblNombre.Visible || lblImagen.Visible)
                return;

            if (MessageBox.Show(MensajePregunta, this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                DialogResult.Yes)
                return;

            PersonajeBC objPersonajeBC = new PersonajeBC();
            Personaje objPersonaje = new Personaje();
            objPersonaje.Nombre = txtNombre.Text;
            objPersonaje.Imagen = txtImagen.Text;
            objPersonaje.X = (int)nudX.Value;
            objPersonaje.Y = (int)nudY.Value;

            if (Modo == TypeModo.Editar)
            {
                objPersonaje.PersonajeId = Id;
                objPersonajeBC.PersonajeEditar(objPersonaje);
            }
            else if (Modo == TypeModo.Registrar)
            {
                objPersonajeBC.PersonajeRegistrar(objPersonaje);
            }

            objDelegado();
            MessageBox.Show(MensajeRespuesta, this.Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
