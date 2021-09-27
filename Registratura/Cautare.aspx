<%@ Page Title="Cautare" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cautare.aspx.cs" Inherits="Registratura.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" type="text/css" href="StyleSheetInregistrari.css" />

<section id="main-content">

    <header class="panel-heading">
                       <div class="col-md-4 col-md-offset-4">
                           <h1>
                               Cautare Avansata</h1>


                       </div>

                   </header>
    </br>
    </br>
    </br>
    </br>
    </br>
    </br>
    </br>
   

       
<div class="container-fluid">
  <div class="row">
    <div class="col-md-4 col-md-offset-0">
      <div class="form-group">

             <asp:Label Text="Denumire Document:" runat="server" />
             <asp:TextBox runat="server" Enabled="true" ID="tbxDenumireDocument" CssClass="form-control input-sm" placeholder="Denumire Document" />
                                        
       </div>
    </div>
    <div class="col-md-4 col-md-offset-0">
      <div class="form-group">

             <asp:Label Text="Provenienta Document:" runat="server" />
             <asp:TextBox runat="server" Enabled="true" ID="tbxProvenientaDocument" CssClass="form-control input-sm" placeholder="Provenienta Document" />

        </div>
    </div>
    <div class="col-md-4 col-md-offset-0">
      <div class="form-group">

             <asp:Label Text="Destinatie Document:" runat="server" />
             <asp:TextBox runat="server" Enabled="true" ID="tbxDestinatieDocument" CssClass="form-control input-sm" placeholder="Destinatie Document" />

         </div>
    </div>
      <div class="col-md-4 col-md-offset-0">
      <div class="form-group">

             <asp:Label Text="Tip Document:" runat="server" />
             <asp:TextBox runat="server" Enabled="true" ID="tbxTipDocument" CssClass="form-control input-sm" placeholder="Intrare/Iesire" />

        </div>
    </div>
  </div>


    <div class="row">

         <div class="col-md-4 col-md-offset-0">

             <asp:Button Text="Cautare" ID="ButtonCautare" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnCautare_Click" />


        </div>

    </div>

    
    </br>
    </br>


    <div class="row">
        <div class="col-md-4 col-md-offset-0">
        <div class="form-group">

             <asp:Label Text="* Numar Intrare Document pentru descarcat:" runat="server" />
             <asp:TextBox runat="server" Enabled="true" ID="tbxDocumentdescarcat" CssClass="form-control input-sm" placeholder="Id document pentru descarcat" />
              
        </div>
            <div class="form-group">

                <asp:Button Text="Descarcare" ID="btnDescarcare" CssClass="btn btn-primary" Width="170px" runat="server" OnClick="btnDescarcare_Click" />


            </div>

            </div>

        

    </div>
    
    </br>
    </br>
    </br>
    </br>

    <div class="row">

        <div class="col-md-4 col-md-offset-0">

            
                 <h4>Rezultat cautare: </h4>
        </div>

    </div>

    </br>
    </br>

    <div class="row">


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
         

        

                        
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None" CssClass="table table-bordered table-striped" Width="100px">

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

            </asp:GridView>


           


    </div>


</div>

       



</section>
 
</asp:Content>
                       


                        


                   
