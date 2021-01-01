using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VILA2._0
{
    public partial class AddConta : Form
    {
        public Conta Conta { get; set; }
        public AddConta(Conta conta)
        {
            Conta = conta;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conta.Nome = txtNomeConta.Text;
            Conta.Valor = double.Parse(txtValorConta.Text);
            this.Close();
        }
    }
}
