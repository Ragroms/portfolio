namespace Курсач
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            авторизацияToolStripMenuItem = new ToolStripMenuItem();
            какАптекарьToolStripMenuItem = new ToolStripMenuItem();
            какТовароведToolStripMenuItem = new ToolStripMenuItem();
            какАдминистраторToolStripMenuItem = new ToolStripMenuItem();
            историяToolStripMenuItem = new ToolStripMenuItem();
            историяПроToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { авторизацияToolStripMenuItem, историяToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(936, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // авторизацияToolStripMenuItem
            // 
            авторизацияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { какАптекарьToolStripMenuItem, какТовароведToolStripMenuItem, какАдминистраторToolStripMenuItem });
            авторизацияToolStripMenuItem.Name = "авторизацияToolStripMenuItem";
            авторизацияToolStripMenuItem.Size = new Size(90, 20);
            авторизацияToolStripMenuItem.Text = "Авторизация";
            авторизацияToolStripMenuItem.Click += авторизацияToolStripMenuItem_Click;
            // 
            // какАптекарьToolStripMenuItem
            // 
            какАптекарьToolStripMenuItem.Name = "какАптекарьToolStripMenuItem";
            какАптекарьToolStripMenuItem.Size = new Size(181, 22);
            какАптекарьToolStripMenuItem.Text = "Как аптекарь";
            какАптекарьToolStripMenuItem.Click += какАптекарьToolStripMenuItem_Click;
            // 
            // какТовароведToolStripMenuItem
            // 
            какТовароведToolStripMenuItem.Name = "какТовароведToolStripMenuItem";
            какТовароведToolStripMenuItem.Size = new Size(181, 22);
            какТовароведToolStripMenuItem.Text = "Как товаровед";
            какТовароведToolStripMenuItem.Click += какТовароведToolStripMenuItem_Click;
            // 
            // какАдминистраторToolStripMenuItem
            // 
            какАдминистраторToolStripMenuItem.Name = "какАдминистраторToolStripMenuItem";
            какАдминистраторToolStripMenuItem.Size = new Size(181, 22);
            какАдминистраторToolStripMenuItem.Text = "Как администратор";
            какАдминистраторToolStripMenuItem.Click += какАдминистраторToolStripMenuItem_Click;
            // 
            // историяToolStripMenuItem
            // 
            историяToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { историяПроToolStripMenuItem });
            историяToolStripMenuItem.Name = "историяToolStripMenuItem";
            историяToolStripMenuItem.Size = new Size(66, 20);
            историяToolStripMenuItem.Text = "История";
            историяToolStripMenuItem.Click += историяToolStripMenuItem_Click;
            // 
            // историяПроToolStripMenuItem
            // 
            историяПроToolStripMenuItem.Name = "историяПроToolStripMenuItem";
            историяПроToolStripMenuItem.Size = new Size(180, 22);
            историяПроToolStripMenuItem.Text = "История товаров";
            историяПроToolStripMenuItem.Click += историяПроToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 565);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "УПЛСА";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem авторизацияToolStripMenuItem;
        private ToolStripMenuItem какАптекарьToolStripMenuItem;
        private ToolStripMenuItem какТовароведToolStripMenuItem;
        private ToolStripMenuItem какАдминистраторToolStripMenuItem;
        private ToolStripMenuItem историяToolStripMenuItem;
        private ToolStripMenuItem историяПроToolStripMenuItem;
    }
}