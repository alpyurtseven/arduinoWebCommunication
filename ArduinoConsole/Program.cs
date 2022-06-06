using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Data.Models;
using Newtonsoft.Json;


namespace ArduinoConsole
{
    internal class Program
    {
        static SerialPort _serialPort;
        private static readonly HttpClient client = new HttpClient();
        enum Level
        {
            Low,
            Medium,
            High
        }

        private static Answer answer;
        static void Main(string[] args)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";
            _serialPort.BaudRate = 9600;
            _serialPort.Open();

            bool potantiometerState = false;

            while (_serialPort.IsOpen)
            {
                string a = _serialPort.ReadExisting();
                if (a != "")
                {
                    if (a == "CST0" || a == "CST1")
                    {
                        getPotantiometerTime(a);
                    }else if(a == "CGV")
                    {
                        getPotantiometerValue(a);
                    }else if (a == "CBV")
                    {
                        getButtonAnswer(a);
                    }



                }
                Thread.Sleep(200);
            }
        }

        private static void getPotantiometerTime(string command)
        {
            if (command == "CST0")
            {

            }else if (command == "CST1")
            {

            }
        }

        private static void getPotantiometerValue(string command)
        {
            if (command == "CGV")
            {

            }
        }

        private static void getButtonAnswer(string command)
        {
            if (command == "CBV")
            {

            }
        }

        private static void updateOrCreateAnswer(string text)
        {   
            if (answer == null)
            {
                answer = new Answer();
            }

            new JavaScriptSerializer().Serialize(text);

            answer.AnswerText = "";
        }

        private static void confirmAnswer()
        {
            throw new ArgumentException();
        }

        private static async Task sendAnswer(Answer answer)
        {
            var content = JsonConvert.SerializeObject(answer);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.PostAsync("https://api.github.com/orgs/dotnet/repos",byteContent);

            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}
