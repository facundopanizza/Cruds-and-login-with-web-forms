<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brands.aspx.cs" Inherits="WEBFORM.Brands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title col-md-9" style="margin-top: 8px">Brands</h3>
            <asp:Button runat="server" ID="createBrand" Text="Create Brand" OnClick="createBrand_OnClick" CssClass="btn btn-sm btn-primary col-md-2 col-md-offset-1" />
            <div class="clearfix"></div>
        </div>

        <div class="row" style="padding: 10px 10px 0px 10px">
            <div class="col-md-6 form-inline">
                <asp:TextBox runat="server" ID="searchTerm" CssClass="form-control"></asp:TextBox>
                <asp:Button runat="server" ID="search" CssClass="btn btn-primary" Text="Search" OnClick="search_OnClick"/>
            </div>
            <div class="col-md-3">
                <asp:Button runat="server" ID="orderByName" CssClass="btn btn-primary" Text="Order by Name" OnClick="orderByName_OnClick"/>
            </div>
        </div>

        <h3 class="text-danger" runat="server" ID="error"></h3>

        <div>
            <asp:GridView ID="GridBrands" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" HorizontalAlign="Center" PageSize="5">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id"/>
                    <asp:BoundField DataField="Name" HeaderText="Name"/>
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/EditBrand?id={0}" Text="Edit" ControlStyle-CssClass="btn btn-sm btn-info"/>
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/Brands?Delete={0}" Text="Delete" ControlStyle-CssClass="btn btn-sm btn-danger" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
