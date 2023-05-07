using BarmejBelLebnene.Exceptions;
using System.Security.Policy;


namespace BarmejBelLebnene
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void compileBtn_Click(object sender, EventArgs e)
        {

            if (bblCode.Text.Trim().Length == 0)
            {
                return;
            }

            try
            {
                BBL bbl = new BBL(bblCode.Text);
                saveFileDialog1.DefaultExt = ".s";
                saveFileDialog1.FileName = "file.s";
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filename = saveFileDialog1.FileName;
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        writer.Write(bbl.ToString());
                    }
                }
            }
            catch (InvalidArithmaticOperation err)
            {
                MessageBox.Show("Error occured at expression: " + err, "Invalid Arithmatic Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidVariableDefinitionException err)
            {
                MessageBox.Show("Error occured at expression: " + err, "Invalid Variable Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidForLoopDefinitionException err)
            {
                MessageBox.Show("Error occured at expression: " + err, "Invalid ForLoop Definition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UndefinedVariabledException err)
            {
                MessageBox.Show("Error occured at expression: " + err, "Undefined Variable used in barmajeh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FunctionNotFound err)
            {
                MessageBox.Show(err.ToString(), "#Tejhiz || #barmajeh not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                MessageBox.Show("We dont know what happened either " + err, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            System.Diagnostics.Process.Start("https://github.com/ahmadmaaz/Barmij-Bil-Lebneneh");
        }



        private void generateSampleBtn_Click_1(object sender, EventArgs e)
        {
            bblCode.Text = BBL.generateRandomCode();

        }
    }
}