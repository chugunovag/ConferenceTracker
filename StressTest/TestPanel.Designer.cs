namespace StressTest
{
    partial class TestPanel
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.autoBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.findAllBtn = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.findOneBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "http://localhost:9000/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Центральный сервер";
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.BackColor = System.Drawing.Color.White;
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Location = new System.Drawing.Point(15, 372);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(421, 350);
            this.logBox.TabIndex = 2;
            this.logBox.Text = "";
            // 
            // autoBtn
            // 
            this.autoBtn.Location = new System.Drawing.Point(149, 199);
            this.autoBtn.Name = "autoBtn";
            this.autoBtn.Size = new System.Drawing.Size(120, 23);
            this.autoBtn.TabIndex = 3;
            this.autoBtn.Text = "Начать";
            this.autoBtn.UseVisualStyleBackColor = true;
            this.autoBtn.Click += new System.EventHandler(this.autoBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Города";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "",
            "Ангарск",
            "Анжеро-Судженск",
            "Апатиты",
            "Арзамас",
            "Армавир",
            "Арсеньев",
            "Артем",
            "Архангельск",
            "Асбест",
            "Астрахань",
            "Ачинск",
            "Балаково",
            "Балахна",
            "Балашиха",
            "Балашов",
            "Барнаул",
            "Батайск",
            "Белгород",
            "Белебей",
            "Белово",
            "Белогорск (Амурская область)",
            "Белорецк",
            "Белореченск",
            "Бердск",
            "Березники",
            "Березовский (Свердловская область)",
            "Бийск",
            "Биробиджан",
            "Благовещенск (Амурская область)",
            "Бор",
            "Борисоглебск",
            "Боровичи",
            "Братск",
            "Брянск",
            "Бугульма",
            "Буденновск",
            "Бузулук",
            "Буйнакск",
            "Великие Луки",
            "Великий Новгород",
            "Верхняя Пышма",
            "Видное",
            "Владивосток",
            "Владикавказ",
            "Владимир",
            "Волгоград",
            "Волгодонск",
            "Волжск",
            "Волжский",
            "Вологда",
            "Вольск",
            "Воркута",
            "Воронеж",
            "Воскресенск",
            "Воткинск",
            "Всеволожск",
            "Выборг",
            "Выкса",
            "Вязьма",
            "Узловая",
            "Улан-Удэ",
            "Ульяновск",
            "Урус-Мартан",
            "Усолье-Сибирское",
            "Уссурийск",
            "Усть-Илимск",
            "Уфа",
            "Ухта",
            "Феодосия",
            "Фрязино",
            "Хабаровск",
            "Ханты-Мансийск",
            "Хасавюрт",
            "Химки",
            "Чайковский",
            "Чапаевск"});
            this.listBox1.Location = new System.Drawing.Point(12, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 147);
            this.listBox1.TabIndex = 7;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "GIS",
            "MATH",
            "ASU",
            "OIL",
            "GAS",
            "SPACE",
            "AUTO",
            "CS",
            "LAB",
            "ERP",
            "CAS",
            "HR",
            "GEO",
            "RE"});
            this.listBox2.Location = new System.Drawing.Point(287, 38);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 147);
            this.listBox2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Секции";
            // 
            // findAllBtn
            // 
            this.findAllBtn.Location = new System.Drawing.Point(287, 46);
            this.findAllBtn.Name = "findAllBtn";
            this.findAllBtn.Size = new System.Drawing.Size(120, 23);
            this.findAllBtn.TabIndex = 10;
            this.findAllBtn.Text = "Показать все";
            this.findAllBtn.UseVisualStyleBackColor = true;
            this.findAllBtn.Click += new System.EventHandler(this.findAllBtn_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Items.AddRange(new object[] {
            "Улица 19 Гвардейской Дивизии",
            "Переулок 1905 года",
            "Улица 30-летия Победы",
            "Улица 350-летия Томска",
            "Улица 5 Армии",
            "Улица 79 Гвардейской Дивизии",
            "Автомоторный переулок",
            "Азербайджанская улица",
            "Азиатская улица",
            "Азиатский переулок",
            "Улица Айвазовского",
            "Площадь Академика Зуева",
            "Улица Академика Пилюгина",
            "Академический микрорайон",
            "Академический проспект",
            "Академический 2-й микрорайон",
            "Албанский переулок",
            "Улица Александра Невского",
            "Александровский проезд",
            "Улица Алексея Беленца",
            "Алеутская улица",
            "Алеутский 1-й переулок",
            "Алеутский 2-й переулок",
            "Алтайская улица",
            "Амурская улица",
            "Ангарская улица",
            "Ангарский переулок",
            "Улица Андрея Крячкова",
            "Анжерский переулок",
            "Аникинский 1-й переулок",
            "Аникинский 2-й переулок",
            "Аникинский 3-й переулок",
            "Аникинский 4-й переулок",
            "Аникинский 4-й тупик",
            "Аникинский 5-й переулок",
            "Аникинский 6-й переулок",
            "Аптекарский переулок",
            "Улица Аркадия Иванова",
            "Армянский переулок",
            "Артельный переулок",
            "Улица Артема",
            "Архангельский переулок",
            "Улица Архитектора Василия Болдырева",
            "Улица Архитекторов",
            "Асиновская улица",
            "Асфальтовый переулок",
            "Ачинская улица",
            "Аэродромная улица",
            "Базарный переулок",
            "Бакинский переулок",
            "Улица Бакунина",
            "Балагурная улица",
            "Балтийская улица",
            "Барабинский переулок",
            "Баранчуковский переулок",
            "Улица Баратынского",
            "Баргузинская улица",
            "Барнаульская улица",
            "Барнаульский проезд",
            "Барнаульский переулок",
            "Бархатная улица",
            "Басандайская улица",
            "Басандайский 1-й переулок",
            "Басандайский 2-й переулок",
            "Басандайский 3-й переулок",
            "Басандайский 4-й переулок",
            "Басандайский 5-й переулок",
            "Басандайский 6-й переулок",
            "Площадь Батенькова",
            "Переулок Батенькова",
            "Батистовая улица",
            "Улица Баумана",
            "Переулок Баумана",
            "Башкирский переулок",
            "Безымянный переулок",
            "Улица Бела Куна",
            "Белая улица",
            "Белградский переулок",
            "Улица Белинского",
            "Проезд Белинского",
            "Белозерская улица",
            "Белозерский переулок",
            "Беломорская улица",
            "Белоснежная улица",
            "Бердская улица",
            "Березовая улица",
            "Березовский переулок",
            "Улица Беринга",
            "Бийская улица",
            "Улица Бирюкова"});
            this.listBox3.Location = new System.Drawing.Point(149, 38);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(120, 147);
            this.listBox3.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Улицы";
            // 
            // findOneBtn
            // 
            this.findOneBtn.Location = new System.Drawing.Point(287, 17);
            this.findOneBtn.Name = "findOneBtn";
            this.findOneBtn.Size = new System.Drawing.Size(120, 23);
            this.findOneBtn.TabIndex = 13;
            this.findOneBtn.Text = "Найти";
            this.findOneBtn.UseVisualStyleBackColor = true;
            this.findOneBtn.Click += new System.EventHandler(this.findOneBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.autoBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.listBox3);
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Location = new System.Drawing.Point(15, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 228);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Автотест";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.findOneBtn);
            this.groupBox2.Controls.Add(this.findAllBtn);
            this.groupBox2.Location = new System.Drawing.Point(15, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 81);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поиск";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(59, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(210, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "GIS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Секция";
            // 
            // TestPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 725);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "TestPanel";
            this.Text = "TestPanel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Button autoBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button findAllBtn;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button findOneBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
    }
}

