/**
 * Created by Tran Anh Tuan on 28-Nov-17.
 */
$(document).ready(function () {
    $('.product').owlCarousel({
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

    $('#image-gallery').lightSlider({
        gallery: true,
        item: 1,
        auto:false,
        loop:false,
        pager: true,
        enableTouch:true,
        enableDrag:true,
        controls: false,
        speed: 500,
        currentPagerPosition: 'middle',
        autoWidth:false,
        vertical:false,
        vThumbWidth:78,
        thumbItem:4,
        thumbMargin:5,
        slideMargin:0,
        responsive : [
            {
                breakpoint:768,
                settings: {
                    item:1,
                    slideMove:1,
                }
            },
            {
                breakpoint:480,
                settings: {
                    item:1,
                    slideMove:1,
                    vThumbWidth:40,
                    thumbItem:4,
                    thumbMargin:5,
                }
            }
        ],
        onSliderLoad: function (el) {
            el.find('.lslide.active img').addClass('zoom');

            //initiate the plugin and pass the id of the div containing gallery images
            $(".zoom").elevateZoom({
                gallery:'gallery_01',
                cursor: 'pointer',
                galleryActiveClass: 'active',
                imageCrossfade: true,
                loadingIcon: 'http://www.elevateweb.co.uk/spinner.gif',
                tint:true,
                tintColour:'#333',
                tintOpacity:0.5,
                scrollZoom : true,
                responsive: true,
                zoomWindowWidth: 200,
                zoomWindowHeight: 200
            });
        },
        onAfterSlide: function (el) {
            $('.zoomContainer').remove();
            el.find('.lslide img.zoom').removeClass('zoom');
            el.find('.lslide.active img').addClass('zoom');

            //initiate the plugin and pass the id of the div containing gallery images
            $(".zoom").elevateZoom({
                gallery:'gallery_01',
                cursor: 'pointer',
                galleryActiveClass: 'active',
                imageCrossfade: true,
                loadingIcon: 'http://www.elevateweb.co.uk/spinner.gif',
                tint:true,
                tintColour:'#333',
                tintOpacity:0.5,
                scrollZoom : true,
                responsive: true,
                zoomWindowWidth: 300,
                zoomWindowHeight: 300
            });
        }
    });
});