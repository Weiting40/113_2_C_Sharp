namespace Tutorial_4_4
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            distancetextbox = new TextBox();
            gastextbox = new TextBox();
            averagelabel = new Label();
            calculatebutton = new Button();
            exitbutton = new Button();
            loglistbox = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(101, 97);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(204, 35);
            label1.TabIndex = 0;
            label1.Text = "輸入行駛里程數";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(101, 178);
            label2.Margin = new Padding(7, 0, 7, 0);
            label2.Name = "label2";
            label2.Size = new Size(204, 35);
            label2.TabIndex = 1;
            label2.Text = "消耗油量公升數";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label3.Location = new Point(101, 276);
            label3.Margin = new Padding(7, 0, 7, 0);
            label3.Name = "label3";
            label3.Size = new Size(177, 35);
            label3.TabIndex = 2;
            label3.Text = "您的平均油耗";
            // 
            // distancetextbox
            // 
            distancetextbox.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            distancetextbox.Location = new Point(373, 94);
            distancetextbox.Margin = new Padding(7);
            distancetextbox.Name = "distancetextbox";
            distancetextbox.Size = new Size(206, 42);
            distancetextbox.TabIndex = 3;
            // 
            // gastextbox
            // 
            gastextbox.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            gastextbox.Location = new Point(373, 178);
            gastextbox.Margin = new Padding(7);
            gastextbox.Name = "gastextbox";
            gastextbox.Size = new Size(206, 42);
            gastextbox.TabIndex = 4;
            // 
            // averagelabel
            // 
            averagelabel.BorderStyle = BorderStyle.Fixed3D;
            averagelabel.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            averagelabel.Location = new Point(373, 253);
            averagelabel.Margin = new Padding(7, 0, 7, 0);
            averagelabel.Name = "averagelabel";
            averagelabel.Size = new Size(206, 58);
            averagelabel.TabIndex = 5;
            averagelabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // calculatebutton
            // 
            calculatebutton.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            calculatebutton.Location = new Point(194, 406);
            calculatebutton.Margin = new Padding(7);
            calculatebutton.Name = "calculatebutton";
            calculatebutton.Size = new Size(111, 56);
            calculatebutton.TabIndex = 6;
            calculatebutton.Text = "計算";
            calculatebutton.UseVisualStyleBackColor = true;
            calculatebutton.Click += calculatebutton_Click;
            // 
            // exitbutton
            // 
            exitbutton.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            exitbutton.Location = new Point(394, 404);
            exitbutton.Margin = new Padding(7);
            exitbutton.Name = "exitbutton";
            exitbutton.Size = new Size(111, 60);
            exitbutton.TabIndex = 7;
            exitbutton.Text = "離開";
            exitbutton.UseVisualStyleBackColor = true;
            exitbutton.Click += exitbutton_Click;
            // 
            // loglistbox
            // 
            loglistbox.FormattingEnabled = true;
            loglistbox.ItemHeight = 35;
            loglistbox.Location = new Point(620, 72);
            loglistbox.Name = "loglistbox";
            loglistbox.Size = new Size(344, 354);
            loglistbox.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button1.Location = new Point(699, 462);
            button1.Margin = new Padding(7);
            button1.Name = "button1";
            button1.Size = new Size(204, 60);
            button1.TabIndex = 9;
            button1.Text = "總平均油耗";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(16F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(988, 604);
            Controls.Add(button1);
            Controls.Add(loglistbox);
            Controls.Add(exitbutton);
            Controls.Add(calculatebutton);
            Controls.Add(averagelabel);
            Controls.Add(gastextbox);
            Controls.Add(distancetextbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 136);
            Margin = new Padding(7);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox distancetextbox;
        private TextBox gastextbox;
        private Label averagelabel;
        private Button calculatebutton;
        private Button exitbutton;
        private ListBox loglistbox;
        private Button button1;
    }
}
