<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Assignment_2.Checkout" Theme="General" UnobtrusiveValidationMode="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager runat="Server" />
    <div class="container">
        <h1>Checkout</h1>
        <div class="row col-md-8">
            <h4><asp:Label runat="server" Text="Cardholder Name: "></asp:Label></h4>
            <asp:TextBox runat="server" ID="cardholderNameBox"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqCardholderName" controltovalidate="cardholderNameBox" errormessage="Required" />
        </div>
        <div class="row col-md-8">
            <h4><asp:Label runat="server" Text="Card Number: "></asp:Label></h4>
            <asp:TextBox runat="server" ID="cardNumberBox"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" id="reqCardNumber" controltovalidate="cardNumberBox" errormessage="Required" />
            <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "cardNumberBox" ID="validateCardNumber" ValidationExpression = "^[\d]{9,9}$" runat="server" ErrorMessage="Invalid Credit Card Number (format = 123456789)"></asp:RegularExpressionValidator>

        </div>
        <div class="row col-md-8">
            <h4><asp:Label runat="server" Text="Expiry: "></asp:Label></h4>
            <asp:TextBox runat="server" ID="expCalendar"></asp:TextBox>
            <ajaxToolkit:CalendarExtender runat="server" ID="expCalendarExtender" TargetControlID="expCalendar"/>
            <asp:RequiredFieldValidator runat="server" ID="expReq" ControlToValidate="expCalendar" ErrorMessage="Expiry is Required"></asp:RequiredFieldValidator>
            <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="ajaxexpReq" TargetControlID="expReq"/> 
        </div>
        <hr/>
        <div class="row col-md-8">
            <hr/>
            <asp:HyperLink runat="server" ID="completeTransactionLink" Text="Complete Transaction" NavigateUrl="ThankYou.aspx" CausesValidation="True" SkinID="hyperlinkSkin"/>
            <asp:HyperLink runat="server" ID="cancelButton" Text="Cancel" NavigateUrl="Default.aspx" CausesValidation="False" SkinID="hyperlinkSkin"/>
        </div>
    </div>

</asp:Content>


<%--This page requires a ‘Complete Transaction’ and ‘Cancel’ button. When the ‘Complete Transaction’ button is clicked the user is 
    redirected to ~/ThankYou.aspx. When the ‘Cancel’ button is clicked the user is redirected to ~/Default.aspx--%>