<%@ Page Title="" Language="C#" MasterPageFile="~/Game.Master" AutoEventWireup="true" CodeBehind="adminpage.aspx.cs" Inherits="SportsManagement.adminpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
        <div class="row mt-3">
            <div class="col-12 text-center mb-5">
                <h1 class="display-1 text-center font-weight-bold">Hello Admin!</h1>
            </div>
          
      </div>
       
        <div class="row">
            <div class="col-3">
                <div class="card">
                    <img class="card-img-top" src="imgs/admin-game.png" alt="Card image" style="width:100%">
                <div class="card-body">
                    
                        <h5 class="card-title">Game</h5>
                        <h5 class="card-title">Management</h5>
                        <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Go" OnClick="Button1_Click" />
                   
                    
                </div>
            </div>
            </div>
            <div class="col-3">
                <div class="card">
                    <img class="card-img-top" src="imgs/admin-competitor.png" alt="Card image" style="width:100%">
                <div class="card-body">
                    <h5 class="card-title">Competitor</h5>
                    <h5 class="card-title">Management</h5>
                    <asp:Button ID="Button2" runat="server" class="btn btn-success" Text="Go" OnClick="Button2_Click" />
                </div>
            </div>
            </div>
            <div class="col-3">
                <div class="card">
                    <img class="card-img-top" src="imgs/admin-event.png" alt="Card image" style="width:100%">
                <div class="card-body">
                    <h5 class="card-title">Event</h5>
                    <h5 class="card-title">Management</h5>
                    <asp:Button ID="Button3" runat="server" class="btn btn-success" Text="Go" OnClick="Button3_Click" />
                </div>
            </div>
            </div>
            <div class="col-3">
                <div class="card">
                    <img class="card-img-top" src="imgs/admin-report.png" alt="Card image" style="width:100%">
                <div class="card-body">
                    <h5 class="card-title">Report</h5>
                    <h5 class="card-title">Management</h5>
                    <asp:Button ID="Button4" runat="server" class="btn btn-success" Text="Go" OnClick="Button4_Click" />
                </div>
            </div>
            </div>
           
           
        </div>
        <div class="row mt-5">
            <div class="col-3">
                <div class="card">
                    <img class="card-img-top" src="imgs/admin-player.jpg" alt="Card image" style="width:100%">
                <div class="card-body">
                    
                        <h5 class="card-title">player</h5>
                        <h5 class="card-title">Performance</h5>
                        <asp:Button ID="Button5" runat="server" class="btn btn-success" Text="Go" OnClick="Button5_Click" />
                   
                    
                </div>
            </div>
            </div>
        </div>
    </div>
    
</asp:Content>
