using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VILA2._0.Servicos;

namespace VILA2._0
{
    public partial class Form1 : Form
    {

        private List<Conta> _listaContas = new List<Conta>();

        public Form1()
        {
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
            using CobrancaContext cobrancaContext = new CobrancaContext();//Adiciona/Recupera/Deleta a instância do banco de dados.
            CobrancaServicos cobrancaServicos = new CobrancaServicos(cobrancaContext);
            var cobrancas = cobrancaServicos.FindAllByDate();

            foreach (var item in cobrancas)
            {
                var row = new string[] { item.Nome, item.Data.ToString() };

                ListViewItem listViewItem = new ListViewItem(row);
                listViewItem.Tag = item;
                listViewContas.Items.Add(listViewItem);
            }


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

            Cobranca cobranca = new Cobranca(StatusCobranca.Deve, quarto, date, observacao);

            foreach (Conta conta in _listaContas)
            {
                cobranca.AddConta(conta);
            }

            cobrancaServicos.Insert(cobranca);
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
            using CobrancaContext cobrancaContext = new CobrancaContext();

            CobrancaServicos cobrancaServicos = new CobrancaServicos(cobrancaContext);
            Conta conta = new Conta();
            var cobranca = cobrancaContext.Cobrancas.Include(cobranca => cobranca.Contas).OrderBy(cobranca => cobranca.Id).Last();
            Editar editar = new Editar(cobranca);


            editar.txtQuarto.Text = cobranca.Nome;
            editar.txtData.Text = cobranca.Data.ToString();
            editar.txtObservacao.Text = cobranca.Observacao;

            foreach (var item in cobranca.Contas)
            {
                var row = new string[] { item.Nome, item.Valor.ToString() };
                ListViewItem listViewItem = new ListViewItem(row);
                listViewItem.Tag = item;
                editar.listViewContas.Items.Add(listViewItem);
            }
            editar.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using CobrancaContext cobrancaContext = new CobrancaContext();
            CobrancaServicos cobrancaServicos = new CobrancaServicos(cobrancaContext);
            var cobranca = cobrancaContext.Cobrancas.Include(cobranca => cobranca.Contas).OrderBy(cobranca => cobranca.Id).Last();
            cobrancaServicos.Remove(cobranca.Id);
        }
    }
}
