namespace Loader
{
	// Token: 0x02000019 RID: 25
	public partial class dashboard : global::System.Windows.Forms.Form
	{
		// Token: 0x060000DF RID: 223 RVA: 0x000026FD File Offset: 0x000008FD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00007E78 File Offset: 0x00006078
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Loader.dashboard));
			this.siticonePanel1 = new global::Siticone.UI.WinForms.SiticonePanel();
			this.label2 = new global::System.Windows.Forms.Label();
			this.subscription = new global::System.Windows.Forms.Label();
			this.expiry = new global::System.Windows.Forms.Label();
			this.key = new global::System.Windows.Forms.Label();
			this.fontDialog1 = new global::System.Windows.Forms.FontDialog();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.siticonePanel1.SuspendLayout();
			base.SuspendLayout();
			this.siticonePanel1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.siticonePanel1.BorderColor = global::System.Drawing.Color.White;
			this.siticonePanel1.BorderRadius = 15;
			this.siticonePanel1.BorderThickness = 2;
			this.siticonePanel1.Controls.Add(this.label2);
			this.siticonePanel1.Controls.Add(this.subscription);
			this.siticonePanel1.Controls.Add(this.expiry);
			this.siticonePanel1.Controls.Add(this.key);
			this.siticonePanel1.CustomBorderColor = global::System.Drawing.Color.White;
			this.siticonePanel1.Location = new global::System.Drawing.Point(12, 12);
			this.siticonePanel1.Name = "siticonePanel1";
			this.siticonePanel1.ShadowDecoration.Parent = this.siticonePanel1;
			this.siticonePanel1.Size = new global::System.Drawing.Size(214, 71);
			this.siticonePanel1.TabIndex = 43;
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Bold | global::System.Drawing.FontStyle.Underline, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.White;
			this.label2.Location = new global::System.Drawing.Point(10, 6);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(85, 17);
			this.label2.TabIndex = 47;
			this.label2.Text = "Subscription";
			this.subscription.AutoSize = true;
			this.subscription.Font = new global::System.Drawing.Font("Microsoft YaHei UI", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.subscription.ForeColor = global::System.Drawing.Color.White;
			this.subscription.Location = new global::System.Drawing.Point(10, 49);
			this.subscription.Name = "subscription";
			this.subscription.Size = new global::System.Drawing.Size(59, 16);
			this.subscription.TabIndex = 46;
			this.subscription.Text = "Loading...";
			this.expiry.AutoSize = true;
			this.expiry.Font = new global::System.Drawing.Font("Microsoft YaHei UI", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.expiry.ForeColor = global::System.Drawing.Color.White;
			this.expiry.Location = new global::System.Drawing.Point(10, 36);
			this.expiry.Name = "expiry";
			this.expiry.Size = new global::System.Drawing.Size(59, 16);
			this.expiry.TabIndex = 45;
			this.expiry.Text = "Loading...";
			this.key.AutoSize = true;
			this.key.Font = new global::System.Drawing.Font("Microsoft YaHei UI", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.key.ForeColor = global::System.Drawing.Color.White;
			this.key.Location = new global::System.Drawing.Point(10, 23);
			this.key.Name = "key";
			this.key.Size = new global::System.Drawing.Size(59, 16);
			this.key.TabIndex = 44;
			this.key.Text = "Loading...";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.DarkViolet;
			base.ClientSize = new global::System.Drawing.Size(590, 389);
			base.Controls.Add(this.siticonePanel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "dashboard";
			this.Text = "dashboard";
			base.Load += new global::System.EventHandler(this.dashboard_Load);
			this.siticonePanel1.ResumeLayout(false);
			this.siticonePanel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000074 RID: 116
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000075 RID: 117
		private global::Siticone.UI.WinForms.SiticonePanel siticonePanel1;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.FontDialog fontDialog1;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.Label subscription;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.Label expiry;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.Label key;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.Timer timer1;
	}
}
