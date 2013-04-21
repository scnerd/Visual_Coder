namespace Visual_Coder
{
    partial class Form1
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
            this.spltMainContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.clstAssemblies = new System.Windows.Forms.CheckedListBox();
            this.lstClasses = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSelectionPicker = new System.Windows.Forms.ComboBox();
            this.lstMethods = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tblAssemblies = new System.Windows.Forms.TableLayoutPanel();
            this.txtClassSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saver = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.spltMainContainer)).BeginInit();
            this.spltMainContainer.Panel1.SuspendLayout();
            this.spltMainContainer.Panel2.SuspendLayout();
            this.spltMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tblAssemblies.SuspendLayout();
            this.SuspendLayout();
            // 
            // spltMainContainer
            // 
            this.spltMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMainContainer.Location = new System.Drawing.Point(0, 0);
            this.spltMainContainer.Name = "spltMainContainer";
            // 
            // spltMainContainer.Panel1
            // 
            this.spltMainContainer.Panel1.Controls.Add(this.splitContainer2);
            this.spltMainContainer.Panel1.Controls.Add(this.statusStrip1);
            // 
            // spltMainContainer.Panel2
            // 
            this.spltMainContainer.Panel2.Controls.Add(this.vScrollBar1);
            this.spltMainContainer.Panel2.Controls.Add(this.hScrollBar1);
            this.spltMainContainer.Panel2.Controls.Add(this.statusStrip2);
            this.spltMainContainer.Panel2.Controls.Add(this.menuStrip1);
            this.spltMainContainer.Panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingBoard_Click);
            this.spltMainContainer.Size = new System.Drawing.Size(1091, 576);
            this.spltMainContainer.SplitterDistance = 321;
            this.spltMainContainer.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tblAssemblies);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(321, 554);
            this.splitContainer2.SplitterDistance = 147;
            this.splitContainer2.TabIndex = 1;
            // 
            // clstAssemblies
            // 
            this.clstAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clstAssemblies.FormattingEnabled = true;
            this.clstAssemblies.Location = new System.Drawing.Point(3, 3);
            this.clstAssemblies.Name = "clstAssemblies";
            this.clstAssemblies.Size = new System.Drawing.Size(141, 117);
            this.clstAssemblies.TabIndex = 0;
            this.clstAssemblies.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.AssemblySelected);
            // 
            // lstClasses
            // 
            this.lstClasses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClasses.Location = new System.Drawing.Point(3, 126);
            this.lstClasses.MultiSelect = false;
            this.lstClasses.Name = "lstClasses";
            this.lstClasses.Size = new System.Drawing.Size(141, 358);
            this.lstClasses.TabIndex = 0;
            this.lstClasses.UseCompatibleStateImageBehavior = false;
            this.lstClasses.View = System.Windows.Forms.View.List;
            this.lstClasses.SelectedIndexChanged += new System.EventHandler(this.ClassSelected);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cmbSelectionPicker, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lstMethods, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.512635F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.48737F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(170, 554);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmbSelectionPicker
            // 
            this.cmbSelectionPicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSelectionPicker.FormattingEnabled = true;
            this.cmbSelectionPicker.Items.AddRange(new object[] {
            "Methods",
            "Constants",
            "Operators"});
            this.cmbSelectionPicker.Location = new System.Drawing.Point(3, 3);
            this.cmbSelectionPicker.Name = "cmbSelectionPicker";
            this.cmbSelectionPicker.Size = new System.Drawing.Size(164, 21);
            this.cmbSelectionPicker.TabIndex = 3;
            this.cmbSelectionPicker.SelectedIndexChanged += new System.EventHandler(this.cmbSelectionPicker_SelectedIndexChanged);
            // 
            // lstMethods
            // 
            this.lstMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMethods.Location = new System.Drawing.Point(3, 27);
            this.lstMethods.MultiSelect = false;
            this.lstMethods.Name = "lstMethods";
            this.lstMethods.Size = new System.Drawing.Size(164, 524);
            this.lstMethods.TabIndex = 1;
            this.lstMethods.UseCompatibleStateImageBehavior = false;
            this.lstMethods.View = System.Windows.Forms.View.List;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(321, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(749, 24);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 513);
            this.vScrollBar1.TabIndex = 4;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 537);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(766, 17);
            this.hScrollBar1.TabIndex = 3;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Location = new System.Drawing.Point(0, 554);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(766, 22);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.compileToolStripMenuItem,
            this.previewCodeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // compileToolStripMenuItem
            // 
            this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
            this.compileToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.compileToolStripMenuItem.Text = "Compile";
            this.compileToolStripMenuItem.Click += new System.EventHandler(this.Compile_Clicked);
            // 
            // tblAssemblies
            // 
            this.tblAssemblies.ColumnCount = 1;
            this.tblAssemblies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAssemblies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblAssemblies.Controls.Add(this.btnSearch, 0, 3);
            this.tblAssemblies.Controls.Add(this.lstClasses, 0, 1);
            this.tblAssemblies.Controls.Add(this.clstAssemblies, 0, 0);
            this.tblAssemblies.Controls.Add(this.txtClassSearch, 0, 2);
            this.tblAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAssemblies.Location = new System.Drawing.Point(0, 0);
            this.tblAssemblies.Name = "tblAssemblies";
            this.tblAssemblies.RowCount = 4;
            this.tblAssemblies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.32833F));
            this.tblAssemblies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.67167F));
            this.tblAssemblies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tblAssemblies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tblAssemblies.Size = new System.Drawing.Size(147, 554);
            this.tblAssemblies.TabIndex = 0;
            // 
            // txtClassSearch
            // 
            this.txtClassSearch.Location = new System.Drawing.Point(3, 490);
            this.txtClassSearch.Name = "txtClassSearch";
            this.txtClassSearch.Size = new System.Drawing.Size(141, 20);
            this.txtClassSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Location = new System.Drawing.Point(3, 515);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(141, 36);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search Class";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // previewCodeToolStripMenuItem
            // 
            this.previewCodeToolStripMenuItem.Name = "previewCodeToolStripMenuItem";
            this.previewCodeToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.previewCodeToolStripMenuItem.Text = "Preview Code";
            this.previewCodeToolStripMenuItem.Click += new System.EventHandler(this.previewCodeToolStripMenuItem_Click);
            // 
            // saver
            // 
            this.saver.DefaultExt = "cs";
            this.saver.Filter = "C# Code File (*.cs) | cs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 576);
            this.Controls.Add(this.spltMainContainer);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.spltMainContainer.Panel1.ResumeLayout(false);
            this.spltMainContainer.Panel1.PerformLayout();
            this.spltMainContainer.Panel2.ResumeLayout(false);
            this.spltMainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltMainContainer)).EndInit();
            this.spltMainContainer.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tblAssemblies.ResumeLayout(false);
            this.tblAssemblies.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spltMainContainer;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView lstClasses;
        private System.Windows.Forms.ListView lstMethods;
        private System.Windows.Forms.CheckedListBox clstAssemblies;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbSelectionPicker;
        private System.Windows.Forms.TableLayoutPanel tblAssemblies;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtClassSearch;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewCodeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saver;
    }
}

