<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="StonksWeb.SignUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container-login">
        <h2 class="login-h2">Sign Up</h2>
        <form>
           <div class="form-group">
            <label for="InputName2">First Name</label>
            <asp:TextBox ID="TextBoxName1" type="text" class="form-control" runat="server"></asp:TextBox>
          </div>
           <div class="form-group">
            <label for="InputName2">Last Name</label>
            <asp:TextBox ID="TextBoxName2" type="text" class="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="InputEmail">Email address</label>
            <asp:TextBox ID="TextBoxEmail" type="email" class="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="InputPassword1">Password</label>
            <asp:TextBox ID="TextBoxPassword" type="password" class="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="InputPassword2">Confirm Password</label>
            <asp:TextBox ID="TextBoxPassword2" type="password" class="form-control"  runat="server"></asp:TextBox>
          </div>
          <asp:Button ID="ButtonLogin" runat="server" type="submit" class="btn btn-primary btn-login" Text="Sign Up"/>
         <button type="button" class="btn btn-info"><a href="Login.aspx" class="login-sign">Log in</a>
        </form>
    </div>
    <script src="Scripts/Main.js"></script>
</asp:Content>
