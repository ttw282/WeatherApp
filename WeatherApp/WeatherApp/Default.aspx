<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WeatherApp._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    Zip: <asp:TextBox runat="server" ID="zip"></asp:TextBox> <asp:Button runat="server" ID="getweather" Text="Get Weather" OnClick="getweather_Click" /><asp:Button runat="server" ID="getforecast" Text="Get Forecast" OnClick="getforecast_Click" />
    <br />
    City: <asp:Label runat="server" ID="city"></asp:Label>
    <br />
        State: <asp:Label runat="server" ID="state"></asp:Label>
    <br />
        Weather Station City: <asp:Label runat="server" ID="weatherstationcity"></asp:Label>
    <br />
        Temperature (F): <asp:Label runat="server" ID="temperaturef"></asp:Label>
    <br />
     Temperature (C): <asp:Label runat="server" ID="temperaturec"></asp:Label>
    <br />
        Wind: <asp:Label runat="server" ID="wind"></asp:Label>
    <br />
    <asp:Label runat="server" ForeColor="Red" ID="error"></asp:Label>

    <asp:Label runat="server" ForeColor="Green" ID="success"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="forecast" runat="server">
        <Columns>
<asp:TemplateField HeaderText="Image">
<ItemTemplate>
<asp:Image ID="Image1" runat="server" 
           ImageUrl='<%# Eval("PictureURL")%>'/>
</ItemTemplate>
</asp:TemplateField>
</Columns>
    </asp:GridView>

</asp:Content>
