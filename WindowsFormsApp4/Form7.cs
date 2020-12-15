using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form7 : Form
    {
        public delegate void FormSendDataHandler(string Ext);
        public event FormSendDataHandler form7SendEvent;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label1.Text = "추가하실 확장자를 *.포함하여 \n입력하여 주세요.";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("*.exe 형식으로 입력하여주세요!!");
            }
            else
            {
                char[] c = new char[10];
                string str = textBox1.Text;

                c = str.ToCharArray();
                if (c[0] == '*' && c[1] == '.')
                {
                    this.form7SendEvent(textBox1.Text); //텍스트박스 내용을 상위 폼으로 전달해준다.
                    this.Close();
                }
                else
                {
                    MessageBox.Show("*.exe 형식으로 입력하여주세요!!");
                }
            }
        }
    }
}
