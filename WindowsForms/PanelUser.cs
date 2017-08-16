using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public class PanelUser:Panel
    {
        public delegate void PanelUserDeleteHandler(PanelUser me);

        public event PanelUserDeleteHandler panelUserDeleteEvent;

        private User _user;

        //----------------------Interface members------------------

        Label lblUserName = new Label() { Text = @"Name" };
        Label lblUserAge = new Label() { Text = @"Age" };
        Label lblUserBirthday = new Label() { Text = @"Birthday" };



        TextBox txtUserName = new TextBox();
        TextBox txtUserAge = new TextBox();
        TextBox txtUserBirthday = new TextBox();

        
        Button btnEdit = new Button() { Text = @"Edit" };
        Button btnDelete = new Button() { Text = @"Delete" };

        private int lblWidth = 50;
        private int txtWidth = 60;
        private int btnWidth = 70;
        private int padding = 5;

        private int controlHeight = 20;


        public User User
        {
            get { return _user; }
        }

        public PanelUser(ref User user):base()
        {
            _user = user;
            this.BorderStyle = BorderStyle.FixedSingle;
            CreateView();

            btnDelete.Click+=OnDeleteClick;

            txtUserName.Text = _user.UserName;
            txtUserAge.Text = _user.UserAge.ToString();
            txtUserBirthday.Text = _user.UserBirthday.ToString("d");
        }

        private void CreateView()
        {

            this.Size = new Size(0, controlHeight+4);

            //this.BackColor = Color.Aqua; //for testing

            AddControlHorizontally(lblUserName, lblWidth, controlHeight,padding);
            AddControlHorizontally(txtUserName, txtWidth,controlHeight, 0);

            AddControlHorizontally(lblUserAge, lblWidth,controlHeight, padding);
            AddControlHorizontally(txtUserAge, txtWidth,controlHeight, 0);

            AddControlHorizontally(lblUserBirthday, lblWidth, controlHeight,padding);
            AddControlHorizontally(txtUserBirthday, txtWidth, controlHeight,0);

            AddControlHorizontally(btnEdit, btnWidth, controlHeight,padding + 30);
            AddControlHorizontally(btnDelete, btnWidth, controlHeight,padding);

        }

        private void AddControlHorizontally(Control control, int controlWidth, int controlHeight, int padding)
        {
            Point locationPoint = new Point(0,2);
            if (this.Controls.Count > 0)
            {
                locationPoint = this.Controls[this.Controls.Count-1].Location;
                locationPoint.X += this.Controls[this.Controls.Count - 1].Width + padding;
            }

            control.Width = controlWidth;
            control.Height = controlHeight;
            control.Location = locationPoint;
            control.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.Controls.Add(control);
            this.Width += control.Width + padding;

        }

        private void OnDeleteClick(Object sender, EventArgs e)
        {
            panelUserDeleteEvent(this);
        }
    }
}
