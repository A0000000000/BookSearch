<%@ Page Title="首页" Language="C#" MasterPageFile="~/MainTheme.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BookManager.Web.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div>
        <asp:UpdatePanel runat="server" ID="upPanel">
            <ContentTemplate>
                <p>请输入查询关键词(多个关键词以空格分隔):</p><asp:TextBox runat="server" ID="inputMessage"></asp:TextBox><br/>
                <asp:DropDownList runat="server" ID="SearchType">
                    <asp:ListItem Text="书名" Value="Book" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="作者" Value="Author"></asp:ListItem>
                    <asp:ListItem Text="出版社" Value="Publisher"></asp:ListItem>
                    <asp:ListItem Text="模糊" Value="All"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button runat="server" ID="Search" Text="查询"/>
                <asp:Panel runat="server" ID="Result"></asp:Panel>
                <asp:Panel runat="server" ID="Detail"></asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
