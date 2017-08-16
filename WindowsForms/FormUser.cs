using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class FormUser : Form
    {
        private User _user;
        private FormUserType _type;

        
        public FormUser(ref User  user, FormUserType type)
        {
            InitializeComponent();
            _user = user;
            _type = type;

            txtUserName.Text = _user.UserName;
            dtpUserBirthday.Value = _user.UserBirthday;
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            if (_type.formType == FormUserType.NEW.formType)
            {
                txtUserName.ReadOnly = false;
                dtpUserBirthday.Enabled = true;

                btnAccept.Click += onNewUser;
                btnAccept.Text = "Save";
                return;
            }

            if (_type.formType == FormUserType.EDIT.formType)
            {
                txtUserName.ReadOnly = false;
                dtpUserBirthday.Enabled = true;

                btnAccept.Click += onEditUser;
                btnAccept.Text = "Save";
                return;
            }

            if (_type.formType == FormUserType.DELETE.formType)
            {
                txtUserName.ReadOnly = true;
                dtpUserBirthday.Enabled = false;
                btnAccept.BackColor=Color.DarkRed;

                btnAccept.Click += onDeleteUser;
                return;
            }

        }

        private void onDeleteUser(object sender, EventArgs e)
        {
            this.DialogResult = MessageBox.Show("Are you sure?", "User deleting", MessageBoxButtons.OKCancel);
            this.Close();
        }

        private void onNewUser(object sender, EventArgs e)
        {
            _user.UserName = txtUserName.Text;
            _user.UserBirthday = dtpUserBirthday.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void onEditUser(object sender, EventArgs e)
        {
            _user.UserName = txtUserName.Text;
            _user.UserBirthday = dtpUserBirthday.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }


    public sealed class FormUserType
    {
        public static readonly FormUserType EDIT = new FormUserType("Edit");
        public static readonly FormUserType DELETE = new FormUserType("Delete");
        public static readonly FormUserType NEW = new FormUserType("New");

        public readonly string formType;

        private FormUserType(string formType)
        {
            this.formType = formType;
        }
    }
}
