using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playfair_Matrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSecretWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void btn_Translate_Text_Click(object sender, EventArgs e)
        {
            String alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var chars = alpha.ToCharArray();
            char[,] encrypt = new char[5, 5];
            String secretWord = txtSecretWord.Text.ToUpper();
            String input = txtInput.Text.ToUpper();
            string alphaPlusSecret = secretWord + alpha;
            alphaPlusSecret = RemoveDuplicates(alphaPlusSecret);
            chars = alphaPlusSecret.ToCharArray();
            char[] messageArray = input.ToCharArray();
            string output = "";

            int ctr2 = 0;
            int row1 = 0;
            int col1 = 0;

            for (int ctr = 0; ctr < chars.Length; ctr++)
            {
                if (chars[ctr] == 'J')
                    continue;

                ctr2++;
              
                if (ctr2 == 5)
                {
               
                    ctr2 = 0;
                }

               
                if (col1 == 5)
                {
                    col1 = 0;
                    row1++;
                }

                encrypt[row1, col1] = chars[ctr];
                col1++;

            }



            for (int i = 0; i < messageArray.Length; i++)
            {
                for (int j = 0; j < encrypt.GetLength(0); j++)
                {
                    for (int k = 0; k < encrypt.GetLength(1); k++)
                    {
                        if (messageArray[i] == encrypt[j, k])
                        {
                            output += encrypt[k, j];
                        }

                    }

                }
                if (messageArray[i] == ' ')
                {
                    output += ' ';
                }
                else if (messageArray[i] == '.') 
                {
                    output += '.';
                }
            }
            txtOutput.Text += output;
            
            

        }
      
        static string RemoveDuplicates(string key)
        {
            // Remove duplicate chars using string concats.
            // ... Store encountered letters in this string.

            string result = ""; //initialize result

            foreach (char value in key)
            {
                // See if character is in the result already; if not,
                //then, append that character to "result"
                if (result.IndexOf(value) == -1)
                {
                    result += value;
                }
            }
            return result;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txtInput.Text = null;
            txtOutput.Text = null;
            txtSecretWord.Text = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
