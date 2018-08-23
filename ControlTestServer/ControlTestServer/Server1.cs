using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Pipes;
using System.IO;
using System.Security.Principal;



namespace ControlTestServer
{
    
    public partial class Server1 : Form
    {
        Thread newThread;
        static int numThreads = 2;
        private int numClients = 0;
        bool first = true;
        bool button_click = false;
        

        private bool isHost = false;
        public enum MainMenu {
            FLIGHT_DATA = 0,
            FLIGHT_PLANNER = 1,
            INITIAL_SETTING = 2,
            SOFTWARE_SETTING = 3,
            SIMULATION = 4,
            TERMINAL = 5,
        };

        public Server1()
        {
            InitializeComponent();
        }

        private void KillThread()
        {
            if (newThread != null)
            {
                NamedPipeClientStream clt = new NamedPipeClientStream(".", "testpipe",
                            PipeDirection.InOut, PipeOptions.Asynchronous,
                            TokenImpersonationLevel.Impersonation);
                StreamWriter sw = new StreamWriter(clt);
                StreamReader sr = new StreamReader(clt);
                string s = "";
                clt.Connect();
                if (sr.ReadLine() == "My Server!")
                {
                    sw.WriteLine(".exit");
                }
                clt.Close();
            }
        }

        private void BUT_HostServer_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button Click!");

            if (newThread == null && txt_ServerName.Text != "")
            {
                newThread = new Thread(ServerThread);
                newThread.Start();
                BUT_HostServer.Text = "Wait!";
                isHost = true;
            }
            
        }

        private async void ServerThread(object data)
        {
            
            NamedPipeServerStream pipeServer =
                new NamedPipeServerStream(txt_ServerName.Text, PipeDirection.InOut, numThreads,PipeTransmissionMode.Message, PipeOptions.Asynchronous);
            Console.WriteLine("NamedPipeServerStream thread created.");

            //等待客户端连接  
            //pipeServer.WaitForConnection();
            //pipeServer.BeginWaitForConnection(new AsyncCallback(WaitForConnectionCallBack), pipeServer);
            while (true)
            {
                await Task.Factory.FromAsync(
                    (cb, state) => pipeServer.BeginWaitForConnection(cb, state),
                    ar => pipeServer.EndWaitForConnection(ar),
                    null);
                Console.WriteLine("Client connected.");

                StreamReader sr = new StreamReader(pipeServer);
                StreamWriter sw = new StreamWriter(pipeServer);
                sw.AutoFlush = true;

                if (first)
                {
                    first = false;
                    await sw.WriteLineAsync("My_Server!");
                }
                    
                    string content = await sr.ReadLineAsync();

                    if (content == MainMenu.FLIGHT_DATA.ToString())
                        Console.WriteLine("Flight Data");
                    if (content == MainMenu.FLIGHT_PLANNER.ToString())
                        Console.WriteLine("Flight Planner");
                    if (content == MainMenu.INITIAL_SETTING.ToString())
                        Console.WriteLine("Initial Setting");
                    if (content != null)
                    {
                        Console.WriteLine(content);
                        await sw.WriteLineAsync(content);
                    }
                   
                

                pipeServer.Disconnect();
            }
            
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Send Click!");
            button_click = true;
        }
    }
}
