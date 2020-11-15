<%@ Page Title="Smart Saver" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SmartSaver.aspx.cs" Inherits="StonksWeb.SmartSaver" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-fluid smart-back">
      <div class="container">
        <h1 class="title"><%: Title %></h1>
        
      </div>
    </div>
    <div class="container-smart">
        <h2 class="smart-h2">Save for the Future</h2>
        <p class="smart-p">
            The first step to saving for short- and long-term goals is to identify the amount you need to save and when you need the funds. 
            Use our calculator to determine how much to save each month toward your goal.
        </p>
        <div class="row" style="margin-bottom: 2%;">
            <div class="col-md-4">
                <h3 class="smart-h3">
                    Income: <p class="smart-p" runat="server" id="Income">0.00</p>
                </h3>
            </div>
            <div class="col-md-4">
                <h3 class="smart-h3">
                    Savings: <p class="smart-p" runat="server" id="Savings">0.00</p>
                </h3>
            </div>
            <div class="col-md-4">
                <h3 class="smart-h3">
                    Spendings: <p class="smart-p" runat="server" id="Spendings">0.00</p>
                </h3>
            </div>
        </div>
        <h3 class="currentDate smart-h3">Current date:  <%: DateTime.Now.ToString("yyyy-M-dd") %></h3>
            <div class="row slider-margin">
                <div class="col-md-8">
                    <div class="slidecontainer">
                        <input type="range" min="1" max="100" value="50" class="slider" runat="server" id="Housing" style="margin-left: 0;" />
                    </div>
                </div>
                <div class="col-md-3 smart-text__display">
                    <asp:TextBox ID="TextBoxHousing" type="text" class="smart-text" runat="server"></asp:TextBox>
                </div>
            </div>
            
            <div class="row slider-margin">
                <div class="col-md-8">
                    <div class="slidecontainer">
                        <input type="range" min="1" max="100" value="50" class="slider" runat="server" id="Groceries"/>
                    </div>
                </div>
                <div class="col-md-3 smart-text__display">
                    <asp:TextBox ID="TextBoxGroceries" type="text" class="smart-text" runat="server"></asp:TextBox>
                </div>
            </div>

        <div class="row slider-margin">
                <div class="col-md-8">
                    <div class="slidecontainer">
                        <input type="range" min="1" max="100" value="50" runat="server" class="slider" id="Transportation"/>
                    </div>
                </div>
                <div class="col-md-3 smart-text__display">
                    <asp:TextBox ID="TextBoxTransportation" type="text" class="smart-text" runat="server"></asp:TextBox>
                </div>
            </div>

        <div class="row slider-margin">
                <div class="col-md-8">
                    <div class="slidecontainer">
                        <input type="range" min="1" max="100" value="50" runat="server" class="slider" id="Entertainment"/>
                    </div>
                </div>
                <div class="col-md-3 smart-text__display">
                    <asp:TextBox ID="TextBoxEntertainment" type="text" class="smart-text" runat="server"></asp:TextBox>
                </div>
            </div>

        <div class="row slider-margin">
            <div class="col-md-8">
                <div class="slidecontainer">
                    <input type="range" min="1" max="100" value="50" runat="server" class="slider" id="Shopping"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxShopping" type="text" class="smart-text" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row slider-margin">
            <div class="col-md-8">
                <div class="slidecontainer">
                    <input type="range" min="1" max="100" value="50" runat="server" class="slider" id="Health"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxHealth" type="text" class="smart-text" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row slider-margin">
            <div class="col-md-8">
                <div class="slidecontainer">
                    <input type="range" min="1" max="100" value="50" runat="server" class="slider" id="Utilities"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxUtilities" type="text" class="smart-text" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row slider-margin">
            <div class="col-md-8">
                <div class="slidecontainer">
                    <input type="range" min="1" max="100" value="50" runat="server" class="slider" id="Other"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxOther" type="text" class="smart-text" runat="server"></asp:TextBox>
            </div>
        </div>

        <asp:Button ID="ButtonSave" runat="server" type="submit" class="btn btn-success btn-login" Text="Save Plan"/>
        <asp:Button ID="ButtonLogin" runat="server" type="submit" class="btn btn-primary btn-login" Text="Add A Goal"/>

        <div class="goals">

        </div>

    </div>
    <script src="Scripts/Main.js"></script>
</asp:Content>
