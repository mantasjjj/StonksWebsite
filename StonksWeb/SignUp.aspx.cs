using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StonksWeb
{
    public partial class SignUp : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            if (TextBoxName1.Text != "" && TextBoxName1.Text != "" && TextBoxEmail.Text != "" && TextBoxPassword.Text != "" && TextBoxPassword2.Text != "")
            {
                if (TextBoxPassword.Text == TextBoxPassword2.Text)
                {
                    var user = new User(TextBoxName1.Text, TextBoxName1.Text, TextBoxEmail.Text, TextBoxPassword.Text);
                    if (DBConnector.AddUser(user))
                    {
                        MessageBox.Show(this, "You have signed up. Login to use personalized Stonks saver.");
                    }
                    else
                    {
                        MessageBox.Show(this, "Sign up failed. Email already in use.");
                    }
                }
                else
                {
                    MessageBox.Show(this, "Sign up failed. Passwords do not match.");
                }
            }
            else
            {
                MessageBox.Show(this, "Sign up failed. Please fill in all fields.");
            }
        }
    }
}