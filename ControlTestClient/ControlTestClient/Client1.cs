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
using System.Diagnostics;

namespace ControlTestClient
{
    public partial class Client1 : Form
    {
        Thread newThread;
        bool button_click = false;
        bool kill = false;
        private string id = "";
        public Client1()
        {
            InitializeComponent();
        }

        delegate void setRtbHandler(string s);
        private void KillThread()
        {
            kill = true;
            //TXT_InputBox.Text = ".exit";
            button_click = true;
        }
        private void TXT_InputBox_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BUT_SendMsg.PerformClick();
            }
        }

        private async void ClientThread(object data)
        {
            try
            {
                
                do
                {
                    if (button_click != true)
                        continue;
                    //这里第一个参数是我的计算机名  
                    NamedPipeClientStream pipeClientA =
                        new NamedPipeClientStream(".", "testpipe",
                            PipeDirection.InOut, PipeOptions.Asynchronous,
                            TokenImpersonationLevel.Impersonation);
                    StreamWriter sw = new StreamWriter(pipeClientA);
                    StreamReader sr = new StreamReader(pipeClientA);
                    pipeClientA.Connect(300);
                    sw.AutoFlush = true;

                    //确认服务器连接
                    string s = sr.ReadLine();
                    Console.WriteLine(s);
                    if (s != "My_Server!")
                    {
                        throw new ApplicationException("Error");
                    }
                    else
                    {
                        //id = split_msg[0];
                        //Console.WriteLine(id);
                        string toWrite = "";




                        if (!kill)
                            toWrite = TXT_InputBox.Text;
                        else
                            toWrite = ".exit";
                        await sw.WriteLineAsync(toWrite);
                        string ack = await sr.ReadLineAsync();
                        Console.WriteLine(ack);
                        if (ack != toWrite)
                        {
                            throw new ApplicationException("Error");
                        }
                        this.Invoke(new Action(() => { TXT_InputBox.Clear(); }));
                        button_click = false;
                        

                    }
                    //关闭客户端
                    pipeClientA.Close();
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BUT_SendMsg_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button Click!");
            button_click = true;
            if (newThread == null)
            {
                newThread = new Thread(ClientThread);
                newThread.Start();
            }
            
        }
    }
}
