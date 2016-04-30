<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="BadWords.aspx.cs" Inherits="Assignment_2.Admin.BadWords" Theme="General" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row col-md-offset-3">
            <div class="col-md-3">
                <h4>List of Bad Words</h4>
                <asp:ListBox runat="server" ID="badWordsListBox" SelectionMode="Single"/>
                <asp:Button runat="server" ID="removeBadWordButton" OnClick="RemoveBadWord" Text="Remove selected from List" SkinID="buttonSkin"/>
            </div>
            <div class="col-md-4">
                <h4><asp:Label runat="server" Text="Enter a word to censor in comments"></asp:Label></h4>
                <asp:TextBox runat="server" ID="addBadWordBox"></asp:TextBox>
                <asp:Button runat="server" ID="addBadWordButton" OnClick="AddBadWord" Text="Add to List" SkinID="buttonSkin"/>
            </div>
        </div>
    </div>
</asp:Content>
