<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Project_client_template.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        
        <header>
            <div class="text-box">
                <h2 class="title1">Discover</h2>
                <h3>Choose whatever you desire.</h3>
                <a href="../SignUp.aspx" class="btn full-btn" runat="server">Sign up</a>
                <a href="../Login.aspx" class="btn ghost-btn" runat="server">Login</a>
            </div>
        </header>
        
        <section class="section-story">
            <div class="row">
                <div class="col span-1-of-3 story-box">
                    <asp:Image ID="before" alt="before" class="cooking" runat="server" ImageUrl="~/fonts/before.jpeg"/>
                </div>
                <div class="col span-1-of-3 story-box">
                    <h2 class="title2">Our story</h2>
                    <p>Noissete is an elegant fine dining restaurant with an emphasis on natural, sustainable food, sourced from the UK’s most dedicated farmers and food producers.
                    </p><br>
                    <p>We create beautifully crafted dishes, seeking out the best of Romanian produce, with a passion to delight and share our curiosity and our love of delicious artisanal food.</p> <br>
                    <p>Since opening, Noissete has received numerous awards 10/10 in the Good Food Guide, five AA rosettes, Best Restaurant at the GQ Food and Drink Awards and the Service Award at the National Restaurant Awards.</p>
                </div>
                <div class="col span-1-of-3 story-box">
                    <asp:Image ID="Image2" alt="after" class="cooking" runat="server" ImageUrl="~/fonts/after.jpeg"/>
                </div>
            </div>
        </section>
        
        <section class="section-food">
            <div class="row text-food">
                <h2 class="title3">Different tastes</h2>
                <p>Noissete offers a large variety of food.</p><p>You can choose your favorite restaurant and taste the culture.</p>
            </div>
            <ul class="meals-showcase clearfix">
                <li>
                    <figure class="meal-photo">
                        <asp:Image ID="Image3" alt="american" runat="server" ImageUrl="~/fonts/american.jpeg"/>
                    </figure>
                </li>
                <li>
                    <figure class="meal-photo">
                        <asp:Image ID="Image1" alt="pizza" runat="server" ImageUrl="~/fonts/pizza.jpeg"/>
                    </figure>
                </li>
                <li>
                    <figure class="meal-photo">
                        <asp:Image ID="Image4" alt="pasta" runat="server" ImageUrl="~/fonts/pasta.jpeg"/>
                    </figure>
                </li>
                <li>
                    <figure class="meal-photo">
                        <asp:Image ID="Image5" alt="mexican" runat="server" ImageUrl="~/fonts/mexican.jpeg"/>
                    </figure>
                </li>
            </ul>
            
            <ul class="meals-showcase clearfix">
                <li>
                    <figure class="meal-photo">
                        <asp:Image ID="Image6" alt="thai" runat="server" ImageUrl="~/fonts/thai.jpeg"/>
                    </figure>
                </li>
                <li>
                    <figure class="meal-photo">
                        <asp:Image ID="Image7" alt="japanese" runat="server" ImageUrl="~/fonts/japanese.jpeg"/>
                    </figure>
                </li>
                <li>
                    <figure class="meal-photo">
                        <asp:Image ID="Image8" alt="indian" runat="server" ImageUrl="~/fonts/indian.jpeg"/>
                    </figure>
                </li>
                <li>
                    <figure class="meal-photo">
                        <asp:Image ID="Image9" alt="soup" runat="server" ImageUrl="~/fonts/soup.jpeg"/>
                    </figure>
                </li>
            </ul>
        </section>
</asp:Content>
