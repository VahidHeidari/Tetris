using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
namespace Tetris
{
	public class Form_tetris : Form
	{
		private enum FilledDirections
		{
			Down,
			Left,
			Right
		}
		private const int panel_width = 200;
		private const int panel_height = 300;
		private const int matrix_width = 10;
		private const int matrix_height = 20;
		private const int block_width = 10;
		private const int block_height = 10;
		private const int X_offset = 40;
		private const int Y_offset = 30;
		private IContainer components = null;
		private PictureBox pictureBox1;
		private Timer timer1;
		private PictureBox pct_NextShap;
		private GroupBox groupBox1;
		private Label label4;
		private Label lbl_score;
		private Label lbl_rand;
		private Label label7;
		private Label lbl_tetrominoes;
		private Label lbl_lines;
		private Label label9;
		private Label label8;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem newToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private Label lbl_level;
		private Label label1;
		private ToolStripMenuItem helpToolStripMenuItem1;
		private bool keydown = false;
		private bool gameover = false;
		private bool SpeedUp = false;
		private bool Finished = false;
		private Graphics graph;
		private Graphics Next_graph;
		private Bitmap game;
		private Bitmap Next_game;
		private Brush wall;
		private Brush backgrund;
		private int Score = 0;
		private int Lines = 0;
		private int iTetrominoes = 0;
		private int LevelSpeed = 300;
		private sbyte X = 4;
		private sbyte Y = -4;
		private uint[] game_matrix = new uint[20];
		private Random rand = new Random();
		private Tetrominoes Tetromino = new Tetrominoes();
		private int Line = 19;
		private int Block = 0;
		private bool LineChecking = false;
		private bool LineClearing = false;
		private Keys RightKey = Keys.Right;
		private Keys LeftKey = Keys.Left;
		private Keys DropKey = Keys.Down;
		private Keys SpinKey = Keys.Space;
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
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form_tetris));
			this.timer1 = new Timer(this.components);
			this.groupBox1 = new GroupBox();
			this.lbl_level = new Label();
			this.label1 = new Label();
			this.lbl_tetrominoes = new Label();
			this.lbl_lines = new Label();
			this.label9 = new Label();
			this.label8 = new Label();
			this.lbl_score = new Label();
			this.label4 = new Label();
			this.lbl_rand = new Label();
			this.label7 = new Label();
			this.menuStrip1 = new MenuStrip();
			this.fileToolStripMenuItem = new ToolStripMenuItem();
			this.newToolStripMenuItem = new ToolStripMenuItem();
			this.exitToolStripMenuItem = new ToolStripMenuItem();
			this.helpToolStripMenuItem = new ToolStripMenuItem();
			this.helpToolStripMenuItem1 = new ToolStripMenuItem();
			this.aboutToolStripMenuItem = new ToolStripMenuItem();
			this.pct_NextShap = new PictureBox();
			this.pictureBox1 = new PictureBox();
			this.groupBox1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((ISupportInitialize)this.pct_NextShap).BeginInit();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.timer1.Enabled = true;
			this.timer1.Interval = 300;
			this.timer1.Tick += new EventHandler(this.timer1_Tick);
			this.groupBox1.BackColor = Color.Yellow;
			this.groupBox1.Controls.Add(this.lbl_level);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.lbl_tetrominoes);
			this.groupBox1.Controls.Add(this.lbl_lines);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.lbl_score);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.FlatStyle = FlatStyle.Flat;
			this.groupBox1.ForeColor = Color.Black;
			this.groupBox1.Location = new Point(218, 153);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(169, 201);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Console";
			this.lbl_level.AutoSize = true;
			this.lbl_level.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.lbl_level.Location = new Point(89, 147);
			this.lbl_level.Name = "lbl_level";
			this.lbl_level.Size = new Size(0, 13);
			this.lbl_level.TabIndex = 21;
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.label1.Location = new Point(6, 147);
			this.label1.Name = "label1";
			this.label1.Size = new Size(46, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Level :";
			this.lbl_tetrominoes.AutoSize = true;
			this.lbl_tetrominoes.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.lbl_tetrominoes.Location = new Point(89, 114);
			this.lbl_tetrominoes.Name = "lbl_tetrominoes";
			this.lbl_tetrominoes.Size = new Size(0, 13);
			this.lbl_tetrominoes.TabIndex = 18;
			this.lbl_lines.AutoSize = true;
			this.lbl_lines.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.lbl_lines.Location = new Point(89, 101);
			this.lbl_lines.Name = "lbl_lines";
			this.lbl_lines.Size = new Size(0, 13);
			this.lbl_lines.TabIndex = 17;
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.label9.Location = new Point(5, 114);
			this.label9.Name = "label9";
			this.label9.Size = new Size(84, 13);
			this.label9.TabIndex = 16;
			this.label9.Text = "Tetrominoes :";
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.label8.Location = new Point(5, 101);
			this.label8.Name = "label8";
			this.label8.Size = new Size(45, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "Lines :";
			this.lbl_score.AutoSize = true;
			this.lbl_score.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.lbl_score.Location = new Point(89, 46);
			this.lbl_score.Name = "lbl_score";
			this.lbl_score.Size = new Size(0, 13);
			this.lbl_score.TabIndex = 8;
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.label4.Location = new Point(6, 46);
			this.label4.Name = "label4";
			this.label4.Size = new Size(48, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Score :";
			this.lbl_rand.AutoSize = true;
			this.lbl_rand.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.lbl_rand.Location = new Point(323, 49);
			this.lbl_rand.Name = "lbl_rand";
			this.lbl_rand.Size = new Size(0, 13);
			this.lbl_rand.TabIndex = 13;
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 178);
			this.label7.Location = new Point(264, 49);
			this.label7.Name = "label7";
			this.label7.Size = new Size(41, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Next :";
			this.menuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.fileToolStripMenuItem,
				this.helpToolStripMenuItem
			});
			this.menuStrip1.Location = new Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new Size(392, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Click += new EventHandler(this.menuStrip1_Click);
			this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.newToolStripMenuItem,
				this.exitToolStripMenuItem
			});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new Size(95, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new EventHandler(this.newToolStripMenuItem_Click);
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new Size(95, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
			this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.helpToolStripMenuItem1,
				this.aboutToolStripMenuItem
			});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new Size(40, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
			this.helpToolStripMenuItem1.Size = new Size(103, 22);
			this.helpToolStripMenuItem1.Text = "&Help";
			this.helpToolStripMenuItem1.Click += new EventHandler(this.helpToolStripMenuItem1_Click);
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new Size(103, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
			this.pct_NextShap.BorderStyle = BorderStyle.Fixed3D;
			this.pct_NextShap.Location = new Point(264, 65);
			this.pct_NextShap.Name = "pct_NextShap";
			this.pct_NextShap.Size = new Size(70, 70);
			this.pct_NextShap.TabIndex = 1;
			this.pct_NextShap.TabStop = false;
			this.pictureBox1.BackgroundImageLayout = ImageLayout.None;
			this.pictureBox1.BorderStyle = BorderStyle.Fixed3D;
			this.pictureBox1.Location = new Point(12, 54);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(200, 300);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.Yellow;
			base.ClientSize = new Size(392, 366);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.pct_NextShap);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.menuStrip1);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.lbl_rand);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip1;
			base.MaximizeBox = false;
			this.MaximumSize = new Size(400, 400);
			this.MinimumSize = new Size(400, 400);
			base.Name = "Form_tetris";
			base.SizeGripStyle = SizeGripStyle.Hide;
			this.Text = "lgg";
			base.Activated += new EventHandler(this.Form_tetris_Activated);
			base.Deactivate += new EventHandler(this.Form_tetris_Deactivate);
			base.Paint += new PaintEventHandler(this.Form_tetris_Paint);
			base.KeyDown += new KeyEventHandler(this.Form_tetris_KeyDown);
			base.KeyUp += new KeyEventHandler(this.Form_tetris_KeyUp);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((ISupportInitialize)this.pct_NextShap).EndInit();
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		public Form_tetris()
		{
			this.InitializeComponent();
			this.init_game();
		}
		private void init_game()
		{
			this.Score = 0;
			this.LevelSpeed = 300;
			this.Score = (this.Lines = (this.iTetrominoes = 0));
			this.X = 4;
			this.Y = -4;
			this.Line = 19;
			this.Block = 0;
			this.LineChecking = false;
			this.LineClearing = false;
			this.gameover = false;
			this.Finished = false;
			this.SpeedUp = false;
			this.keydown = false;
			this.game = new Bitmap(200, 300, PixelFormat.Format24bppRgb);
			this.Next_game = new Bitmap(this.pct_NextShap.Width, this.pct_NextShap.Height, PixelFormat.Format24bppRgb);
			this.graph = Graphics.FromImage(this.game);
			this.Next_graph = Graphics.FromImage(this.Next_game);
			this.wall = Brushes.Green;
			this.backgrund = Brushes.Black;
			for (int i = 0; i < 20; i++)
			{
				this.game_matrix[i] = 0u;
			}
			this.Tetromino.Next();
			this.Tetromino.Next();
			this.iTetrominoes++;
			this.timer1.Interval = this.LevelSpeed;
			this.timer1.Enabled = true;
			this.draw_matrix();
			this.Console();
		}
		private void draw_matrix()
		{
			this.graph.FillRectangle(this.backgrund, 0, 0, 200, 300);
			for (int i = 0; i <= 20; i++)
			{
				this.graph.FillEllipse(this.wall, 28, i * 12 + 30, 10, 10);
				this.graph.FillEllipse(this.wall, 160, i * 12 + 30, 10, 10);
			}
			for (int i = 0; i < 10; i++)
			{
				this.graph.FillEllipse(this.wall, i * 12 + 40, 270, 10, 10);
			}
			for (int i = 19; i >= 0; i--)
			{
				for (int j = 0; j < 10; j++)
				{
					if (((ulong)this.game_matrix[i] & (ulong)(1L << (j & 31))) != 0uL)
					{
						this.graph.FillRectangle(Brushes.Blue, j * 12 + 40, i * 12 + 30, 10, 10);
						this.graph.DrawRectangle(Pens.PaleGreen, j * 12 + 40, i * 12 + 30, 10, 10);
					}
				}
			}
			if (this.gameover)
			{
				this.graph.DrawString("Game\nOver", new Font("lucida console", 30f, FontStyle.Bold), Brushes.White, 40f, 90f);
			}
			if (this.Finished)
			{
				this.graph.DrawString("You\nWin", new Font("lucida console", 30f, FontStyle.Bold), Brushes.White, 60f, 90f);
			}
			this.Next_graph.FillRectangle(Brushes.Teal, 0, 0, this.pct_NextShap.Width, this.pct_NextShap.Height);
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (((ulong)this.Tetromino.Next_Shape[i + 4 * this.Tetromino.NextIndex] & (ulong)(1L << (j & 31))) != 0uL)
					{
						this.Next_graph.FillRectangle(Brushes.Blue, j * 12 + 20, i * 12 + 10, 10, 10);
						this.Next_graph.DrawRectangle(Pens.PaleGreen, j * 12 + 20, i * 12 + 10, 10, 10);
					}
				}
			}
			this.pictureBox1.Image = this.game;
			this.pct_NextShap.Image = this.Next_game;
		}
		private void StepDown()
		{
			for (int i = 0; i < 4; i++)
			{
				if ((int)this.Y + i >= 0)
				{
					this.game_matrix[(int)this.Y + i] &= ~(this.Tetromino.Shape[i + this.Tetromino.Index * 4] << (int)this.X);
				}
			}
			if (this.Y + 4 >= 20 || this.Filled(Form_tetris.FilledDirections.Down))
			{
				for (int i = 0; i < 4; i++)
				{
					if ((int)this.Y + i >= 0)
					{
						this.game_matrix[(int)this.Y + i] |= this.Tetromino.Shape[i + this.Tetromino.Index * 4] << (int)this.X;
					}
				}
				this.LineChecking = true;
			}
			else
			{
				this.Y += 1;
				for (int i = 0; i < 4; i++)
				{
					if ((int)this.Y + i >= 0)
					{
						this.game_matrix[(int)this.Y + i] |= this.Tetromino.Shape[i + this.Tetromino.Index * 4] << (int)this.X;
					}
				}
			}
		}
		private void CheckGameOver()
		{
			if (this.game_matrix[0] != 0u)
			{
				this.timer1.Enabled = false;
				this.gameover = true;
			}
		}
		private void CheckLine()
		{
			for (int i = 19; i >= 0; i--)
			{
				if (this.game_matrix[i] == 1023u)
				{
					for (int j = i; j > 0; j--)
					{
						this.game_matrix[j] = this.game_matrix[j - 1];
					}
					i++;
					this.Score += 10;
					this.Lines++;
					if (this.Lines % 10 == 0)
					{
						this.LevelSpeed -= 10;
						this.timer1.Interval = this.LevelSpeed;
					}
				}
			}
		}
		private bool Filled(Form_tetris.FilledDirections direction)
		{
			bool result = false;
			for (int i = 0; i < 4; i++)
			{
				if ((int)this.Y + i >= 0 && (this.game_matrix[(int)(this.Y + 1) + i] & this.Tetromino.Shape[this.Tetromino.Index * 4 + i] << (int)this.X) != 0u)
				{
					result = true;
				}
			}
			return result;
		}
		private bool FilledRight()
		{
			bool flag = false;
			for (int i = 0; i < 4; i++)
			{
				if ((int)this.Y + i >= 0 && (this.game_matrix[(int)this.Y + i] & this.Tetromino.Shape[this.Tetromino.Index * 4 + i] << (int)(this.X + 1)) != 0u)
				{
					flag = true;
				}
			}
			return !flag;
		}
		private bool FilledLeft()
		{
			bool flag = false;
			for (int i = 0; i < 4; i++)
			{
				if ((int)this.Y + i >= 0 && (this.game_matrix[(int)this.Y + i] & this.Tetromino.Shape[this.Tetromino.Index * 4 + i] << (int)(this.X - 1)) != 0u)
				{
					flag = true;
				}
			}
			return !flag;
		}
		private bool FilledRotate()
		{
			bool flag = false;
			int num = this.Tetromino.Index;
			num = (num + 1) % this.Tetromino.Len;
			for (int i = 0; i < 4; i++)
			{
				if ((int)this.Y + i >= 0 && (this.game_matrix[(int)this.Y + i] & this.Tetromino.Shape[num * 4 + i] << (int)this.X) != 0u)
				{
					flag = true;
				}
			}
			if ((this.Tetromino.Shape[num * 4] << (int)this.X & 62464u) != 0u || (this.Tetromino.Shape[num * 4 + 1] << (int)this.X & 62464u) != 0u || (this.Tetromino.Shape[num * 4 + 2] << (int)this.X & 62464u) != 0u || (this.Tetromino.Shape[num * 4 + 3] << (int)this.X & 62464u) != 0u)
			{
				flag = true;
			}
			return !flag;
		}
		private void CheckLines()
		{
			if (!this.LineClearing)
			{
				while (this.Line >= 0)
				{
					if (this.game_matrix[this.Line] == 1023u)
					{
						this.LineClearing = true;
						break;
					}
					this.Line--;
				}
			}
			if (this.LineClearing)
			{
				this.timer1.Interval = 1;
				if (this.Block < 10)
				{
					this.game_matrix[this.Line] &= ~(1u << this.Block);
					this.Block++;
				}
				else
				{
					this.Block = 0;
					this.LineClearing = false;
					for (int i = this.Line; i > 0; i--)
					{
						this.game_matrix[i] = this.game_matrix[i - 1];
					}
					this.Score += 10;
					this.Lines++;
					if (this.Lines % 10 == 0)
					{
						this.LevelSpeed -= 10;
						this.timer1.Interval = this.LevelSpeed;
					}
				}
			}
			if (this.Line < 0)
			{
				this.LineChecking = false;
				this.LineClearing = false;
				this.Line = 19;
				this.timer1.Interval = this.LevelSpeed;
				this.CheckGameOver();
				this.CheckFinished();
				this.Tetromino.Next();
				this.X = 4;
				this.Y = -4;
				this.iTetrominoes++;
			}
			this.draw_matrix();
		}
		private void CheckFinished()
		{
			if (this.Lines == 150)
			{
				this.timer1.Enabled = false;
				this.Finished = true;
			}
		}
		private void Play()
		{
			this.StepDown();
			this.draw_matrix();
		}
		private void Console()
		{
			this.lbl_score.Text = this.Score.ToString();
			this.lbl_lines.Text = this.Lines.ToString();
			this.lbl_tetrominoes.Text = this.iTetrominoes.ToString();
			this.lbl_rand.Text = ((Tetrominoes.Shapes)this.Tetromino.rand).ToString();
			this.lbl_level.Text = (this.Lines / 10 + 1).ToString();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (this.LineChecking)
			{
				this.CheckLines();
			}
			else
			{
				this.Play();
			}
			this.Console();
		}
		private void Form_tetris_KeyDown(object sender, KeyEventArgs e)
		{
			if (!this.keydown && !this.LineChecking)
			{
				for (int i = 0; i < 4; i++)
				{
					if ((int)this.Y + i >= 0)
					{
						this.game_matrix[(int)this.Y + i] &= ~(this.Tetromino.Shape[i + this.Tetromino.Index * 4] << (int)this.X);
					}
				}
				if (e.KeyCode == this.LeftKey && this.X > 0)
				{
					if (this.FilledLeft())
					{
						this.X -= 1;
					}
				}
				if (e.KeyCode == this.RightKey)
				{
					if ((this.Tetromino.Shape[this.Tetromino.Index * 4] << (int)(this.X + 1) & 1024u) == 0u && (this.Tetromino.Shape[this.Tetromino.Index * 4 + 1] << (int)(this.X + 1) & 1024u) == 0u && (this.Tetromino.Shape[this.Tetromino.Index * 4 + 2] << (int)(this.X + 1) & 1024u) == 0u && (this.Tetromino.Shape[this.Tetromino.Index * 4 + 3] << (int)(this.X + 1) & 1024u) == 0u && this.FilledRight())
					{
						this.X += 1;
					}
				}
				if (e.KeyCode == this.SpinKey)
				{
					if (this.FilledRotate())
					{
						this.Tetromino.Rotate();
					}
				}
				if (e.KeyCode == this.DropKey)
				{
					this.SpeedUp = true;
					this.timer1.Interval = 1;
				}
				this.keydown = true;
				for (int i = 0; i < 4; i++)
				{
					if ((int)this.Y + i >= 0)
					{
						this.game_matrix[(int)this.Y + i] |= this.Tetromino.Shape[i + this.Tetromino.Index * 4] << (int)this.X;
					}
				}
				this.draw_matrix();
			}
		}
		private void Form_tetris_KeyUp(object sender, KeyEventArgs e)
		{
			if (this.SpeedUp)
			{
				if (!this.LineChecking)
				{
					this.timer1.Interval = this.LevelSpeed;
				}
				this.SpeedUp = false;
			}
			this.keydown = false;
		}
		private void Form_tetris_Paint(object sender, PaintEventArgs e)
		{
			this.draw_matrix();
		}
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}
		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.init_game();
		}
		private void menuStrip1_Click(object sender, EventArgs e)
		{
			if (this.timer1.Enabled)
			{
				this.timer1.Enabled = false;
			}
			else
			{
				if (!this.gameover && !this.Finished)
				{
					this.timer1.Enabled = true;
				}
			}
		}
		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About about = new About();
			about.ShowDialog(this);
			if (!this.gameover && !this.Finished)
			{
				this.timer1.Enabled = true;
			}
		}
		private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Help help = new Help();
			help.ShowDialog(this);
			if (!this.gameover && !this.Finished)
			{
				this.timer1.Enabled = true;
			}
		}
		private void Form_tetris_Deactivate(object sender, EventArgs e)
		{
			this.timer1.Enabled = false;
		}
		private void Form_tetris_Activated(object sender, EventArgs e)
		{
			if (!this.gameover && !this.Finished)
			{
				this.timer1.Enabled = true;
			}
		}
	}
}
