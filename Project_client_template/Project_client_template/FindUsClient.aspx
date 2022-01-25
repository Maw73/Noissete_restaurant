<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="FindUsClient.aspx.cs" Inherits="Project_client_template.FindUsClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
            <section class="section-cities" id="cities">
            <div class="row js--wp-3">
                <h2>We're currently in these places</h2>
            </div>
            <div class="row">
                <div class="col span-1-of-3 box">
                    
                    <img src="../fonts/english-rest.jpeg" alt="Lisbon" class="img-row">
                    <h3><%=loc[0]%></h3>
                    <div class="city-feature">
                        <img src="../fonts/person.svg" alt="user" class="icon-small">
                        1600+ happy eaters
                    </div>
                    <div class="city-feature">
                        <img src="../fonts/star.svg" alt="star" class="icon-small third">
                        top chefs
                    </div>
                    <div class="city-feature">
                        <img src="../fonts/logo-twitter.svg" alt="tweeter" class="icon-small last">
                        <a href="#">@noissete_english</a>
                    </div>
                </div>
                
                <div class="col span-1-of-3 box">
                    <img src="../fonts/indian-rest.jpeg" alt="inf" class="img-row">
                    <h3><%=loc[1]%></h3>
                    <div class="city-feature">
                        <img src="../fonts/person.svg" alt="user" class="icon-small">
                        3700+ happy eaters
                    </div>
                    <div class="city-feature">
                        <img src="../fonts/star.svg" alt="star" class="icon-small third">
                        top chefs
                    </div>
                    <div class="city-feature">
                        <img src="../fonts/logo-twitter.svg" alt="tweeter" class="icon-small last">
                        <a href="#">@noissete_indian</a>
                    </div>
                </div>
                
                <div class="col span-1-of-3 box">
                    <img src="../fonts/chinese-rest.jpeg" alt="inf" class="img-row">
                    <h3><%=loc[2]%></h3>
                    <div class="city-feature">
                        <img src="../fonts/person.svg" alt="user" class="icon-small">
                        2300+ happy eaters
                    </div>
                    <div class="city-feature">
                        <img src="../fonts/star.svg" alt="star" class="icon-small third">
                        top chefs
                    </div>
                    <div class="city-feature">
                        <img src="../fonts/logo-twitter.svg" alt="tweeter" class="icon-small last">
                        <a href="#">@noissete_chinese</a>
                    </div>
                </div>
                
            </div>
        </section>

</asp:Content>
