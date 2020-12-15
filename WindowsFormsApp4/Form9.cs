using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApp4
{
    public partial class Form9 : Form
    {
        List<string> delete_memo; //삭제 내역 리스트
        public Form9()
        {
            InitializeComponent();
        }

      

        private void Form9_Load(object sender, EventArgs e)
        {
            FileRead();
            FIleMemo f = new FIleMemo();


        }
        private void FileRead()
        {
            FIleMemo f = new FIleMemo(); //FileMemo 객체 생성

            delete_memo = f.FileRead(DateTime.Now); // 삭제내역을 파일 입출력으로 불러온다


            string[] d_m;
            string str;
            try
            {
                for (int i = 0; i < delete_memo.Count(); i++)
                {//삭제내역이 존재하는 만큼 반복
                    str = delete_memo[i]; 
                    d_m = str.Split('\t');
                    ListViewItem lvt = new ListViewItem();
                    lvt.Text = ((i + 1) + "");
                    lvt.SubItems.Add(d_m[0]);
                    lvt.SubItems.Add(d_m[2]);
                    lvt.SubItems.Add(d_m[1]);

                    listView1.Items.Add(lvt);
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("삭제 내역이 없습니다.");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("")) //텍스트박스가 빈칸일 경우 자동으로 새로고침
            {
                listView1.Items.Clear();
                FileRead();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();

            try
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        string s1 = listView1.Items[i].SubItems[j].Text;
                        string s2 = textBox1.Text;

                        if (s1.Contains(s2)) //String 클래스에 존재하는 Contains함수를 이용해 s1의 문자열이 s2에 일부라도 있으면 true를 반환 이것으로 검색기능 구현 
                        {
                            lines.Add(listView1.Items[i].SubItems[0].Text + "\t" + listView1.Items[i].SubItems[1].Text + "\t" + listView1.Items[i].SubItems[2].Text + "\t" + listView1.Items[i].SubItems[3].Text);
                            break;
                        }
                    }
                }

                listView1.Items.Clear();

                string str;
                string[] d_m;
                for (int i = 0; i < lines.Count(); i++)
                {
                    str = lines[i];
                    d_m = str.Split('\t');

                    ListViewItem lvt = new ListViewItem();
                    lvt.Text = d_m[0];
                    lvt.SubItems.Add(d_m[1]);
                    lvt.SubItems.Add(d_m[2]);
                    lvt.SubItems.Add(d_m[3]);

                    listView1.Items.Add(lvt);
                }
            }
            catch (ArgumentNullException)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FIleMemo f = new FIleMemo();
            string Path = f.FilePath + "delete_memo.txt";
            FileInfo fileDel = new FileInfo(@Path);
            listView1.Items.Clear();
           
            if (fileDel.Exists) // 삭제할 파일이 있는지
            {
                fileDel.Delete(); // 없어도 에러안남
            }
        }
    }
}
