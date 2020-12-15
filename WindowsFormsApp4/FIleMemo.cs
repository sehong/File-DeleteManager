using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp4
{
    interface File_set
    {
        string FilePath { get; set; } //파일경로 프로퍼티  인터페이스
      
        void FileWrite(string s, string s1); //파일 쓰기 
        void FileRead(); // 파일 읽기
    }
   
    class FIleMemo : File_set
    {
        public StreamWriter stream_write;
        public StreamReader stream_read;

        private List<string> stereo; //오디오
        private List<string> text; //문서
        private List<string> media;//동영상
        private List<string> image; //이미지
        private List<string> other;//기타
        private List<string> delete_memo; //삭제내역

        private List<int> count;//확장자 별 개수 저장할 리스트
        private List<string> Ext;//모든 확장자 리스트

   
        public List<string> STEREO() //오디오 리스트를 반환받을 프로퍼티
        {
            return stereo;
        }
        public List<string> TEXT() //문서 리스트를 반환받을 프로퍼티
        {
            return text;
        }
        public List<string> MEDIA() // 동영상 리스트를 반환받을 프로퍼티
        {
            return media;
        }
        public List<string> IMAGE() // 이미지 리스트를 반환받을 프로퍼티
        {
            return image;
        }
        public List<string> OTHER() //기타 파일 리스트를 반환받을 프로퍼티
        {
            return other;
        }

        public void sort() // 확장자 리스트에 저장된 확장자 개수별로 각각의 리스트로 저장
        {
            int j = 0;
 
            for (int i = 0; i < count[0]; i++)
            {
                stereo.Add(Ext[j++]);
            }
            for (int i = 0; i < count[1]; i++)
            {
                text.Add(Ext[j++]);
            }
            for (int i = 0; i < count[2]; i++)
            {
                media.Add(Ext[j++]);
            }
            for (int i = 0; i < count[3]; i++)
            {
                image.Add(Ext[j++]);
            }
            for (int i = 0; i < count[4]; i++)
            {
                other.Add(Ext[j++]);
            }
        }

        public string FilePath //메소드 오버라이딩
        {
            get; set;
        }


        public void FileWrite(string filename, string filesize)
        {
            string f_path = FilePath + "delete_memo.txt";
            try
            {
                FileStream fs = new FileStream(@f_path, FileMode.Append, FileAccess.Write);
                //이어쓰기 모드로 파일을 열고 없으면 만든다.
                stream_write = new StreamWriter(fs); //상대경로로 쓰기파일 생성
                stream_write.WriteLine(filename  + "\t"+ filesize + "\t" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //파일명, 파일크기, 현재 날짜 및 시간(삭제일자)
                stream_write.Close(); //파일 닫기
                fs.Close();//이어쓰기 모드 닫기
            }
            catch (IOException)
            {

            }
        }
        public void FileWrite(Form2 form2) //Form2 의 listBox에 접근하기 위해 form2객체를 매개변수로 받아온다.
        {

            string[] Path = { "stereo.txt", "text.txt", "media.txt", "image.txt", "other.txt" };
            string f_path = FilePath; 
            string ff_path;
            foreach (string path in Path)
            {
                try
                {
                    ff_path = f_path + path;
                    stream_write = new StreamWriter(@ff_path); //상대경로로 쓰기파일 생성
                    if (path.Equals("stereo.txt"))
                    {
                        for (int i = 0; i < form2.listBox1.Items.Count; i++)
                        {
                            stream_write.WriteLine(form2.listBox1.Items[i].ToString()); //리스트 박스에 있는 내역을 파일에 쓴다.
                        }
                    }
                    else if (path.Equals("text.txt"))
                    {
                        for (int i = 0; i < form2.listBox2.Items.Count; i++)
                        {
                            stream_write.WriteLine(form2.listBox2.Items[i].ToString());
                        }
                    }
                    else if (path.Equals("media.txt"))
                    {
                        for (int i = 0; i < form2.listBox3.Items.Count; i++)
                        {
                            stream_write.WriteLine(form2.listBox3.Items[i].ToString());
                        }
                    }
                    else if (path.Equals("image.txt"))
                    {
                        for (int i = 0; i < form2.listBox4.Items.Count; i++)
                        {
                            stream_write.WriteLine(form2.listBox4.Items[i].ToString());
                        }
                    }
                    else if (path.Equals("other.txt"))
                    {
                        for (int i = 0; i < form2.listBox5.Items.Count; i++)
                        {
                            stream_write.WriteLine(form2.listBox5.Items[i].ToString());
                        }
                    }

                    stream_write.Close(); //파일 닫기

                }
                catch (IOException)
                {

                }
            }

        }
        public List<string> FileRead(DateTime today)
        {
            string f_path = FilePath + "delete_memo.txt";
            string[] d_m;
            string[] time;
            string[] date;
            try
            {
                stream_read = new StreamReader(@f_path);  //삭제 내역 상대경로로 열기
                delete_memo = new List<string>(); //삭제 내역을 저장할 리스트 초기화
                List<int> last_date= new List<int>(); // 삭제날짜와 현재날짜를 빼서 30일이 초과할 경우 자동 내역 삭제

                while (stream_read.Peek() >= 0) // 파일 끝을 만나기 전까지 반복
                {
                    d_m = stream_read.ReadLine().Split('\t');
                    time = d_m[2].Split(' '); 
                    date = time[0].Split('-');

                    DateTime Time = new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])); //년,월,일 순으로 나누어서 datetime 형식으로 변환 
                    TimeSpan resultTime = today - Time; //현재에서 삭제 날짜를 뺌

                    last_date.Add(int.Parse(resultTime.Days + "")); //결과 값들을 모두 리스트에 저장
                    delete_memo.Add(d_m[0]+"\t"+d_m[1]+"\t"+d_m[2]); //삭제 내역을 삭제내역 리스트에 저장
                }
                stream_read.Close();//파일닫기
              
                for(int i = 0; i<last_date.Count(); i++)
                {
                    if(last_date[i]>30)
                    {
                        delete_memo.RemoveAt(i); // 30일이 초과하는 경우 삭제내역에서 내역삭제
                    }
                }
               
                try
                {

                    stream_write = new StreamWriter(@f_path); //상대경로로 쓰기파일 생성
                   
                    for (int j = 0; j < delete_memo.Count(); j++)
                    {
                        stream_write.WriteLine(delete_memo[j]); //30일 초과 내역을 제외하고 삭제내역을 새로쓴다
                    }
                    stream_write.Close();//파일닫기
                  
                }
                catch (IOException)
                {

                }
            }
            catch (IOException)
            {
                
            }
            return delete_memo; //30일 초과 내역을 제외한 삭제 리스트를 반환해서 리스트 뷰에 출력한다.
           
        }
        public void FileRead()
        {
            string[] Path = { "stereo.txt", "text.txt", "media.txt", "image.txt", "other.txt" };
            string f_path = FilePath;
            string ff_path;
            foreach (string path in Path)
            {
                try
                {
                    ff_path = f_path + path;
                    stream_read = new StreamReader(@ff_path); //상대경로로 열기
                    List<string> lines = new List<string>();

                    while (stream_read.Peek() >= 0) // 파일 끝을 만날 때까지 반복
                    {
                        lines.Add(stream_read.ReadLine()); //파일 내역을 한줄씩 lines리스트에 저장
                    }
                    stream_read.Close(); //파일닫기
                    count.Add(lines.Count()); //파일별 확장자 개수가 저장될 count리스트

                    if (lines.Count() > 0) // lines 리스트에 확장자가 0개가 아닌 경우
                    {
                        for (int i = 0; i < lines.Count(); i++)
                        {
                            Ext.Add(lines[i]); //확장자를 순서대로 Ext 리스트에 저장
                        }
                    }
                }
                catch (IOException)
                {
                    count.Add(0); //만약 읽을 내용이 없어서 오류가 발생하면 그 확장자 파일은 카운트 0으로 설정
                }
            }
            sort();
        }



        public FIleMemo()
        {
            count = new List<int>(); // 파일별 확장자 갯수가 저장될 리스트 초기화
            Ext = new List<string>(); //확장자가 저장될 리스트 초기화
            FilePath = "..\\.\\"; // 상대경로 초기화

            stereo = new List<string>(); //오디오 리스트 초기화
            text = new List<string>(); // 문서 리스트 초기화
            image = new List<string>(); // 이미지 리스트 초기화
            media = new List<string>(); // 동영상 리스트 초기화
            other = new List<string>(); // 기타파일 리스트 초기화

        }
    }
}
