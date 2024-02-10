<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RLDC_Report._Default" %>

<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <div style="padding: 15px">
      <div align="center">
          <asp:Label runat="server" Text="Select Department" ID="ctl02" ForeColor="Black"></asp:Label>
          
          
          <asp:DropDownList ID="DropDownDepartment" runat="server" DataTextField="Name" DataValueField="Id" DataSourceID="SqlDataSource1"></asp:DropDownList><asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [Name] FROM [Departments]"></asp:SqlDataSource>
          <asp:Button ID="Button1" runat="server" Text="Load Report" ForeColor="White" BackColor="#660066" OnClick="Button1_Click" />

      </div>
      <div align="center">
          <rsweb:ReportViewer ID="ReportViewer" runat="server" Width="700px"></rsweb:ReportViewer>
          &nbsp;</div>
  </div>

</asp:Content>
