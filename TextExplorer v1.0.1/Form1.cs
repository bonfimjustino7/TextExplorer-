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
    public partial class Tela_inicial : Form
    {
        public Tela_inicial()
        {
            InitializeComponent();
        }

       
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 2;
            }
            else 
            {
                // Disabilita o timer tick
                timer1.Enabled = false;

                // Fecha o carregamento sem fechar a aplicação
                this.Visible = false;
                
                //Instancia da janela
                Form3 f3 = new Form3();
                // Chamada do formulario
                f3.ShowDialog();
            }
              
        }


        

      
        
    
    }
}
