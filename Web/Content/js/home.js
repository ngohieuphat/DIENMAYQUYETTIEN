/**
 * Created by Tran Anh Tuan on 28-Nov-17.
 */
$(window).load(function(){
    $('.flexslider').flexslider({
        animation: "fade",
        easing: "swing",
        prevText: '<i class="fa fa-angle-left" aria-hidden="true"></i>',
        nextText: '<i class="fa fa-angle-right" aria-hidden="true"></i>',
        animationLoop: true,
        pauseOnAction: true, // default setting
        start: function(slider){
            $('.flexslider').removeClass('loading');
        },
        after: function(slider) {
            /* auto-restart player if paused after action */
            if (!slider.playing) {
                slider.play();
            }
        }
    });

    $('.product-feature').owlCarousel({
        items:4,
        loop:true,
        margin:25,
        nav:true,
        dots: false,
        navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>'],
        responsiveClass:true,
        lazyContent: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        center: false,
        responsive:{
            0:{
                items:1
            },
            450:{
                items:2
            },
            768:{
                items:4,
                nav:true
            }
        }
    });

    $('.product-tab').owlCarousel({
        items:4,
        loop:true,
        margin:25,
        nav:true,
        dots: false,
        navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>'],
        responsiveClass:true,
        lazyContent: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        center: false,
        responsive:{
            0:{
                items:1
            },
            450:{
                items:2
            },
            768:{
                items:4,
                nav:true
            }
        }
    });

    var pdefault = $('#product-list .nav-tabs li.active a').attr('href');
    $('.tab-content > div').hide();
    $(pdefault).show();
    $('#product-list .nav-tabs a').click(function(){
        $('.tab-content > div').hide();
        var active = $(this).attr('href');
        $(active).show();
    });

    $('.news').owlCarousel({
        items:3,
        loop:true,
        margin:25,
        nav:true,
        dots: false,
        navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>'],
        responsiveClass:true,
        lazyContent: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        center: false,
        responsive:{
            0:{
                items:1
            },
            450:{
                items:2
            },
            768:{
                items:3,
                nav:true
            }
        }
    });

    $('.videos').owlCarousel({
        items:2,
        loop:true,
        margin:25,
        nav:true,
        dots: false,
        navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>'],
        responsiveClass:true,
        lazyContent: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        center: false,
        responsive:{
            0:{
                items:1
            },
            450:{
                items:2
            },
            768:{
                items:2,
                nav:true
            }
        }
    });
    $('#video').on('hidden.bs.modal', function (e) {
        $('#video-title').html("");
        $("#video-iframe").attr('src', "");
    });
});

loadWebsiteVideo = function (el) {
    var title = el.getAttribute("data-title");
    var src = el.getAttribute("data-video") + "?autoplay=1";
    $('#video-title').html(title);
    $("#video-iframe").attr('src', src);
    $('#video').modal({});
};