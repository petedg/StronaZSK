<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gallery.aspx.cs" Inherits="StronaZSK.galleries.gallery1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8"/> 
    <title>Galeria - fotografie | Zakład Systemów Komputerowych</title>
    <link rel="stylesheet" href="/_css/template-stylesheet.css"/>    
    <link rel="stylesheet" href="/_css/gallery-stylesheet.css"/>   
    <link rel="stylesheet" href="/_css/plugins/fancybox/jquery.fancybox.css"/>    
    <link href="/_css/plugins/colored-dropdown-menu-styles.css" rel="stylesheet" media="all" />      
    <script src="/_js/jquery-1.11.2.min.js"></script>        
    <script src="/_js/template-script.js"></script> 
    <script src="/_js/plugins/jquery.fancybox.pack.js"></script>  
    <script>
        $(document).ready(function () {
            $('.fancybox').fancybox({
                openEffect: 'elastic',
                closeEffect: 'elastic',
                helpers: {
                    title: {
                        type: 'over'
                    }
                },
                cycle: true
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <!--Nie wrzucać tu nic.-->
        </header>
	
        <asp:Panel ID="panelGallery" runat="server" CssClass="main-layout">
            <a id="previous-page" href="/galleries/gallery_navigation.aspx">Powrót do strony głównej galerii</a>
        </asp:Panel>
      
        <footer>
            <!--Nie wrzucać tu nic.-->
        </footer>
    </form>
</body>
</html>