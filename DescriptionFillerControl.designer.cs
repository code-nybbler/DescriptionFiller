namespace DescriptionFiller
{
    partial class DescriptionFillerControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DescriptionFillerControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_LoadEntities = new System.Windows.Forms.ToolStripButton();
            this.lbl_entities = new System.Windows.Forms.Label();
            this.lst_Entities = new System.Windows.Forms.ListBox();
            this.txt_TableDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_FormDesc = new System.Windows.Forms.TextBox();
            this.txt_ViewDesc = new System.Windows.Forms.TextBox();
            this.txt_FieldDesc = new System.Windows.Forms.TextBox();
            this.chk_Entity = new System.Windows.Forms.CheckBox();
            this.chk_Forms = new System.Windows.Forms.CheckBox();
            this.chk_Views = new System.Windows.Forms.CheckBox();
            this.chk_Fields = new System.Windows.Forms.CheckBox();
            this.btn_Execute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.btn_LoadEntities});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(667, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(40, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btn_LoadEntities
            // 
            this.btn_LoadEntities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btn_LoadEntities.Image = ((System.Drawing.Image)(resources.GetObject("btn_LoadEntities.Image")));
            this.btn_LoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_LoadEntities.Name = "btn_LoadEntities";
            this.btn_LoadEntities.Size = new System.Drawing.Size(78, 22);
            this.btn_LoadEntities.Text = "Load Entities";
            this.btn_LoadEntities.Click += new System.EventHandler(this.btn_LoadEntities_Click);
            // 
            // lbl_entities
            // 
            this.lbl_entities.AutoSize = true;
            this.lbl_entities.Location = new System.Drawing.Point(0, 27);
            this.lbl_entities.Name = "lbl_entities";
            this.lbl_entities.Size = new System.Drawing.Size(41, 13);
            this.lbl_entities.TabIndex = 25;
            this.lbl_entities.Text = "Entities";
            // 
            // lst_Entities
            // 
            this.lst_Entities.Enabled = false;
            this.lst_Entities.FormattingEnabled = true;
            this.lst_Entities.Location = new System.Drawing.Point(3, 43);
            this.lst_Entities.Name = "lst_Entities";
            this.lst_Entities.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_Entities.Size = new System.Drawing.Size(200, 537);
            this.lst_Entities.TabIndex = 24;
            // 
            // txt_TableDesc
            // 
            this.txt_TableDesc.Location = new System.Drawing.Point(278, 41);
            this.txt_TableDesc.Name = "txt_TableDesc";
            this.txt_TableDesc.Size = new System.Drawing.Size(374, 20);
            this.txt_TableDesc.TabIndex = 30;
            this.txt_TableDesc.Text = "A table to hold {table} records.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Components";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Description Formats";
            // 
            // txt_FormDesc
            // 
            this.txt_FormDesc.Location = new System.Drawing.Point(278, 64);
            this.txt_FormDesc.Name = "txt_FormDesc";
            this.txt_FormDesc.Size = new System.Drawing.Size(374, 20);
            this.txt_FormDesc.TabIndex = 34;
            this.txt_FormDesc.Text = "{type} form to display {form} data for the {table} table.";
            // 
            // txt_ViewDesc
            // 
            this.txt_ViewDesc.Location = new System.Drawing.Point(278, 87);
            this.txt_ViewDesc.Name = "txt_ViewDesc";
            this.txt_ViewDesc.Size = new System.Drawing.Size(374, 20);
            this.txt_ViewDesc.TabIndex = 36;
            this.txt_ViewDesc.Text = "{view} view for the {table} table.";
            // 
            // txt_FieldDesc
            // 
            this.txt_FieldDesc.Location = new System.Drawing.Point(278, 110);
            this.txt_FieldDesc.Name = "txt_FieldDesc";
            this.txt_FieldDesc.Size = new System.Drawing.Size(374, 20);
            this.txt_FieldDesc.TabIndex = 37;
            this.txt_FieldDesc.Text = "Field to store {field} information for the {table} table.";
            // 
            // chk_Entity
            // 
            this.chk_Entity.AutoSize = true;
            this.chk_Entity.Location = new System.Drawing.Point(209, 43);
            this.chk_Entity.Name = "chk_Entity";
            this.chk_Entity.Size = new System.Drawing.Size(52, 17);
            this.chk_Entity.TabIndex = 38;
            this.chk_Entity.Text = "Entity";
            this.chk_Entity.UseVisualStyleBackColor = true;
            // 
            // chk_Forms
            // 
            this.chk_Forms.AutoSize = true;
            this.chk_Forms.Location = new System.Drawing.Point(209, 66);
            this.chk_Forms.Name = "chk_Forms";
            this.chk_Forms.Size = new System.Drawing.Size(54, 17);
            this.chk_Forms.TabIndex = 39;
            this.chk_Forms.Text = "Forms";
            this.chk_Forms.UseVisualStyleBackColor = true;
            // 
            // chk_Views
            // 
            this.chk_Views.AutoSize = true;
            this.chk_Views.Location = new System.Drawing.Point(209, 89);
            this.chk_Views.Name = "chk_Views";
            this.chk_Views.Size = new System.Drawing.Size(54, 17);
            this.chk_Views.TabIndex = 40;
            this.chk_Views.Text = "Views";
            this.chk_Views.UseVisualStyleBackColor = true;
            // 
            // chk_Fields
            // 
            this.chk_Fields.AutoSize = true;
            this.chk_Fields.Location = new System.Drawing.Point(209, 112);
            this.chk_Fields.Name = "chk_Fields";
            this.chk_Fields.Size = new System.Drawing.Size(57, 17);
            this.chk_Fields.TabIndex = 41;
            this.chk_Fields.Text = "Fields*";
            this.chk_Fields.UseVisualStyleBackColor = true;
            // 
            // btn_Execute
            // 
            this.btn_Execute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Execute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Execute.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_Execute.Location = new System.Drawing.Point(209, 133);
            this.btn_Execute.Name = "btn_Execute";
            this.btn_Execute.Size = new System.Drawing.Size(443, 45);
            this.btn_Execute.TabIndex = 42;
            this.btn_Execute.Text = "Execute";
            this.btn_Execute.UseVisualStyleBackColor = true;
            this.btn_Execute.Click += new System.EventHandler(this.btn_Execute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "* Only custom fields will be updated.";
            // 
            // DescriptionFillerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Execute);
            this.Controls.Add(this.chk_Fields);
            this.Controls.Add(this.chk_Views);
            this.Controls.Add(this.chk_Forms);
            this.Controls.Add(this.chk_Entity);
            this.Controls.Add(this.txt_FieldDesc);
            this.Controls.Add(this.txt_ViewDesc);
            this.Controls.Add(this.txt_FormDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_TableDesc);
            this.Controls.Add(this.lbl_entities);
            this.Controls.Add(this.lst_Entities);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "DescriptionFillerControl";
            this.Size = new System.Drawing.Size(667, 588);
            this.Load += new System.EventHandler(this.DescriptionFillerControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton btn_LoadEntities;
        private System.Windows.Forms.Label lbl_entities;
        private System.Windows.Forms.ListBox lst_Entities;
        private System.Windows.Forms.TextBox txt_TableDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_FormDesc;
        private System.Windows.Forms.TextBox txt_ViewDesc;
        private System.Windows.Forms.TextBox txt_FieldDesc;
        private System.Windows.Forms.CheckBox chk_Entity;
        private System.Windows.Forms.CheckBox chk_Forms;
        private System.Windows.Forms.CheckBox chk_Views;
        private System.Windows.Forms.CheckBox chk_Fields;
        private System.Windows.Forms.Button btn_Execute;
        private System.Windows.Forms.Label label3;
    }
}
