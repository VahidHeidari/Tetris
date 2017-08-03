using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Tetris
{
	public class Help : Form
	{
		private IContainer components = null;
		private Label label1;
		private Button btn_ok;
		public Help()
		{
			this.InitializeComponent();
		}
		private void btn_ok_Click(object sender, EventArgs e)
		{
			base.Close();
		}
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Help));
			this.label1 = new Label();
			this.btn_ok = new Button();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 178);
			this.label1.Location = new Point(39, 19);
			this.label1.Name = "label1";
			this.label1.Size = new Size(249, 64);
			this.label1.TabIndex = 0;
			this.label1.Text = componentResourceManager.GetString("label1.Text");
			this.btn_ok.Location = new Point(119, 101);
			this.btn_ok.MaximumSize = new Size(75, 23);
			this.btn_ok.MinimumSize = new Size(75, 23);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new Size(75, 23);
			this.btn_ok.TabIndex = 1;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new EventHandler(this.btn_ok_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(312, 136);
			base.Controls.Add(this.btn_ok);
			base.Controls.Add(this.label1);
			base.MaximizeBox = false;
			this.MaximumSize = new Size(320, 170);
			base.MinimizeBox = false;
			this.MinimumSize = new Size(320, 170);
			base.Name = "Help";
			base.SizeGripStyle = SizeGripStyle.Hide;
			this.Text = "Help";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
