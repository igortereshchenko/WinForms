using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class ListPanelUser:Panel
    {
        private List<User> _sourceUsers;

        public ListPanelUser():base()
        {
            this.AutoScroll = true;
        }


        public List<User> SourceUsers
        {
            get { return _sourceUsers; }
            set
            {
                _sourceUsers = value;
                Refresh();

            }
        }

        public void Refresh()
        {
            for (int i = 0; i < _sourceUsers.Count; i++)
            {
                User user = _sourceUsers[i];
                PanelUser panel = new PanelUser(ref user);
                AddUserPanel(panel);
            }
        }

        private void AddUserPanel(PanelUser panel)
        {
            Point location = new Point(0, 0);
            if (this.Controls.Count > 0)
            {
                Control lastControl = this.Controls[this.Controls.Count - 1];
                location.Y += lastControl.Location.Y + lastControl.Height;
            }
            panel.Location = location;
            this.Controls.Add(panel);

            panel.panelUserDeleteEvent += onDeleteUserPanel;
        }

        public void onDeleteUserPanel(PanelUser panelToDelete)
        {
            this.Controls.Remove(panelToDelete);

            this._sourceUsers.Remove(panelToDelete.User);

            // reordering

            for (int i = 0; i < this.Controls.Count; i++)
            {
                Control currentControl = this.Controls[i];
               
                Point location = new Point(0,0);
                if (i > 0)
                {
                    Control previousControl = this.Controls[i - 1];
                    location.Y += previousControl.Location.Y + previousControl.Height;
                }

                currentControl.Location = location;
            }
        }
    }
}
