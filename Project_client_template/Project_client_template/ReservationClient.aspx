<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="ReservationClient.aspx.cs" Inherits="Project_client_template.ReservationClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="section-story">
            <div class="row">
                <div class="col span-1-of-3 story-box">
                    <asp:Image ID="before" alt="before" class="cooking" runat="server" ImageUrl="~/fonts/table1.jpg"/>
                </div>
                <div class="col span-1-of-3 story-box form-box">
                    <h2 class="title2">Reservation</h2>
                    <h3>BOOK YOUR TABLE</h3>
                    <form method="post" action="#" class="contact-form">
                        <div class="row">
                            <select class="selectpicker" name="address" ID="address" runat="server">
                                <option runat="server">English: Str.Bucuresti</option>
                                <option runat="server">Indian: Str.Eroilor</option>
                                <option runat="server">Chinese: Str.Horea</option>
                            </select>
                        </div>
                        <div class="row">
                            <asp:TextBox class="date" type="text" ID="date" name="date" placeholder="12/02/2021" runat="server" required="1"/>
                        </div>
                        <div class="row">
                            <select class="selectpicker" name="hours" id="hours" runat="server">
                                <option runat="server">2:00 pm</option>
                                <option runat="server">3:00 pm</option>
                                <option runat="server">4:00 pm</option>
                                <option runat="server">5:00 pm</option>
                                <option runat="server">6:00 pm</option>
                                <option runat="server">7:00 pm</option>
                                <option runat="server">8:00 pm</option>
                                <option runat="server">9:00 pm</option>
                                <option runat="server">10:00 pm</option>
                            </select>
                        </div>
                            <div class="row">
                                <asp:button Text="Check availability" class="btn new-btn" OnClick="Button1_Click" ID="available" runat="server" />
                            </div>
                        <div class="row">
                            <select class="selectpicker" name="chefs" id="chefs" runat="server">
                                <option value="" disabled selected hidden>Chefs</option>
                            </select>
                        </div>
                        <div class="row">
                        <Label>&nbsp;</Label>
                        <div class="row">
                            <asp:button Text="Find a table" class="btn full-btn" OnClick="Button2_Click" ID="table" runat="server" />
                        </div>
                    </div>
                        <div class="row">
                             <a class="myres" href="../MyReservationsClient.aspx" runat="server">My reservations</a>
                        </div>
                
                </form>
                </div>
                <div class="col span-1-of-3 story-box">
                    <asp:Image ID="Image2" alt="after" class="cooking" runat="server" ImageUrl="~/fonts/table2.jpg"/>
                </div>
            </div>
        </section>
</asp:Content>
