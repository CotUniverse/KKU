using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ККУ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            OpenChildForm(new Forms.FormPok(), 0);
            this.Text = string.Empty;
            this.ControlBox = false;
            status();
        }
        public void status()
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(btnClose, "Закрыть");

            t.SetToolTip(button6, "Свернуть");
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Form activeForm;

       

            private void DisableButton()
            {
                foreach (Control previousBtn in panelMenu.Controls)
                {
                    if (previousBtn.GetType() == typeof(Button))
                    {
                        previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                        previousBtn.ForeColor = Color.Gainsboro;
                        previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                }
            }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormPok(), sender);
            label1.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Form2(), sender);
            label1.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.assist(), sender);
            label1.Text = button3.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "КАЛЬКУЛЯТОР КОММУНАЛЬНЫХ УСЛУГ";
            OpenChildForm(new Forms.FormPok(), sender);
        }
    }

}
