<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment_2.Admin.Default" Theme="General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="row">
            <asp:GridView runat="server" ID="cateogryGridView" SkinID="gvSkin" AutoGenerateColumns="False" EmptyDataText="No Categories" OnRowDeleting="DeleteCategory">
                <Columns>
                    <asp:BoundField HeaderText="Category" DataField="Name" />
                    <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="CategoryId" DataNavigateUrlFormatString="EditCategory.aspx?CategoryId={0}" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete" SkinID="buttonSkin" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="row">
            <asp:GridView runat="server" ID="productGridView" SkinID="gvSkin" AutoGenerateColumns="False" EmptyDataText="No Products" OnRowDeleting="DeleteProduct">
                <Columns>
                    <asp:BoundField HeaderText="Product" DataField="Name" />
                    <asp:BoundField HeaderText="Description" DataField="ShortDescription" />
                    <asp:BoundField HeaderText="Price" DataField="Price" />
                    <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="EditProduct.aspx?ProductId={0}" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button ID="deleteButton" runat="server" CommandName="Delete" Text="Delete" SkinID="buttonSkin" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
