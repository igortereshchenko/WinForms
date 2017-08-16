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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        List<User> users = new List<User>();

        private void FormMain_Load(object sender, EventArgs e)
        {

            users.Add(new User("try1", DateTime.Today));
            users.Add( new User("try2", DateTime.Today.AddYears(-20)));
            users.Add(new User("try3", DateTime.Today.AddYears(-40)));

            

            ListPanelUser listPanelUser = new ListPanelUser();
            listPanelUser.SourceUsers = users;
            
            listPanelUser.Location = new Point(0,0);
            listPanelUser.Dock = DockStyle.Fill;
            this.tblLayoutMain.Controls.Add(listPanelUser,0,1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
