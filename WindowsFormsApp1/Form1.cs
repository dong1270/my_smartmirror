using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

using RestKit;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WindowsFormsApp1;
using Microsoft.Win32;
using System.Runtime.Remoting.Messaging;


namespace WindowsFormsApp1
{
    public class WeatherInfo
    {
        public WeatherInfo()
        {

        }

        public string[] RunWeather()
        {
            return GetWeather().Result;
        }
        static async Task<string[]> GetWeather()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\my_weather");
            string ApiKey = reg.GetValue("my_key").ToString();

            dynamic res = new JObject();

            Task<string[]> position = GetPosition();
            string lat = position.Result[0];
            string lon = position.Result[1];
            var client = new RestClient();
            var request = new RestRequest("https://api.openweathermap.org/data/2.5/weather?lat="
                + lat
                + "&lon="
                + lon
                + "&appid="
                + ApiKey
                + "&units=metric&lang=kr");

            string[] ret = new string[6];

            try
            {
                var response = await client.GetAsync(request);
                res = JObject.Parse(response.Content);

                //Console.WriteLine(res["weather"][0]["description"]);
                ret[0] = res["weather"][0]["description"];
                ret[1] = res["main"]["temp"];
                ret[2] = res["main"]["temp_min"];
                ret[3] = res["main"]["temp_max"];
                ret[4] = res["main"]["feels_like"];
                ret[5] = position.Result[2];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ret;
        }

        static async Task<string[]> GetPosition()
        {
            dynamic res = new JObject();

            string p_ip = GetIp();
            var client = new RestClient();
            var request = new RestRequest("http://ip-api.com/json/" + p_ip);
            string[] ret = new string[3];
            try
            {
                var response = await client.GetAsync(request);
                res = JObject.Parse(response.Content);

                ret[0] = res["lat"];
                ret[1] = res["lon"];
                ret[2] = res["city"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return ret;
        }

        static string GetIp()
        {
            string p_ip = new WebClient().DownloadString("http://ipinfo.io/ip").Trim();

            return p_ip;
        }

    }

    public partial class Form1: Form
    {
        OpenCvSharp.VideoCapture video;
        Mat mImage = new Mat(1080, 1920, MatType.CV_8UC3);
        private string[] info = new string[6];
        System.Threading.Timer thread;
        int num;


        /*
            info[0]: description
            info[1]: temp
            info[2]: temp_min
            info[3]: temp_max
            info[4]: feels_like
            info[5]: city name
         */

        public Form1()
        {
            InitializeComponent();
            num = 0;
            //weatherInfo
            //WeatherInfo weather = new WeatherInfo();
            
            //weatherTimer.Enabled = true;
            //weatherTimer.Interval = 600000;

            //this.thread = new System.Threading.Timer();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            today_temp.Parent = pictureBox1;
            //today_temp.Text = info[1];

            today_temp.BackColor = Color.Transparent;

            weather_icon.Parent = pictureBox1;
            weather_icon_des.Parent = weather_icon;
            //weather_icon_des.Text = info[0];

            weather_icon_des.BackColor = Color.Transparent;

            position.Parent = pictureBox1;
            //position.Text = info[5];
            position.BackColor = Color.Transparent;

            celsius_text.Parent = pictureBox1;
            celsius_text.BackColor = Color.Transparent;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int my_padding = 20;
            
            //WeatherInfo weather = new WeatherInfo();
            //this.info = weather.RunWeather();
            //thread

            //today_temp.Text = info[1];
            //weather_icon_des.Text = info[0];
            //position.Text = info[5];

            try
            {
                video = new VideoCapture(0);
                video.FrameWidth = this.Width;
                video.FrameHeight = this.Height;

                today_temp.Left = my_padding;

                celsius_text.Left = today_temp.Width + my_padding /2 ;

                weather_icon.Left = my_padding + 10;
                weather_icon.Top = weather_icon.Height + my_padding;

                position.Left = (this.Width - (my_padding * 7 + today_temp.Width)); // 오른쪽 상단 배치
                today_temp.Text = num.ToString();

                
            }
            catch
            {
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            video.Read(mImage);
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mImage);
            pictureBox1.Size = this.ClientSize;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mImage.Dispose();
        }

        private void weatherTimer_Event(object sender, EventArgs e)
        {
            //today_temp.Text = this.info[1];
            //weather_icon_des.Text = this.info[0];
            //position.Text = this.info[5];

            num++;
            //weatherTimer
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
