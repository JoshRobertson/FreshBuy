<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="Assignment_2.CategoryDetails" Theme="General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid col-md-10 col-md-offset-2">
        <div class="col-md-10 row">
            <asp:GridView runat="server" ID="productGridView" SkinID="gvSkin" AutoGenerateColumns="False" EmptyDataText="No Products">
                <Columns>
                    <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="ProductDetails.aspx?ProductId={0}" />
                    <asp:BoundField HeaderText="Description" DataField="ShortDescription" />
                    <asp:BoundField HeaderText="Regular Price" DataField="Price" />
                    <asp:BoundField HeaderText="Sale Price" DataField="SalePrice" />
                    <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="image" runat="server" ImageUrl='<%# "~/GetFileHandler.ashx?id=" + Eval("FileId") %>' Width="300" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
