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
    public partial class Form2 : Form
    {
        public delegate void FormSendDataHandler(string Path);
        public event FormSendDataHandler form2SendEvent;
        public delegate void FormSendDataHandler2(List<string> stereo, List<string> text, List<string> media, List<string> image, List<string> other);
        public event FormSendDataHandler2 form2SendEvent2;
        public delegate void FormSendDataHandler3(string LastDay);
        public event FormSendDataHandler3 form2SendEvent3;

        string Path; //폴더 경로
        string LastDay;//마지막 사용일자

        private List<string> stereo; //오디오
        private List<string> text; //문서
        private List<string> media;//동영상
        private List<string> image; //이미지
        private List<string> other;//기타

        public Form2()
        {
            InitializeComponent();

        }
        public Form2(string LastDay, string Path)
        {
            InitializeComponent();
            this.LastDay = LastDay;
            label10.Text = this.LastDay;
            this.Path = Path;
            label8.Text = this.Path;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            FIleMemo ext = new FIleMemo();
            ext.FileRead();

            stereo = ext.STEREO();
            text = ext.TEXT();
            media = ext.MEDIA();
            image = ext.IMAGE();
            other = ext.OTHER();

            try
            {
                if (stereo.Count() != 0)
                {
                    for (int i = 0; i < stereo.Count(); i++)
                    {
                        listBox1.Items.Add(stereo[i]);
                    }

                }
                if (text.Count() != 0)
                {
                    for (int i = 0; i < text.Count(); i++)
                    {
                        listBox2.Items.Add(text[i]);
                    }

                }
                if (media.Count() != 0)
                {
                    for (int i = 0; i < media.Count(); i++)
                    {
                        listBox3.Items.Add(media[i]);
                    }

                }
                if (image.Count() != 0)
                {
                    for (int i = 0; i < image.Count(); i++)
                    {
                        listBox4.Items.Add(image[i]);
                    }

                }
                if (other.Count() != 0)
                {
                    for (int i = 0; i < other.Count(); i++)
                    {
                        listBox5.Items.Add(other[i]);
                    }

                }
            }
            catch (ArgumentNullException)
            {

            }
            //현재 로컬 컴퓨터에 존재하는 드라이브 정보 검색하여 트리노드에 추가

            DriveInfo[] allDrives = DriveInfo.GetDrives();



            foreach (DriveInfo dname in allDrives)
            {

                if (dname.DriveType == DriveType.Fixed)
                {

                    if (dname.Name == @"C:\")

                    {

                        TreeNode rootNode = new TreeNode(dname.Name);

                        rootNode.ImageIndex = 0;

                        rootNode.SelectedImageIndex = 0;

                        treeView1.Nodes.Add(rootNode);

                        Fill(rootNode);

                    }

                    else

                    {

                        TreeNode rootNode = new TreeNode(dname.Name);

                        rootNode.ImageIndex = 1;

                        rootNode.SelectedImageIndex = 1;

                        treeView1.Nodes.Add(rootNode);

                        Fill(rootNode);

                    }

                }

            }
            //첫번째 노드 확장

            treeView1.Nodes[0].Expand();
        }



        private void Fill(TreeNode dirNode)

        {

            try

            {

                DirectoryInfo dir = new DirectoryInfo(dirNode.FullPath);

                //드라이브의 하위 폴더 추가

                foreach (DirectoryInfo dirItem in dir.GetDirectories())

                {

                    TreeNode newNode = new TreeNode(dirItem.Name);

                    newNode.ImageIndex = 2;

                    newNode.SelectedImageIndex = 2;

                    dirNode.Nodes.Add(newNode);

                    newNode.Nodes.Add("*");

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show("에러 발생 : " + ex.Message);

            }

        }


        // 트리가 확장되기 전에 발생하는 이벤트

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)

        {

            if (e.Node.Nodes[0].Text == "*")

            {

                e.Node.Nodes.Clear();

                e.Node.ImageIndex = 3;

                e.Node.SelectedImageIndex = 3;

                Fill(e.Node);

            }

        }

        // 트리가 닫히기 전에 발생하는 이벤트

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)

        {

            if (e.Node.Nodes[0].Text == "*")

            {

                e.Node.ImageIndex = 2;

                e.Node.SelectedImageIndex = 2;

            }

        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                TreeNode node = treeView1.SelectedNode;
                TreeNode Parent_node = node;

                string Path = "";

                List<string> node_text = new List<string>(); //경로를 저장할 리스트

                node_text.Add(node.Text);

                while (true)
                {
                    Parent_node = Parent_node.Parent;
                    if (Parent_node == null)
                    {
                        break;
                    }
                    else
                    {
                        node_text.Add(Parent_node.Text);
                    }
                }
                if (node_text.Count() == 1) //클릭한 트리노드가 루트노드일 경우
                {
                    Path = "";
                    MessageBox.Show("드라이브를 제외한 폴더를 선택해 주세요.");
                }
                else
                {
                    for (int i = node_text.Count - 1; i >= 0; i--)
                    {
                        if (i != 0 && node_text.Count - 1 != i) //C:\ 직계 하위폴더 선택시 \가 하나더 출력되지 않게 하기위해서
                        {
                            Path += node_text[i] + "\\";
                        }
                        else
                        {
                            Path += node_text[i];
                        }
                    }
                }
                this.Path = Path;
                label8.Text = Path;
            }
            catch (NullReferenceException )
            {
              
            }
        }
    
        private void button12_Click(object sender, EventArgs e)
        {
            FIleMemo ext = new FIleMemo();
            ext.FileWrite(this);
            stereo = new List<string>();
            text = new List<string>();
            media = new List<string>();
            image = new List<string>();
            other = new List<string>();

            try
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    stereo.Add(listBox1.Items[i].ToString());
                }
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    text.Add(listBox2.Items[i].ToString());
                }
                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    media.Add(listBox3.Items[i].ToString());
                }
                for (int i = 0; i < listBox4.Items.Count; i++)
                {
                    image.Add(listBox4.Items[i].ToString());
                }
                for (int i = 0; i < listBox5.Items.Count; i++)
                {
                    other.Add(listBox5.Items[i].ToString());
                }
                this.form2SendEvent(Path);
                this.form2SendEvent2(stereo, text, media, image, other);
                this.form2SendEvent3(LastDay);
                this.Close();


            }
            catch (ArgumentNullException )
            {

            }
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals(""))
                {
                    LastDay = "0";
                    label10.Text = LastDay;
                    textBox1.Text = "";
                }
                else if (int.Parse(textBox1.Text) > 0)
                {
                    LastDay = textBox1.Text;
                    label10.Text = LastDay;
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("양수를 입력해주세요!!");
                }
            }
            catch(FormatException)
            { 
                MessageBox.Show("숫자를 입력해주세요!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form4 form4 = new Form4();
            form4.form4SendEvent += new Form4.FormSendDataHandler(sendExt);
            form4.Show();

        }
        public void sendExt(string Ext)
        {
            listBox1.Items.Add(Ext);
        }
        public void sendExt1(string Ext)
        {
            listBox2.Items.Add(Ext);
        }
        public void sendExt2(string Ext)
        {
            listBox3.Items.Add(Ext);
        }
        public void sendExt3(string Ext)
        {
            listBox4.Items.Add(Ext);
        }
        public void sendExt4(string Ext)
        {
            listBox5.Items.Add(Ext);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.form5SendEvent += new Form5.FormSendDataHandler(sendExt1);
            form5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.form6SendEvent += new Form6.FormSendDataHandler(sendExt2);
            form6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.form7SendEvent += new Form7.FormSendDataHandler(sendExt3);
            form7.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.form8SendEvent += new Form8.FormSendDataHandler(sendExt4);
            form8.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox5.Items.Remove(listBox5.SelectedItem);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox4.Items.Remove(listBox4.SelectedItem);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}

