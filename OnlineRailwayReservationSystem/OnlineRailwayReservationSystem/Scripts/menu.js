$(document).ready(function(){
    $("#nav-mobile").html($(".menu-secondary-container").html());
    $("#nav-trigger span").click(function(){
        if ($(".menu-secondary-container").hasClass("expanded")) {
            $(".menu-secondary-container.expanded").removeClass("expanded").slideUp(250);
            $(this).removeClass("open");
        } else {
            $(".menu-secondary-container").addClass("expanded").slideDown(250);
            $(this).addClass("open");
        }
    });
});


$(document).ready(function(){
    $("#nav-mobile").html($(".menu-secondary-container").html());
    $("#nav-trigger span").click(function(){
        if ($("nav#nav-mobile ul").hasClass("expanded")) {
            $("nav#nav-mobile ul.expanded").removeClass("expanded").slideUp(250);
            $(this).removeClass("open");
        } else {
            $("nav#nav-mobile ul").addClass("expanded").slideDown(250);
            $(this).addClass("open");
        }
    });
});