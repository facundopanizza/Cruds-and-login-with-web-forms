<%@ Page Title="Create Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WEBFORM.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Login</h3>
        </div>
        <div class="panel-body">
            <h3 class="text-danger" runat="server" ID="error"></h3>
            <div class="form-group">
                <asp:Label runat="server" Text="Username"></asp:Label>
                <asp:TextBox runat="server" ID="username" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Password" ></asp:Label>
                <asp:TextBox runat="server" ID="password" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Confirm Password" ></asp:Label>
                <asp:TextBox runat="server" ID="confirmPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="button" OnClick="button_OnClick" Text="Register" CssClass="btn btn-primary"/>
        </div>
    </div>
</asp:Content>
