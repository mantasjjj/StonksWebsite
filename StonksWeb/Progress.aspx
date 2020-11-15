<%@ Page Title="Progress" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Progress.aspx.cs" Inherits="StonksWeb.Progress" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
        <div class="row" style="margin-bottom: 4%;">
            <div class="col-md-3">

            </div>
            <div class="col-md-3">
                <h3 class="smart-h3">
                    Income: <p class="smart-p" runat="server" id="Income">0.00</p>
                </h3>
            </div>
            <div class="col-md-3">
                <h3 class="smart-h3">
                    Spendings: <p class="smart-p" runat="server" id="Spendings">0.00</p>
                </h3>
            </div>
        </div>
          
        <h2 class="smart-h2">Your monthly expense chart</h2>
        <asp:Chart ID="chartPlanned" runat="server" Height="500px" Palette="SemiTransparent" Width="624px">
            <series>
                <asp:Series Name="Monthly Expenses" Legend="Legend1">
                </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea">
                    </asp:ChartArea>
                </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
            </asp:Chart>
    </div>

</asp:Content>
