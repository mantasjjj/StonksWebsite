using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StonksWeb
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            if (TextBoxEmail.Text != "" && TextBoxPassword.Text != "")
            {
                var user = new User(TextBoxEmail.Text, TextBoxPassword.Text);
                if (DBConnector.LoggedInUser(user))
                {
                    MessageBox.Show(this, "You have logged in.");
                }
                else
                {
                    MessageBox.Show(this, "Log in failed. Incorrect email or password.");
                }
            }
            else
            {
                MessageBox.Show(this, "Log in failed. Please fill in all fields.");
            }
        }
    }
}