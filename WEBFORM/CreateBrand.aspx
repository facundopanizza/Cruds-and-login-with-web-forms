﻿<%@ Page Title="Create Brand" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateBrand.aspx.cs" Inherits="WEBFORM.CreateBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Create Brand</h3>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <asp:Label runat="server" Text="Name"></asp:Label>
                <asp:TextBox runat="server" ID="name" CssClass="form-control"></asp:TextBox>
                <asp:Label runat="server" ID="lblError" CssClass="text-danger"></asp:Label>
            </div>
            <asp:Button runat="server" ID="button" OnClick="button_OnClick" Text="Create Brand" CssClass="btn btn-primary"/>
        </div>
    </div>
</asp:Content>
