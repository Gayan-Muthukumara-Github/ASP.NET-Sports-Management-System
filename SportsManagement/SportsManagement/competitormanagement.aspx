<%@ Page Title="" Language="C#" MasterPageFile="~/Game.Master" AutoEventWireup="true" CodeBehind="competitormanagement.aspx.cs" Inherits="SportsManagement.competitormanagement" %>
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
                           <h4>Competitors Management</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="imgs/1.png" />
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <p class="font-weight-bold">- To add a competitor, please fill the form and press “<span class="text-primary">ADD</span>” </p>
                        <p class="font-weight-bold">- To edit an entry, type the competitor ID in the form and press go. After doing relevant changes press “<span class="text-warning">UPDATE</span>” </p>
                        <p class="font-weight-bold">- To delete an entry, type the competitor ID in the form and press go. After that press “<span class="text-danger">DELETE</span>” </p>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Competitor ID</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="competitorid" runat="server" placeholder="Competitor ID" OnTextChanged="competitorid_TextChanged"></asp:TextBox>
                              <asp:Button ID="go" class="btn btn-success" runat="server" Text="Go" OnClick="go_Click"    />
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>First Name</label>
  
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="firstname" runat="server" placeholder="First Name"></asp:TextBox>
                        </div>
                     </div>
                       <div class="col-md-6">
                        <label>Surname</label>
  
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="surname" runat="server" placeholder="Surname" ></asp:TextBox>
                         </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>DOB</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="dob" runat="server" placeholder="DOB" TextMode="Date"></asp:TextBox>
                           </div>
                        </div>
                      </div>
                     <div class="col-md-6">
                        <label>Country</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="country" runat="server" placeholder="Country"></asp:TextBox>
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                        <label>Bio Details</label>
  
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox ID="bio" runat="server" CssClass="form-control" placeholder="Bio Details" server="" TextMode="MultiLine"></asp:TextBox>
                               
                           </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-primary" runat="server" Text="Add" OnClick="Button2_Click"   />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Button3_Click"    />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Button4_Click"   />
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
                           <h4>Competitors Management List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [competitor]"></asp:SqlDataSource>
                       <div class="col">
                          <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Competitor_ID" DataSourceID="SqlDataSource1" >
                                  <Columns>
                                      <asp:BoundField DataField="Competitor_ID" HeaderText="Competitor_ID" ReadOnly="True" SortExpression="Competitor_ID" />
                                      <asp:BoundField DataField="Competitor_FName" HeaderText="Competitor_FName" SortExpression="Competitor_FName" />
                                      <asp:BoundField DataField="Competitor_Surname" HeaderText="Competitor_Surname" SortExpression="Competitor_Surname" />
                                      <asp:BoundField DataField="Competitor_DOB" HeaderText="Competitor_DOB" SortExpression="Competitor_DOB" />
                                      <asp:BoundField DataField="Competitor_Country" HeaderText="Competitor_Country" SortExpression="Competitor_Country" />
                                      <asp:BoundField DataField="Competitor_Bio" HeaderText="Competitor_Bio" SortExpression="Competitor_Bio" />
                                  </Columns>
                              </asp:GridView>
                          </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <div class="row m-3">
            <asp:Button class="btn btn-primary btn-lg btn-block" ID="Button1" runat="server" Text="Back" OnClick="Button1_Click"  />
        </div>
   </div>
</asp:Content>
