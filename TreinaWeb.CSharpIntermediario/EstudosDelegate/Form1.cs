using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudosDelegate
{
    public partial class frmCalculadora : Form
    {
        private delegate int ExecutarOperacao(int numero1, int numero2);
        private ExecutarOperacao minhaOperacao;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {            
        }

        private int Calcular()
        {
            int numero1 = Convert.ToInt32(txbNumero1.Text);
            int numero2 = Convert.ToInt32(txbNumero2.Text);
            return minhaOperacao(numero1, numero2);
        }

        private int Somar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        private int Subtrair(int numero1, int numero2)
        {
            return numero1 - numero2;
        }

        private int Multiplicar(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        private int Dividir(int numero1, int numero2)
        {
            return numero1 / numero2;
        }

        private void BtnAdicao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Somar);
            txbResultado.Text = Calcular().ToString();
        }

        private void BtnSubtracao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Subtrair);
            txbResultado.Text = Calcular().ToString();
        }

        private void BtnMultiplicacao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Multiplicar);
            txbResultado.Text = Calcular().ToString();
        }

        private void BtnDivisao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Dividir);
            txbResultado.Text = Calcular().ToString();
        }
    }
}
