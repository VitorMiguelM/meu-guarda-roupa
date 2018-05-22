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
    public partial class listaDePeca : Form
    {
        public listaDePeca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CadastroDePecas().ShowDialog();

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }


        public void AtualizarLista()
        {
            for (int i = 0; i < Program.pecas.Count; i++)
            {
                Peca peca = Program.pecas[i];
                dgvListaPeca.Rows.Add(new object[] { peca.Nome, peca.Cor, peca.Marca, peca.Valor });
            }

        }

        private void listaDePeca_Load(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListaPeca.CurrentRow == null)
            {
                MessageBox.Show("Não há nenhuma peça selecionada!!");
                return;
            }

            int linhaSelecionada = dgvListaPeca.CurrentRow.Index;
           
            Peca peca = Program.pecas[linhaSelecionada];

            new CadastroDePecas(peca, linhaSelecionada).ShowDialog();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvListaPeca.CurrentRow == null)
            {
                MessageBox.Show("Não tem nenhuma peça selecionada");
                return;
            }

            int linhaSelecionada = dgvListaPeca.CurrentRow.Index;

            Peca peca = Program.pecas[linhaSelecionada];
            DialogResult resultado = MessageBox.Show("Deseja apagar" + peca.Nome + "  o registro?",
                "AVISO", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {

                Program.pecas.RemoveAt(linhaSelecionada);
                AtualizarLista();
                MessageBox.Show("Registro apagado com sucesso!");
            }
            else
            {
                MessageBox.Show("Registro não apagado");
            }
        }

    }
}
