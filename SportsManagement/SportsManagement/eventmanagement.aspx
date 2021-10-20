<%@ Page Title="" Language="C#" MasterPageFile="~/Game.Master" AutoEventWireup="true" CodeBehind="eventmanagement.aspx.cs" Inherits="SportsManagement.eventmanagement" %>
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
                           <h4>Events Management</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/3.png" />
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <p class="font-weight-bold">- To add an event, please fill the form and press “<span class="text-primary">ADD</span>” </p>
                        <p class="font-weight-bold">- To edit an entry, type the event ID in the form and press go. After doing relevant changes press “<span class="text-warning">UPDATE</span>” </p>
                        <p class="font-weight-bold">- To delete an entry, type the event ID in the form and press go. After that press “<span class="text-danger">DELETE</span>” </p>
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
                              <asp:TextBox CssClass="form-control" ID="eventid" runat="server" placeholder="Event ID" ></asp:TextBox>
                              <asp:Button ID="go" class="btn btn-success" runat="server" Text="Go" OnClick="go_Click"   />
                           </div>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Game ID</label>
  
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                              <asp:ListItem Text="A1" Value="a1" />
                              <asp:ListItem Text="a2" Value="a2" />
                           </asp:DropDownList>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Feature Event</label>
  
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="featureevent" runat="server" placeholder="Feature Event"></asp:TextBox>
                        </div>
                     </div>
                       <div class="col-md-6">
                        <label>Event Venue</label>
  
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="eventvenue" runat="server" placeholder="Event Venue" ></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Event Date</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="eventdate" runat="server" placeholder="Event Date" TextMode="Date" OnTextChanged="eventdate_TextChanged"></asp:TextBox>
                           </div>
                        </div>
                      </div>
                     <div class="col-md-6">
                        <label>World Record</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                  <asp:ListItem Text="yes" Value="yes" />
                                  <asp:ListItem Text="no" Value="no" />
                              </asp:DropDownList>                          
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Start Time</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="starttime" runat="server" placeholder="Start Time" TextMode="Time"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>End Time</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="endtime" runat="server" placeholder="End Time" TextMode="Time"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                        <label>Event Description</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="eventdescription" runat="server" placeholder="event Description" TextMode="MultiLine"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Add" OnClick="Button2_Click"  />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click"   />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click"  />
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
                           <h4>Events Management List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [event]"></asp:SqlDataSource>
                          <asp:GridView class="table table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Event_ID" DataSourceID="SqlDataSource1" >
                              <Columns>
                                  <asp:BoundField DataField="Event_ID" HeaderText="Event_ID" ReadOnly="True" SortExpression="Event_ID" />
                                  <asp:BoundField DataField="Game_ID" HeaderText="Game_ID" SortExpression="Game_ID" />
                                  <asp:BoundField DataField="FeatureEvent" HeaderText="FeatureEvent" SortExpression="FeatureEvent" />
                                  <asp:BoundField DataField="EventVenue" HeaderText="EventVenue" SortExpression="EventVenue" />
                                  <asp:BoundField DataField="EventDate" HeaderText="EventDate" SortExpression="EventDate" />
                                  <asp:BoundField DataField="EventStartTime" HeaderText="EventStartTime" SortExpression="EventStartTime" />
                                  <asp:BoundField DataField="EventEndTime" HeaderText="EventEndTime" SortExpression="EventEndTime" />
                                  <asp:BoundField DataField="EventDescription" HeaderText="EventDescription" SortExpression="EventDescription" />
                                  <asp:BoundField DataField="WorldRecord" HeaderText="WorldRecord" SortExpression="WorldRecord" />
                              </Columns>
                          </asp:GridView>
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
