using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp4
{
    class ExceptMemo : File_set
    {


        private StreamWriter stream_write; //쓰기용으로 파일 객체
        private StreamReader stream_read; // 읽기용으로 파일 객체
      
        

        public string FilePath // 파일 경로 프로퍼티 
        {
            get; set;
        }
        public List<string> Except_memo // 제외 내역 프로퍼티
        {
            get; set;
        }
        public void FileWrite(string filename, string filepath)
        {
            FIleInformation f = new FIleInformation(); // FileInformation 객체를 생성
            
            
            string f_path = FilePath + "except_memo.txt"; //상대경로 제외 내역 파일 경로 설정
            f.FilePath = f_path; //상대경로를 객체 f 에 저장


            try
            {
                FileStream fs = new FileStream(@f_path, FileMode.Append, FileAccess.Write);
                //이어쓰기 모드로 파일을 열고 없으면 만든다.
                stream_write = new StreamWriter(fs); //상대경로로 쓰기파일 생성
                
                stream_write.WriteLine(filename + "\t" + f.getFileLastTime(f_path)+ "\t" + filepath ); //파일명, 파일 마지막 사용 일자, 파일 경로 텍스트파일에 저장
                stream_write.Close(); // 파일 닫기
                fs.Close(); // 이어쓰기모드 닫기

            }   
            catch (IOException)
            {

            }

        }
      
        public void FileWrite(Form3 form3) //Form3에 접근하기 위해 매개변수로 Form3 객체를 사용
        {

                try
                {
                string f_path = FilePath + "except_memo.txt";
                stream_write = new StreamWriter(@f_path); //절대경로로 쓰기파일 생성
                  
                        for (int i = 0; i < form3.listView1.Items.Count; i++)
                        {
                            stream_write.WriteLine(form3.listView1.Items[i].SubItems[1].Text + "\t" + form3.listView1.Items[i].SubItems[2].Text + "\t" + form3.listView1.Items[i].SubItems[3].Text);
                        } // listView1에 있는 리스트 내역을 제외 내역에 저장
             

                    stream_write.Close(); // 파일닫기

                }
                catch (IOException) //파일 입출력 오류 예외 처리
                {

                }
            }

        
        public void FileRead()
        {
            string f_path = FilePath + "except_memo.txt"; // 상대경로 설정
           
            try
            {
                stream_read = new StreamReader(@f_path); //상대경로로 파일읽기로 열기

                while (stream_read.Peek() >= 0) // Peek함수를 이용해 파일끝 까지 반복
                {
                    Except_memo.Add(stream_read.ReadLine()); // 리스트에 파일에 내용을 한줄씩 줄단위로 저장
                }
                stream_read.Close();//파일 닫기
                        
            }
            catch (IOException)
            {

            }
        }
        public ExceptMemo()
        {
            FilePath = "..\\.\\"; //초기경로 상대경로
            Except_memo = new List<string>(); //제외내역을 저장할 리스트
        }
    }
}
