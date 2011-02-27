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