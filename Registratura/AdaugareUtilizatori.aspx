<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdaugareUtilizatori.aspx.cs" Inherits="Registratura.AdaugareUtilizatori" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="main-content">
        <section id="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">

                        <header class="panel-heading">

                            <div class="col-md-8 col-md-offset-4">

                                <h1>Inregistrare/Stergere Utilizatori</h1>

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
                                <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="* Email:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxEmail" CssClass="form-control input-sm" placeholder="Email" />

                                    </div>

                                </div>

                                <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="* Nume Utilizator:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxNumeUtilizator" CssClass="form-control input-sm" placeholder="Nume Utilizator" />

                                    </div>

                                </div>
                                <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="* Parola:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxParola" CssClass="form-control input-sm" placeholder="Parola" />

                                    </div>

                                </div>

                                 <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="* Grup:" runat="server" />
                                         <asp:DropDownList ID="DropDownListGrup" runat="server">
                                     <asp:ListItem>Va rugam selectati</asp:ListItem>
                                     <asp:ListItem>Financiar</asp:ListItem>
                                     <asp:ListItem>Logistica</asp:ListItem>
                                      <asp:ListItem>HR</asp:ListItem>
                                     <asp:ListItem>HSE</asp:ListItem>
                                     <asp:ListItem>Purchasing</asp:ListItem>
                                      <asp:ListItem>Admini</asp:ListItem>
                                     

                                    </asp:DropDownList>

                                    </div>

                                </div>

                            </div>

                            <div class="row">

                                    <div class="çol-md-4 col-md-offset-1">
                                        
                                        <asp:Label Text="* Acces :" runat="server" />
                                        
                                        
                                           
                                    </div>

                                <div class="çol-md-4 col-md-offset-1">
                                    <asp:ListBox ID="ListBox1" runat="server" Rows="2">
                                            <asp:ListItem>User</asp:ListItem>
                                            <asp:ListItem>Admin</asp:ListItem>
                                        </asp:ListBox>
                                </div>


                                </div>
                            </br>
                         
                         
                            <div class="row">

                                    <div class="çol-md-4 col-md-offset-1">

                                        <asp:Button Text="Inregistrare" ID="ButtonInregistrare" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnInregistrare_Click" />

                                        

                                    </div>


                                </div>

                            </br>

                               </br>
                               </br>
                            <div class="row">

                                <div class="çol-md-4 col-md-offset-1 ">

                                    <div class="form-group">
                                        <asp:Label Text="* Email Pentru Sters:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxEmailSters" CssClass="form-control input-sm" placeholder="Email Sters/Update" />

                                    </div>

                                </div>
                               
                                  

                            </div>
                            </br>
                            </br>
                            <div class="row">

                                <div class="çol-md-4 col-md-offset-1">

                                        
                                        
                                        <asp:Button Text="Stergere" ID="btnStergere" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnStergere_Click" />
                                       

                                    </div>
                                 
                            </div>
                    </section>

                </div>

            </div>

        </section>


    </section>
</asp:Content>
