using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArduinoConsole
{
    internal class Program
    {
        static SerialPort _serialPort;
        static void Main(string[] args)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM5";//Set your board COM
            _serialPort.BaudRate = 9600;
        
            foreach (var st in SerialPort.GetPortNames())
            {
                Console.WriteLine(st);
            }

            //while (true)
            //{
            //    string a = _serialPort.ReadExisting();
            //    Console.WriteLine(a);
            //    Thread.Sleep(200);
            //}
        }
    }
}
