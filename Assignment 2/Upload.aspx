<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Assignment_2.Upload" EnableTheming="true" Theme="General" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    Fill out the details below and click 'Upload File Now'
    <br />
    <br />
    <br />
    <b>Select a file: </b><asp:FileUpload ID="fileUpload" runat="server" />&nbsp;&nbsp;<asp:Button ID="uploadButton" runat="server" Text="Upload File Now" OnClick="uploadButton_Click" SkinID="buttonSkin" />
</asp:Content>
