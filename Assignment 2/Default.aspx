<%@ Page Title=" Fresh Buy - Home" Language="C#" MasterPageFile="~/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment_2.Default" Theme="General" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="body" runat="server">
    <div class="container-fluid col-md-10 col-md-offset-2">
        <div class="col-md-10 row">
            <asp:GridView runat="server" ID="productGridView" SkinID="gvSkin" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" OnPageIndexChanging="PgvRefreshPage">
                <Columns>
                    <asp:HyperLinkField HeaderText="Name" DataTextField="Name" DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="ProductDetails.aspx?ProductId={0}" />
                    <asp:BoundField HeaderText="Description" DataField="ShortDescription"/>
                    <asp:BoundField HeaderText="Regular Price" DataField="Price"/>
                    <asp:BoundField HeaderText="Sale Price" DataField="SalePrice"/>
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
