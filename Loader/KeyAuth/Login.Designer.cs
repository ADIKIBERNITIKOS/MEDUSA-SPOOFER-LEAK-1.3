namespace KeyAuth
{
	// Token: 0x02000016 RID: 22
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x060000D0 RID: 208 RVA: 0x00002643 File Offset: 0x00000843
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00007080 File Offset: 0x00005280
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::Siticone.UI.AnimatorNS.Animation animation = new global::Siticone.UI.AnimatorNS.Animation();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::KeyAuth.Login));
			this.siticoneDragControl1 = new global::Siticone.UI.WinForms.SiticoneDragControl(this.components);
			this.siticoneControlBox1 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.siticoneControlBox2 = new global::Siticone.UI.WinForms.SiticoneControlBox();
			this.siticoneTransition1 = new global::Siticone.UI.WinForms.SiticoneTransition();
			this.label1 = new global::System.Windows.Forms.Label();
			this.LoginBtn = new global::Siticone.UI.WinForms.SiticoneRoundedButton();
			this.allahu = new global::Siticone.UI.WinForms.SiticoneRoundedTextBox();
			this.akbar = new global::Siticone.UI.WinForms.SiticoneRoundedTextBox();
			this.siticonePanel1 = new global::Siticone.UI.WinForms.SiticonePanel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.siticoneShadowForm = new global::Siticone.UI.WinForms.SiticoneShadowForm(this.components);
			this.siticonePanel1.SuspendLayout();
			base.SuspendLayout();
			this.siticoneDragControl1.TargetControl = this;
			this.siticoneControlBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.siticoneControlBox1.BorderRadius = 10;
			this.siticoneTransition1.SetDecoration(this.siticoneControlBox1, 0);
			this.siticoneControlBox1.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.siticoneControlBox1.HoveredState.FillColor = global::System.Drawing.Color.FromArgb(232, 17, 35);
			this.siticoneControlBox1.HoveredState.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.HoveredState.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox1.Location = new global::System.Drawing.Point(252, 4);
			this.siticoneControlBox1.Name = "siticoneControlBox1";
			this.siticoneControlBox1.ShadowDecoration.Parent = this.siticoneControlBox1;
			this.siticoneControlBox1.Size = new global::System.Drawing.Size(45, 29);
			this.siticoneControlBox1.TabIndex = 1;
			this.siticoneControlBox1.Click += new global::System.EventHandler(this.siticoneControlBox1_Click);
			this.siticoneControlBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.siticoneControlBox2.BorderRadius = 10;
			this.siticoneControlBox2.ControlBoxType = 0;
			this.siticoneTransition1.SetDecoration(this.siticoneControlBox2, 0);
			this.siticoneControlBox2.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.siticoneControlBox2.HoveredState.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.IconColor = global::System.Drawing.Color.White;
			this.siticoneControlBox2.Location = new global::System.Drawing.Point(205, 4);
			this.siticoneControlBox2.Name = "siticoneControlBox2";
			this.siticoneControlBox2.ShadowDecoration.Parent = this.siticoneControlBox2;
			this.siticoneControlBox2.Size = new global::System.Drawing.Size(45, 29);
			this.siticoneControlBox2.TabIndex = 2;
			this.siticoneTransition1.AnimationType = 1;
			this.siticoneTransition1.Cursor = null;
			animation.AnimateOnlyDifferences = true;
			animation.BlindCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.BlindCoeff");
			animation.LeafCoeff = 0f;
			animation.MaxTime = 1f;
			animation.MinTime = 0f;
			animation.MosaicCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.MosaicCoeff");
			animation.MosaicShift = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.MosaicShift");
			animation.MosaicSize = 0;
			animation.Padding = new global::System.Windows.Forms.Padding(50);
			animation.RotateCoeff = 1f;
			animation.RotateLimit = 0f;
			animation.ScaleCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.ScaleCoeff");
			animation.SlideCoeff = (global::System.Drawing.PointF)componentResourceManager.GetObject("animation1.SlideCoeff");
			animation.TimeCoeff = 0f;
			animation.TransparencyCoeff = 1f;
			this.siticoneTransition1.DefaultAnimation = animation;
			this.label1.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label1, 0);
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Light", 10f);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(-1, 136);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(0, 19);
			this.label1.TabIndex = 22;
			this.LoginBtn.BackColor = global::System.Drawing.Color.Transparent;
			this.LoginBtn.BorderThickness = 1;
			this.LoginBtn.CausesValidation = false;
			this.LoginBtn.CheckedState.Parent = this.LoginBtn;
			this.LoginBtn.CustomImages.Parent = this.LoginBtn;
			this.siticoneTransition1.SetDecoration(this.LoginBtn, 0);
			this.LoginBtn.FillColor = global::System.Drawing.Color.White;
			this.LoginBtn.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.LoginBtn.ForeColor = global::System.Drawing.Color.Black;
			this.LoginBtn.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(213, 218, 223);
			this.LoginBtn.HoveredState.Parent = this.LoginBtn;
			this.LoginBtn.Location = new global::System.Drawing.Point(84, 129);
			this.LoginBtn.Name = "LoginBtn";
			this.LoginBtn.ShadowDecoration.Parent = this.LoginBtn;
			this.LoginBtn.Size = new global::System.Drawing.Size(132, 27);
			this.LoginBtn.TabIndex = 26;
			this.LoginBtn.Text = "Login";
			this.LoginBtn.Click += new global::System.EventHandler(this.LoginBtn_Click);
			this.allahu.AllowDrop = true;
			this.allahu.BorderColor = global::System.Drawing.Color.Black;
			this.allahu.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.siticoneTransition1.SetDecoration(this.allahu, 0);
			this.allahu.DefaultText = "Username";
			this.allahu.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.allahu.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.allahu.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.allahu.DisabledState.Parent = this.allahu;
			this.allahu.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.allahu.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.allahu.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.allahu.FocusedState.Parent = this.allahu;
			this.allahu.ForeColor = global::System.Drawing.Color.White;
			this.allahu.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.allahu.HoveredState.Parent = this.allahu;
			this.allahu.Location = new global::System.Drawing.Point(51, 54);
			this.allahu.Margin = new global::System.Windows.Forms.Padding(4);
			this.allahu.Name = "allahu";
			this.allahu.PasswordChar = '\0';
			this.allahu.PlaceholderText = "";
			this.allahu.SelectedText = "";
			this.allahu.ShadowDecoration.Parent = this.allahu;
			this.allahu.Size = new global::System.Drawing.Size(196, 30);
			this.allahu.TabIndex = 33;
			this.allahu.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.allahu.Enter += new global::System.EventHandler(this.username_Enter);
			this.akbar.AllowDrop = true;
			this.akbar.BorderColor = global::System.Drawing.Color.Black;
			this.akbar.Cursor = global::System.Windows.Forms.Cursors.IBeam;
			this.siticoneTransition1.SetDecoration(this.akbar, 0);
			this.akbar.DefaultText = "Password";
			this.akbar.DisabledState.BorderColor = global::System.Drawing.Color.FromArgb(208, 208, 208);
			this.akbar.DisabledState.FillColor = global::System.Drawing.Color.FromArgb(226, 226, 226);
			this.akbar.DisabledState.ForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.akbar.DisabledState.Parent = this.akbar;
			this.akbar.DisabledState.PlaceholderForeColor = global::System.Drawing.Color.FromArgb(138, 138, 138);
			this.akbar.FillColor = global::System.Drawing.Color.FromArgb(35, 39, 42);
			this.akbar.FocusedState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.akbar.FocusedState.Parent = this.akbar;
			this.akbar.ForeColor = global::System.Drawing.Color.White;
			this.akbar.HoveredState.BorderColor = global::System.Drawing.Color.FromArgb(94, 148, 255);
			this.akbar.HoveredState.Parent = this.akbar;
			this.akbar.Location = new global::System.Drawing.Point(51, 92);
			this.akbar.Margin = new global::System.Windows.Forms.Padding(4);
			this.akbar.Name = "akbar";
			this.akbar.PasswordChar = '\0';
			this.akbar.PlaceholderText = "";
			this.akbar.SelectedText = "";
			this.akbar.ShadowDecoration.Parent = this.akbar;
			this.akbar.Size = new global::System.Drawing.Size(196, 30);
			this.akbar.TabIndex = 34;
			this.akbar.TextAlign = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.akbar.UseSystemPasswordChar = true;
			this.akbar.Enter += new global::System.EventHandler(this.password_Enter);
			this.siticonePanel1.BackColor = global::System.Drawing.Color.Purple;
			this.siticonePanel1.Controls.Add(this.label2);
			this.siticonePanel1.Controls.Add(this.siticoneControlBox1);
			this.siticonePanel1.Controls.Add(this.siticoneControlBox2);
			this.siticoneTransition1.SetDecoration(this.siticonePanel1, 0);
			this.siticonePanel1.Location = new global::System.Drawing.Point(0, -2);
			this.siticonePanel1.Name = "siticonePanel1";
			this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
			this.siticonePanel1.Size = new global::System.Drawing.Size(311, 33);
			this.siticonePanel1.TabIndex = 35;
			this.siticonePanel1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.label2.AutoSize = true;
			this.siticoneTransition1.SetDecoration(this.label2, 0);
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 11.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(3, 7);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(103, 20);
			this.label2.TabIndex = 36;
			this.label2.Text = "Login System";
			this.label2.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = global::System.Windows.Forms.AutoValidate.Disable;
			this.BackColor = global::System.Drawing.Color.FromArgb(192, 0, 192);
			base.ClientSize = new global::System.Drawing.Size(300, 177);
			base.Controls.Add(this.siticonePanel1);
			base.Controls.Add(this.akbar);
			base.Controls.Add(this.allahu);
			base.Controls.Add(this.LoginBtn);
			base.Controls.Add(this.label1);
			this.siticoneTransition1.SetDecoration(this, 1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Login";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Loader";
			base.TransparencyKey = global::System.Drawing.Color.Maroon;
			base.Load += new global::System.EventHandler(this.Login_Load);
			this.siticonePanel1.ResumeLayout(false);
			this.siticonePanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000066 RID: 102
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000067 RID: 103
		private global::Siticone.UI.WinForms.SiticoneDragControl siticoneDragControl1;

		// Token: 0x04000068 RID: 104
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox1;

		// Token: 0x04000069 RID: 105
		private global::Siticone.UI.WinForms.SiticoneControlBox siticoneControlBox2;

		// Token: 0x0400006A RID: 106
		private global::Siticone.UI.WinForms.SiticoneTransition siticoneTransition1;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400006C RID: 108
		private global::Siticone.UI.WinForms.SiticoneRoundedButton LoginBtn;

		// Token: 0x0400006D RID: 109
		private global::Siticone.UI.WinForms.SiticoneShadowForm siticoneShadowForm;

		// Token: 0x0400006E RID: 110
		private global::Siticone.UI.WinForms.SiticoneRoundedTextBox akbar;

		// Token: 0x0400006F RID: 111
		private global::Siticone.UI.WinForms.SiticoneRoundedTextBox allahu;

		// Token: 0x04000070 RID: 112
		private global::Siticone.UI.WinForms.SiticonePanel siticonePanel1;

		// Token: 0x04000071 RID: 113
		private global::System.Windows.Forms.Label label2;
	}
}
