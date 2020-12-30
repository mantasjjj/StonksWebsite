<%@ Page Title="Progress" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Progress.aspx.cs" Inherits="StonksWeb.Progress" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron jumbotron-fluid progress-back">
      <div class="container">
        <h1 class="title"><%: Title %></h1>
      </div>
    </div>
    <div class="container-progress">
        <h1 class="smart-h3">📈 Track Your Progress</h1>
        <p class="smart-p">
            In this section you can track you monthly progress, analyze and improve your spending habbits. 
            You can also compare your monthly expenses with the current savings plan that you have selected.
        </p>
        <div class="row" style="margin-bottom: 4%;">
            <div class="col-md-3">

                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

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
          
        <hr> </hr>

        <div ID="Advice" runat="server" class="advice">
            <h1 class="smart-h3">📗 Based on your data, may we offer you some advice on where to put your money?</h1>
            <p class="smart-p" style="margin-bottom: 5rem;">Our professionals are constantly trying to make your life better and that is why we are offering you some advice.</p>
            <div class="row">
                <h3 class="progress-h3 col-md-6 advice-text advice-h3">Money for making investments should be:</h3>
                <asp:TextBox runat="server" ID="AdviceTextBox" CssClass="col-md-2 advice-text"></asp:TextBox>
                <!-- Add a button or whatever that says whether the person already reached this goal or not -->
                <div class="col-md-3">
                    <div ID="Reached" runat="server" visible="false">
                         <i class="fas fa-check-circle" style="color: green;"></i>
                    </div>
                    <div ID="NotReached" runat="server" visible="false">
                         <i class="fas fa-times" style="color: red;"></i>
                    </div>
                </div>
            </div>
            <div class="row">
                <h3 class="progress-h3 col-md-6 advice-text advice-h3">Your monthly expenses should be:</h3>
                <asp:TextBox runat="server" ID="ExpenseTextBox" CssClass="col-md-2 advice-text"></asp:TextBox>
                <div class="col-md-3">
                    <div ID="Div1" runat="server" visible="false">
                         <i class="fas fa-check-circle" style="color: green;"></i>
                    </div>
                    <div ID="Div2" runat="server" visible="false">
                         <i class="fas fa-times" style="color: red;"></i>
                    </div>
                </div>
            </div>
            <div class="row">
                <h3 class="progress-h3 col-md-6 advice-text advice-h3">What you should have in savings:</h3>
                <asp:TextBox runat="server" ID="SaveTextBox" CssClass="col-md-2 advice-text"></asp:TextBox>
                <div class="col-md-3">
                    <div ID="Div3" runat="server" visible="false">
                         <i class="fas fa-check-circle" style="color: green;"></i>
                    </div>
                    <div ID="Div4" runat="server" visible="false">
                         <i class="fas fa-times" style="color: red;"></i>
                    </div>
                </div>
            </div>
        </div>

        <hr> </hr>

        <div ID="PotencialScore" runat="server" visible="false">
            <h1 ID="InvestingText" class="smart-h3" runat="server"></h1>
            <p class="smart-p" style="margin-bottom: 5rem;">We already did the math and here are the results :)</p>
            <div class="row">
                 <h3 class="progress-h3 col-md-8 advice-text advice-h3">What you would have if you saved and haven't invested in 10 years:</h3>
                 <asp:TextBox ID="SavedMoney" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
                 <h3 class="progress-h3 col-md-8 advice-text advice-h3">What you would have if you had been investing for 10 years:</h3>
                 <asp:TextBox ID="Score" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
            </div>
            <hr style="margin-top: 3rem;"> </hr>
        </div>

        <div id="Recommended" runat="server" visible="false">
            <h1 class="smart-h3" runat="server">💳 What and how your monthly expenses should look like</h1>
            <p class="smart-p" style="margin-bottom: 5rem;">We noticed that you did not reach the recommended spending mark, so we though we could give you a helping hand. This is how your expenses should look like, based on your income.</p>
            <div class="row">
                <div class="col-md-12 prog-rec">
                     <h3 class="progress-h3 col-md-3 advice-text advice-h3">Housing:</h3>
                    <asp:TextBox ID="House" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
                </div>
                <div class="col-md-12 prog-rec">
                     <h3 class="progress-h3 col-md-3 advice-text advice-h3">Groceries:</h3>
                     <asp:TextBox ID="Food" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
                 </div>
                <div class="col-md-12 prog-rec">
                     <h3 class="progress-h3 col-md-3 advice-text advice-h3">Transport:</h3>
                     <asp:TextBox ID="Transport" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
                 </div>
                 <div class="col-md-12 prog-rec">
                    <h3 class="progress-h3 col-md-3 advice-text advice-h3">Entertainment:</h3>
                    <asp:TextBox ID="Entertain" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
                 </div>
                 <div class="col-md-12 prog-rec">
                     <h3 class="progress-h3 col-md-3 advice-text advice-h3">Shopping:</h3>
                    <asp:TextBox ID="Shop" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
                 </div>
                <div class="col-md-12 prog-rec">
                     <h3 class="progress-h3 col-md-3 advice-text advice-h3">Health:</h3>
                    <asp:TextBox ID="Health" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
                 </div>
                 <div class="col-md-12 prog-rec">
                    <h3 class="progress-h3 col-md-3 advice-text advice-h3">Utilities:</h3>
                    <asp:TextBox ID="Utilities" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
                 </div>
                 <div class="col-md-12 prog-rec">
                     <h3 class="progress-h3 col-md-3 advice-text advice-h3">Other:</h3>
                     <asp:TextBox ID="Other" runat="server" CssClass="col-md-3 advice-text"></asp:TextBox>
                 </div>
            </div>
            <hr style="margin-top: 3rem;"> </hr>
        </div>

        <h1 class="smart-h3">Your monthly expense chart</h1>
        
        <asp:Chart ID="chartPlanned" runat="server" Height="500px" Palette="SemiTransparent" Width="624px" >
            <series>
                <asp:Series Name="Monthly Expenses" Legend="Legend1" XValueType="String">
                </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea" AlignmentOrientation="None">
                    </asp:ChartArea>
                </chartareas>
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
         </asp:Chart>
        <hr style="margin-top: 0rem;"> </hr>
        <div id="References" runat="server" visible="true" style="margin-bottom: 3%;">
            <h1 class="smart-h3">References</h1>
            <a href="https://www.investopedia.com/articles/personal-finance/022216/i-make-50k-year-how-much-should-i-invest.asp#:~:text=Lock%20in%20a%20Percentage%20of,amount%20for%20your%20income%20level.">How much should you invest: Investopedia</a> </br>
            <a href="https://www.thebalance.com/the-50-30-20-rule-of-thumb-453922#:~:text=The%20rule%20divides%20your%20spending,20%25%20toward%20debt%20and%20savings.">How much should you spend and save: The Balance</a> </br>
            <a href="https://www.bankrate.com/calculators/savings/compound-savings-calculator-tool.aspx">Formula for investing with monthly contributions: Bankrate</a> </br>
        </div>
    </div>
    <script src="https://kit.fontawesome.com/496b21e0f9.js" crossorigin="anonymous"></script>

</asp:Content>
