<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project_client_template.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
    <section class="form">
            <div class="row">
                <h3>Visit us</h3>
                <h2 class="title">Login to continue</h2>
            </div>
            <div class="row login">
                <form method="post" action="#" class="contact-form">
                    <div class="row">
                        <asp:Label CssClass="labels" Text="Username" runat="server"/>
                        <div class="row">
                            <asp:TextBox class="username" type="text" ID="username" name="username" runat="server" required="1"/>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label CssClass="labels" Text="Password" runat="server"/>
                        <div class="row">
                            <asp:TextBox class="password" type="password" ID="password" name="password" runat="server" required="1"/>
                        </div>
                    </div>
                    <div class="row">
                        <Label>&nbsp;</Label>
                        <div class="row">
                            <asp:button Text="Login" class="btn full-btn" ID="login" OnClick="Button1_Click" runat="server" />
                        </div>
                        <div class="row">
                            <a class="login-ref" href="../SignUp.aspx" runat="server">Don't have an account yet?</a>
                        </div>
                    </div>
                
                </form>
            </div>
            </section>
            
        </header>
</asp:Content>
