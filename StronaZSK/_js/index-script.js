$(document).ready(function(){
    $('#projects-links img').each(function(){
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
    
    $('.bxslider').bxSlider({
        auto: true,
        autoControls: false
    });
});