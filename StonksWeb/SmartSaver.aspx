<%@ Page Title="Smart Saver" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SmartSaver.aspx.cs" Inherits="StonksWeb.About" %>

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
        <h3 class="currentDate smart-h3">Current date:  <%: DateTime.Now.ToString("yyyy-M-dd") %></h3>
            <div class="row slider-margin">
                <div class="col-md-8">
                    <div class="slidecontainer">
                        <input type="range" min="1" max="100" value="50" class="slider" id="housing" style="margin-left: 0;"/>
                    </div>
                </div>
                <div class="col-md-3 smart-text__display">
                    <input type="text" class="smart-text"/>
                </div>
            </div>
            
            <div class="row slider-margin">
                <div class="col-md-8">
                    <div class="slidecontainer">
                        <input type="range" min="1" max="100" value="50" class="slider" id="groceries"/>
                    </div>
                </div>
                <div class="col-md-3 smart-text__display">
                    <input type="text" class="smart-text"/>
                </div>
            </div>

        <div class="row slider-margin">
                <div class="col-md-8">
                    <div class="slidecontainer">
                        <input type="range" min="1" max="100" value="50" class="slider" id="transportation"/>
                    </div>
                </div>
                <div class="col-md-3 smart-text__display">
                    <input type="text" class="smart-text"/>
                </div>
            </div>

        <div class="row slider-margin">
                <div class="col-md-8">
                    <div class="slidecontainer">
                        <input type="range" min="1" max="100" value="50" class="slider" id="entertainment"/>
                    </div>
                </div>
                <div class="col-md-3 smart-text__display">
                    <input type="text" class="smart-text"/>
                </div>
            </div>

        <div class="row slider-margin">
            <div class="col-md-8">
                <div class="slidecontainer">
                    <input type="range" min="1" max="100" value="50" class="slider" id="shopping"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <input type="text" class="smart-text"/>
            </div>
        </div>

        <div class="row slider-margin">
            <div class="col-md-8">
                <div class="slidecontainer">
                    <input type="range" min="1" max="100" value="50" class="slider" id="health"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <input type="text" class="smart-text"/>
            </div>
        </div>

        <div class="row slider-margin">
            <div class="col-md-8">
                <div class="slidecontainer">
                    <input type="range" min="1" max="100" value="50" class="slider" id="utilities"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <input type="text" class="smart-text"/>
            </div>
        </div>

        <div class="row slider-margin">
            <div class="col-md-8">
                <div class="slidecontainer">
                    <input type="range" min="1" max="100" value="50" class="slider" id="other"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <input type="text" class="smart-text"/>
            </div>
        </div>


    </div>
    <script src="Scripts/Main.js"></script>
</asp:Content>
