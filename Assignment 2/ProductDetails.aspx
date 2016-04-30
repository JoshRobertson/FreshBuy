<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Assignment_2.ProductDetails" Theme="General" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container">
        <div class="col-md-12 row" style="padding: 15px">
            <div class="col-md-10">
                <!-- Name -->
                <h1>
                    <asp:Label runat="server" ID="nameBox"></asp:Label></h1>
                <!-- Price -->
                    <h4><asp:Label runat="server" ID="priceBox">Price: $</asp:Label></h4>   
                    <h4><asp:Label runat="server" ID="salePriceBox" Visible="False">Sale Price: $</asp:Label></h4>
                
                <hr />
                <!-- Description -->
                <asp:Label runat="server" ID="shortDescriptionBox"></asp:Label>
            </div>
            <!-- When the user is logged into the system an ‘Add to Cart’ button is available. -->
            <asp:Button runat="server" ID="addToCartButton" class="col-md-offset-2" Text="Add To Cart" OnClick="AddToCart" SkinID="buttonSkin"></asp:Button>
        </div>
        <asp:ScriptManager runat="Server" />
        <ajaxToolkit:TabContainer ID="tabs" runat="server">
            <ajaxToolkit:TabPanel runat="server" HeaderText="Long Description">
                <ContentTemplate>
                    <asp:Label runat="server" ID="longDescriptionBox"></asp:Label>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel runat="server" HeaderText="Comments/Ratings">
                <ContentTemplate>
                    <!-- Comments Form -->
                    <asp:Panel runat="server" class="well row col-lg-8" ID="leaveACommentSection" Visible="True" Width="100%" >
                        <h4>Leave a Comment:</h4>
                        <div class="form-group">
                            <asp:TextBox runat="server" Width="100%" Height="80" ID="commentTextBox" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" class="btn btn-primary" ID="commentSubmitButton" OnClick="AddNewComment" Text="Submit" SkinID="buttonSkin"></asp:Button>
                    </asp:Panel>
                    <asp:GridView runat="server" ID="commentGridView" SkinID="gvSkin" EmptyDataText="No Comments yet!" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Comment" DataField="CommentText"/>
                        <asp:BoundField HeaderText="Date" DataField="CreatedDate"/>
                        <asp:BoundField HeaderText="Author" DataField="CommentAuthor"/>
                    </Columns>
                </asp:GridView>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
    </div>
</asp:Content>
