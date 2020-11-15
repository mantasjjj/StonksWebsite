<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StonksWeb.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-login">
        <h2 class="login-h2">Login</h2>
        <form>
          <div class="form-group">
            <label for="exampleInputEmail1">Email address</label>
            <asp:TextBox ID="TextBoxEmail" type="email" class="form-control"  runat="server"></asp:TextBox>
          </div>
          <div class="form-group">
            <label>Password</label>
            <asp:TextBox ID="TextBoxPassword" type="password" class="form-control"  runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="ButtonLogin" runat="server" type="submit" class="btn btn-primary btn-login" Text="Log in"/>

        <button type="button" class="btn btn-info"><a href="SignUp.aspx" class="login-sign">Sign Up</a></button>
        </form>
    </div>
    <script src="Scripts/Main.js"></script>
</asp:Content>
