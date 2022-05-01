
namespace Tatelier.Splash
{
	partial class SplashWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(320, 256);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.ForeColor = System.Drawing.Color.Silver;
			this.label1.Location = new System.Drawing.Point(282, 241);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "v0.4.0";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// SplashWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(320, 256);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SplashWindow";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SplashWindow";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
	}
}