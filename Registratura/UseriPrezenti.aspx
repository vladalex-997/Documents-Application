<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UseriPrezenti.aspx.cs" Inherits="Registratura.UseriPrezenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <link rel="stylesheet" type="text/css" href="StyleSheetInregistrari.css" />
    <section id="main-content">
        <section id="wrapper">
            <div class="row">
                <div class="çol-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            <div class="col-md-8 col-md-offset-5">

                                <h1>Utilizatori Prezenti</h1>


                            </div>


                        </header>
                        <br />
                        <br />
                        <br />
                         </br>
                         </br>
                         </br>
                        <h4>Utilizatori prezenti in baza de date:</h4>
                        
                        <br />
                        <br />
                        <br />
                       <%-- <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
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
                      

            

                        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table table-bordered table-striped" Width="100px" AllowPaging="True" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" PageSize="25">

            <Columns>
                <asp:BoundField DataField="IdUser" HeaderText="Id User" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="NumeUtilizator" HeaderText="Nume Utilizator" />
               
                <asp:BoundField DataField="Parola" HeaderText="Parola" />
                <asp:BoundField DataField="Acces" HeaderText="Acces" />
                <asp:BoundField DataField="Grup" HeaderText="Grup" />
                <asp:BoundField DataField="Passwordcheck" HeaderText="Passwordcheck" />
                <asp:BoundField DataField="StatusUser" HeaderText="Status User" />
               
               
                
            </Columns>

                <PagerSettings FirstPageText="Prima Pagina" LastPageText="Ultima Pagina" Mode="NumericFirstLast" />

            </asp:GridView>


             
                      

                    </section>


                </div>

            </div>

        </section>


    </section>


</asp:Content>
