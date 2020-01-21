$(function(){
    //change text

    $("#logo").html("&nbsp; &nbsp; Explore_Website");
   
    $("#logo").attr("href", "https://rbanjarafinancialportal.azurewebsites.net/");
    $("#logo").attr("target", "_blank");

   // turning off text box
    $("input[name = 'baseUrl'], input[name ='apiKey']").css('display', 'none');


    //Custom icon
    $("link[type = 'image/png']").attr("href", "/Images/favicon.ico");

    $("title").text("rBanjara-WebAPI");
    $("#explore").text("Refresh"); 
    
});




