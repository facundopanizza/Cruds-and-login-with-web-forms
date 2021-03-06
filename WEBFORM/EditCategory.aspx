﻿<%@ Page Title="Edit Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="WEBFORM.EditCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Edit Category</h3>
        </div>
        <div class="panel-body">
            <asp:TextBox runat="server" ID="categoryId" Visible="False"></asp:TextBox>
            <div class="form-group">
                <asp:Label runat="server" Text="Name"></asp:Label>
                <asp:TextBox runat="server" ID="name" CssClass="form-control"></asp:TextBox>
                <asp:Label runat="server" ID="lblError" CssClass="text-danger"></asp:Label>
            </div>
            <asp:Button runat="server" ID="button" OnClick="button_OnClick" Text="Edit Category" CssClass="btn btn-primary"/>
        </div>
    </div>
</asp:Content>
