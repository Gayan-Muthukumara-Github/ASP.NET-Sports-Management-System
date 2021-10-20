<%@ Page Title="" Language="C#" MasterPageFile="~/Game.Master" AutoEventWireup="true" CodeBehind="gamemanagement.aspx.cs" Inherits="SportsManagement.gamemanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      $(document).ready(function () {
      
          //$(document).ready(function () {
              //$('.table').DataTable();
         // });
      
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
          //$('.table1').DataTable();
      });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row mb-5 mt-5">
         <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Game Management</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/2.png" />
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <p class="font-weight-bold">- To add a game, please fill the form and press “<span class="text-primary">ADD</span>” </p>
                        <p class="font-weight-bold">- To edit an entry, type the Game ID in the form and press go. After doing relevant changes press “<span class="text-warning">UPDATE</span>” </p>
                        <p class="font-weight-bold">- To delete an entry, type the Game ID in the form and press go. After that press “<span class="text-danger">DELETE</span>” </p>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-5">
                        <label>Game ID</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="gameid" runat="server" placeholder="ID"></asp:TextBox>
                              <asp:Button ID="go" class="btn btn-success" runat="server" Text="Go" OnClick="go_Click"  />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-7">
                        <label>Game Code</label>
  
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="gamecode" runat="server" placeholder="Game Code" OnTextChanged="gamecode_TextChanged" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter 4 Uppercase letter & 3 numbers " ControlToValidate="gamecode" ValidationExpression="^[A-Z]{4}[0-9]{3}$"></asp:RegularExpressionValidator>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Game Duration Hours</label>
  
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="gamedhours" runat="server" placeholder="Required" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                       <div class="col-md-12">
                        <label>Game Name</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="gamename" runat="server" placeholder="Game Name"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-12">
                        <label>Game Description</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="gamedescription" runat="server" placeholder="Required" TextMode="MultiLine"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Add" OnClick="Button2_Click"  />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click"  />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click" />
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <div class="row">
         <div class="col-md-12">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Game Management List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [game]"></asp:SqlDataSource>
                      <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Game_ID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                              <Columns>
                                  <asp:BoundField DataField="Game_ID" HeaderText="Game_ID" ReadOnly="True" SortExpression="Game_ID" />
                                  <asp:BoundField DataField="Game_Code" HeaderText="Game_Code" SortExpression="Game_Code" />
                                  <asp:BoundField DataField="Game_Name" HeaderText="Game_Name" SortExpression="Game_Name" />
                                  <asp:BoundField DataField="Game_DurationInHours" HeaderText="Game_DurationInHours" SortExpression="Game_DurationInHours" />
                                  <asp:BoundField DataField="Game_Description" HeaderText="Game_Description" SortExpression="Game_Description" />
                              </Columns>
                          </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <div class="row m-3">
            <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
        </div>
   </div>
</asp:Content>
