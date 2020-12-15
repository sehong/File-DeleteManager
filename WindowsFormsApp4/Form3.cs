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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
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

                listView1.Items.Clear(); //리스트뷰를 초기화 

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
            catch (ArgumentNullException) //null참조가 잘못되었을 때 오류를 예외처리해줌
            {

            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ExceptMemo f = new ExceptMemo();

            string str;
            string[] split_str;

            if (textBox1.Text.Equals(""))
            {
                listView1.Items.Clear();
                f.FileRead();

                for (int i = 0; i < f.Except_memo.Count(); i++)
                {
                    str = f.Except_memo[i];
                    split_str = str.Split('\t');

                    FileInfo fileExcept = new FileInfo(@split_str[2]);

                    if (fileExcept.Exists) // 제외할 파일이 있는지
                    {
                        ListViewItem lvt = new ListViewItem();
                        lvt.Text = i + 1 + "";
                        lvt.SubItems.Add(split_str[0]);
                        lvt.SubItems.Add(split_str[1]);
                        lvt.SubItems.Add(split_str[2]);

                        listView1.Items.Add(lvt);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExceptMemo f = new ExceptMemo();
            string Path = f.FilePath + "except_memo.txt";
            FileInfo fileDel = new FileInfo(@Path);
            listView1.Items.Clear();

            if (fileDel.Exists) // 삭제할 파일이 있는지
            {
                fileDel.Delete(); // 없어도 에러안남
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {

                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                { }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;

                try
                {
                    value = Convert.ToBoolean(this.listView1.Columns[e.Column].Tag);
                }
                catch (Exception) { }

                this.listView1.Columns[e.Column].Tag = !value;

                foreach (ListViewItem item in this.listView1.Items)
                {
                    item.Checked = !value; this.listView1.Invalidate();
                }
            }

            if (listView1.Sorting == SortOrder.Ascending)
            {
                listView1.Sorting = SortOrder.Descending;
            }
            else
            {
                listView1.Sorting = SortOrder.Ascending;
            }
            listView1.ListViewItemSorter = new MyListViewComparer(e.Column, listView1.Sorting);

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            ExceptMemo f = new ExceptMemo();

            string str;
            string[] split_str;
            bool result = true;

            f.FileRead();

            for (int i = 0; i < f.Except_memo.Count(); i++)
            {
                str = f.Except_memo[i];
                split_str = str.Split('\t');
                FileInfo fileExcept = new FileInfo(@split_str[2]);


                if (fileExcept.Exists) // 제외할 파일이 있는지
                {
                    ListViewItem lvt = new ListViewItem();
                    lvt.Text = "";
                    lvt.SubItems.Add(split_str[0]);
                    lvt.SubItems.Add(split_str[1]);
                    lvt.SubItems.Add(split_str[2]);

                    listView1.Items.Add(lvt);
                }
                else
                {
                    result = false;
                }

            }
            if (result == false)
            {
                f.FileWrite(this);
            }
        
            if(f.Except_memo.Count() == 0)
            {
                MessageBox.Show("제외 내역이 없습니다.");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExceptMemo f = new ExceptMemo();

            ListView.CheckedListViewItemCollection lstv_Checkitem = listView1.CheckedItems;


            foreach (ListViewItem item in lstv_Checkitem)
            {
                listView1.Items.Remove(item);
            }
            f.FileWrite(this);

        }
    }
}
