using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tatelier.Splash
{
	public partial class SplashWindow : Form
	{
		public SplashWindow(string version)
		{
			InitializeComponent();

			this.ClientSize = new Size(320, 256);

			try
			{
				Bitmap bitmap = new Bitmap("Resources\\Theme\\System\\Init\\Splash.png");
				pictureBox1.Image = bitmap;
				label1.Parent = pictureBox1;
				label1.Text = $"v{version}";
			}
			catch
			{
				// 何もしない
			}
		}
	}
}
