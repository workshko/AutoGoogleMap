using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoGoogleMap
{
    public partial class mainForm : Form
    {
        private delegate void SetTextCallback(string text); //로그기록

        public mainForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SetLog(string log)
        {
            if (this.txtLog.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetLog);
                this.Invoke(d, new object[] { log });
            }
            else
            {
                //this.txtLog.Text += log;
                this.txtLog.Focus();
                this.txtLog.AppendText(log);
            }
        }

        /// <summary>
        /// 오류 발생시 다시 초기 셋팅으로 돌아오도록 함.
        /// </summary>
        /// <param name="driver"></param>
        private void SetInit(IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            foreach (var handel in windowHandles)
            {
                if (handel == driver.CurrentWindowHandle)
                    continue;

                driver.Close();
            }

            driver.SwitchTo().Window(driver.WindowHandles[0]);

            driver.Url = "https://www.google.co.kr/maps/@37.5839889,126.8613182,14z/data=!4m2!10m1!1e2";

            Thread.Sleep(3000);

            var pwTag = driver.FindElement(By.CssSelector("button[aria-label='지도']"));
            pwTag.Click();
        }

        private void StartWork()
        {
            
            try
            {
                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true; //크롬 콘솔창 숨기기 

                var options = new ChromeOptions();

                if (this.chkChrome.Checked == true)
                {
                    options.AddArguments("disable-infobars");
                    options.AddArguments("--js-flags=--expose-gc");
                    options.AddArguments("--enable-precise-memory-info");
                    options.AddArguments("--disable-popup-blocking");
                    options.AddArguments("--disable-default-apps");
                    options.AddArguments("--headless");
                }

                using (IWebDriver driver = new ChromeDriver(driverService, options))
                {
                    string id = this.txtGoogleID.Text.Trim();
                    string pw = this.txtGooglePW.Text.Trim();

                    SetLog("구글 로그인 시작....\n");

                    driver.Url = "https://stackoverflow.com/users/login?ssrc=head";
                    var googleBtn = driver.FindElement(By.ClassName("s-btn__google"));
                    googleBtn.Click();
                    Thread.Sleep(2000);

                    var emailTag = driver.FindElement(By.Name("identifier"));
                    emailTag.SendKeys(id);

                    var nextBtn = driver.FindElement(By.Id("identifierNext"));
                    nextBtn.Click();

                    Thread.Sleep(5000);

                    var passwordTag = driver.FindElement(By.Name("password"));
                    passwordTag.SendKeys(pw);

                    //암호 입력 버튼
                    var passNextBtn = driver.FindElement(By.Id("passwordNext"));
                    passNextBtn.Click();

                    Thread.Sleep(5000);

                    driver.Url = "https://www.google.co.kr/maps/@37.5839889,126.8613182,14z/data=!4m2!10m1!1e2";

                    Thread.Sleep(5000);

                    var login_div = driver.FindElement(By.Id("gb"));

                    if (login_div.Text == "로그인")
                    {
                        SetLog("구글 로그인 실패....\n");
                        return;
                    }

                    SetLog("구글 로그인 성공....\n");
                    SetLog("구글맵 페이지 이동완료....\n");

                    var pwTag = driver.FindElement(By.CssSelector("button[aria-label='지도']"));
                    pwTag.Click();

                    Thread.Sleep(1500);

                    string[] txtLines = System.IO.File.ReadAllLines(this.txtFileDir.Text);

                    //반복 작업 시작!
                    foreach (string lineText in txtLines)
                    {

                        string strAddress = "";     //지도를 찍을 위치
                        string strMapTitle = "";    //제목글
                        string strMapRemark = "";   //설명글

                        try
                        {

                            string[] keywords = lineText.Split('|');

                            if (keywords.Length != 3)
                                continue;

                            strAddress = keywords[0];
                            strMapTitle = keywords[1];
                            strMapRemark = keywords[2];

                            Thread.Sleep(1500);

                            //지도 만들기
                            var createBtn = driver.FindElement(By.CssSelector("span.section-my-maps-create-button"));
                            createBtn.Click();

                            Thread.Sleep(2500);

                            System.Diagnostics.Debug.Print(driver.WindowHandles[0]);    //현재창

                            //새창으로 전환
                            driver.SwitchTo().Window(driver.WindowHandles[1]);

                            Thread.Sleep(250);

                            var mapTitle = driver.FindElement(By.CssSelector("div[aria-label='제목없는 지도']"));
                            mapTitle.Click();

                            Thread.Sleep(250);

                            //update-map
                            var modalPopup = driver.FindElement(By.Id("update-map"));

                            var mapUpTitle = modalPopup.FindElement(By.CssSelector("input[type=text]"));
                            var mapUpRemark = modalPopup.FindElement(By.CssSelector("textarea"));
                            var mapUpSave = modalPopup.FindElement(By.Name("save"));

                            Thread.Sleep(250);

                            mapUpTitle.SendKeys(strMapTitle);

                            foreach (string text in strMapRemark.Split('^'))
                            {
                                mapUpRemark.SendKeys(text);
                                mapUpRemark.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter);
                            }

                            mapUpSave.Click();

                            Thread.Sleep(250);

                            //지도 검색어
                            var mapKeyword = driver.FindElement(By.Id("mapsprosearch-field"));
                            var mapBtn = driver.FindElement(By.Id("mapsprosearch-button"));

                            mapKeyword.SendKeys(strAddress);
                            mapBtn.Click();

                            Thread.Sleep(2000);

                            var addMapBtn = driver.FindElement(By.Id("addtomap-button"));
                            addMapBtn.Click();

                            Thread.Sleep(500);

                            var modifyMapBtn = driver.FindElement(By.Id("map-infowindow-edit-button"));
                            modifyMapBtn.Click();

                            // 찍힌 주소명 수정

                            var mapInfoWindow = driver.FindElement(By.Id("map-infowindow-container"));

                            var mapInfoTitle = mapInfoWindow.FindElement(By.Id("map-infowindow-attr-이름-value"));
                            var mapInfoRemark = mapInfoWindow.FindElement(By.Id("map-infowindow-attr-설명-value"));


                            mapInfoTitle.Clear();
                            mapInfoTitle.SendKeys(strMapTitle);

                            Thread.Sleep(250);

                            foreach (string text in strMapRemark.Split('^'))
                            {
                                mapInfoRemark.SendKeys(text);
                                mapInfoRemark.SendKeys(OpenQA.Selenium.Keys.Shift + OpenQA.Selenium.Keys.Enter);
                            }

                            mapInfoRemark.SendKeys(OpenQA.Selenium.Keys.Enter);

                            //Clipboard.SetText(strMapRemark);
                            //mapInfoRemark.SendKeys(OpenQA.Selenium.Keys.Control + "v");

                            Thread.Sleep(500);

                            //공유 시작

                            var btnShare = driver.FindElement(By.Id("map-action-share"));
                            btnShare.Click();

                            Thread.Sleep(2500);

                            //액세스 권한 변경(모든사용자)

                            var shareModal = driver.FindElement(By.CssSelector("div[guidedhelpid='share_dialog']"));

                            //iframe이 있어서 스위치시켜주어야한다.
                            var shareModaliFrame = shareModal.FindElement(By.TagName("iframe"));

                            driver.SwitchTo().Frame(shareModaliFrame);

                            var modifyAccess = driver.FindElement(By.Id(":h.change-link"));

                            modifyAccess.Click();

                            //사용 - 모든 웹 사용자
                            var shareCheck = driver.FindElement(By.Id(":27.pub"));
                            shareCheck.Click();

                            //링크공유 저장
                            var shareSave = driver.FindElement(By.Id(":27.save"));
                            shareSave.Click();

                            Thread.Sleep(2500);

                            //완료
                            var shareComplete = driver.FindElement(By.Id(":1a.close"));
                            shareComplete.Click();

                            Thread.Sleep(2000);

                            //현재 활성화 탭 닫기
                            driver.Close();

                            //첫번째 창으로 이동
                            driver.SwitchTo().Window(driver.WindowHandles[0]);

                            Thread.Sleep(1500);

                            SetLog(string.Format("작업완료.......  키워드 : {0}, {1}, {2}\n", strMapTitle, strMapRemark, strAddress));
                        }
                        catch (Exception exception)
                        {
                            SetLog(string.Format("반복작업 중 오류발생 - 키워드 : {0}, {1}, {2}\n", strMapTitle, strMapRemark, strAddress));
                            SetLog(exception.Message + "\n\n");

                            SetInit(driver);
                        }

                    }

                    SetLog("최적화 작업이 완료되었습니다.\n");
                    SetLog("-----------------------------------------\n\n");

                    this.Invoke(new Action(delegate()
                    {
                        this.txtFileDir.Text = string.Empty;
                        this.btnTest.Enabled = true;
                    }));

                }
            }
            catch (Exception ee)
            {
                if (ee.Message.Contains("gb"))
                {
                    SetLog("오류내용 : ");
                    SetLog("구글 아이디 또는 암호가 일치하지 않습니다.");
                }

                SetLog(ee.Message);

                MessageBox.Show("작업 중 오류가 발생하였습니다..");

            }

        }

        #region 이벤트

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (this.txtGoogleID.Text == String.Empty)
            {
                MessageBox.Show("구글 로그인 아이디를 입력하세요.");
                this.txtGoogleID.Focus();
                return;
            }

            if (this.txtGooglePW.Text == String.Empty)
            {
                MessageBox.Show("구글 암호를 입력하세요.");
                this.txtGooglePW.Focus();
                return;
            }

            if (this.txtFileDir.Text == String.Empty)
            {
                MessageBox.Show("작업하실 파일을 선택 하세요.");
                return;
            }

            if (File.Exists(this.txtFileDir.Text) == false)
            {
                MessageBox.Show("작업경로에 파일이 존재하지 않습니다.");
                return;
            }
            SetLog("-----------------------------------------\n\n");
            SetLog("작업 시작....\n");

            this.btnTest.Enabled = false;

            Thread worker = new Thread(new ThreadStart(StartWork));
            worker.Start();   
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "작업파일 열기";
            ofd.Filter = "txt 파일 (*.txt) | *.txt;";
            ofd.Multiselect = false;

            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtFileDir.Text = ofd.FileName;
            }

        }

        #endregion

        

    }
}
