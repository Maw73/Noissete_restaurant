<%@ Page Title="" Language="C#" MasterPageFile="~/LoginChefs.Master" AutoEventWireup="true" CodeBehind="ChefsChefs.aspx.cs" Inherits="Project_client_template.ChefsChefs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section>
        <h2>Chefs</h2>
        <div class="row boxes">
        <%for (int i = 0; i < location.Count; i++)
                 { %>
        <h3><%=nameChef[i] + " " + surnameChef[i]%> </h3>
        <p>
            <%=details[i]%>
        </p>
        <div class="row">
            <h4>Type of Cuisine</h4>
            <h5><%=cuisine[i] %></h5>
        </div>
        <div class="row">
            <h4>Location</h4>
            <h5><%=location[i] %></h5>
        </div>
            <%} %>
        </div>
        

    </section>


</asp:Content>
