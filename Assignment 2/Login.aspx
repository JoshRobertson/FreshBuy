<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment_2.Login" Theme="General" UnobtrusiveValidationMode="None"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Body" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row col-md-offset-3 glyphicon-align-center">

                <asp:Login runat="server" 
                    ID="UserLogin" 
                    DestinationPageUrl="Default.aspx" 
                    OnAuthenticate="ValidateUser"
                    CssClass="" 
                    DisplayRememberMe="False" 
                    UserNameRequiredErrorMessage="Username Required" 
                    PasswordRequiredErrorMessage="Password Required"
                    SkinID="loginSkin"
                    Width="400"
                    Height="200"
                    BackColor="AliceBlue"
                    ></asp:Login>
            
        </div>
    </div>
</asp:Content>
