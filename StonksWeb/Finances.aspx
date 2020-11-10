<%@ Page Title="My Finances" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Finances.aspx.cs" Inherits="StonksWeb.Finances" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-fluid finances-back">
      <div class="container">
        <h1 class="title"><%: Title %></h1>
      </div>
    </div>
    <div class="container-finances">
        <h2 class="smart-h2">My Finances</h2>
        <p class="smart-p">
            In this section you can input your income and all of your expenses that will later be used in calculations and in the creation of your very own financial plan.
        </p>
        <div class="container-expenses">
            <div class="input-group input-group-lg">
              <div class="input-group-prepend">
                <span class="input-group-text" id="inputGroup-sizing-lg">My Income</span>
              </div>
              <asp:TextBox ID="TextBoxIncome" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"/>
            </div>
        </div>
        <div class="container-expenses">
            <div class="input-group input-group-lg">
              <div class="input-group-prepend">
                <span class="input-group-text" id="inputGroup-sizing-lg">Housing</span>
              </div>
              <asp:TextBox ID="TextBoxHousing" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"/>
            </div>
        </div>
        <div class="container-expenses">
            <div class="input-group input-group-lg">
              <div class="input-group-prepend">
                <span class="input-group-text" id="inputGroup-sizing-lg">Groceries</span>
              </div>
              <asp:TextBox ID="TextBoxGroceries" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"/>
            </div>
        </div>
        <div class="container-expenses">
            <div class="input-group input-group-lg">
              <div class="input-group-prepend">
                <span class="input-group-text" id="inputGroup-sizing-lg">Transportation</span>
              </div>
              <asp:TextBox ID="TextBoxTransportation" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"/>
            </div>

        </div>
        <div class="container-expenses">
            <div class="input-group input-group-lg">
              <div class="input-group-prepend">
                <span class="input-group-text" id="inputGroup-sizing-lg">Entertainment</span>
              </div>
              <asp:TextBox ID="TextBoxEntertainment" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"/>
            </div>
        </div>
        <div class="container-expenses">
            <div class="input-group input-group-lg">
              <div class="input-group-prepend">
                <span class="input-group-text" id="inputGroup-sizing-lg">Shopping</span>
              </div>
              <asp:TextBox ID="TextBoxShopping" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"/>
            </div>
        </div>
        <div class="container-expenses">
            <div class="input-group input-group-lg">
              <div class="input-group-prepend">
                <span class="input-group-text" id="inputGroup-sizing-lg">Health</span>
              </div>
              <asp:TextBox ID="TextBoxHealth" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"/>
            </div>
        </div>
        <div class="container-expenses">
            <div class="input-group input-group-lg">
              <div class="input-group-prepend">
                <span class="input-group-text" id="inputGroup-sizing-lg">Utilities</span>
              </div>
              <asp:TextBox ID="TextBoxUtilities" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"/>
            </div>
        </div>
        <div class="container-expenses">
            <div class="input-group input-group-lg">
              <div class="input-group-prepend">
                <span class="input-group-text" id="inputGroup-sizing-lg">Other</span>
              </div>
              <asp:TextBox ID="TextBoxOther" type="text" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" runat="server"/>
            </div>
        </div>

        <asp:Button ID="ButtonSave" class="btn btn-success"  OnClick="saveFinances" Text="Save Finances" runat="server"/>
    </div>
    <script src="Scripts/Main.js"></script>
</asp:Content>
