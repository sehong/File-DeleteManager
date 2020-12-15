namespace WindowsFormsApp4
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.configuration_btn = new System.Windows.Forms.Button();
            this.Serach_btn = new System.Windows.Forms.Button();
            this.avi_btn = new System.Windows.Forms.Button();
            this.image_btn = new System.Windows.Forms.Button();
            this.other_file_btn = new System.Windows.Forms.Button();
            this.text_file_btn = new System.Windows.Forms.Button();
            this.delete_report_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.stereo_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.except_btn = new System.Windows.Forms.Button();
            this.except_memo_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // configuration_btn
            // 
            this.configuration_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configuration_btn.Location = new System.Drawing.Point(598, 22);
            this.configuration_btn.Name = "configuration_btn";
            this.configuration_btn.Size = new System.Drawing.Size(74, 31);
            this.configuration_btn.TabIndex = 0;
            this.configuration_btn.Text = "환경 설정";
            this.configuration_btn.UseVisualStyleBackColor = true;
            this.configuration_btn.Click += new System.EventHandler(this.configuration_btn_Click);
            // 
            // Serach_btn
            // 
            this.Serach_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Serach_btn.Location = new System.Drawing.Point(687, 22);
            this.Serach_btn.Name = "Serach_btn";
            this.Serach_btn.Size = new System.Drawing.Size(75, 31);
            this.Serach_btn.TabIndex = 1;
            this.Serach_btn.Text = "검색";
            this.Serach_btn.UseVisualStyleBackColor = true;
            this.Serach_btn.Click += new System.EventHandler(this.Serach_btn_Click);
            // 
            // avi_btn
            // 
            this.avi_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.avi_btn.Location = new System.Drawing.Point(47, 109);
            this.avi_btn.Name = "avi_btn";
            this.avi_btn.Size = new System.Drawing.Size(70, 29);
            this.avi_btn.TabIndex = 2;
            this.avi_btn.Text = "동영상";
            this.avi_btn.UseVisualStyleBackColor = true;
            this.avi_btn.Click += new System.EventHandler(this.avi_btn_Click);
            // 
            // image_btn
            // 
            this.image_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.image_btn.Location = new System.Drawing.Point(112, 109);
            this.image_btn.Name = "image_btn";
            this.image_btn.Size = new System.Drawing.Size(70, 29);
            this.image_btn.TabIndex = 3;
            this.image_btn.Text = "이미지";
            this.image_btn.UseVisualStyleBackColor = true;
            this.image_btn.Click += new System.EventHandler(this.image_btn_Click);
            // 
            // other_file_btn
            // 
            this.other_file_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.other_file_btn.Location = new System.Drawing.Point(309, 109);
            this.other_file_btn.Name = "other_file_btn";
            this.other_file_btn.Size = new System.Drawing.Size(70, 29);
            this.other_file_btn.TabIndex = 4;
            this.other_file_btn.Text = "기타";
            this.other_file_btn.UseVisualStyleBackColor = true;
            this.other_file_btn.Click += new System.EventHandler(this.other_file_btn_Click);
            // 
            // text_file_btn
            // 
            this.text_file_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.text_file_btn.Location = new System.Drawing.Point(177, 109);
            this.text_file_btn.Name = "text_file_btn";
            this.text_file_btn.Size = new System.Drawing.Size(70, 29);
            this.text_file_btn.TabIndex = 5;
            this.text_file_btn.Text = "문서";
            this.text_file_btn.UseVisualStyleBackColor = true;
            this.text_file_btn.Click += new System.EventHandler(this.button6_Click);
            // 
            // delete_report_btn
            // 
            this.delete_report_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_report_btn.Location = new System.Drawing.Point(597, 384);
            this.delete_report_btn.Name = "delete_report_btn";
            this.delete_report_btn.Size = new System.Drawing.Size(75, 23);
            this.delete_report_btn.TabIndex = 6;
            this.delete_report_btn.Text = "삭제 내역";
            this.delete_report_btn.UseVisualStyleBackColor = true;
            this.delete_report_btn.Click += new System.EventHandler(this.delete_report_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_btn.Location = new System.Drawing.Point(690, 384);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(75, 23);
            this.delete_btn.TabIndex = 7;
            this.delete_btn.Text = "파일 삭제";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(47, 144);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(715, 228);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "파일명";
            this.columnHeader2.Width = 335;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "파일 크기";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "마지막 사용";
            this.columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "파일 경로";
            this.columnHeader5.Width = 800;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(47, 76);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(714, 24);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 10;
            // 
            // stereo_btn
            // 
            this.stereo_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stereo_btn.Location = new System.Drawing.Point(243, 109);
            this.stereo_btn.Name = "stereo_btn";
            this.stereo_btn.Size = new System.Drawing.Size(69, 29);
            this.stereo_btn.TabIndex = 11;
            this.stereo_btn.Text = "오디오";
            this.stereo_btn.UseVisualStyleBackColor = true;
            this.stereo_btn.Click += new System.EventHandler(this.stereo_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "지정경로";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // except_btn
            // 
            this.except_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.except_btn.Location = new System.Drawing.Point(140, 384);
            this.except_btn.Name = "except_btn";
            this.except_btn.Size = new System.Drawing.Size(75, 23);
            this.except_btn.TabIndex = 14;
            this.except_btn.Text = "파일 제외";
            this.except_btn.UseVisualStyleBackColor = true;
            this.except_btn.Click += new System.EventHandler(this.except_btn_Click);
            // 
            // except_memo_btn
            // 
            this.except_memo_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.except_memo_btn.Location = new System.Drawing.Point(47, 384);
            this.except_memo_btn.Name = "except_memo_btn";
            this.except_memo_btn.Size = new System.Drawing.Size(75, 23);
            this.except_memo_btn.TabIndex = 13;
            this.except_memo_btn.Text = "제외 내역";
            this.except_memo_btn.UseVisualStyleBackColor = true;
            this.except_memo_btn.Click += new System.EventHandler(this.except_memo_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.except_btn);
            this.Controls.Add(this.except_memo_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.stereo_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.delete_report_btn);
            this.Controls.Add(this.text_file_btn);
            this.Controls.Add(this.other_file_btn);
            this.Controls.Add(this.image_btn);
            this.Controls.Add(this.avi_btn);
            this.Controls.Add(this.Serach_btn);
            this.Controls.Add(this.configuration_btn);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ext Uninstaller 1.0";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button configuration_btn;
        private System.Windows.Forms.Button Serach_btn;
        private System.Windows.Forms.Button avi_btn;
        private System.Windows.Forms.Button image_btn;
        private System.Windows.Forms.Button other_file_btn;
        private System.Windows.Forms.Button text_file_btn;
        private System.Windows.Forms.Button delete_report_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stereo_btn;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button except_btn;
        private System.Windows.Forms.Button except_memo_btn;
    }
}

