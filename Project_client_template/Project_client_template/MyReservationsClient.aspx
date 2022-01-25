<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="MyReservationsClient.aspx.cs" Inherits="Project_client_template.MyReservationsClient" %>
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
                                <div>
                                    <tr>
                                        <td><%=i+1 %></td>
                                    </tr>
                                    <!--<asp:Button ID="btns" runat="server" CssClass="btn" Text="Delete" href='../MyReservationsClient.aspx?<% i%>' OnClick="Button1_Click"/>-->
                                </div>
                                <h3><%= locations[i] %></h3>
                                <h4><%= chefName[i]+" "+chefSurname[i] %></h4>
                                <div><%= date[i]%></div>
                                <div><%= hour[i] %></div>
                            </div>
                        </div>
                    </div>
                   <%} %> 

            </div>
        </div> 
        <div class="row el">
                    <div class="col span-1-of-10">
                        <input class="textbox" id="textbox2" name="textbox2" runat="server"></>
                    </div>
                    <div class="col span-2-of-10">
                        <asp:Button ID="del" text="Delete" CssClass="btn full-blue" OnClick="Button1_Click" runat="server"/>
                    </div>
                </div>
    </section>
</asp:Content>
