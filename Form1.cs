using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_U4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            desactivarControles();
        }
        private Double monto;

        private void activarControles()
        {
            txtCliente.Enabled = false;
            txtMonto.Enabled = false;
            btnAbrir.Enabled = false;

            btnDeposito.Enabled = true;
            btnRetiro.Enabled = true;
        }
        private void desactivarControles()
        {
            txtCliente.Enabled = true;
            txtMonto.Enabled = true;
            btnAbrir.Enabled = true;

            btnDeposito.Enabled = false;
            btnRetiro.Enabled = false;
        }
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string cliente;
            //Leer los datos
            cliente = txtCliente.Text;
            monto = Convert.ToDouble(txtMonto.Text);


            if (monto >0)

            {
                activarControles();
            }
            else
            {
                MessageBox.Show("El monto debe ser mayor o igual que cero", "Gestion de ahorros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    

            }
        }


        private Double leer (string mensaje)
        {
            Double cantidad;
            cantidad = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Infrese monto a" + mensaje,"Gestion de ahorros","0",100,0));
            return cantidad;

        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            Double deposito;
            deposito = leer("Depositar");
            monto = monto + deposito;
            lstDepositos.Items.Add(deposito);
            mostrar();

        }

        private void mostrar()
        {
            txtSaldo.Text = Convert.ToString(monto);
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            Double retiro;
            retiro = leer("Retirar");

            //Evaluamos
            if (retiro <= monto)
            {
                monto = monto - retiro;
                lstRetiros.Items.Add(retiro);
                mostrar();
            }
            else
            {
                MessageBox.Show("La cantidadd de retiro es mayor al monto disponible", "Gestion de ahorros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtMonto.Clear();
            txtSaldo.Clear();
            lstDepositos.Items.Clear();
            lstRetiros.Items.Clear();
            desactivarControles();
        }
    }
}
            
        
            
    

