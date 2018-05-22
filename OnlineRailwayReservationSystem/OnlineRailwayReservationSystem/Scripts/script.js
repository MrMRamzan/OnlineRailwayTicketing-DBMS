jQuery(function(){
jQuery('#camera_wrap_1').camera({
thumbnails: true,
height: '540px'
});
});
		
		
		
  jQuery(document).ready(function($){
                $(".tabs-widget_tabs-id").hide();
                $("ul.widget_tabs-id li:first a").addClass("tabs-widget-current").show();
                $(".tabs-widget_tabs-id:first").show();
      
                $("ul.widget_tabs-id li a").click(function() {
                    $("ul.widget_tabs-id li a").removeClass("tabs-widget-current a");
                    $(this).addClass("tabs-widget-current");
                    $(".tabs-widget_tabs-id").hide();
                    var activeTab = $(this).attr("href");
                    $(activeTab).fadeIn();
                    return false;
                });
            });   

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
	  



