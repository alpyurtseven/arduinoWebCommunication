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
        private static SerialPort _serialPort;
        private static readonly HttpClient Client = new HttpClient();
        private static Answer _answer = new Answer();
        private static string _answerText = "{";

        static void Main(string[] args)
        {
            Listen();
        }

        public static void Listen()
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";
            _serialPort.BaudRate = 9600;
            _serialPort.Open();

            bool potantiometerState = false;

            while (_serialPort.IsOpen)
            {
                string a = _serialPort.ReadExisting();
                if (a.Contains("CBV"))
                {
                    getButtonAnswer("");
                }
                if (a.Contains("CPV"))
                {
                    getPotantiometerValue(100);
                }

                Thread.Sleep(2000);
            }
        }

        private static void getPotantiometerValue(int value)
        {
            _answerText = "Potansiyometre:" + value + ";";
            updateOrCreateAnswer(_answerText);
        }

        private static void getButtonAnswer(string command)
        {
            _answerText =  "Button a tıklandı; ";

            updateOrCreateAnswer(_answerText);
        }

        private static void updateOrCreateAnswer(string text)
        {   
            if (_answer == null)
            {
                _answer = new Answer();
            }

            _answer.QuestionID = 1;
            _answer.UserId = 2;
            _answer.AnswerText = _answerText + "}";
            Console.WriteLine(_answer.AnswerText);

            sendAnswer(_answer);

        }

        private static async Task sendAnswer(Answer answer)
        {
            var content = JsonConvert.SerializeObject(answer);
            var byteContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
            
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = Client.PostAsync("https://localhost:44314/api/answer", byteContent);

            var msg = await stringTask;
            Console.Write(msg);
        }
    }
}
