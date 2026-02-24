namespace TrackerUI
{
    partial class CreateTeamForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTeamForm));
            teamNameValue = new TextBox();
            teamNameLabel = new Label();
            headerLabel = new Label();
            addTMemberButton = new Button();
            selectTeamMemberDropDown = new ComboBox();
            selectTeamMemberLabel = new Label();
            addNewMemberGroupBox = new GroupBox();
            createMemberButton = new Button();
            phoneNumberValue = new TextBox();
            phoneNumberLabel = new Label();
            emailValue = new TextBox();
            emailLabel = new Label();
            lastNameValue = new TextBox();
            lastNameLabel = new Label();
            firstNameValue = new TextBox();
            firstNameLabel = new Label();
            teamMembersListBox = new ListBox();
            deleteSelectedMemberButton = new Button();
            createTeamButton = new Button();
            addNewMemberGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // teamNameValue
            // 
            teamNameValue.Location = new Point(34, 110);
            teamNameValue.Name = "teamNameValue";
            teamNameValue.Size = new Size(362, 35);
            teamNameValue.TabIndex = 13;
            // 
            // teamNameLabel
            // 
            teamNameLabel.AutoSize = true;
            teamNameLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            teamNameLabel.ForeColor = Color.FromArgb(51, 153, 255);
            teamNameLabel.Location = new Point(34, 70);
            teamNameLabel.Name = "teamNameLabel";
            teamNameLabel.Size = new Size(157, 37);
            teamNameLabel.TabIndex = 12;
            teamNameLabel.Text = "Team Name";
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI Light", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            headerLabel.ForeColor = Color.FromArgb(51, 153, 255);
            headerLabel.Location = new Point(12, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(213, 50);
            headerLabel.TabIndex = 11;
            headerLabel.Text = "Create Team";
            // 
            // addTMemberButton
            // 
            addTMemberButton.FlatAppearance.BorderColor = Color.Silver;
            addTMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            addTMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            addTMemberButton.FlatStyle = FlatStyle.Flat;
            addTMemberButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addTMemberButton.ForeColor = Color.FromArgb(51, 153, 255);
            addTMemberButton.Location = new Point(128, 250);
            addTMemberButton.Name = "addTMemberButton";
            addTMemberButton.Size = new Size(174, 41);
            addTMemberButton.TabIndex = 19;
            addTMemberButton.Text = "Add Member";
            addTMemberButton.UseVisualStyleBackColor = true;
            // 
            // selectTeamMemberDropDown
            // 
            selectTeamMemberDropDown.FormattingEnabled = true;
            selectTeamMemberDropDown.Location = new Point(34, 206);
            selectTeamMemberDropDown.Name = "selectTeamMemberDropDown";
            selectTeamMemberDropDown.Size = new Size(362, 38);
            selectTeamMemberDropDown.TabIndex = 18;
            // 
            // selectTeamMemberLabel
            // 
            selectTeamMemberLabel.AutoSize = true;
            selectTeamMemberLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selectTeamMemberLabel.ForeColor = Color.FromArgb(51, 153, 255);
            selectTeamMemberLabel.Location = new Point(34, 165);
            selectTeamMemberLabel.Name = "selectTeamMemberLabel";
            selectTeamMemberLabel.Size = new Size(263, 37);
            selectTeamMemberLabel.TabIndex = 17;
            selectTeamMemberLabel.Text = "Select Team Member";
            // 
            // addNewMemberGroupBox
            // 
            addNewMemberGroupBox.Controls.Add(createMemberButton);
            addNewMemberGroupBox.Controls.Add(phoneNumberValue);
            addNewMemberGroupBox.Controls.Add(phoneNumberLabel);
            addNewMemberGroupBox.Controls.Add(emailValue);
            addNewMemberGroupBox.Controls.Add(emailLabel);
            addNewMemberGroupBox.Controls.Add(lastNameValue);
            addNewMemberGroupBox.Controls.Add(lastNameLabel);
            addNewMemberGroupBox.Controls.Add(firstNameValue);
            addNewMemberGroupBox.Controls.Add(firstNameLabel);
            addNewMemberGroupBox.ForeColor = Color.FromArgb(51, 153, 255);
            addNewMemberGroupBox.Location = new Point(34, 325);
            addNewMemberGroupBox.Name = "addNewMemberGroupBox";
            addNewMemberGroupBox.Size = new Size(362, 297);
            addNewMemberGroupBox.TabIndex = 20;
            addNewMemberGroupBox.TabStop = false;
            addNewMemberGroupBox.Text = "Add New Member";
            addNewMemberGroupBox.Enter += groupBox1_Enter;
            // 
            // createMemberButton
            // 
            createMemberButton.FlatAppearance.BorderColor = Color.Silver;
            createMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            createMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            createMemberButton.FlatStyle = FlatStyle.Flat;
            createMemberButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createMemberButton.ForeColor = Color.FromArgb(51, 153, 255);
            createMemberButton.Location = new Point(94, 234);
            createMemberButton.Name = "createMemberButton";
            createMemberButton.Size = new Size(174, 41);
            createMemberButton.TabIndex = 21;
            createMemberButton.Text = "Create Member";
            createMemberButton.UseVisualStyleBackColor = true;
            // 
            // phoneNumberValue
            // 
            phoneNumberValue.Location = new Point(156, 187);
            phoneNumberValue.Name = "phoneNumberValue";
            phoneNumberValue.Size = new Size(189, 35);
            phoneNumberValue.TabIndex = 28;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            phoneNumberLabel.ForeColor = Color.FromArgb(51, 153, 255);
            phoneNumberLabel.Location = new Point(6, 184);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(144, 37);
            phoneNumberLabel.TabIndex = 27;
            phoneNumberLabel.Text = "Mobile No";
            // 
            // emailValue
            // 
            emailValue.Location = new Point(156, 140);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(189, 35);
            emailValue.TabIndex = 26;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            emailLabel.ForeColor = Color.FromArgb(51, 153, 255);
            emailLabel.Location = new Point(6, 137);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(82, 37);
            emailLabel.TabIndex = 25;
            emailLabel.Text = "Email";
            // 
            // lastNameValue
            // 
            lastNameValue.Location = new Point(156, 93);
            lastNameValue.Name = "lastNameValue";
            lastNameValue.Size = new Size(189, 35);
            lastNameValue.TabIndex = 24;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lastNameLabel.ForeColor = Color.FromArgb(51, 153, 255);
            lastNameLabel.Location = new Point(6, 90);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(142, 37);
            lastNameLabel.TabIndex = 23;
            lastNameLabel.Text = "Last Name";
            // 
            // firstNameValue
            // 
            firstNameValue.Location = new Point(156, 46);
            firstNameValue.Name = "firstNameValue";
            firstNameValue.Size = new Size(189, 35);
            firstNameValue.TabIndex = 22;
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            firstNameLabel.ForeColor = Color.FromArgb(51, 153, 255);
            firstNameLabel.Location = new Point(6, 43);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(144, 37);
            firstNameLabel.TabIndex = 21;
            firstNameLabel.Text = "First Name";
            // 
            // teamMembersListBox
            // 
            teamMembersListBox.BorderStyle = BorderStyle.FixedSingle;
            teamMembersListBox.FormattingEnabled = true;
            teamMembersListBox.Location = new Point(440, 110);
            teamMembersListBox.Name = "teamMembersListBox";
            teamMembersListBox.Size = new Size(309, 512);
            teamMembersListBox.TabIndex = 21;
            // 
            // deleteSelectedMemberButton
            // 
            deleteSelectedMemberButton.FlatAppearance.BorderColor = Color.Silver;
            deleteSelectedMemberButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            deleteSelectedMemberButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            deleteSelectedMemberButton.FlatStyle = FlatStyle.Flat;
            deleteSelectedMemberButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteSelectedMemberButton.ForeColor = Color.FromArgb(51, 153, 255);
            deleteSelectedMemberButton.Location = new Point(769, 329);
            deleteSelectedMemberButton.Name = "deleteSelectedMemberButton";
            deleteSelectedMemberButton.Size = new Size(123, 74);
            deleteSelectedMemberButton.TabIndex = 22;
            deleteSelectedMemberButton.Text = "Delete Selected";
            deleteSelectedMemberButton.UseVisualStyleBackColor = true;
            // 
            // createTeamButton
            // 
            createTeamButton.FlatAppearance.BorderColor = Color.Silver;
            createTeamButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(102, 102, 102);
            createTeamButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(242, 242, 242);
            createTeamButton.FlatStyle = FlatStyle.Flat;
            createTeamButton.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createTeamButton.ForeColor = Color.FromArgb(51, 153, 255);
            createTeamButton.Location = new Point(314, 649);
            createTeamButton.Name = "createTeamButton";
            createTeamButton.Size = new Size(284, 59);
            createTeamButton.TabIndex = 25;
            createTeamButton.Text = "Create Team";
            createTeamButton.UseVisualStyleBackColor = true;
            // 
            // CreateTeamForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(913, 738);
            Controls.Add(createTeamButton);
            Controls.Add(deleteSelectedMemberButton);
            Controls.Add(teamMembersListBox);
            Controls.Add(addNewMemberGroupBox);
            Controls.Add(addTMemberButton);
            Controls.Add(selectTeamMemberDropDown);
            Controls.Add(selectTeamMemberLabel);
            Controls.Add(teamNameValue);
            Controls.Add(teamNameLabel);
            Controls.Add(headerLabel);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "CreateTeamForm";
            Text = "Create Team";
            addNewMemberGroupBox.ResumeLayout(false);
            addNewMemberGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox teamNameValue;
        private Label teamNameLabel;
        private Label headerLabel;
        private Button addTMemberButton;
        private ComboBox selectTeamMemberDropDown;
        private Label selectTeamMemberLabel;
        private GroupBox addNewMemberGroupBox;
        private TextBox firstNameValue;
        private Label firstNameLabel;
        private TextBox phoneNumberValue;
        private Label phoneNumberLabel;
        private TextBox emailValue;
        private Label emailLabel;
        private TextBox lastNameValue;
        private Label lastNameLabel;
        private Button createMemberButton;
        private ListBox teamMembersListBox;
        private Button deleteSelectedMemberButton;
        private Button createTeamButton;
    }
}