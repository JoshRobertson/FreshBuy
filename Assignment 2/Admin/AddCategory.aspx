<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Assignment_2.Admin.AddCategory" Theme="General" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    <div class="container">
        <div class="row col-md-offset-3">
            <div class="col-md-3">
                <h4>List of Categories</h4>
                <asp:ListBox runat="server" ID="categoriesListBox" SelectionMode="Single"/>
            </div>
            <div class="col-md-4">
                <h4><asp:Label runat="server" Text="Enter a new category name"></asp:Label></h4>
                <asp:TextBox runat="server" ID="addCategoryBox"></asp:TextBox>
                <asp:Button runat="server" ID="addCategoryButton" OnClick="AddCat" Text="Add to List" SkinID="buttonSkin"/>
            </div>
        </div>
    </div>
</asp:Content>
