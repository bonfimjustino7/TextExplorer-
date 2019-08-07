using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextExplorer_v1._0._1
{
    public partial class Form5 : Form
    {
        double pnumero;
        double snumero;
        string operador = "";
        Boolean jafoicalculado = false;


        public void limpar()
        {
            pnumero = 0;
            snumero = 0;
            operador = "";
            label1.Text = "";
            label1.Visible = false;
            Ecran.Clear();
            jafoicalculado = false;
        }


        public Form5()
        {
            operador = "";
            InitializeComponent();
            limpar();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            limpar();
        }


        // Operador
        private void Operador(string operadorbt)
        {
            if (Ecran.Text != "")
            {
                try
                {
                    // atribuição da variavel pnumero
                    pnumero = Convert.ToDouble(Ecran.Text);
                }
                catch (Exception erro)
                {
                    var error = MessageBox.Show(this, "Erro de conversão, por favor, digite apenas números.\nDeseja visualizar o erro?", "Erro de conversão", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (error == DialogResult.Yes)
                    {
                        MessageBox.Show("" + erro);
                    }
                }
                if (operadorbt == "*")
                {
                    label1.Text = "x";
                }
                else
                {
                    label1.Text = operadorbt;
                }
                label1.Visible = true;
                operador = operadorbt;
                if (jafoicalculado == false)
                {
                    Ecran.Clear();
                }
                jafoicalculado = true;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Operador("+");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Operador("-");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Operador("*");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Operador("/");
        }

       


       /* private void Digitar(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }
        */
        private void Calcular()
        {
            if (Ecran.Text != "" && operador != "")
            {
                try
                {
                    snumero = Convert.ToDouble(Ecran.Text);
                }
                catch (Exception erro)
                {
                    var error = MessageBox.Show(this,"Erro de conversão, por favor, digite apenas números.\nDeseja Visualizar o erro?", "Erro de conversão", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (error == DialogResult.Yes)
                    {
                        MessageBox.Show(""+ erro);
                    }
                }

                label1.Text = "";
               // if (operador == "+")//Assim
                //{
                  //  resultado = pnumero + snumero;
                    //Ecran.Text = Convert.ToString(resultado);
                //}

                switch (operador)
                {
                    case "+": Ecran.Text = Convert.ToString(pnumero + snumero); //Ou Assim
                     break;

                    case "-": Ecran.Text = Convert.ToString(pnumero - snumero);
                        break;

                    case "*": Ecran.Text = Convert.ToString(pnumero * snumero);
                        break;

                    case "/": Ecran.Text = Convert.ToString(pnumero / snumero);
                        break;


                }
                pnumero = 0;
                snumero = 0;
                operador = "";
                label1.Text = "";
                label1.Visible = false;
                jafoicalculado = false;
            }

        }
        // Botao igual "="
        private void button3_Click(object sender, EventArgs e)
        {
            Calcular();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Ecran.Text += (sender as Button).Text;
        }
        
    


        private void button1_Click(object sender, EventArgs e)
        {
            limpar();
        }

        // Borracha
        private void button2_Click(object sender, EventArgs e)
        {
            int CharNum = (Ecran.Text.Length) - 1;

            if (CharNum >= 0)
            {
                Ecran.Text = Ecran.Text.Remove(CharNum);
            }  
        }

       

    }
}