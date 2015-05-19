$(document).ready(function(){
    $('header').load('/index.html header', function(){
        $('#header-social img').each(function(){
            var imgFile = $(this).attr('src');
            var preloadImage = new Image();
            var imgExt = /(\.\w{3,4}$)/;
            preloadImage.src = imgFile.replace(imgExt, '_c$1');
            $(this).hover(
                    function() {
                        $(this).attr('src', preloadImage.src);
                    },
                    function() {
                        $(this).attr('src', imgFile);
                    }
            );
        }); 
        $.getScript("/_js/plugins/colored-dropdown-menu-script.js", function(){
            
        });        
    });
    $('footer').load('/index.html footer');
});