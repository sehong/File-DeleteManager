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
using System.Timers;
using System.Collections;

namespace WindowsFormsApp4
{

    public partial class Form1 : Form
    {
        private string Path; //파일 경로
        private string LastDay; //마지막 사용일자
        private string f_Path; //파일에 저장된 파일경로
        private List<string> stereo; //오디오
        private List<string> text; //문서
        private List<string> media;//동영상
        private List<string> image; //이미지
        private List<string> other;//기타
        private List<string> EXT;//확장자 모음
        

        public Form1()
        {
            InitializeComponent();
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

        private void delete_btn_Click(object sender, EventArgs e)
        {
            FIleMemo f = new FIleMemo();

            ListView.CheckedListViewItemCollection lstv_Checkitem = listView1.CheckedItems;
            //리스트뷰에서 선택된 항목들을 가져온다.

            foreach (ListViewItem item in lstv_Checkitem) // 체크된 항목들을 하나씩 
            {
                FileInfo fileDel = new FileInfo(@item.SubItems[4].Text); //서브아이템 5번째 칸에 있는 파일경로를 가져온다.

                f.FileWrite(item.SubItems[1].Text, item.SubItems[2].Text); //서브아이템 1과 2에있는 파일명과 파일크기를 매개변수로 전달하여 파일에 삭제내역을 쓴다.

                if (fileDel.Exists) // 삭제할 파일이 있는지
                {
                    fileDel.Delete(); // 없어도 에러안남
                }
                listView1.Items.Remove(item); //리스트뷰에서 내역을 삭제한다.
            }
        }
        public void getFiles(List<string> fileExt, string filePath, FIleInformation file)
        {
            try
            {
                ExceptMemo except_memo = new ExceptMemo(); //제외내역 객체 생성
               

                string[] files;

                string[] dirs = Directory.GetDirectories(filePath); //하위 디렉토리 경로를 배열에 저장

                if (_MAX_PATH.MAX_PATH > filePath.Length) //경로의 길이가 최대 길이보다 작을 경우만 실행
                {
                    //label1.Text = dirs[index++];

                    for (int i = 0; i < fileExt.Count(); i++)
                    { //확장자 수 만큼 반복
                        try
                        {
                            files = Directory.GetFiles(filePath, fileExt[i]);
                            //디렉토리 경로에 있는 설정한 확장자와 같은 파일들의 목록을 배열에 저장
                            foreach (string f in files)
                            { 
                                f_Path = f; //경로를 저장
                                timer2.Start(); //timer로 딜레이를 줘서 실시간으로 검색내역 보여줌 
                                timer1.Start();

                                if (file.getFileLastDay(f) >= int.Parse(LastDay))//설정한 마지막 사용일자와 같거나 큰 내역만 출력
                                {
                                    file.FilePath = f;
                                    except_memo.FileRead();//제외 내역을 읽어옴
                                    bool result = true;
                                    if (except_memo.Except_memo.Count() > 0)//제외내역이 존재할 경우
                                    {
                                        for (int j = 0; j < except_memo.Except_memo.Count(); j++)
                                        {//제외내역 수만큼 반복
                                            string str = except_memo.Except_memo[j];
                                            string[] split_str = str.Split('\t');

                                            if (split_str[2].Equals((file.getFileDirectoryName() + "\\" + file.getFileName())))
                                            {// 제외 내역에 있는 파일 경로와 검색하고있는 파일경로를 비교해 같으면 
                                                result = false; //result에 false를 주고 
                                                break; //반복문을 빠져나감
                                            }
                                        }
                                        if (result) //제외 내역이 아닌 경우 리스트뷰에 아이템 추가
                                        {
                                            ListViewItem lvt = new ListViewItem();
                                            progressBar1.PerformStep();
                                            lvt.SubItems.Add(file.getFileName());
                                            lvt.SubItems.Add(file.getFileSize());
                                            lvt.SubItems.Add(file.getFileLastTime(f));
                                            lvt.SubItems.Add(file.getFileDirectoryName() + "\\" + file.getFileName());
                                            listView1.Items.Add(lvt);

                                            except_memo.Except_memo = new List<string>();
                                        }
                                    }
                                    else
                                    {
                                        ListViewItem lvt = new ListViewItem();
                                        progressBar1.PerformStep();
                                        lvt.SubItems.Add(file.getFileName());
                                        lvt.SubItems.Add(file.getFileSize());
                                        lvt.SubItems.Add(file.getFileLastTime(f));
                                        lvt.SubItems.Add(file.getFileDirectoryName() + "\\" + file.getFileName());
                                        listView1.Items.Add(lvt);
                                    }

                                }
                            }
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                        }

                    }
                    if (dirs.Length > 0)
                    {
                        foreach (string dir in dirs)
                        {
                            getFiles(fileExt, dir, file);
                        }
                    }
                }

            }
            catch (Exception)
            {

            }

        }


        private void Serach_btn_Click(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer2.Interval = 1000;

            label1.Text = Path;
          
            try
            {
                listView1.Items.Clear();
                progressBar1.Value = 0;

                progressBar1.Step = 100;
                FIleInformation f = new FIleInformation();

                getFiles(EXT, Path, f);
                progressBar1.PerformStep();

            }
            catch (Exception)
            {
                MessageBox.Show("등록된 확장자가 없습니다!!");
            }

        }




        /*public static List<string[]> fn_getPcFiles(string filePath, List<string> filterList)
        {
            List<string[]> list = new List<string[]>();
            var ext = filterList;
            foreach (string file in Directory.GetFiles(filePath, "*.*").Where(s => ext.Any(e => s.ToLower().EndsWith(e))).OrderByDescending(f => new FileInfo(f).LastWriteTime))
            {
                FileInfo f = new FileInfo(file);
                list.Add(filePath);
            }
            return list;
        }*/



        private void button6_Click(object sender, EventArgs e)
        {

            EXT = text;
            avi_btn.Enabled = true;
            image_btn.Enabled = true;
            text_file_btn.Enabled = false;
            other_file_btn.Enabled = true;
            stereo_btn.Enabled = true;
        }


        private void avi_btn_Click(object sender, EventArgs e)
        {
            EXT = media;
            avi_btn.Enabled = false;
            image_btn.Enabled = true;
            text_file_btn.Enabled = true;
            other_file_btn.Enabled = true;
            stereo_btn.Enabled = true;

        }



        private void configuration_btn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(LastDay, Path);
            form2.form2SendEvent += new Form2.FormSendDataHandler(sendPath); // form2 에서 파일경로를 넘겨받는다
            form2.form2SendEvent2 += new Form2.FormSendDataHandler2(sendExt); //form2에서 확장자들을 넘겨받는다
            form2.form2SendEvent3 += new Form2.FormSendDataHandler3(sendLastDay); // form2에서 마지막 사용일자를 넘겨받는다
            form2.Show();

        }
        public void sendLastDay(string LastDay)
        {
            if (LastDay == null)
            {
                this.LastDay = "7";
            }
            else
            {
                this.LastDay = LastDay;
            }
        }
        public void sendPath(string Path)
        {
            this.Path = Path;
            label1.Text = Path;
        }
        public void sendExt(List<string> stereo, List<string> text, List<string> media, List<string> image, List<string> other)
        {
            this.stereo = stereo;
            this.text = text;
            this.media = media;
            this.image = image;
            this.other = other;

        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            FIleMemo ext = new FIleMemo();
            EXT = new List<string>();

            ext.FileRead();
            stereo = ext.STEREO();
            text = ext.TEXT();
            media = ext.MEDIA();
            image = ext.IMAGE();
            other = ext.OTHER();
            LastDay = "7";
            Path = "C:\\Users\\fc\\Desktop\\";
            label1.Text = Path;
        }

        private void image_btn_Click(object sender, EventArgs e)
        {
            EXT = image;
            avi_btn.Enabled = true;
            image_btn.Enabled = false;
            text_file_btn.Enabled = true;
            other_file_btn.Enabled = true;
            stereo_btn.Enabled = true;
        }

        private void stereo_btn_Click(object sender, EventArgs e)
        {
            EXT = stereo;
            avi_btn.Enabled = true;
            image_btn.Enabled = true;
            text_file_btn.Enabled = true;
            other_file_btn.Enabled = true;
            stereo_btn.Enabled = false;
        }

        private void other_file_btn_Click(object sender, EventArgs e)
        {
            EXT = this.other;
            avi_btn.Enabled = true;
            image_btn.Enabled = true;
            text_file_btn.Enabled = true;
            other_file_btn.Enabled = false;
            stereo_btn.Enabled = true;
        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            ListViewItem item = new ListViewItem();

            bool value = false;
            item.Checked = !value;


        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void delete_report_btn_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = f_Path;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = f_Path;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label1.Text = f_Path;
        }

        private void except_btn_Click(object sender, EventArgs e)
        {
            ExceptMemo f = new ExceptMemo();

            ListView.CheckedListViewItemCollection lstv_Checkitem = listView1.CheckedItems;


            foreach (ListViewItem item in lstv_Checkitem)
            {

                f.FileWrite(item.SubItems[1].Text, item.SubItems[4].Text);

                listView1.Items.Remove(item);
            }
        }

        private void except_memo_btn_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
