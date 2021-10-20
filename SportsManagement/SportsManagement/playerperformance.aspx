<%@ Page Title="" Language="C#" MasterPageFile="~/Game.Master" AutoEventWireup="true" CodeBehind="playerperformance.aspx.cs" Inherits="SportsManagement.playerperformance" %>
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
                           <h4>Player Performance</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/player.png" />
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
                     <div class="col-md-6">
                        <label>Event ID</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                  <asp:ListItem  Text="Gold" value="g"/>
                                  <asp:ListItem  Text="Silver" value="s"/>
                                  <asp:ListItem  Text="Bronze" value="b" />
                                  <asp:ListItem  Text="No" value="n" />
                           </asp:DropDownList>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Competitor ID</label>
  
                        <div class="form-group">
                          <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                              <asp:ListItem  Text="Gold" value="g"/>
                              <asp:ListItem  Text="Silver" value="s"/>
                              <asp:ListItem  Text="Bronze" value="b" />
                              <asp:ListItem  Text="No" value="n" />
                           </asp:DropDownList>
                           
                        </div>
                     </div>
                  </div>
                   <div class="row">
                       <div class="col-12">
                               <asp:Button ID="go" class="btn btn-success" runat="server" Text="Go" OnClick="go_Click"   />
                       </div>
                   </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Competitor Position</label>
  
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="position" runat="server" placeholder="Position" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-6">
                        <label>Competitor Medal</label>
  
                        <div class="form-group">
                            <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                              <asp:ListItem  Text="Gold" value="Gold"/>
                              <asp:ListItem  Text="Silver" value="Silver"/>
                              <asp:ListItem  Text="Bronze" value="Bronze" />
                              <asp:ListItem  Text="No" value="No" />
                           </asp:DropDownList>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Add" OnClick="Button2_Click"   />
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
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [event_competition]"></asp:SqlDataSource>
                      <div class="col">
                          <asp:GridView class="table table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Event_ID,Competitor_ID" DataSourceID="SqlDataSource1">
                              <Columns>
                                  <asp:BoundField DataField="Event_ID" HeaderText="Event_ID" ReadOnly="True" SortExpression="Event_ID" />
                                  <asp:BoundField DataField="Competitor_ID" HeaderText="Competitor_ID" ReadOnly="True" SortExpression="Competitor_ID" />
                                  <asp:BoundField DataField="Competitor_Position" HeaderText="Competitor_Position" SortExpression="Competitor_Position" />
                                  <asp:BoundField DataField="Competitor_Medal" HeaderText="Competitor_Medal" SortExpression="Competitor_Medal" />
                              </Columns>
                          </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <div class="row m-3">
            <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button1" runat="server" Text="Back"  />
        </div>
   </div>
</asp:Content>
