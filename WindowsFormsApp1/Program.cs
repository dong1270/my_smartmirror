using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

using RestKit;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        static async Task<string[]> getWeather()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\my_weather");
            string ApiKey = reg.GetValue("my_key").ToString();

            dynamic res = new JObject();

            Task<string[]> position = getPosition();
            string lat = position.Result[0];
            string lon = position.Result[1];
            var client = new RestClient();
            var request = new RestRequest("https://api.openweathermap.org/data/2.5/weather?lat="
                + lat
                + "&lon="
                + lon
                + "&appid="
                + ApiKey
                +"&units=metric&lang=kr");

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

        static async Task<string[]> getPosition()
        {
            dynamic res = new JObject();

            string p_ip = getIp();
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

        static string getIp()
        {
            string p_ip = new WebClient().DownloadString("http://ipinfo.io/ip").Trim();

            return p_ip;
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new Form1(getWeather().Result));
            Application.Run(new Form1());
        }
    }
}
