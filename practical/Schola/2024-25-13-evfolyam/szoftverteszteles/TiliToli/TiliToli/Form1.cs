using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiliToli
{
	public partial class Form1 : Form
	{
		static Random rnd = new Random();
		int puzzleCount, emptyPuzzleindex;
		int gameSize = 0;
		Size puzzleSize, puzzleImageSize;
		Bitmap bmpImage;
		Puzzle[] puzzles;

		private void btn_Open_Click(object sender, EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					bmpImage = new Bitmap(openFileDialog1.FileName);
					splitContainer1.Panel2.BackgroundImage = bmpImage;
				}
				catch (Exception)
				{

					throw;
				}
			}
		}

		private void btn_Start_Click(object sender, EventArgs e)
		{
			gameSize = (int)numericUpDown1.Value;
			flowLayoutPanel1.Controls.Clear();
			puzzleCount = gameSize * gameSize;
			int n = 0;
			Puzzle p;

			if (bmpImage != null && puzzleCount > 0)
			{
				puzzles = new Puzzle[puzzleCount];
				puzzleImageSize = new Size(bmpImage.Width / gameSize, bmpImage.Height / gameSize);
				puzzleSize = new Size(flowLayoutPanel1.ClientSize.Width / gameSize,
					flowLayoutPanel1.ClientSize.Height / gameSize);
				emptyPuzzleindex = rnd.Next(0, puzzleCount);
				#region Puzzle generálás
				for (int y = 0; y < gameSize; y++)
				{
					for (int x = 0; x < gameSize; x++)
					{
						p = new Puzzle(puzzleSize, n,
							new Bitmap(bmpImage
							.Clone(
								new Rectangle(
									x * puzzleImageSize.Width, y * puzzleImageSize.Height,
									puzzleImageSize.Width, puzzleImageSize.Height
									), bmpImage.PixelFormat)));
						p.Click += P_Click;
						puzzles[n++] = p;
					}
				}
				#endregion
			}
			flowLayoutPanel1.Controls.AddRange(puzzles);
		}

		private void P_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			splitContainer1.Width = this.ClientSize.Width;
		}
	}
	class Puzzle : Button
	{
		public int ID { get; set; }
		public Puzzle(Size _size, int _realPosition, Bitmap _bmp)
		{
			this.AutoSize = false;
			this.FlatStyle = FlatStyle.Flat;
			this.Margin = new Padding(0);
			this.Padding = new Padding(0);
			this.Name = "Btn_" + _realPosition.ToString();
			this.ID = _realPosition;
			this.Size = _size;
			this.TextAlign = ContentAlignment.TopLeft;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			if (_realPosition != -1)
			{
				this.Text = (_realPosition + 1).ToString();
				this.BackgroundImage = _bmp;
			}
		}
	}
}
