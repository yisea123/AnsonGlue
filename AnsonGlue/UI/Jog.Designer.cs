namespace AnsonGlue.UI
{
    partial class CJog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CJog));
            this.m_rBtnYp = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnZp = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnXn = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnXp = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnZn = new AnsonGlue.Repaint.CRoundButton();
            this.m_rBtnYn = new AnsonGlue.Repaint.CRoundButton();
            this.m_cBoxInchSel = new System.Windows.Forms.CheckBox();
            this.m_labelPositionX = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelPositionY = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelPositionZ = new AnsonGlue.Repaint.CRoundButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_labelXPosLimit = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelXNegLimit = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelXHome = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelXAlarm = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelYAlarm = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelYHome = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelYNegLimit = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelYPosLimit = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelZAlarm = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelZHome = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelZNegLimit = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelZPosLimit = new AnsonGlue.Repaint.CRoundButton();
            this.label1 = new System.Windows.Forms.Label();
            this.m_labelZStatus = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelYStatus = new AnsonGlue.Repaint.CRoundButton();
            this.m_labelXStatus = new AnsonGlue.Repaint.CRoundButton();
            this.label2 = new System.Windows.Forms.Label();
            this.m_rBtnHome = new AnsonGlue.Repaint.CRoundButton();
            this.timer_UpdatePosition = new System.Windows.Forms.Timer(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.m_tBoxInchDis = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_rBtnYp
            // 
            this.m_rBtnYp.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnYp.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnYp.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnYp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnYp.FlatAppearance.BorderSize = 0;
            this.m_rBtnYp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnYp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnYp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnYp.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnYp.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnYp.Location = new System.Drawing.Point(186, 76);
            this.m_rBtnYp.Name = "m_rBtnYp";
            this.m_rBtnYp.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnYp.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnYp.Radius = 20;
            this.m_rBtnYp.Size = new System.Drawing.Size(81, 44);
            this.m_rBtnYp.TabIndex = 1;
            this.m_rBtnYp.Text = "Y+";
            this.m_rBtnYp.UseVisualStyleBackColor = true;
            this.m_rBtnYp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseDown);
            this.m_rBtnYp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseUp);
            // 
            // m_rBtnZp
            // 
            this.m_rBtnZp.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnZp.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnZp.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnZp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnZp.FlatAppearance.BorderSize = 0;
            this.m_rBtnZp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnZp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnZp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnZp.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnZp.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnZp.Location = new System.Drawing.Point(186, 130);
            this.m_rBtnZp.Name = "m_rBtnZp";
            this.m_rBtnZp.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnZp.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnZp.Radius = 20;
            this.m_rBtnZp.Size = new System.Drawing.Size(81, 44);
            this.m_rBtnZp.TabIndex = 2;
            this.m_rBtnZp.Text = "Z+";
            this.m_rBtnZp.UseVisualStyleBackColor = true;
            this.m_rBtnZp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseDown);
            this.m_rBtnZp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseUp);
            // 
            // m_rBtnXn
            // 
            this.m_rBtnXn.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnXn.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnXn.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnXn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnXn.FlatAppearance.BorderSize = 0;
            this.m_rBtnXn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnXn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnXn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnXn.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnXn.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnXn.Location = new System.Drawing.Point(93, 22);
            this.m_rBtnXn.Name = "m_rBtnXn";
            this.m_rBtnXn.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnXn.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnXn.Radius = 20;
            this.m_rBtnXn.Size = new System.Drawing.Size(81, 44);
            this.m_rBtnXn.TabIndex = 3;
            this.m_rBtnXn.Text = "X-";
            this.m_rBtnXn.UseVisualStyleBackColor = true;
            this.m_rBtnXn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseDown);
            this.m_rBtnXn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseUp);
            // 
            // m_rBtnXp
            // 
            this.m_rBtnXp.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnXp.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnXp.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnXp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnXp.FlatAppearance.BorderSize = 0;
            this.m_rBtnXp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnXp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnXp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnXp.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnXp.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnXp.Location = new System.Drawing.Point(186, 22);
            this.m_rBtnXp.Name = "m_rBtnXp";
            this.m_rBtnXp.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnXp.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnXp.Radius = 20;
            this.m_rBtnXp.Size = new System.Drawing.Size(81, 44);
            this.m_rBtnXp.TabIndex = 4;
            this.m_rBtnXp.Text = "X+";
            this.m_rBtnXp.UseVisualStyleBackColor = true;
            this.m_rBtnXp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseDown);
            this.m_rBtnXp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseUp);
            // 
            // m_rBtnZn
            // 
            this.m_rBtnZn.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnZn.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnZn.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnZn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnZn.FlatAppearance.BorderSize = 0;
            this.m_rBtnZn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnZn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnZn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnZn.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnZn.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnZn.Location = new System.Drawing.Point(93, 130);
            this.m_rBtnZn.Name = "m_rBtnZn";
            this.m_rBtnZn.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnZn.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnZn.Radius = 20;
            this.m_rBtnZn.Size = new System.Drawing.Size(81, 44);
            this.m_rBtnZn.TabIndex = 5;
            this.m_rBtnZn.Text = "Z-";
            this.m_rBtnZn.UseVisualStyleBackColor = true;
            this.m_rBtnZn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseDown);
            this.m_rBtnZn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseUp);
            // 
            // m_rBtnYn
            // 
            this.m_rBtnYn.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnYn.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnYn.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnYn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnYn.FlatAppearance.BorderSize = 0;
            this.m_rBtnYn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnYn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnYn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnYn.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnYn.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnYn.Location = new System.Drawing.Point(93, 76);
            this.m_rBtnYn.Name = "m_rBtnYn";
            this.m_rBtnYn.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_rBtnYn.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnYn.Radius = 20;
            this.m_rBtnYn.Size = new System.Drawing.Size(81, 44);
            this.m_rBtnYn.TabIndex = 9;
            this.m_rBtnYn.Text = "Y-";
            this.m_rBtnYn.UseVisualStyleBackColor = true;
            this.m_rBtnYn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseDown);
            this.m_rBtnYn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MotionBtn_MouseUp);
            // 
            // m_cBoxInchSel
            // 
            this.m_cBoxInchSel.AutoSize = true;
            this.m_cBoxInchSel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cBoxInchSel.Location = new System.Drawing.Point(68, 235);
            this.m_cBoxInchSel.Name = "m_cBoxInchSel";
            this.m_cBoxInchSel.Size = new System.Drawing.Size(74, 31);
            this.m_cBoxInchSel.TabIndex = 10;
            this.m_cBoxInchSel.Text = "Inch";
            this.m_cBoxInchSel.UseVisualStyleBackColor = true;
            // 
            // m_labelPositionX
            // 
            this.m_labelPositionX.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelPositionX.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_labelPositionX.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelPositionX.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelPositionX.FlatAppearance.BorderSize = 0;
            this.m_labelPositionX.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelPositionX.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelPositionX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelPositionX.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_labelPositionX.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelPositionX.Location = new System.Drawing.Point(368, 328);
            this.m_labelPositionX.Name = "m_labelPositionX";
            this.m_labelPositionX.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_labelPositionX.PressForeColor = System.Drawing.Color.Black;
            this.m_labelPositionX.Radius = 20;
            this.m_labelPositionX.Size = new System.Drawing.Size(88, 31);
            this.m_labelPositionX.TabIndex = 17;
            this.m_labelPositionX.Text = "000.00";
            this.m_labelPositionX.UseVisualStyleBackColor = true;
            // 
            // m_labelPositionY
            // 
            this.m_labelPositionY.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelPositionY.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_labelPositionY.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelPositionY.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelPositionY.FlatAppearance.BorderSize = 0;
            this.m_labelPositionY.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelPositionY.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelPositionY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelPositionY.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_labelPositionY.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelPositionY.Location = new System.Drawing.Point(368, 374);
            this.m_labelPositionY.Name = "m_labelPositionY";
            this.m_labelPositionY.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_labelPositionY.PressForeColor = System.Drawing.Color.Black;
            this.m_labelPositionY.Radius = 20;
            this.m_labelPositionY.Size = new System.Drawing.Size(88, 31);
            this.m_labelPositionY.TabIndex = 19;
            this.m_labelPositionY.Text = "000.00";
            this.m_labelPositionY.UseVisualStyleBackColor = true;
            // 
            // m_labelPositionZ
            // 
            this.m_labelPositionZ.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelPositionZ.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_labelPositionZ.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelPositionZ.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelPositionZ.FlatAppearance.BorderSize = 0;
            this.m_labelPositionZ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelPositionZ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelPositionZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelPositionZ.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_labelPositionZ.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelPositionZ.Location = new System.Drawing.Point(368, 419);
            this.m_labelPositionZ.Name = "m_labelPositionZ";
            this.m_labelPositionZ.PressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_labelPositionZ.PressForeColor = System.Drawing.Color.Black;
            this.m_labelPositionZ.Radius = 20;
            this.m_labelPositionZ.Size = new System.Drawing.Size(88, 31);
            this.m_labelPositionZ.TabIndex = 21;
            this.m_labelPositionZ.Text = "000.00";
            this.m_labelPositionZ.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 27);
            this.label3.TabIndex = 22;
            this.label3.Text = "限位+";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 27);
            this.label4.TabIndex = 23;
            this.label4.Text = "限位-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 27);
            this.label5.TabIndex = 24;
            this.label5.Text = "零点";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 27);
            this.label6.TabIndex = 25;
            this.label6.Text = "报警";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 27);
            this.label7.TabIndex = 26;
            this.label7.Text = "X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 372);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 27);
            this.label8.TabIndex = 27;
            this.label8.Text = "Y:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 414);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 27);
            this.label9.TabIndex = 28;
            this.label9.Text = "Z:";
            // 
            // m_labelXPosLimit
            // 
            this.m_labelXPosLimit.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelXPosLimit.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelXPosLimit.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelXPosLimit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelXPosLimit.FlatAppearance.BorderSize = 0;
            this.m_labelXPosLimit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelXPosLimit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelXPosLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelXPosLimit.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelXPosLimit.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelXPosLimit.Location = new System.Drawing.Point(67, 323);
            this.m_labelXPosLimit.Name = "m_labelXPosLimit";
            this.m_labelXPosLimit.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelXPosLimit.PressForeColor = System.Drawing.Color.Black;
            this.m_labelXPosLimit.Radius = 40;
            this.m_labelXPosLimit.Size = new System.Drawing.Size(40, 40);
            this.m_labelXPosLimit.TabIndex = 29;
            this.m_labelXPosLimit.UseVisualStyleBackColor = true;
            // 
            // m_labelXNegLimit
            // 
            this.m_labelXNegLimit.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelXNegLimit.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelXNegLimit.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelXNegLimit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelXNegLimit.FlatAppearance.BorderSize = 0;
            this.m_labelXNegLimit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelXNegLimit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelXNegLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelXNegLimit.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelXNegLimit.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelXNegLimit.Location = new System.Drawing.Point(126, 323);
            this.m_labelXNegLimit.Name = "m_labelXNegLimit";
            this.m_labelXNegLimit.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelXNegLimit.PressForeColor = System.Drawing.Color.Black;
            this.m_labelXNegLimit.Radius = 40;
            this.m_labelXNegLimit.Size = new System.Drawing.Size(40, 40);
            this.m_labelXNegLimit.TabIndex = 30;
            this.m_labelXNegLimit.UseVisualStyleBackColor = true;
            // 
            // m_labelXHome
            // 
            this.m_labelXHome.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelXHome.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelXHome.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelXHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelXHome.FlatAppearance.BorderSize = 0;
            this.m_labelXHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelXHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelXHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelXHome.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelXHome.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelXHome.Location = new System.Drawing.Point(185, 323);
            this.m_labelXHome.Name = "m_labelXHome";
            this.m_labelXHome.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelXHome.PressForeColor = System.Drawing.Color.Black;
            this.m_labelXHome.Radius = 40;
            this.m_labelXHome.Size = new System.Drawing.Size(40, 40);
            this.m_labelXHome.TabIndex = 31;
            this.m_labelXHome.UseVisualStyleBackColor = true;
            // 
            // m_labelXAlarm
            // 
            this.m_labelXAlarm.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelXAlarm.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelXAlarm.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelXAlarm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelXAlarm.FlatAppearance.BorderSize = 0;
            this.m_labelXAlarm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelXAlarm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelXAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelXAlarm.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelXAlarm.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelXAlarm.Location = new System.Drawing.Point(244, 323);
            this.m_labelXAlarm.Name = "m_labelXAlarm";
            this.m_labelXAlarm.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelXAlarm.PressForeColor = System.Drawing.Color.Black;
            this.m_labelXAlarm.Radius = 40;
            this.m_labelXAlarm.Size = new System.Drawing.Size(40, 40);
            this.m_labelXAlarm.TabIndex = 32;
            this.m_labelXAlarm.UseVisualStyleBackColor = true;
            // 
            // m_labelYAlarm
            // 
            this.m_labelYAlarm.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelYAlarm.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelYAlarm.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelYAlarm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelYAlarm.FlatAppearance.BorderSize = 0;
            this.m_labelYAlarm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelYAlarm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelYAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelYAlarm.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelYAlarm.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelYAlarm.Location = new System.Drawing.Point(244, 369);
            this.m_labelYAlarm.Name = "m_labelYAlarm";
            this.m_labelYAlarm.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelYAlarm.PressForeColor = System.Drawing.Color.Black;
            this.m_labelYAlarm.Radius = 40;
            this.m_labelYAlarm.Size = new System.Drawing.Size(40, 40);
            this.m_labelYAlarm.TabIndex = 36;
            this.m_labelYAlarm.UseVisualStyleBackColor = true;
            // 
            // m_labelYHome
            // 
            this.m_labelYHome.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelYHome.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelYHome.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelYHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelYHome.FlatAppearance.BorderSize = 0;
            this.m_labelYHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelYHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelYHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelYHome.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelYHome.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelYHome.Location = new System.Drawing.Point(185, 369);
            this.m_labelYHome.Name = "m_labelYHome";
            this.m_labelYHome.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelYHome.PressForeColor = System.Drawing.Color.Black;
            this.m_labelYHome.Radius = 40;
            this.m_labelYHome.Size = new System.Drawing.Size(40, 40);
            this.m_labelYHome.TabIndex = 35;
            this.m_labelYHome.UseVisualStyleBackColor = true;
            // 
            // m_labelYNegLimit
            // 
            this.m_labelYNegLimit.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelYNegLimit.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelYNegLimit.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelYNegLimit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelYNegLimit.FlatAppearance.BorderSize = 0;
            this.m_labelYNegLimit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelYNegLimit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelYNegLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelYNegLimit.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelYNegLimit.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelYNegLimit.Location = new System.Drawing.Point(126, 369);
            this.m_labelYNegLimit.Name = "m_labelYNegLimit";
            this.m_labelYNegLimit.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelYNegLimit.PressForeColor = System.Drawing.Color.Black;
            this.m_labelYNegLimit.Radius = 40;
            this.m_labelYNegLimit.Size = new System.Drawing.Size(40, 40);
            this.m_labelYNegLimit.TabIndex = 34;
            this.m_labelYNegLimit.UseVisualStyleBackColor = true;
            // 
            // m_labelYPosLimit
            // 
            this.m_labelYPosLimit.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelYPosLimit.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelYPosLimit.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelYPosLimit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelYPosLimit.FlatAppearance.BorderSize = 0;
            this.m_labelYPosLimit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelYPosLimit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelYPosLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelYPosLimit.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelYPosLimit.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelYPosLimit.Location = new System.Drawing.Point(67, 369);
            this.m_labelYPosLimit.Name = "m_labelYPosLimit";
            this.m_labelYPosLimit.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelYPosLimit.PressForeColor = System.Drawing.Color.Black;
            this.m_labelYPosLimit.Radius = 40;
            this.m_labelYPosLimit.Size = new System.Drawing.Size(40, 40);
            this.m_labelYPosLimit.TabIndex = 33;
            this.m_labelYPosLimit.UseVisualStyleBackColor = true;
            // 
            // m_labelZAlarm
            // 
            this.m_labelZAlarm.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelZAlarm.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelZAlarm.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelZAlarm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelZAlarm.FlatAppearance.BorderSize = 0;
            this.m_labelZAlarm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelZAlarm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelZAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelZAlarm.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelZAlarm.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelZAlarm.Location = new System.Drawing.Point(244, 414);
            this.m_labelZAlarm.Name = "m_labelZAlarm";
            this.m_labelZAlarm.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelZAlarm.PressForeColor = System.Drawing.Color.Black;
            this.m_labelZAlarm.Radius = 40;
            this.m_labelZAlarm.Size = new System.Drawing.Size(40, 40);
            this.m_labelZAlarm.TabIndex = 40;
            this.m_labelZAlarm.UseVisualStyleBackColor = true;
            // 
            // m_labelZHome
            // 
            this.m_labelZHome.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelZHome.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelZHome.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelZHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelZHome.FlatAppearance.BorderSize = 0;
            this.m_labelZHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelZHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelZHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelZHome.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelZHome.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelZHome.Location = new System.Drawing.Point(185, 414);
            this.m_labelZHome.Name = "m_labelZHome";
            this.m_labelZHome.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelZHome.PressForeColor = System.Drawing.Color.Black;
            this.m_labelZHome.Radius = 40;
            this.m_labelZHome.Size = new System.Drawing.Size(40, 40);
            this.m_labelZHome.TabIndex = 39;
            this.m_labelZHome.UseVisualStyleBackColor = true;
            // 
            // m_labelZNegLimit
            // 
            this.m_labelZNegLimit.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelZNegLimit.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelZNegLimit.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelZNegLimit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelZNegLimit.FlatAppearance.BorderSize = 0;
            this.m_labelZNegLimit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelZNegLimit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelZNegLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelZNegLimit.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelZNegLimit.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelZNegLimit.Location = new System.Drawing.Point(126, 414);
            this.m_labelZNegLimit.Name = "m_labelZNegLimit";
            this.m_labelZNegLimit.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelZNegLimit.PressForeColor = System.Drawing.Color.Black;
            this.m_labelZNegLimit.Radius = 40;
            this.m_labelZNegLimit.Size = new System.Drawing.Size(40, 40);
            this.m_labelZNegLimit.TabIndex = 38;
            this.m_labelZNegLimit.UseVisualStyleBackColor = true;
            // 
            // m_labelZPosLimit
            // 
            this.m_labelZPosLimit.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelZPosLimit.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelZPosLimit.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelZPosLimit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelZPosLimit.FlatAppearance.BorderSize = 0;
            this.m_labelZPosLimit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelZPosLimit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelZPosLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelZPosLimit.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelZPosLimit.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelZPosLimit.Location = new System.Drawing.Point(67, 414);
            this.m_labelZPosLimit.Name = "m_labelZPosLimit";
            this.m_labelZPosLimit.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelZPosLimit.PressForeColor = System.Drawing.Color.Black;
            this.m_labelZPosLimit.Radius = 40;
            this.m_labelZPosLimit.Size = new System.Drawing.Size(40, 40);
            this.m_labelZPosLimit.TabIndex = 37;
            this.m_labelZPosLimit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 27);
            this.label1.TabIndex = 41;
            this.label1.Text = "位置";
            // 
            // m_labelZStatus
            // 
            this.m_labelZStatus.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelZStatus.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelZStatus.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelZStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelZStatus.FlatAppearance.BorderSize = 0;
            this.m_labelZStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelZStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelZStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelZStatus.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelZStatus.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelZStatus.Location = new System.Drawing.Point(309, 414);
            this.m_labelZStatus.Name = "m_labelZStatus";
            this.m_labelZStatus.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelZStatus.PressForeColor = System.Drawing.Color.Black;
            this.m_labelZStatus.Radius = 40;
            this.m_labelZStatus.Size = new System.Drawing.Size(40, 40);
            this.m_labelZStatus.TabIndex = 45;
            this.m_labelZStatus.UseVisualStyleBackColor = true;
            // 
            // m_labelYStatus
            // 
            this.m_labelYStatus.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelYStatus.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelYStatus.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelYStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelYStatus.FlatAppearance.BorderSize = 0;
            this.m_labelYStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelYStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelYStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelYStatus.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelYStatus.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelYStatus.Location = new System.Drawing.Point(309, 369);
            this.m_labelYStatus.Name = "m_labelYStatus";
            this.m_labelYStatus.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelYStatus.PressForeColor = System.Drawing.Color.Black;
            this.m_labelYStatus.Radius = 40;
            this.m_labelYStatus.Size = new System.Drawing.Size(40, 40);
            this.m_labelYStatus.TabIndex = 44;
            this.m_labelYStatus.UseVisualStyleBackColor = true;
            // 
            // m_labelXStatus
            // 
            this.m_labelXStatus.DisableBackColor = System.Drawing.Color.Red;
            this.m_labelXStatus.EnterBackColor = System.Drawing.Color.Lime;
            this.m_labelXStatus.EnterForeColor = System.Drawing.Color.Black;
            this.m_labelXStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_labelXStatus.FlatAppearance.BorderSize = 0;
            this.m_labelXStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_labelXStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_labelXStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_labelXStatus.HoverBackColor = System.Drawing.Color.Lime;
            this.m_labelXStatus.HoverForeColor = System.Drawing.Color.Black;
            this.m_labelXStatus.Location = new System.Drawing.Point(309, 323);
            this.m_labelXStatus.Name = "m_labelXStatus";
            this.m_labelXStatus.PressBackColor = System.Drawing.Color.Lime;
            this.m_labelXStatus.PressForeColor = System.Drawing.Color.Black;
            this.m_labelXStatus.Radius = 40;
            this.m_labelXStatus.Size = new System.Drawing.Size(40, 40);
            this.m_labelXStatus.TabIndex = 43;
            this.m_labelXStatus.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 27);
            this.label2.TabIndex = 42;
            this.label2.Text = "运动";
            // 
            // m_rBtnHome
            // 
            this.m_rBtnHome.DisableBackColor = System.Drawing.Color.Red;
            this.m_rBtnHome.EnterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.m_rBtnHome.EnterForeColor = System.Drawing.Color.Black;
            this.m_rBtnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.m_rBtnHome.FlatAppearance.BorderSize = 0;
            this.m_rBtnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.m_rBtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rBtnHome.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(218)))), ((int)(((byte)(151)))));
            this.m_rBtnHome.HoverForeColor = System.Drawing.Color.Black;
            this.m_rBtnHome.Location = new System.Drawing.Point(285, 235);
            this.m_rBtnHome.Name = "m_rBtnHome";
            this.m_rBtnHome.PressBackColor = System.Drawing.Color.Empty;
            this.m_rBtnHome.PressForeColor = System.Drawing.Color.Black;
            this.m_rBtnHome.Radius = 20;
            this.m_rBtnHome.Size = new System.Drawing.Size(143, 35);
            this.m_rBtnHome.TabIndex = 47;
            this.m_rBtnHome.Text = "回零";
            this.m_rBtnHome.UseVisualStyleBackColor = true;
            this.m_rBtnHome.Click += new System.EventHandler(this.m_rBtnHome_Click);
            // 
            // timer_UpdatePosition
            // 
            this.timer_UpdatePosition.Enabled = true;
            this.timer_UpdatePosition.Tick += new System.EventHandler(this.timer_UpdatePosition_Tick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(213, 234);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 27);
            this.label11.TabIndex = 96;
            this.label11.Text = "°/mm";
            // 
            // m_tBoxInchDis
            // 
            this.m_tBoxInchDis.Location = new System.Drawing.Point(137, 231);
            this.m_tBoxInchDis.Name = "m_tBoxInchDis";
            this.m_tBoxInchDis.Size = new System.Drawing.Size(75, 35);
            this.m_tBoxInchDis.TabIndex = 95;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 27);
            this.label10.TabIndex = 97;
            this.label10.Text = "轴1：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 27);
            this.label12.TabIndex = 98;
            this.label12.Text = "轴2：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 27);
            this.label13.TabIndex = 99;
            this.label13.Text = "轴3：";
            // 
            // CJog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(501, 480);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.m_tBoxInchDis);
            this.Controls.Add(this.m_rBtnHome);
            this.Controls.Add(this.m_labelZStatus);
            this.Controls.Add(this.m_labelYStatus);
            this.Controls.Add(this.m_labelXStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_labelZAlarm);
            this.Controls.Add(this.m_labelZHome);
            this.Controls.Add(this.m_labelZNegLimit);
            this.Controls.Add(this.m_labelZPosLimit);
            this.Controls.Add(this.m_labelYAlarm);
            this.Controls.Add(this.m_labelYHome);
            this.Controls.Add(this.m_labelYNegLimit);
            this.Controls.Add(this.m_labelYPosLimit);
            this.Controls.Add(this.m_labelXAlarm);
            this.Controls.Add(this.m_labelXHome);
            this.Controls.Add(this.m_labelXNegLimit);
            this.Controls.Add(this.m_labelXPosLimit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_labelPositionZ);
            this.Controls.Add(this.m_labelPositionY);
            this.Controls.Add(this.m_labelPositionX);
            this.Controls.Add(this.m_cBoxInchSel);
            this.Controls.Add(this.m_rBtnYn);
            this.Controls.Add(this.m_rBtnZn);
            this.Controls.Add(this.m_rBtnXp);
            this.Controls.Add(this.m_rBtnXn);
            this.Controls.Add(this.m_rBtnZp);
            this.Controls.Add(this.m_rBtnYp);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximumSize = new System.Drawing.Size(2000, 1000);
            this.MinimumSize = new System.Drawing.Size(100, 180);
            this.Name = "CJog";
            this.Text = "Jog";
            this.Load += new System.EventHandler(this.Jog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Repaint.CRoundButton m_rBtnYp;
        private Repaint.CRoundButton m_rBtnZp;
        private Repaint.CRoundButton m_rBtnXn;
        private Repaint.CRoundButton m_rBtnXp;
        private Repaint.CRoundButton m_rBtnZn;
        private Repaint.CRoundButton m_rBtnYn;
        private System.Windows.Forms.CheckBox m_cBoxInchSel;
        private Repaint.CRoundButton m_labelPositionX;
        private Repaint.CRoundButton m_labelPositionY;
        private Repaint.CRoundButton m_labelPositionZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Repaint.CRoundButton m_labelXPosLimit;
        private Repaint.CRoundButton m_labelXNegLimit;
        private Repaint.CRoundButton m_labelXHome;
        private Repaint.CRoundButton m_labelXAlarm;
        private Repaint.CRoundButton m_labelYAlarm;
        private Repaint.CRoundButton m_labelYHome;
        private Repaint.CRoundButton m_labelYNegLimit;
        private Repaint.CRoundButton m_labelYPosLimit;
        private Repaint.CRoundButton m_labelZAlarm;
        private Repaint.CRoundButton m_labelZHome;
        private Repaint.CRoundButton m_labelZNegLimit;
        private Repaint.CRoundButton m_labelZPosLimit;
        private System.Windows.Forms.Label label1;
        private Repaint.CRoundButton m_labelZStatus;
        private Repaint.CRoundButton m_labelYStatus;
        private Repaint.CRoundButton m_labelXStatus;
        private System.Windows.Forms.Label label2;
        private Repaint.CRoundButton m_rBtnHome;
        private System.Windows.Forms.Timer timer_UpdatePosition;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox m_tBoxInchDis;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}