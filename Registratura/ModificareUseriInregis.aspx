<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificareUseriInregis.aspx.cs" Inherits="Registratura.ModificareUseriInregis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="main-content">

        <header class="panel-heading">

            <div class="col-md-8 col-md-offset-3">

                <h1>Modificare Inregistrari sau Utilizatori </h1>
            </div>
        </header>
    </br>
    </br>
    </br>
    </br>
    </br>
    </br>
    </br>
    </br>
    </br>

        <div class="container">

            <div class="row">

                <div class="col-md-4 col-md-offset-0">
                <div class="form-group">

                    <h4>Sectiune modificare Inregistrari</h4>
                    </br>
                    <asp:Label Text="* Numar Intrare Document(autocomplete si modificare) - nu se poate modifica :" runat="server" />
                    <asp:TextBox runat="server" Enabled="true" ID="tbxNumarIntrareDocument" CssClass="form-control input-sm" placeholder="Numar Intrare Document" />
                 

                </div>

                </div>

                 <div class="col-md-4 col-md-offset-3">
                <div class="form-group">

                    <h4>Sectiune modificare Utilizatori</h4>
                    </br>
                    <asp:Label Text="* Email (autocomplete si modificare) - nu se poate modifica :" runat="server" />
                    <asp:TextBox runat="server" Enabled="true" ID="tbxEmail" CssClass="form-control input-sm" placeholder="Email" />
                 

                </div>

                </div>


            </div>
            
                        <div class="row">

                <div class="col-md-4 col-md-offset-0">
                <div class="form-group">

                    
                    <asp:Label Text="* Denumire Document:" runat="server" />
                    <asp:TextBox runat="server" Enabled="true" ID="tbxDenumireDocument" CssClass="form-control input-sm" placeholder="Denumire Document" />
                 

                </div>

                </div>

                 <div class="col-md-4 col-md-offset-3">
                <div class="form-group">

                   
                    <asp:Label Text="* Nume utilizator:" runat="server" />
                    <asp:TextBox runat="server" Enabled="true" ID="tbxNumeUtilizator" CssClass="form-control input-sm" placeholder="Nume utilizator" />
                 

                </div>

                </div>


            </div>

                    <div class="row">

                <div class="col-md-4 col-md-offset-0">
                <div class="form-group">

                    
                    <asp:Label Text="* Provenienta Document:" runat="server" />
                    <asp:TextBox runat="server" Enabled="true" ID="tbxProvenientaDocument" CssClass="form-control input-sm" placeholder="Provenienta Document" />
                 

                </div>

                </div>

                 <div class="col-md-4 col-md-offset-3">
                <div class="form-group">

                   
                    <asp:Label Text="* Parola:" runat="server" />
                    <asp:TextBox runat="server" Enabled="true" ID="tbxParola" CssClass="form-control input-sm" placeholder="Parola" />
                 

                </div>

                </div>


            </div>

                     <div class="row">

                <div class="col-md-4 col-md-offset-0">
                <div class="form-group">

                    
                    <asp:Label Text="* Destinatie Document:" runat="server" />
                    <asp:TextBox runat="server" Enabled="true" ID="tbxDestinatieDocument" CssClass="form-control input-sm" placeholder="Destinatie Document" />
                 

                </div>

                </div>

                 <div class="col-md-4 col-md-offset-3">
                <div class="form-group">

                   
                    <asp:Label Text="* Acces:" runat="server" />
                    </br>
                   <asp:ListBox ID="ListBoxAcces" runat="server" Rows="2">
                                            <asp:ListItem>User</asp:ListItem>
                                            <asp:ListItem>Admin</asp:ListItem>
                                        </asp:ListBox>

                </div>

                </div>


            </div>

            <div class="row">

                <div class="col-md-4 col-md-offset-0">

                    <div class="form-group">

                    <asp:Label Text="Numar Data/Document:" runat="server" />
                    <asp:TextBox runat="server" Enabled="true" ID="tbxNumarDataDocument" CssClass="form-control input-sm" placeholder="Numar/Data Document" />
                 

                    </div>

                </div>

                  <div class="col-md-4 col-md-offset-3">
                <div class="form-group">

                   
                    <asp:Label Text="*  Schimbare parola status:" runat="server" />
                    </br>
                   <asp:ListBox ID="ListBoxReinitilizare" runat="server" Rows="2">
                                            <asp:ListItem>Efectuat</asp:ListItem>
                                            <asp:ListItem>Neefectuat</asp:ListItem>
                                        </asp:ListBox>

                </div>

                </div>

            </div>


                      <div class="row">

                <div class="col-md-4 col-md-offset-0">
                <div class="form-group">

                    
                    <asp:Label Text="* Tip Document:" runat="server" />
                    </br>
                    <asp:ListBox ID="ListBoxTip" runat="server" Rows="2">
                                            <asp:ListItem>Intrare</asp:ListItem>
                                            <asp:ListItem>Iesire</asp:ListItem>
                                        </asp:ListBox>

                </div>

                </div>

               <div class="col-md-4 col-md-offset-3">

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

                    <div class="form-group">

                    
                    <asp:Label Text="* Status User:" runat="server" />
                    </br>
                    <asp:ListBox ID="ListBoxStatus" runat="server" Rows="2">
                                            <asp:ListItem>Activ</asp:ListItem>
                                            <asp:ListItem>Inactiv</asp:ListItem>
                                        </asp:ListBox>

                </div>

               </div>


            </div>

            <div class ="row">

                <div class="col-md-4 col-md-offset-7">

                   

                </div>

            </div>

          </br>

            <div class="row">

                <div class="col-md-4 col-md-offset-0">

                    <asp:Button Text="Autocomplete Doc" ID="btnAutocompleteDoc" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnAutocompleteDoc_Click" />

                     <asp:Button Text="Modificare Doc" ID="btnModificare" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnModificare_Click" />

                                        
                                        
                                        
                                       

                </div>

                <div class="col-md-4 col-md-offset-3">

                    <asp:Button Text="Autocomplete User" ID="btnAutocompleteUser" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnAutocompleteUser_Click" />

                     <asp:Button Text="Modificare User" ID="btnModificareUser" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnModificareUser_Click" />

                                        
                                        
                                        
                                       

                </div>

            </div>

        </div>

    </section>

</asp:Content>
