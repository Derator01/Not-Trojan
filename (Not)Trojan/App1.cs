using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace _Not_Trojan
{
    public partial class App1 : Form
    {
        string[] _scripts = new string[5];
        public int ScriptNumber = 0;
        readonly string[] _shortcuts = new string[] { "Start ", "Taskkill ", "explorer.exe ", "/f /im ", "Crome.exe ", "taskkill /f /im (Not)Trojan.exe " };

        public App1()
        {
            InitializeComponent();
            UpdateScriptNumber();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            _scripts = new string[5];
            OutputText.Text = "";
            ScriptNumber = 0;
        }

        private void Thread_Click(object sender, EventArgs e)
        {
            Thread App = new Thread(StartApp2);
            App.Start();
        }

        private void StartApp2()
        {
            Application.Run(new App2());
        } 


        private void Run_Click(object sender, EventArgs e)
        {
            string vitalPart = "/C ";
            if (Script_0.Checked)
            {
                string Output = vitalPart + _scripts[0];
                Process.Start("CMD.exe", Output);
            }
            if (Script_1.Checked)
            {
                string Output = vitalPart + _scripts[1];
                Process.Start("CMD.exe", Output);
            }
            if (Script_2.Checked)
            {
                string Output = vitalPart + _scripts[2];
                Process.Start("CMD.exe", Output);
            }
            if (Script_3.Checked)
            {
                string Output = vitalPart + _scripts[3];
                Process.Start("CMD.exe", Output);
            }
            if (Script_4.Checked)
            {
                string Output = vitalPart + _scripts[4];
                Process.Start("CMD.exe", Output);
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (ScriptNumber > 0)
            {
                ScriptNumber--;
            }
            UpdateScriptNumber();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (ScriptNumber < 4)
            {
                ScriptNumber++;
            }
            UpdateScriptNumber();
        }

        private void UpdateScriptNumber()
        {
            ScriptNumberTxt.Text = (ScriptNumber + 1).ToString();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            _scripts[ScriptNumber] = OutputText.Text;
        }

        private void ShctStart_Click(object sender, EventArgs e)
        {
            AddShortcut(0);
        }

        private void ShctTaskkill_Click(object sender, EventArgs e)
        {
            AddShortcut(1);
        }

        private void ShctExplorer_Click(object sender, EventArgs e)
        {
            AddShortcut(2);
        }

        private void ShctFIM_Click(object sender, EventArgs e)
        {
            AddShortcut(3);
        }
        
        private void Chrome_Click(object sender, EventArgs e)
        {
            AddShortcut(4);
        }

        private void ShctClose_Click(object sender, EventArgs e)
        {
            AddShortcut(5);
        }

        private void AddShortcut(int ID)
        {
            _scripts[ScriptNumber] = OutputText.Text;
            _scripts[ScriptNumber] += _shortcuts[ID];
            OutputText.Text = _scripts[ScriptNumber].ToString();
        }
    }
}
