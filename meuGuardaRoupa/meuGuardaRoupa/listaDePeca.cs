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

    }
}
