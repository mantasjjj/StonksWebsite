<%@ Page Title="Progress" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Progress.aspx.cs" Inherits="StonksWeb.Progress" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-fluid progress-back">
      <div class="container">
        <h1 class="title"><%: Title %></h1>
        
      </div>
    </div>
    <div class="container-progress">
        <h2 class="smart-h2">Track Your Progress</h2>
        <p class="smart-p">
            In this section you can track you monthly progress, analyze and improve your spending habbits. 
            You can also compare your monthly expenses with the current savings plan that you have selected.
        </p>
    </div>
    <script src="Scripts/Main.js"></script>
</asp:Content>
