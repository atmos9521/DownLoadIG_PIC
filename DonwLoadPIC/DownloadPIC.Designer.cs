namespace DonwLoadPIC
{
    partial class DownloadPIC
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadPIC));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cuttext = new System.Windows.Forms.Button();
            this.DownAllPagePIC_ckx = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cuttext
            // 
            this.cuttext.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cuttext.Location = new System.Drawing.Point(13, 23);
            this.cuttext.Margin = new System.Windows.Forms.Padding(4);
            this.cuttext.Name = "cuttext";
            this.cuttext.Size = new System.Drawing.Size(255, 85);
            this.cuttext.TabIndex = 1;
            this.cuttext.Text = "StartToDownLoad";
            this.cuttext.UseVisualStyleBackColor = true;
            this.cuttext.Click += new System.EventHandler(this.cuttext_Click);
            // 
            // DownAllPagePIC_ckx
            // 
            this.DownAllPagePIC_ckx.AutoSize = true;
            this.DownAllPagePIC_ckx.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DownAllPagePIC_ckx.Location = new System.Drawing.Point(13, 115);
            this.DownAllPagePIC_ckx.Name = "DownAllPagePIC_ckx";
            this.DownAllPagePIC_ckx.Size = new System.Drawing.Size(134, 29);
            this.DownAllPagePIC_ckx.TabIndex = 3;
            this.DownAllPagePIC_ckx.Text = "下載全網址";
            this.DownAllPagePIC_ckx.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(154, 109);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "測試下載";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // DownloadPIC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 153);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DownAllPagePIC_ckx);
            this.Controls.Add(this.cuttext);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DownloadPIC";
            this.Text = "DownLoadPicture_v3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button cuttext;
        private System.Windows.Forms.CheckBox DownAllPagePIC_ckx;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
    }
}

