<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SchimbareParola.aspx.cs" Inherits="Registratura.SchimbareParola" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="main-content">

        <section id="wrapper">

            <div class="col-lg-12">

                <section class="panel">


                    <header class="panel-heading">

                        <div class="col-md-8 col-md-offset-0">

                            <h1> Va rugam schimbati parola !!!</h1>
                        </div>
                    </header>

                    </br>
                         </br>
                         </br>
                         </br>
                         </br>
                         </br>

                    <div class="panel-body">

                        <div class="row">

                            <div class="çol-md-4 col-md-offset-0">

                                    <div class="form-group">
                                        <asp:Label Text="* Email:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxEmail" CssClass="form-control input-sm" placeholder="Email" />

                                    </div>

                                </div>

                        </div>

                        <div class="row">

                            <div class="çol-md-4 col-md-offset-0">

                                    <div class="form-group">
                                        <asp:Label Text="* Parola Noua:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxparola1" TextMode="Password" CssClass="form-control input-sm" placeholder="Introduceti parola noua" />

                                    </div>

                                </div>

                        </div>

                        <div class="row">

                            <div class="çol-md-4 col-md-offset-0">

                                    <div class="form-group">
                                        <asp:Label Text="* Repetati Parola Noua:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxparola2" TextMode="Password" CssClass="form-control input-sm" placeholder="Reintroduceti parola noua" />

                                    </div>

                                </div>

                        </div>

                        <div class="row">

                             <div class="çol-md-8 col-md-offset-0">

                                        <asp:Button Text="Schimbare" ID="btnSchimbare" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnSchimbare_Click" />

                                    </div>
                        </div>
                    </div>
                </section>
            </div>
        </section>
    </section>

</asp:Content>
