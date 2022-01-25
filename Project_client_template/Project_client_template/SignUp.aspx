<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Project_client_template.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <section class="form">
            <div class="row">
                <h3>Visit us</h3>
                <h2>We're happy to hear from you!</h2>
            </div>
            <div class="row contact-form" ID="contact-form">
                <form method="post" action="#">
                    <div class="row">
                        <asp:Label Text="Name*" runat="server"/>
                        <div class="row">
                            <div class="col span-1-of-3">
                                <asp:TextBox CssClass="name" type="text" ID="name" name="name" placeholder="First Name" runat="server" required="1"/>
                            </div>
                            <div class="col span-2-of-3">
                                <asp:TextBox CssClass="surname" type="text" ID="surname" name="surname" placeholder="Last Name" runat="server" required="1"/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label Text="Birthday*" runat="server"/>
                        <div class="row">
                            <div class="col span-1-of-10">
                                <asp:TextBox type="text" class="birthday" ID="day" name="day" placeholder="DD" runat="server" required="1"/>
                            </div>
                            <div class="col span-1-of-10">
                                <asp:TextBox type="text" class="birthday" ID="month" name="month" placeholder="MM" runat="server" required="1"/>
                            </div>
                            <div class="col span-1-of-10">
                                <asp:TextBox type="text" class="birthday" ID="year" name="year" placeholder="YYYY" runat="server" required="1"/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label Text="Email*" runat="server"/>
                        <div class="row">
                            <asp:TextBox class="email" type="email" ID="address" name="email" placeholder="ex: sen@gmail.com" runat="server" required="1"/>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label Text="Username*" runat="server"/>
                        <div class="row">
                            <asp:TextBox class="username" type="text" ID="username" name="username" runat="server" required="1"/>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label Text="Password*" runat="server"/>
                        <div class="row">
                            <asp:TextBox class="password" type="password" ID="password" name="password" runat="server" required="1"/>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label Text="Comments" runat="server"/>
                        <div class="row">
                            <textarea name="other_details" ID="other_details" runat="server" ></textarea>
                        </div>
                    </div>
                    <div class="row">
                        <Label>&nbsp;</Label>
                        <div class="row">
                            <asp:button Text="Submit" class="btn full-btn btn-hide" ID="hide" runat="server" OnClick="Button1_Click"/>
                        </div>
                        <div class="row">
                            <a class="login-ref" href="../Login.aspx" runat="server">Already have an account?</a>
                        </div>
                    </div>
                </form>
            </div>
            </section>
        </header>
</asp:Content>
