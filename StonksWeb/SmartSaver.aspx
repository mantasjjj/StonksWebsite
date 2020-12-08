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
        <h3 class="smart-expenses-text smart-h3">Your Expenses:</h3>
        <div class="row" style="margin-bottom: 2%;">
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-5">
                <h3 class="smart-h3">
                    Planned values / Actual values
                </h3>
            </div>
        </div>
        <div class="row slider-margin">
            <div class="col-md-1">
                <i class="fas fa-home icons" title="Housing"></i>
            </div>
            <div class="col-md-5">
                <div class="slidecontainer">
                    <input type="range" min="0" max="100" value="50" runat="server" class="slider" id="HousingSlider" style="margin-left: 0;" oninput="updateTextBoxHousing(this.value);"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxHousing" type="text" class="smart-text" runat="server" Text="50"></asp:TextBox>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxHousingActual" type="text" class="smart-text smart-text-actual" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <script>
            function updateTextBoxHousing(val)
            {
                document.getElementById("<%=TextBoxHousing.ClientID%>").value=val; 
            }
        </script>
            
        <div class="row slider-margin">
            <div class="col-md-1">
               <i class="fas fa-utensils icons" title="Groceries"></i>
            </div>
            <div class="col-md-5">
                <div class="slidecontainer">
                    <input type="range" min="0" max="100" value="50" runat="server" class="slider" id="GroceriesSlider" style="margin-left: 0;" oninput="updateTextBoxGroceries(this.value);"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxGroceries" type="text" class="smart-text" runat="server" Text="50"></asp:TextBox>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxGroceriesActual" type="text" class="smart-text smart-text-actual" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <script>
            function updateTextBoxGroceries(val)
            {
                document.getElementById("<%=TextBoxGroceries.ClientID%>").value=val; 
            }
        </script>

        <div class="row slider-margin">
            <div class="col-md-1">
                <i class="fas fa-car icons" title="Transportation"></i>
            </div>
            <div class="col-md-5">
                <div class="slidecontainer">
                    <input type="range" min="0" max="100" value="50" runat="server" class="slider" id="TransportationSlider" style="margin-left: 0;" oninput="updateTextBoxTransportation(this.value);"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxTransportation" type="text" class="smart-text" runat="server" Text="50"></asp:TextBox>
            </div>
        <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxTransportationActual" type="text" class="smart-text smart-text-actual" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <script>
            function updateTextBoxTransportation(val)
            {
                document.getElementById("<%=TextBoxTransportation.ClientID%>").value=val; 
            }
        </script>

        <div class="row slider-margin">
            <div class="col-md-1">
               <i class="fas fa-table-tennis icons" title="Entertainment"></i>
            </div>
            <div class="col-md-5">
                <div class="slidecontainer">
                    <input type="range" min="0" max="100" value="50" runat="server" class="slider" id="EntertainmentSlider" style="margin-left: 0;" oninput="updateTextBoxEntertainment(this.value);"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxEntertainment" type="text" class="smart-text" runat="server" Text="50"></asp:TextBox>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxEntertainmentActual" type="text" class="smart-text smart-text-actual" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <script>
            function updateTextBoxEntertainment(val)
            {
                document.getElementById("<%=TextBoxEntertainment.ClientID%>").value=val; 
            }
        </script>

        <div class="row slider-margin">
            <div class="col-md-1">
               <i class="fas fa-shopping-cart icons" title="Shopping"></i>
            </div>
            <div class="col-md-5">
                <div class="slidecontainer">
                    <input type="range" min="0" max="100" value="50" runat="server" class="slider" id="ShoppingSlider" style="margin-left: 0;" oninput="updateTextBoxShopping(this.value);"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxShopping" type="text" class="smart-text" runat="server" Text="50"></asp:TextBox>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxShoppingActual" type="text" class="smart-text smart-text-actual" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <script>
            function updateTextBoxShopping(val)
            {
                document.getElementById("<%=TextBoxShopping.ClientID%>").value=val; 
            }
        </script>

        <div class="row slider-margin">
            <div class="col-md-1">
                <i class="fas fa-heartbeat icons" title="Health"></i>
            </div>
            <div class="col-md-5">
                <div class="slidecontainer">
                    <input type="range" min="0" max="100" value="50" runat="server" class="slider" id="HealthSlider" style="margin-left: 0;" oninput="updateTextBoxHealth(this.value);"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxHealth" type="text" class="smart-text" runat="server" Text="50"></asp:TextBox>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxHealthActual" type="text" class="smart-text smart-text-actual" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <script>
            function updateTextBoxHealth(val)
            {
                document.getElementById("<%=TextBoxHealth.ClientID%>").value=val; 
            }
        </script>

        <div class="row slider-margin">
            <div class="col-md-1">
               <i class="fas fa-wrench icons" title="Utilities"></i>
            </div>
            <div class="col-md-5">
                <div class="slidecontainer">
                    <input type="range" min="0" max="100" value="50" runat="server" class="slider" id="UtilitiesSlider" style="margin-left: 0;" oninput="updateTextBoxUtilities(this.value);"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxUtilities" type="text" class="smart-text" runat="server" Text="50"></asp:TextBox>
            </div>
            <div class="col-md-3 smart-text__display">
               <asp:TextBox ID="TextBoxUtilitiesActual" type="text" class="smart-text smart-text-actual" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <script>
            function updateTextBoxUtilities(val)
            {
                document.getElementById("<%=TextBoxUtilities.ClientID%>").value=val; 
            }
        </script>

        <div class="row slider-margin">
            <div class="col-md-1">
                <i class="fas fa-align-justify icons" title="Other"></i>
            </div>
            <div class="col-md-5">
                <div class="slidecontainer">
                    <input type="range" min="0" max="100" value="50" runat="server" class="slider" id="OtherSlider" style="margin-left: 0;" oninput="updateTextBoxOther(this.value);"/>
                </div>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxOther" type="text" class="smart-text" runat="server" Text="50"></asp:TextBox>
            </div>
            <div class="col-md-3 smart-text__display">
                <asp:TextBox ID="TextBoxOtherActual" type="text" class="smart-text smart-text-actual" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
        <script>
            function updateTextBoxOther(val)
            {
                document.getElementById("<%=TextBoxOther.ClientID%>").value=val; 
            }
        </script>

        <asp:Button ID="ButtonSave" runat="server" type="submit" class="btn btn-success btn-login" Text="Save Plan" OnClick="SavePlan"/>
      <!--  <asp:Button ID="ButtonLogin" runat="server" type="submit" class="btn btn-primary btn-login" Text="Add A Goal" data-toggle="modal" data-target="#exampleModal"/> -->


        <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary btn-login" data-toggle="modal" data-target="#staticBackdrop">
          Add a Goal
        </button>

        <div class="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="staticBackdropLabel">Add a goal</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
             <div class="modal-body container-progress">
                <div class="form-group">
                    <label>Goal Name</label>
                    <asp:TextBox ID="TextBoxGoalName" type="text" class="form-control" runat="server"></asp:TextBox>
                  </div>
                 <div class="form-group">
                    <label>Goal Price</label>
                    <asp:TextBox ID="TextBoxGoalPrice" type="text" class="form-control" runat="server"></asp:TextBox>
                  </div>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal" style="margin-bottom: 0;">Close</button>
                <asp:Button type="button" ID="ButtonAddGoal" class="btn btn-primary" runat="server" Text="Add a goal" OnClick="AddGoal"/>
              </div>
            </div>
          </div>
        </div>

        <div class="goals">
            <h3 class="smart-h3">Your Goals:</h3>
            <asp:Button type="button" ID="ButtonSetGoal" class="btn btn-primary" runat="server" Text="Update Goals" OnClick="SetGoalValue"/>
            <asp:Repeater ID="RepeaterGoals" runat="server" SelectMethod="rptCustomer_GetData" ItemType="StonksWeb.FinancialGoalInfo">
                <ItemTemplate>
                    <div class="goal">
                        <!-- Goal 1st row, used for goal name, price and slider -->
                        <div class="row slider-margin">
                            <div class="col-md-3 smart-text__display">
                                <asp:TextBox ID="TextBoxName" type="text" class="smart-text smart-goal-text" runat="server" ReadOnly="true" Text="<%# Item.Name %>"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <div class="slidecontainer">
                                    <input type="range" min="1" max="<%# Item.Value %>" value="<%# Item.Funds %>" runat="server" class="slider" id="Slider" style="margin-left: 0;"/>
                                </div>
                            </div>
                            <div class="col-md-3 smart-text__display">
                                <asp:TextBox ID="TextBoxValue" type="text" class="smart-text" runat="server" Text="<%# Item.Funds %>"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Goal 2nd row, used for goal deadline, the display of how much time is left to achieve the goal -->
                        <div class="row slider-margin">
                            <div class="col-md-3 smart-text__display">
                                <asp:TextBox ID="TextBoxDeadline" type="text" class="smart-text smart-goal-text goal-info-text" runat="server" ReadOnly="true" Text="Goal deadline:"></asp:TextBox>
                            </div>
                            <div class="col-md-3 smart-text__display">
                                <asp:TextBox ID="TextBoxDeadlineVal" type="text" class="smart-text smart-goal-text" runat="server" ReadOnly="true" Text="<%# Item.Deadline %>"></asp:TextBox>
                            </div>
                            <div class="col-md-3 smart-text__display">
                                <asp:TextBox ID="TextBoxReachedIn" type="text" class="smart-text smart-goal-text goal-info-text" runat="server" ReadOnly="true" Text="Goal will be reached in:"></asp:TextBox>
                            </div>
                            <div class="col-md-3 smart-text__display">
                                <asp:TextBox ID="TextBoxReachedInVal" type="text" class="smart-text smart-goal-text" runat="server" ReadOnly="true" Text="<%# Item.TimeToDeadline %>"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button type="button" ID="ButtonDeleteGoal" class="btn btn-primary" runat="server" Text="Delete Goal" OnClick="DeleteGoal"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        
</div>
<script src="https://kit.fontawesome.com/496b21e0f9.js" crossorigin="anonymous"></script>
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ho+j7jyWK8fNQe+A12Hb8AhRq26LrZ/JpcUGGOn+Y7RsweNrtN/tE3MoK7ZeZDyx" crossorigin="anonymous"></script>
</asp:Content>
