<%@ Page Title="" Language="C#" MasterPageFile="~/Game.Master" AutoEventWireup="true" CodeBehind="loginmodule.aspx.cs" Inherits="SportsManagement.loginmodule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="150px" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Login Module</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>User Name</label>
  
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="useremail" runat="server" placeholder="User Name" OnTextChanged="useremail_TextChanged"></asp:TextBox>
                        </div>
                        <label>Password</label>
  
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="userpassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                         <label>User Type</label>
                        <div class="form-group">
                           <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">  
                               <asp:ListItem Value="Admin">Admin</asp:ListItem>
                               <asp:ListItem Value="Event Manager">Event Manager</asp:ListItem>  

                           </asp:DropDownList>
                        </div>
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"  />
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
