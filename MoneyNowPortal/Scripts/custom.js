$(document).ready(function($) {
    //- Multi-Step form
    $(".btn-next").click(function() {
        $(this).parent().next().fadeIn("slow");
        $(this).parent().css({
            "display": "none"
        });
        $(".progressbar .active").next().addClass("active");
    });
    $(".btn-prev").click(function() {
        $(this).parent().prev().fadeIn("slow");
        $(this).parent().css({
            "display": "none"
        });
        $(".progressbar .active:last").removeClass("active");
    });

    //Initializing Data table
    $("#data-table").DataTable();

    //Accordion Toggle
    function toggleIcon(e) {
        $(e.target)
            .prev(".panel-heading")
            .find(".more-less")
            .toggleClass("fa-angle-right fa-angle-down");
    }
    $(".panel-group").on("hidden.bs.collapse", toggleIcon);
    $(".panel-group").on("shown.bs.collapse", toggleIcon);

    //To display a background image for a page.
    function displayCustomBGImage() {
        $("body").css("background-image", "url(../Content/images/home-bg.png)").css("background-size", "cover");
    }
});
