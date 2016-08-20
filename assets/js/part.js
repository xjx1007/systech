$(document).ready(function(){
$(".widget .toolbar .widget-collapse").click(
    function () {
        var A = $(this).parents(".widget");
        var x = A.children(".widget-content");
        var z = A.children(".widget-chart");
        var y = A.children(".divider");
        if (A.hasClass("widget-closed")) {
            $(this).children("i").removeClass("icon-angle-up").addClass("icon-angle-down");
            x.slideDown(200,
                function () { A.removeClass("widget-closed") }); z.slideDown(200);
            y.slideDown(200)
        } else {
            $(this).children("i").removeClass("icon-angle-down").addClass("icon-angle-up");
            x.slideUp(200, function () { A.addClass("widget-closed") }); z.slideUp(200); y.slideUp(200)
        }
    });
});