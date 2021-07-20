using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LINCHANGZHI7324
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            MytoolStripButtonOpen.Enabled = true;
            MytoolStripButtonClose.Enabled = false;
            MytoolStripStatusLabel1.Text = MytoolStripButtonClose.Text;
        }
        SoundPlayer soundPlayer;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                soundPlayer = new SoundPlayer();
                soundPlayer.SoundLocation = @"./music/m_set_68.wav";//我丟的背景音很好聽喔謝謝毛豆老師幫我改作業要休息喔
                soundPlayer.PlayLooping();
            }
            catch (Exception error)
            {
                MessageBox.Show("音樂檔案遺失" + error.Message);
            }
        }

        private void MytoolStripButtonOpen_Click(object sender, EventArgs e)
        {
            soundPlayer.PlayLooping();
            MytoolStripButtonOpen.Enabled = false;
            MytoolStripButtonClose.Enabled = true;
            MytoolStripStatusLabel1.Text = MytoolStripButtonOpen.Text;
        }

        private void 關閉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            MytoolStripButtonOpen.Enabled = true;
            MytoolStripButtonClose.Enabled = false;
            MytoolStripStatusLabel1.Text = MytoolStripButtonClose.Text;
        }

        private void 開啟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundPlayer.PlayLooping();
            MytoolStripButtonOpen.Enabled = false;
            MytoolStripButtonClose.Enabled = true;
            MytoolStripStatusLabel1.Text = MytoolStripButtonOpen.Text;
        }

        private void 開啟微軟計算機ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process processCount = new Process();
                processCount.StartInfo.FileName = @"calc.exe";

                processCount.Start();


            }
            catch (Exception ex)
            {
                MessageBox.Show("你的電腦可能沒有微軟小算盤，導致功能喪失");
            }
        }

       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DoYouLeave(e);
        }
        /// <summary>
        /// 談話窗口用來確定是否關閉主視窗
        /// </summary>
        /// <param name="e">視窗關閉事件</param>
        private void DoYouLeave(FormClosingEventArgs e)
        {
            if (MessageBox.Show("請問是否真的要退出？", "準備離開", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;  //關閉視窗
            }
            else
            {
                e.Cancel = true;    //取消關閉
            }
        }

        private void 關閉本軟體ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 橫向排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 縱向排列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        
        private void 新增表單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildFrom childFrom = new ChildFrom();
            childFrom.MdiParent = this;
            childFrom.Show();
            MytoolStripStatusLabel1.Text = "表單新建成功";
        }

        private void 新建文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildFrom childFrom = new ChildFrom();
            childFrom.Show();
            MytoolStripStatusLabel1.Text = "表單新建成功";
        }
    }
}
