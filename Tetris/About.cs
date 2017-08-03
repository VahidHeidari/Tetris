using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Properties;
namespace Tetris
{
	public class About : Form
	{
		private IContainer components = null;
		private Button btn_ok;
		private PictureBox pictureBox1;
		private Panel panel1;
		private LinkLabel link_lbl_tjs;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.btn_ok = new Button();
			this.pictureBox1 = new PictureBox();
			this.panel1 = new Panel();
			this.link_lbl_tjs = new LinkLabel();
			this.label4 = new Label();
			this.label3 = new Label();
			this.label2 = new Label();
			this.label1 = new Label();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.btn_ok.Location = new Point(178, 218);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new Size(75, 23);
			this.btn_ok.TabIndex = 0;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new EventHandler(this.btn_ok_Click);
			this.pictureBox1.Image = Resources.NES_Tetris_Box_Front;
			this.pictureBox1.Location = new Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(134, 192);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.panel1.BorderStyle = BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.link_lbl_tjs);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new Point(162, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new Size(230, 192);
			this.panel1.TabIndex = 2;
			this.link_lbl_tjs.AutoSize = true;
			this.link_lbl_tjs.Cursor = Cursors.Hand;
			this.link_lbl_tjs.Location = new Point(46, 158);
			this.link_lbl_tjs.Name = "link_lbl_tjs";
			this.link_lbl_tjs.Size = new Size(134, 13);
			this.link_lbl_tjs.TabIndex = 4;
			this.link_lbl_tjs.TabStop = true;
			this.link_lbl_tjs.Text = "http://tjs87.wordpress.com";
			this.link_lbl_tjs.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_lbl_tjs_LinkClicked);
			this.label4.AutoSize = true;
			this.label4.Location = new Point(60, 111);
			this.label4.Name = "label4";
			this.label4.Size = new Size(103, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Feel free to Enjoy it !";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(66, 70);
			this.label3.Name = "label3";
			this.label3.Size = new Size(92, 26);
			this.label3.TabIndex = 2;
			this.label3.Text = " Version : 1.03.3\r\nBuild :  May 2011 \r\n";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(66, 30);
			this.label2.Name = "label2";
			this.label2.Size = new Size(87, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "by Vahid Heydari";
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.label1.Location = new Point(87, 14);
			this.label1.Name = "label1";
			this.label1.Size = new Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tetris";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(404, 253);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.btn_ok);
			base.MaximizeBox = false;
			this.MaximumSize = new Size(412, 287);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(412, 287);
			base.Name = "About";
			base.SizeGripStyle = SizeGripStyle.Hide;
			this.Text = "About";
			((ISupportInitialize)this.pictureBox1).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}
		public About()
		{
			this.InitializeComponent();
		}
		private void btn_ok_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		private void link_lbl_tjs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://tjs87.wordpress.com");
		}
	}
}
