/* google analytics TRACKS*/
var _gaq = _gaq || [];
 _gaq.push(['_setAccount', 'UA-2662731-6']);
 _gaq.push(['_trackPageview']);

(function() {
   var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
   ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
   var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
 })();

Shadowbox.init({ handleOversize: "drag", modal: true });
$(function () {
    $("#accordion").accordion({ autoHeight: false, navigation: true });

    var ticker = function () {
    setTimeout(function () 
        {
            $('#ticker li:first').animate({ marginTop: '-120px' }, 800, function () {$(this).detach().appendTo('ul#ticker').removeAttr('style');});
            ticker();
       }, 4000);
    };
    ticker();
    $(".water").each(function () {
        $tb = $(this);
        if ($tb.val() != this.title) { $tb.removeClass("water"); }
    });

    $(".water").focus(function () {
        $tb = $(this);
        if ($tb.val() == this.title) { $tb.val(""); $tb.removeClass("water"); }
    });

    $(".water").blur(function () {
        $tb = $(this);
        if ($.trim($tb.val()) == "") {
            $tb.val(this.title); $tb.addClass("water");
        }
    });
}); 