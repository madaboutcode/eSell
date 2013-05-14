$(function() {
    $('#categories-minimenu').append($('#taxonomy-menu ul').clone());
    var showMenu = function(e) {
        var $el = $('#categories-minimenu');
        $el.toggleClass('hover');
        e.preventDefault();
        e.stopPropagation();
    };

    if(/iphone|ipad|android/i.test(navigator.userAgent) == false) {
        $('#categories-minimenu').hover(showMenu, showMenu);
    }
    else {
        $('#categories-minimenu h2,#categories-minimenu b#micro-icon').click(showMenu);
    }
    console.log($(window).width());
    var $heroImg = $('.detail-heroimage img');
    if($(window).width() < $heroImg.width()) {
        $heroImg.removeAttr('width', '').removeAttr('height', '').width('90%');
    }
});