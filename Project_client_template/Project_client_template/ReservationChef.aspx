<%@ Page Title="" Language="C#" MasterPageFile="~/LoginChefs.Master" AutoEventWireup="true" CodeBehind="ReservationChef.aspx.cs" Inherits="Project_client_template.ReservationChef" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <section class="reservations">
        <h2 class="title">My reservations</h2>
        <div class="container">
            <div class="row"> 

                <%for(int i=0; i<locations.Count; i++)
                    { %>
                    <div class="col-sm-6 col-md-3 space">
                        <div class="card z-depth-0">
                            <div class="card-content center">
                                <h3><%= locations[i] %></h3>
                                <h4><%= clientName[i]+" "+clientSurname[i] %></h4>
                                <div><%= date[i]%></div>
                                <div><%= hour[i] %></div>
                            </div>
                        </div>
                    </div>
                   <%} %> 

            </div>
        </div> 
    </section>

</asp:Content>
