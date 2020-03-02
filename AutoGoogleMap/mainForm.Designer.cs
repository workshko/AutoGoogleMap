namespace AutoGoogleMap
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.txtGoogleID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGooglePW = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkChrome = new System.Windows.Forms.CheckBox();
            this.txtFileDir = new System.Windows.Forms.TextBox();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 271);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(105, 43);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "작업시작";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtLog);
            this.groupBox5.Location = new System.Drawing.Point(12, 341);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(599, 261);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "최근 실행 로그";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 17);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLog.Size = new System.Drawing.Size(593, 241);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // txtGoogleID
            // 
            this.txtGoogleID.Location = new System.Drawing.Point(57, 9);
            this.txtGoogleID.Name = "txtGoogleID";
            this.txtGoogleID.Size = new System.Drawing.Size(178, 21);
            this.txtGoogleID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "구글ID";
            // 
            // txtGooglePW
            // 
            this.txtGooglePW.Location = new System.Drawing.Point(57, 36);
            this.txtGooglePW.Name = "txtGooglePW";
            this.txtGooglePW.Size = new System.Drawing.Size(178, 21);
            this.txtGooglePW.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "암호";
            // 
            // chkChrome
            // 
            this.chkChrome.AutoSize = true;
            this.chkChrome.Location = new System.Drawing.Point(479, 14);
            this.chkChrome.Name = "chkChrome";
            this.chkChrome.Size = new System.Drawing.Size(128, 16);
            this.chkChrome.TabIndex = 3;
            this.chkChrome.Text = "크롬창 숨겨서 실행";
            this.chkChrome.UseVisualStyleBackColor = true;
            // 
            // txtFileDir
            // 
            this.txtFileDir.Location = new System.Drawing.Point(12, 75);
            this.txtFileDir.Name = "txtFileDir";
            this.txtFileDir.ReadOnly = true;
            this.txtFileDir.Size = new System.Drawing.Size(514, 21);
            this.txtFileDir.TabIndex = 4;
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(532, 73);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(75, 23);
            this.btnFileSelect.TabIndex = 5;
            this.btnFileSelect.Text = "파일선택";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 72);
            this.label3.TabIndex = 6;
            this.label3.Text = "※ 메모장 파일을 이용하세요. 구분자는 반드시 \'|\' 로 지정 개행문자\'^\'\r\n\r\n\r\n예시 ) 위치주소|제목|설명 \r\n\r\n         강남대로" +
    "92길|앱기획|앱기획설명^www.naver.com";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 615);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFileSelect);
            this.Controls.Add(this.txtFileDir);
            this.Controls.Add(this.chkChrome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGoogleID);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtGooglePW);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.Text = "검색엔진 최적화 작업";
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TextBox txtGoogleID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGooglePW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkChrome;
        private System.Windows.Forms.TextBox txtFileDir;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.Label label3;
    }
}

