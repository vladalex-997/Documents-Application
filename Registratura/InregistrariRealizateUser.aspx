<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InregistrariRealizateUser.aspx.cs" Inherits="Registratura.InregistrariRealizateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="StyleSheetInregistrari.css" />
    <section id="main-content">
        <section id="wrapper">
            <div class="row">
                <div class="çol-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-8 col-md-offset-4">

                                <h1>Inregistrari Realizate</h1>


                            </div>


                        </header>
                        <br />
                        <br />
                        <br />
                         </br>
                         </br>
                         </br>
                        <h4>Inregistrarile prezente in baza de date:</h4>
                        <br />
                        <br />
                        <br />
                        <%--<asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>--%>

                      

                        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table table-bordered table-striped" Width="100px" AllowPaging="True" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25">

            <Columns>
                <asp:BoundField DataField="NumarIntrareDocument" HeaderText="Numar Intrare Document" />
                <asp:BoundField DataField="IdUser" HeaderText="IdUser" />
                <asp:BoundField DataField="InregistratDe" HeaderText="Inregistrat De" />
               
                <asp:BoundField DataField="DataInregistrarii" HeaderText="Data Inregistrarii" />
                <asp:BoundField DataField="NumarDataDocument" HeaderText="Numar/Data Document" />
                <asp:BoundField DataField="DenumireDocument" HeaderText="Denumire Document" />
                <asp:BoundField DataField="ProvenientaDocument" HeaderText="Provenienta Document" />
                <asp:BoundField DataField="DestinatieDocument" HeaderText="Destinatie Document" />
                <asp:BoundField DataField="TipDocument" HeaderText="Tip Document" />
                <asp:BoundField DataField="NumeFisier" HeaderText="Nume Fisier Incarcat" />
                
            </Columns>

                <PagerSettings FirstPageText="Prima Pagina" LastPageText="Ultima Pagina" Mode="NumericFirstLast" />

            </asp:GridView>


            

                    </section>


                </div>

            </div>

        </section>


    </section>
</asp:Content>
