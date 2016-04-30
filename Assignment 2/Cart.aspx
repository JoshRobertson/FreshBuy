<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Assignment_2.Cart" Theme="General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid col-md-10 col-md-offset-2">
        <div class="col-md-10 row">
            <asp:GridView runat="server" ID="cartGridView" SkinID="gvSkin" AutoGenerateColumns="False" EmptyDataText="No Products in your cart" OnRowDeleting="RemoveProduct">
                <Columns>
                    <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="ProductDetails.aspx?ProductId={0}" />
                    <asp:BoundField HeaderText="Description" DataField="ShortDescription" />
                    <asp:BoundField HeaderText="Regular Price" DataField="Price" />
                    <asp:BoundField HeaderText="Sale Price" DataField="SalePrice" />
                    <asp:TemplateField HeaderText="Total Price">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="totalPriceLabel"><%# Convert.ToBoolean(Eval("IsOnSale"))? Eval("Price"): Eval("SalePrice") %></asp:Label>                      
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="removeButton" runat="server" CommandName="Delete" Text="Remove" SkinID="buttonSkin" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-10 row">
            <div class="pull-right">
                <h4 class="media-heading">
                    <asp:Label runat="server" ID="totalLabel" Text="Cart Total: $"></asp:Label></h4>
                <asp:HyperLink runat="server" SkinID="hyperlinkSkin" ID="buyNowButton" Text="Buy Now!" NavigateUrl="Checkout.aspx"></asp:HyperLink>
                <asp:HyperLink runat="server" ID="continueShoppingLink" Text="Continue Shopping" NavigateUrl="~/Default.aspx" SkinID="hyperlinkSkin"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
