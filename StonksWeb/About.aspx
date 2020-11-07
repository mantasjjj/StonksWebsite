<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="StonksWeb.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-fluid about-back">
      <div class="container">
        <h1 class="title"><%: Title %></h1>
        
      </div>
    </div>
    <div class="container-progress">
        <h2 class="smart-h2">About Us</h2>
        <p class="smart-p">
            We are a team of students trying to help people save as much money as possible.
            Our aim is to show people that they are spending to much on stuff that they do not need and could easily save up for their goals by just analyzing their spending habbits.
        </p>
    </div>
    <script src="Scripts/Main.js"></script>
</asp:Content>
