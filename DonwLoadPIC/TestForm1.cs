using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
namespace DonwLoadPIC
{
    public partial class TestForm1 : Form
    {
        WebClient wc = new WebClient();
        public TestForm1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri imageURL = new Uri("https://scontent.cdninstagram.com/vp/71f80117c40b63c04f51733d68baa894/5D5510FF/t50.2886-16/68664155_2177817729008303_6316536586253649825_n.mp4?_nc_ht=scontent.cdninstagram.com");
            wc.DownloadFileAsync(imageURL, "MyDownLoadedImage.mp4");
        }

        void FileDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed");
        }
    }
}
