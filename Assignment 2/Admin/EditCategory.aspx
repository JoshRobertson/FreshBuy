<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="Assignment_2.Admin.EditCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row col-lg-5">
            <asp:Label runat="server" CssClass="label-info">Category Name: </asp:Label>
            <asp:TextBox runat="server" ID="categoryTextBox" CssClass="input-large"></asp:TextBox>   
        </div>
        <div class="row">
            <asp:Button runat="server" ID="submitButton" CssClass="btn btn-primary" OnClick="EditCat" Text="Update"/>
        </div>
    </div>

</asp:Content>
