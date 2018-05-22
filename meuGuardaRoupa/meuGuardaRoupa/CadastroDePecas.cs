using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meuGuardaRoupa
{
    public partial class CadastroDePecas : Form
    {
        private int posicao = -1;
        public CadastroDePecas()
        {
            InitializeComponent();
            
        }

        public CadastroDePecas(Peca peca, int posicao)
        {
            InitializeComponent();
            
            for (int i = 8; i <= 60; i++)
            {
                cbTamanho.Items.Add(i);
            }

            this.posicao = posicao;
            txtNome.Text = peca.Nome;
            txtValor.Text = Convert.ToString(peca.Valor);
            cbCor.SelectedItem = peca.Cor;
            cbMarca.SelectedItem = peca.Marca;
            cbTamanho.SelectedItem = peca.Tamanho;
            cbTecido.SelectedItem = peca.Tecido;
            cbTipo.SelectedItem = peca.Tipo;
            dtpDataCompra.Value = peca.DataCompra;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Length < 4)
            {
                MessageBox.Show("Nome deve conter no mínimo 4 caracteres");
                txtNome.Focus();
                return;
            }

            if (cbTipo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o tipo da peça!");
                cbTipo.DroppedDown = true;
                return;
            }

            if (cbTamanho.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o tamanho da peça!");
                cbTamanho.DroppedDown = true;
                return;
            }

            if (txtValor.Text.Length == 0)
            {
                MessageBox.Show("Insira um valor válido!");
                txtValor.Focus();
                return;
            }

            try
            {
                double valor = Convert.ToDouble(txtValor.Text);
            }
            catch
            {
                MessageBox.Show("Valor deve conter apenas números reais!!");
                txtValor.Focus();
                return;
            }

            if (cbMarca.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma marca!");
                cbMarca.DroppedDown = true;
                return;
            }

            if (cbCor.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione uma cor!");
                cbCor.DroppedDown = true;
                return;
            }

            if (cbTecido.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um tecido!");
                cbTecido.DroppedDown = true;
                return;
            }

            if (dtpDataCompra.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("A data de compra deve ser hoje ou uma data anterior");
            }

            Peca peca = new Peca()
            {
                Nome = txtNome.Text,
                Cor = cbCor.SelectedItem.ToString(),
                Marca = cbMarca.SelectedItem.ToString(),
                Tamanho = Convert.ToInt32(cbTamanho.SelectedItem.ToString()),
                Tipo = cbTipo.SelectedItem.ToString(),
                Valor = Convert.ToDouble(txtValor.Text),
                Tecido = cbTecido.SelectedItem.ToString(),
                DataCompra = dtpDataCompra.Value


            };

            if (posicao >= 0)
            {
                Program.pecas[posicao] = peca;
                MessageBox.Show("Cadastro alterado com sucesso");

            }
            else
            {
                Program.pecas.Add(peca);
                MessageBox.Show("Cadastro realizado com sucesso!!!");

            }
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtValor.Text = "";
            cbCor.SelectedIndex = -1;
            cbTamanho.SelectedIndex = -1;
            cbTecido.SelectedIndex = -1;
            cbMarca.SelectedIndex = -1;
            cbCor.SelectedIndex = -1;
            cbTipo.SelectedIndex = -1;
            dtpDataCompra.Value = DateTime.Now;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
