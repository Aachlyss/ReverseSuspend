using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReverseSuspend
{
    public partial class name : Form
    {
        delegate void CharParamDelegate(char aChar);
        private const string MESSAGE = " This application demonstrates " +
"Thread.Suspend() and Thread.Resume() methods. ";
private Thread mThread;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.Button buttonSuspend;

        [Obsolete]
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            mThread = new Thread(new ThreadStart(this.PrintMessages));
            mThread.IsBackground = true;
            mThread.Start();
            SuspendThread();
        }

        [Obsolete]
        private void SuspendThread()
        {
            mThread.Suspend();
            buttonSuspend.Enabled = false;
            buttonResume.Enabled = true;
        }

        [Obsolete]
        private void ResumeThread()
        {
            mThread.Resume();
            buttonSuspend.Enabled = true;
            buttonResume.Enabled = false;
        }
        private void AppendTextToTextBox(char aChar)
        {
            textBoxMessage.AppendText(aChar.ToString());
        }
        /// &lt;summary&gt;
        /// PrintMessages() runs in a separate thread and slowly
        /// prints messages in the MainForm&#39;s text box.
        /// &lt;/summary&gt;
        private void PrintMessages()
        {
            while (true)
            {
                foreach (char letter in MESSAGE.ToCharArray())
                {
                    try
                    {
                        this.Invoke(new CharParamDelegate(
                        AppendTextToTextBox), new object[] { letter });
                    }
                    catch (Exception)
                    {
                        // Can not call Invoke() bacause the form is closed.
                        return;
                    }
                    Thread.Sleep(50);
                }
            }
        }

        [Obsolete]
        private void buttonSuspend_Click(object sender,
        System.EventArgs e)
        {
            SuspendThread();
        }

        [Obsolete]
        private void buttonResume_Click(object sender,
        System.EventArgs e)
        {
            ResumeThread();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // name
            // 
            this.ClientSize = new System.Drawing.Size(297, 267);
            this.Name = "name";
            this.ResumeLayout(false);

        }
    }
}
