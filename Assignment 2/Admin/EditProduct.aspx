<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="Assignment_2.Admin.EditProduct" Theme="General" UnobtrusiveValidationMode="None"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-8">
                <!-- Name -->
                <h4>Name: </h4>
                <h1><asp:TextBox runat="server" ID="nameBox"></asp:TextBox></h1>
                <asp:RequiredFieldValidator runat="server" ID="rewName" ControlToValidate="nameBox" ErrorMessage="Product name is required"></asp:RequiredFieldValidator>
                <%-- Price--%>
                <h4>Price:</h4>
                <p><asp:TextBox runat="server" ID="priceBox" TextMode="SingleLine"></asp:TextBox></p>
                <asp:RequiredFieldValidator runat="server" ID="reqPrice" ControlToValidate="priceBox" ErrorMessage="Price is required"></asp:RequiredFieldValidator>
                <%-- Sale Price--%>
                <h4>Sale Price:</h4>
                <p><asp:TextBox runat="server" ID="salePriceBox" TextMode="SingleLine"></asp:TextBox></p>
                <asp:RequiredFieldValidator runat="server" ID="reqSalePrice" ControlToValidate="salePriceBox" ErrorMessage="Sale price is required"></asp:RequiredFieldValidator>
                <h4 style="display: inline-block;">On Sale: &nbsp;</h4>
                <asp:CheckBox runat="server" ID="isOnSaleBox" />
                <!-- Category -->
                <h4>Category: </h4>
                <p class="lead"><asp:DropDownList runat="server" ID="categoryDropDown" /></p>
                <asp:RequiredFieldValidator runat="server" ID="reqCategory" ControlToValidate="categoryDropDown" ErrorMessage="Category is required"></asp:RequiredFieldValidator>
                <!-- Description -->
                <h4>Description:</h4>
                <p><asp:TextBox runat="server" ID="descriptionBox" TextMode="MultiLine" Rows="1" Columns="100"></asp:TextBox></p>
                <asp:RequiredFieldValidator runat="server" ID="reqDescription" ControlToValidate="descriptionBox" ErrorMessage="Description is required"></asp:RequiredFieldValidator>
                <!-- Full Description -->
                <h4>Full Description:</h4>
                <asp:ScriptManager ID="scriptManager" runat="server" />
                <asp:TextBox ID="longDescriptionTextBox" TextMode="MultiLine" Columns="60" Rows="8" runat="server" />
                <ajaxToolkit:HtmlEditorExtender runat="server" TargetControlID="longDescriptionTextBox" EnableSanitization="false" />
                <asp:RequiredFieldValidator runat="server" ID="reqFullPost" ControlToValidate="longDescriptionTextBox" ErrorMessage="Description Text is required"></asp:RequiredFieldValidator><br />
                <h4>Select an image: </h4>
                <asp:FileUpload ID="fileUpload" runat="server" />
                <hr />
                <asp:Button runat="server" ID="addProductButton" OnClick="EditProd" Text="Submit" CausesValidation="True" SkinID="buttonSkin" />
            </div>
        </div>
    </div>
</asp:Content>
