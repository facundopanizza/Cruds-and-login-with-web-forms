﻿<%@ Page Title="Create Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="WEBFORM.CreateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Create Product</h3>
        </div>
        <div class="panel-body">
            <h3 class="text-danger" runat="server" ID="error"></h3>
            <div class="form-group">
                <asp:Label runat="server" Text="Name"></asp:Label>
                <asp:TextBox runat="server" ID="name" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Price"></asp:Label>
                <asp:TextBox runat="server" ID="price" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Brand"></asp:Label>
                <asp:DropDownList CssClass="form-control" ID="brand" DataTextField="Name" DataValueField="Id" runat="server">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label runat="server" Text="Category"></asp:Label>
                <asp:DropDownList CssClass="form-control" ID="category" DataTextField="Name" DataValueField="Id" runat="server">
                </asp:DropDownList>
            </div>
            <div class="checkbox">
                <label>
                    <asp:CheckBox CssClass="checkbox" ID="isAvailable" runat="server" /> Is Available
                </label>
            </div>
            <asp:Button runat="server" ID="button" OnClick="button_OnClick" Text="Create Product" CssClass="btn btn-primary"/>
        </div>
    </div>
</asp:Content>
