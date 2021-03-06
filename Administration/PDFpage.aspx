﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PDFpage.aspx.cs" Inherits="Administration.PDFpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .div1{
            margin-bottom:30px;
        }
        .div2{
            margin-bottom:30px;
        }
        .div3{
            text-align:center;
            margin-bottom:30px;
        }
        .div3 .txt1{
            width:100%;
        }
        .div2 .listbox1{
            width:100%;
        }
        .div2 .div22{
            text-align:center;
        }
    </style>
    <h1 style="text-align:center">PDF Page</h1>
    <br />
    <br />
    <div class="div1">
        <asp:FileUpload ID="PdfInput" runat="server" />
        <div>
            <asp:Button runat="server" OnClick="PDF_Upload_Click" Text="Send" />
        </div>
    </div>

    <div class="div2">
        <asp:ListBox runat="server" id="listbox1" OnPreRender="GetListFile" CssClass="listbox1"></asp:ListBox>
        <div class="div22">
            <asp:Button runat="server" OnClick="PDF_Delete_Click" Text="Delete the PDF Selected"  />
        </div>
    </div>
    <div class="div3">
        <div>
            <asp:Button ID="btnGet" runat="server" Text="Show URL"></asp:Button>
        </div>
    </div>
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("[id*=btnGet]").click(function () {
            var values = "";
            var selected = $("[id*=listbox1] option:selected").html();
            values = "PDF name Selected : " + selected + "\n\n You can copy and paste this url : \n" +window.location.host+"/PDFFolder/"+ selected;
            alert(values);
            return false;
        });
    });
</script>
</asp:Content>
