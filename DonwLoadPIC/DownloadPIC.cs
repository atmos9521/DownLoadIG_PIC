using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonwLoadPIC
{
    public partial class DownloadPIC : Form
    {
        public DownloadPIC()
        {
            InitializeComponent();
        }

        /* 步驟一:
         * 1.讀取txt取得圖片url後回傳list 
         * 2.依照list的網址，轉成圖片下載
         * 3.下載過程中有錯誤或無資料出error訊息，成功出"下載結束"訊息
         * **/
        //開始下載按鈕
        string error = "";
        private void cuttext_Click(object sender, EventArgs e)
        {
            List<string> WebStrings = ReadString();
            foreach (string webstring in WebStrings)
            {
                //Console.WriteLine(webstring);
                StartToDownPicture(webstring);
            }
            if (error != "")
            {
                MessageBox.Show(error);
                error = "";
            }
            else
            {
                MessageBox.Show("下載結束");
                pathtext = "";
            }
        }

        /* 步驟二:
         * 1.開啟txt
         * 2.讀取一行資料，該行為空白則停止
         * 3.讀取該行資料時用正則比對出picture網址，加入WebStrings的list
         * 4.回傳list
         **/
        List<string> ReadString()
        {
            // 讀取TXT檔內文串
            /*
                StreamReader str = new StreamReader(@"E:\pixnet\20160614\Lab2_TXT_Read_Write\Read.TXT");
                StreamReader str = new StreamReader(讀取TXT檔路徑)    
                str.ReadLine(); (一行一行讀取)
                str.ReadToEnd();(一次讀取全部)
                str.Close(); (關閉str)
            */
            List<string> WebStrings = new List<string>();
            string OpenFilePath = "";
            string getstring = "stringstart";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenFilePath = openFileDialog1.FileName;
            }
            else
            {
                return WebStrings;
            }
            //StreamReader str = new StreamReader(@"F:\2019-07-14備份圖片\kurita__emi\圖片網址.txt");
            StreamReader str = new StreamReader(OpenFilePath);
            bool CheckeedValue = DownAllPagePIC_ckx.Checked;
            while (getstring != "" && getstring != null)
            {
                //讀取此行
                getstring = str.ReadLine();
                string textcut = "";
                if (getstring != null && !CheckeedValue)
                {
                    //string[] sArray = getstring.Split(new string[] { "src=\""," ","\"" }, StringSplitOptions.RemoveEmptyEntries);
                    //string[] sArray = getstring.Split(new string[] { "https:" }, StringSplitOptions.RemoveEmptyEntries);//rule 1
                    //foreach (var item in sArray)
                    //{
                    //    string textcut = GetImgUrl(string.Format("https:{0}", item), DownAllPagePIC_ckx.Checked);
                    //    WebStrings.Add(textcut);
                    //}
                    textcut = GetImgUrl(getstring, 1);
                    if (textcut != "")
                    {
                        WebStrings.Add(textcut);
                    }
                }
                else if (getstring != null && CheckeedValue)
                {
                    string[] sArray = getstring.Split(new string[] { "https:" }, StringSplitOptions.RemoveEmptyEntries);//rule 1
                    foreach (string item in sArray)
                    {
                        textcut = GetImgUrl(string.Format("https:{0}", item), 2);
                        if (textcut != "")
                        {
                            WebStrings.Add(textcut);
                        }
                    }
                }
            }
            str.Close();
            return WebStrings;
        }

        //步驟三:
        ///   <summary>
        ///   用正則 取出HTML中的图片地址
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string GetImgUrl(string HTMLStr, int Type)
        {
            string PicPath = "";
            string pattern = "";
            switch (Type)
            {
                case 1://一張張打開下載
                    //string str = string.Empty;
                    ////Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
                    //Regex r = new Regex(@"/^(?:(https?|ftp):\/\/)?((?:[a-zA-Z0-9.\-]+\.)+(?:[a-zA-Z0-9]{2,4}))((?:/[\w+=%&.~\-]*)*)\??([\w+=%&.~\-]*)$/",RegexOptions.Compiled);
                    //Match m = r.Match(HTMLStr.ToLower());
                    //pattern = "https:(.*)(?= 1080w)";//rule 1
                    //pattern = "(?<=src=\")(.*)fna.fbcdn.net";//rule 2
                    pattern = "https:(.*)https:(.*)https:(.*)https:(.*)\" style=\"";//rule 3 2020/11/26修改
                    break;
                case 2:
                    //pattern = "https:(.*)jpg(.*)(?=\",\"edge_liked_by)";
                    pattern = "https:(.*)fbcdn.net\"";
                    break;
                default:
                    break;
            }
            Match match = Regex.Match(HTMLStr, pattern);
            if (match.Success)
            {
                Group g = match.Groups[0];
                foreach (var PicPathString in match.Groups)
                {
                    PicPath = PicPathString.ToString().Replace("\"", "").Replace("&amp", "").Replace(";", "&");
                    PicPath = string.Format("http:{0}", PicPath);
                }                
            }
            return PicPath;
        }

        /* 步驟四:
         * 1.取得檔名
         * 2.有下載地址不pop視窗選擇
         * 3.下載檔案
         * **/
        string pathtext = "";
        void StartToDownPicture(string WebPath)
        {
            System.Net.WebClient WC = new System.Net.WebClient();

            //取得圖片名稱
            string[] filenames = WebPath.Split('?');
            string filename = "";
            foreach (string PartItem in filenames)
            {
                bool testhave = PartItem.Contains(".jpg");
                if (testhave)
                {
                    char[] cut = { '/' };
                    string[] cutnames = PartItem.Split(cut);
                    filename = cutnames.Last();
                }
            }

            string errorstring = "";
            try
            {
                System.IO.MemoryStream Ms = new System.IO.MemoryStream(WC.DownloadData(WebPath));
                Image img = Image.FromStream(Ms);
                var test = img.Tag;
                if (pathtext == "")//沒有下載地址
                {
                    //FolderBrowserDialog path = new FolderBrowserDialog();
                    //path.ShowDialog();
                    //pathtext = path.SelectedPath;
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pathtext = folderBrowserDialog1.SelectedPath;
                    }
                    else
                    {
                        pathtext = "cancel";
                    }
                }

                if (pathtext != "cancel")
                {
                    //下載檔案
                    if (pathtext != "" && filename != "")
                    {
                        string willsavepath = string.Format("{0}\\{1}", pathtext, filename);
                        errorstring = willsavepath;
                        int time = 0;
                        SaveFileVoid(time, willsavepath, img);
                    }
                    else
                    {
                        error = "Can't find txt name.";
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(string.Format("無法下載:{0}", errorstring));
                error = "It's not picture. Can't download.";
            }

        }

        /* 步驟五:
         * 1.確認此檔案是否存在
         * 2.已存在，加上編號
         * 3.不存在，下載到資料夾
         * **/
        private void SaveFileVoid(int time, string willsavepath, Image img)
        {
            var test = System.IO.File.Exists(willsavepath);
            if (test)
            {
                string[] InputNmuber = willsavepath.Split('.');
                string newfilename = string.Format("{0}({1}).{2}", InputNmuber[0], time + 1, InputNmuber[1]);
                SaveFileVoid(time + 1, newfilename, img);
                //MessageBox.Show("檔案存在");
            }
            else
            {
                Console.WriteLine(string.Format("下載成功:{0}", willsavepath));
                //MessageBox.Show("檔案不存在");
                img.Save(willsavepath);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TestForm1 tf = new TestForm1();
            tf.Show();
        }

    }
}
