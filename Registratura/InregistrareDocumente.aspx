<%@ Page Title="Inregistrare Documente Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InregistrareDocumente.aspx.cs" Inherits="Registratura._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%--     <link rel="stylesheet" type="text/css" href="StyleSheetInregistrari.css" />--%>

    <section id ="main-content">
        <section id ="wrapper">
            <div class ="row">

                <div class ="col-lg-12">

                    <section class ="panel">

                        <header class="panel-heading">
                            <div class="col-md-8 col-md-offset-4">
                                <h1>Inregistrare Documente</h1>

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
                                        <asp:Label Text="Numar/Data Document:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxNumar_Data" CssClass="form-control input-sm" placeholder="Numar/Data Document" />

                                    </div>

                                </div>

                                <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="* Denumire Document:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxDenumire" CssClass="form-control input-sm" placeholder="Denumire Document" />

                                    </div>

                                </div>

                            </div>




                            <div class="row">
                                
                                <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="* Provenienta Document:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxProvenienta" CssClass="form-control input-sm" placeholder="Provenienta Document" />

                                    </div>

                                </div>

                            </div>

                            
                            <div class="row">
                            <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="* Destinatie Document:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxDestinatieDoc" CssClass="form-control input-sm" placeholder="Destinatie Document" />

                                    </div>

                                </div>

                                
                         
                             <div class="col-md-4 col-md-offset-1">
                             <asp:Label Text="* Tip Document:" runat="server" />
                                 <asp:DropDownList ID="DropDownList1" runat="server">
                                     <asp:ListItem>Va rugam selectati</asp:ListItem>
                                     <asp:ListItem>Intrare</asp:ListItem>
                                     <asp:ListItem>Iesire</asp:ListItem>
                                 </asp:DropDownList>

                                </div>

                                </div>
                            

                                  <%--<div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="Inregistrat de:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxInregistratDe" CssClass="form-control input-sm" placeholder="Inregistrat de" />

                                    </div>

                                </div>--%>

                            </br>
                            <div class="row">
                                <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="Data Inregistrarii Aproximative:" runat="server" />
                                        <asp:Label runat="server" Enabled="true" ID="labelDataCalen"/>

                                    </div>

                                </div>


                                <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="Numarul ultimului document inregistrat:" runat="server" />
                                        <asp:Label runat="server" Enabled="true" ID="ultimdocument"/>

                                    </div>

                                </div>

                          </div>




                                <div class="row">

                                    <div class="çol-md-8 col-md-offset-1">

                                        <asp:Button Text="Inregistrare" ID="btnInregistrare" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnInregistrare_Click" />

                                    </div>


                                </div>

                         </br>
                         </br>
                         </br>
                         </br>

                            <div class="row">
                                <div class="çol-md-4 col-md-offset-1">

                                    <div class="form-group">
                                        <asp:Label Text="* Numar Intrare Document de incarcat/descarcat:" runat="server" />
                                        <asp:TextBox runat="server" Enabled="true" ID="tbxdocumentincarcat" CssClass="form-control input-sm" placeholder="Numar Document de incarcat" />

                                    </div>

                                </div>
                            </div>
                           
                             <div class="row">

                                    <div class="çol-md-4 col-md-offset-1">

                                        
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-primary" Height="33px" Width="247px" />

                                        
                                        </br>
                                        </br>
                                        

                                        <asp:Button Text="Incarcare" ID="btnIncarcare" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnIncarcare_Click" />

                                        </br>
                                        </br>

                                        <asp:Button Text="Descarcare" ID="btnDownload" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnDownload_Click" />

                                        </br>
                                        </br>

                                        <asp:Button Text="Stergere" ID="btnStergere" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnStergere_Click" />


                                       </div> 

                                  


                                </div>


                           

                                        


                                



                           



                        </div>

                     </section>


                </div>


                </div>



            </section>

    </section>
</asp:Content>
