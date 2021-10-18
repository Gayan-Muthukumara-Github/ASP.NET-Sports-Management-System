<%@ Page Title="" Language="C#" MasterPageFile="~/Game.Master" AutoEventWireup="true" CodeBehind="reportmanagement.aspx.cs" Inherits="SportsManagement.reportmanagement" %>
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
    <div class="row mb-5">
        <div class="col-12">
            <div class="card">
                <div class="card-body">
                        <div class="form-group">
                            <h4 class="text-center">View Details of Event</h4>
                            <div class="input-group">
                                <div class="col-6">
                                     <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Search By Event"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                     <asp:Button ID="Button3" class="btn  btn-block btn-danger" runat="server" Text="View" OnClick="Button3_Click"  />
                                </div> 
                            </div>
                        </div>
                    
                </div>
            </div>
       
    </div>  
    </div>
    <div class="row mb-5">
        <div class="col-12">
           
            <div class="card">
                <div class="card-body">
                   
                        <div class="form-group">
                            <h4 class="text-center">View Country’s Medals</h4>
                            <div class="input-group">
                                <div class="col-6">
                                     <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Search By Country"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                     <asp:Button ID="Button1" class="btn  btn-block btn-danger" runat="server" Text="View" OnClick="Button1_Click"  />
                                </div> 
                            </div>
                        </div>
                     </div>
                 
                </div>
        </div>
    </div>
    <div class="row mb-5">
        <div class="col-12">
            
            <div class="card">
                <div class="card-body">
                    
                        <div class="form-group">
                            <h4 class="text-center">View World Records achieved Game</h4>
                            <div class="input-group">
                                <div class="col-6">
                                     <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Search By Game"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                     <asp:Button ID="Button2" class="btn  btn-block btn-danger" runat="server" Text="View" OnClick="Button2_Click"  />
                                </div> 
                            </div>
                        </div>
                    
                  </div>
               </div>
      
        </div>
    </div>
    <div class="row mb-5">
        <div class="col-12">
            
            <div class="card">
                <div class="card-body">
                  
                        <div class="form-group">
                            <h4 class="text-center">View World Records achieved Country</h4>
                            <div class="input-group">
                                <div class="col-6">
                                     <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Search By Country"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                     <asp:Button ID="Button4" class="btn  btn-block btn-danger" runat="server" Text="View" OnClick="Button4_Click"  />
                                </div> 
                            </div>
                        </div>
                     </div>
                 
               </div>
        </div>
        
    </div>
    <div class="row mb-5">
        <div class="col-12">
            
            <div class="card">
                <div class="card-body">
                  
                        <div class="form-group">
                            <h4 class="text-center">View World Records achieved Country</h4>
                            <div class="input-group">
                                <div class="col-12">
                                    <asp:Button class="btn  btn-block btn-danger" ID="Button5" runat="server" Text="Button" OnClick="Button5_Click" />
                                </div> 
                            </div>
                        </div>
                     </div>
                 
               </div>
        </div>
        
    </div>
    <div class="row">
            <div class="col-12">
                <h2 class="text-center">Search Results</h2>
             </div>
     </div>
    <div class="row">
            <div class="col-12">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                <asp:GridView class="table table-bordered" ID="GridView1" runat="server"></asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SMS_DBConnectionString10 %>" SelectCommand="SELECT event_competition.Competitor_Medal, competitor.Competitor_FName, competitor.Competitor_Country FROM event_competition INNER JOIN competitor ON competitor.Competitor_ID = event_competition.Competitor_ID"></asp:SqlDataSource>
                <asp:GridView  class="table table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="Competitor_Medal" HeaderText="Competitor_Medal" SortExpression="Competitor_Medal" />
                    <asp:BoundField DataField="Competitor_FName" HeaderText="Competitor_FName" SortExpression="Competitor_FName" />
                    <asp:BoundField DataField="Competitor_Country" HeaderText="Competitor_Country" SortExpression="Competitor_Country" />
                </Columns>
                </asp:GridView>
             </div>
     </div>
</div>
</asp:Content>
