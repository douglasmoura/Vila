using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VILA2._0.Servicos;

namespace VILA2._0
{
    public partial class Editar : Form
    {
        public Cobranca Cobranca { get; set; }

        private List<Conta> _listaContas = new List<Conta>();

        public Editar(Cobranca cobranca)
        {
            Cobranca = cobranca;
            InitializeComponent();
        }

        private void luzToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void luzToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtQuarto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            using CobrancaContext cobrancaContext = new CobrancaContext();//Adiciona/Recupera/Deleta a instância do banco de dados.

            CobrancaServicos cobrancaServicos = new CobrancaServicos(cobrancaContext);

            string quarto = txtQuarto.Text;

            DateTime date = DateTime.Parse(txtData.Text);
            string observacao = txtObservacao.Text;


            Cobranca.Nome = quarto;
            Cobranca.Data = date;
            Cobranca.Observacao = observacao;

            

            foreach (Conta conta in _listaContas)
            {
                Cobranca.Contas.Add(conta);
            }

            cobrancaServicos.Update(Cobranca);
        }

        private void btnAddConta_Click(object sender, EventArgs e)
        {
            Conta conta = new Conta();
            AddConta addConta = new AddConta(conta);
            addConta.ShowDialog();
            _listaContas.Add(conta);

            var row = new string[] { conta.Nome, conta.Valor.ToString() };
            ListViewItem listViewItem = new ListViewItem(row);
            listViewItem.Tag = conta;
            listViewContas.Items.Add(listViewItem);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
          
        }

       
    }
}
