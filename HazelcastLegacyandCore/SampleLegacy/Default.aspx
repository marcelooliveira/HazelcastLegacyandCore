<%@ Page Async="true" Title="Shopping Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleLegacy._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>
        SHOPPING CART
    </h3>

    <asp:Repeater ID="cartItemsRepeater" runat="server">

    <HeaderTemplate>
        <table id="cartItemsTable" class="table">
        <thead>
            <tr>
                <th>Qty</th>
                <th>Description</th>
                <th>Unit Price</th>
                <th>Total</th>
            </tr>
        </thead>
    </HeaderTemplate>

    <ItemTemplate>
        <tr>
            <td><%# Eval("Quantity") %></td>
            <td><%# Eval("Description") %></td>
            <td><%# Eval("UnitPrice") %></td>
            <td><%# Eval("Total") %></td>
        </tr>
    </ItemTemplate>

    <FooterTemplate>
        </table>
    </FooterTemplate>
    </asp:Repeater>

    <form method="POST">
        <div class="row">
            <div class="col">
                <asp:Button runat="server" ID="addOrange" Text="Add Orange" OnClick="addItem_Click" />
                <asp:Button runat="server" ID="addCoconut" Text="Add Coconut" OnClick="addItem_Click" />
                <asp:Button runat="server" ID="addApple" Text="Add Apple" OnClick="addItem_Click" />
                <asp:Button runat="server" ID="addGrapefruit" Text="Add Grapefruit" OnClick="addItem_Click" />
            </div>
        </div>
    </form>

</asp:Content>
