using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TextExplorer_v1._0._1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Lógica para confirmação para fechar o formulario
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(this, "Você deseja criar uma cópia de segurança do texto antes de sair?\nObservação: A cópia de segurança está localizada na pasta Meus documentos!", "Alerta de Segurança", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Backup();
                        MessageBox.Show("Cópia de Segurança criado com sucesso!");
                    }
                    catch (Exception erro)
                    {
                        var re = MessageBox.Show(this, "Erro ao salvar a cópia de segurança\nDeseja visualizar o erro?", "Erro de salvamento", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (re == DialogResult.Yes)
                        {
                            MessageBox.Show("" + erro);
                            e.Cancel = true;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }

        }

        public void Backup()
        {
            if (rtb_texto.Text == string.Empty) // Se o texto não tiver nenhuma letra
            {
                MessageBox.Show("Texto vazio, insira algum texto para salvar.", "Sem Texto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                rtb_texto.SaveFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)
                + @"\Cópia_de_segurança_Texto_Explorador.rtf",
                RichTextBoxStreamType.RichText);

            }
            /*   DirectoryInfo diretorio = new DirectoryInfo(@"C:\Text_Explorer");
                          diretorio.Create();

                          diretorio.CreateSubdirectory("backup_texto");

                          FileInfo arquivo = new FileInfo(@"C:\Text_Explorer\backup_texto\texto_backup.txt");
                          // FileStream ps = arquivo.Create();

                          FileStream fs = new FileStream(@"C:\Text_Explorer\backup_texto\texto_backup.txt", FileMode.OpenOrCreate, FileAccess.Write);
                          StreamWriter sw = new StreamWriter(fs);

                          string texto = rtb_texto.Text;
                          sw.WriteLine(texto);
                          sw.Close();
                        
                           if (arquivo.Exists)
                           {
                       
                              arquivo.Delete();

                              Criar_backup();
                           }

                            else
                           {

                              Criar_backup();
                       
                           }
                           e.Cancel = true;
                  }

                  else if (result == DialogResult.Cancel)
                  {
                      e.Cancel = true;
                  }

                  else
                  {
                      Application.Exit();
                  }
              }

          }

          public void Criar_backup()
          {
              DirectoryInfo diretorio = new DirectoryInfo(@"C:\Text_Explorer");
              diretorio.Create();
              diretorio.CreateSubdirectory("backup_texto");

              FileInfo arquivo = new FileInfo(@"C:\Text_Explorer\backup_texto\texto_backup.txt");
              // FileStream ps = arquivo.Create();

              FileStream fs = new FileStream(@"C:\Text_Explorer\backup_texto\texto_backup.txt", FileMode.OpenOrCreate, FileAccess.Write);
              StreamWriter sw = new StreamWriter(fs);
              string texto = rtb_texto.Text;
              sw.WriteLine(texto);
              sw.Close();
          }
          }
             */
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Salva_Arquivos();
            var result = MessageBox.Show(this, "Você deseja salvar o texto antes de abrir outro?", "Alerta de Segurança", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    Salvar();

                    Form3 f3 = new Form3();
                    f3.Show();

                }
                catch (Exception erro)
                {
                    var re = MessageBox.Show(this, "Erro ao salvar a cópia de segurança\nDeseja visualizar o erro?", "Erro ao Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (re == DialogResult.Yes)
                    {
                        MessageBox.Show("" + erro);
                        return;
                    }
                    else
                    {
                        return ;
                    }
                }


            }
            else
            {

                Dispose();

                Form3 form4 = new Form3();
                form4.ShowDialog();
            }
        }

        public void Abrir_Arquivos()
        {
            
                OpenFileDialog abrir = new OpenFileDialog();
                abrir.Title = "Abrir Texto";
                abrir.Filter = "Arquivo de Texto (*.txt)|*.txt|Documento do RTF (*.rtf)|*.rtf|Todos os Arquivos (*.*)|*.*";

                var res = MessageBox.Show("Deseja abrir o texto com a formatação?\nObservação: Para abrir textos com a formatação, eles devem ser criados pelo Texto Explorador.", "Conversão de caracteres", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {

                    if (abrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            rtb_texto.LoadFile(abrir.FileName, RichTextBoxStreamType.RichText);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Erro de coversão de caracteres ao abrir o arquivo.\nPara abrir arquivo '.txt'ou outras extensões o texto tem que ser criado pelo o Texto Explorador.", "Erro de conversão de caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

                else
                {

                    if (abrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            rtb_texto.LoadFile(abrir.FileName, RichTextBoxStreamType.PlainText);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Erro de coversão de caracteres ao abrir o arquivo.\nPara abrir arquivo '.txt' ou outras extensões, o texto tem que ser criado pelo o Texto Explorador.", "Erro de conversão de caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        
        public void Salvar()
        {
            if (rtb_texto.Text == string.Empty) // Se o texto não tiver nenhuma letra
            // Ou  if (String.IsNullOrWhiteSpace(txt_SeuEmail.Text)) 
            {
                MessageBox.Show("Texto vazio, insira algum texto para salvar.", "Sem Texto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                SaveFileDialog salvar = new SaveFileDialog();
                salvar.Title = "Salvar Texto";
                salvar.Filter = "Arquivo de Texto(*.txt)|*.txt|Documento RTF(*.rtf)|*.rtf";


                if (salvar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    rtb_texto.SaveFile(salvar.FileName, RichTextBoxStreamType.PlainText);
                    MessageBox.Show("Texto salvo com sucesso!", "Texto Salvo");
                }
            }

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            // Abrir o selecionador de fontes
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                rtb_texto.Font = fontDialog.Font;
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //Abri o selecionador de cores para a fonte
            ColorDialog colorDialog1 = new ColorDialog();


            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtb_texto.SelectionColor = colorDialog1.Color;
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            //Abri o selecionador de cores para o plano de fundo
            ColorDialog colorDialog1 = new ColorDialog();


            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtb_texto.BackColor = colorDialog1.Color;
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            // Deixa o texto Alinhado a esquerda
            rtb_texto.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            // Deixar o texto centralizado
            rtb_texto.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            // Deixa o texto Alinhado a direita
            rtb_texto.SelectionAlignment = HorizontalAlignment.Right;
        }


        // Metodo para deixar a fonte italico
        private void Italico()
        {
            if (rtb_texto.SelectionFont != null)
            {
                System.Drawing.Font currentFont = rtb_texto.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (rtb_texto.SelectionFont.Bold && rtb_texto.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Bold;
                }
                else if (rtb_texto.SelectionFont.Italic && rtb_texto.SelectionFont.Italic && rtb_texto.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Italic | FontStyle.Underline;
                }

                else if (rtb_texto.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else if (rtb_texto.SelectionFont.Bold == true)
                {
                    // linha para fonte ser negrito, italico e 
                    newFontStyle = FontStyle.Bold | FontStyle.Italic;
                }

                else
                {
                    newFontStyle = FontStyle.Italic;

                }

                rtb_texto.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );

            }
        }


        // Metodo para deixar a fonte negrito
        private void Negrito()
        {

            System.Drawing.Font currentFont = rtb_texto.SelectionFont;
            System.Drawing.FontStyle newFontStyle;

            if (rtb_texto.SelectionFont.Bold && rtb_texto.SelectionFont.Italic && rtb_texto.SelectionFont.Underline == true)
            {
                newFontStyle = FontStyle.Italic | FontStyle.Underline;
            }
            else if (rtb_texto.SelectionFont.Bold == true)
            {
                newFontStyle = FontStyle.Regular;


            }
            else if (rtb_texto.SelectionFont.Italic == true)
            {
                // linha para fonte ser negrito, italico ao mesmo tempo
                newFontStyle = FontStyle.Bold | FontStyle.Italic;

            }
            else
            {
                newFontStyle = FontStyle.Bold;
            }

            rtb_texto.SelectionFont = new Font(
               currentFont.FontFamily,
               currentFont.Size, newFontStyle

               );
        }


        // Metodo para deixar a fonte sublinhado
        private void Sublinhado()
        {

            System.Drawing.Font currentFont = rtb_texto.SelectionFont;
            System.Drawing.FontStyle newFontStyle;

            if (rtb_texto.SelectionFont.Underline && rtb_texto.SelectionFont.Bold && rtb_texto.SelectionFont.Italic == true)
            {
                newFontStyle = FontStyle.Bold | FontStyle.Italic;
            }


            else if (rtb_texto.SelectionFont.Underline && rtb_texto.SelectionFont.Bold == true)
            {
                newFontStyle = FontStyle.Underline | FontStyle.Bold;
            }



            else if (rtb_texto.SelectionFont.Underline == true)
            {
                newFontStyle = FontStyle.Regular;
            }

            else if (rtb_texto.SelectionFont.Bold == true)
            {
                // linha para fonte ser negrito, italico e sublinhado ao mesmo tempo 
                newFontStyle = FontStyle.Bold | FontStyle.Italic | FontStyle.Underline;
            }

            else
            {
                newFontStyle = FontStyle.Underline;
            }

            rtb_texto.SelectionFont = new Font(
               currentFont.FontFamily,
               currentFont.Size,
               newFontStyle
               );
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void limparToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Limpar
            rtb_texto.Clear();
        }

        private void negritoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void centralizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Deixar o texto centralizado
            rtb_texto.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void alinhadoAEsquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Deixa o texto Alinhado a esquerda
            rtb_texto.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alinhadoÀDireitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Deixa o texto Alinhado a direita
            rtb_texto.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void fonte_Click(object sender, EventArgs e)
        {

            // Abrir o selecionador de fontes
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                rtb_texto.Font = fontDialog.Font;
            }
        }

        private void coresToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //Abri o selecionador de cores para a fonte
            ColorDialog colorDialog1 = new ColorDialog();


            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtb_texto.SelectionColor = colorDialog1.Color;
            }
        }

        private void corDoPlanoDeFundoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Abri o selecionador de cores para o plano de fundo
            ColorDialog colorDialog1 = new ColorDialog();


            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                rtb_texto.BackColor = colorDialog1.Color;
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Metodo para copiar 
            if (rtb_texto.SelectedText != "")
            {
                Clipboard.SetText(rtb_texto.SelectedText);
            }
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Metodo para colar
            if (Clipboard.ContainsText())
            {
                rtb_texto.Text = Clipboard.GetText();
            }
            else
            {
                rtb_texto.Text = Clipboard.GetText();
            }
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ajuda();
        }

        public void Ajuda()
        {
            // Metodo para abrir a página de ajuda
            string url = "http://textoexplorador.hol.es";
            System.Diagnostics.Process.Start(url);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Form5 calculadora = new Form5();
            calculadora.Show();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Salva_Arquivos();
            var result = MessageBox.Show(this, "Você deseja salvar o texto antes de abrir outro?", "Alerta de Segurança", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {

                    //abrindo outro form para "escrever"
                    Salvar();

                    Dispose();

                    Form3 f3 = new Form3();
                    f3.Show();

                }


                catch (Exception erro)
                {
                    var re = MessageBox.Show(this, "Erro ao salvar a cópia de segurança\nDeseja visualizar o erro?", "Erro ao Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (re == DialogResult.Yes)
                    {
                        MessageBox.Show("" + erro);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }


            }
            else
            {

                Dispose();

                Form3 form4 = new Form3();
                form4.ShowDialog();
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            //Abrir_Arquivos();
            var result = MessageBox.Show(this, "Você deseja salvar o texto antes de abrir outro?", "Alerta de Segurança", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {

                    Salvar();

                    Abrir_Arquivos();
                    

                }


                catch (Exception erro)
                {
                    var re = MessageBox.Show(this, "Erro ao salvar a cópia de segurança\nDeseja visualizar o erro?", "Erro ao Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (re == DialogResult.Yes)
                    {
                        MessageBox.Show("" + erro);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

            }
            else
            {
                Abrir_Arquivos();



            }
        }

        public void Abrir_File()
        {
             //Abrir_Arquivos();
                    OpenFileDialog abrir = new OpenFileDialog();
                    abrir.Title = "Abrir Texto";
                    abrir.Filter = "Arquivo de Texto (*.txt)|*.txt|Documento do RTF (*.rtf)|*.rtf|Todos os Arquivos (*.*)|*.*";

                    var res = MessageBox.Show("Deseja abrir o texto com a formatação?\nObservação: Para abrir textos com a formatação, eles devem ser criados pelo Texto Explorador.", "Conversão de caracteres", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                    {

                        if (abrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            try
                            {
                                rtb_texto.LoadFile(abrir.FileName, RichTextBoxStreamType.RichText);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Erro de coversão de caracteres ao abrir o arquivo.\nPara abrir arquivo '.txt'ou outras extensões o texto tem que ser criado pelo o Texto Explorador.", "Erro de conversão de caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }

                    else
                    {

                        if (abrir.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            try
                            {
                                rtb_texto.LoadFile(abrir.FileName, RichTextBoxStreamType.PlainText);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Erro de coversão de caracteres ao abrir o arquivo.\nPara abrir arquivo '.txt' ou outras extensões, o texto tem que ser criado pelo o Texto Explorador.", "Erro de conversão de caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
        }


        public void Salvar_File()
        {

            SaveFileDialog salvar = new SaveFileDialog();
            salvar.Title = "Salvar Texto";
            salvar.Filter = "Arquivo de Texto(*.txt)|*.txt|Documento RTF(*.rtf)|*.rtf";


            if (salvar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtb_texto.SaveFile(salvar.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("Texto salvo com sucesso!", "Texto Salvo");
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bacoDeTextosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            //Abrir_Arquivos();
            var result = MessageBox.Show(this, "Você deseja salvar o texto antes de abrir outro?", "Alerta de Segurança", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {

                    Salvar();

                    Abrir_Arquivos();


                }


                catch (Exception erro)
                {
                    var re = MessageBox.Show(this, "Erro ao salvar a cópia de segurança\nDeseja visualizar o erro?", "Erro ao Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (re == DialogResult.Yes)
                    {
                        MessageBox.Show("" + erro);
                        return;
                    }
                    else
                    {
                        return;
                    }
                }

            }
            else
            {
                Abrir_Arquivos();



            }


        }


        }
    }
//}