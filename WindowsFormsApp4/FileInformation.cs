

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace WindowsFormsApp4
{

    static class _MAX_PATH
    {
        public const int MAX_PATH = 248; //경로 길이, 256자 이상일 경우 오류발생 
    }
    public class FIleInformation 
    {

        //파일 경로가 저장될 필드
        //private string filePath;
        //파일 확장자가 저장될 필드
        //private string fileExt;
        //파일 갯수
        //private int fileCount;
        List<string> collection;


        //파일 경로 프로퍼티
        public string FilePath
        {
            get; set;
        }

    
        //찾고자 하는 파일들의 경로를 받아온다. 재귀 메소드
        public void getFiles(List<string> fileExt,string filePath)
        {
            try
            {
                string[] files;
               
                string[] dirs = Directory.GetDirectories(filePath); //하위 디렉토리 경로를  배열에 저장

                
                if (_MAX_PATH.MAX_PATH > dirs.Length) //하위 디렉토리가 존재하면 
                {
                    for (int i = 0; i < fileExt.Count(); i++)
                    {
                        if (fileExt[i] == null)
                        {
                            files = Directory.GetFiles(filePath, fileExt[i]);
                        }
                        else
                        {
                            files = Directory.GetFiles(filePath, fileExt[i]);
                        }
                        foreach (string f in files)
                        {
                            collection.Add(f);
                        }
                    }
                    if (dirs.Length > 0)
                    {
                        foreach (string dir in dirs)
                        {
                            getFiles(fileExt, filePath);
                        }
                    }
                }

            }
            catch (Exception)
            {

            }

        }

        //파일명
        public string getFileName()
        {
            return Path.GetFileName(FilePath);
        }
        //디렉토리 명
        public string getFileDirectoryName()
        {
            return Path.GetDirectoryName(FilePath);
        }
        //파일 경로
        public string[] getFilePath()
        {
            /*for (int i = 0; i < SerachFiles.Count(); i++)
            {
                Files[i] = SerachFiles[i];
            }*/
            //return Files;
            string[] Files = new string[collection.Count];
            for (int i = 0; i < collection.Count; i++)
            {
                Files[i] = collection[i];
            }
            return Files;
            //return Path.GetDirectoryName(filePath);
        }
        //파일 크기
        public string getFileSize()
        {
            //파일인포
            FileInfo info = new FileInfo(FilePath);
            double byteCount = info.Length;
            string size = "0 Bytes";

            if (byteCount >= 1073741824.0)
                size = string.Format("{0:##.##}", byteCount / 1073741824.0) + " GB"; // String format으로 형식변경
            else if (byteCount >= 1048576.0)
                size = string.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = string.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " Bytes";

            return size;
        }

        //파일/디렉토리를 마지막으로 사용한 날짜
        public string getFileTime(string filepath)
        {
            return File.GetLastWriteTime(filepath).ToString("yyyy-MM-dd");
        }
        //파일 디렉토리를 마지막으로 사용한 날짜 및 시간
        public string getFileLastTime(string filepath)
        {
            return File.GetLastWriteTime(filepath).ToString("yyyy-MM-dd HH:mm:ss");
        }
        //파일 디렉토리를 마지막으로 사용한 날짜에서 현재 날짜를 빼 며칠이 지났는지
        public int getFileLastDay(string filepath)
        {
            string[] time = getFileTime(filepath).Split('-');

            System.DateTime Time = new System.DateTime(int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
            TimeSpan resultTime = DateTime.Now - Time;

            return int.Parse(resultTime.Days+"");
        }

        public FIleInformation()
        {
            FilePath = "C:\\"; //초기 경로
            collection = new List<string>();
        }

    }


}
