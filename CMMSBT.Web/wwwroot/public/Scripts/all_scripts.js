//All Scripts
$(document).ready(function() {
	$('.collapse').find('li ul').parent().addClass('dropdown');
	$('.collapse li.dropdown').prepend('<span></span>');
	$('.collapse li.dropdown>span').attr({
		'class': 'dropdown-toggle',
		'data-toggle': 'dropdown',
		'role': 'button',
		'aria-expanded': 'false'
		}); 
	$('.navbar-toggle').click(function(){
                            $(this).toggleClass('navbar-toggle-collapsed');
			$('.overlay-menu').toggleClass('show');	
			$('body').toggleClass('hide-srcoll');		
                        });
	$('.navbar-toggle-collapsed').click(function(){   
			$(".overlay-menu").remove();                       		
                        });	
	$('.collapse li.dropdown>span').click(function(){
                            $(this).toggleClass('sub-toggle-collapsed');				
                        });	
$('.collapse .dropdown-toggle').on('click', function(e) {
     var $el = $(this);
     var $parent = $(this).offsetParent(".dropdown-menu");
     $(this).parent("li").toggleClass('open');
     $('.collapse li.open').not($(this).parents("li")).removeClass("open").find('.dropdown-toggle').removeClass("sub-toggle-collapsed");	
     return false;
    });
});
    $('.account-link-pad').click(function () {
        $(this).parent().find('.contentEGP').slideToggle(200);
    });
	$('.close-form').click(function () {
                $('.account-area .contentEGP').hide();
            });	
    $('.click-voucher').click(function () {
        $(".cart-voucher").slideToggle();
        $(".voucher-ques").hide();
    });
    $(".item-cargo .box-ct").click(function () {
        $(this).next(".box-item").slideToggle();
    });
$(".categoryitems:first").show();
    $(".menuheader:first").addClass('current');
    $(".menuheader").click(function () {
        $(this).addClass('current').siblings().removeClass('current');
        $(this).next(".categoryitems").slideDown(300).siblings(".categoryitems:visible").slideUp(300);
    });
$(document).ready(function () {
	$('.left-nav').find('li ul').parent().addClass('has-sub');
	/*$('.slider-home').slick({
		autoplay: true,
		autoplaySpeed: 3000,		
		arrows: false,
		speed:1000,
		dots: true
	});*/
	$('.featured-cates,.featured-prods').slick({
        dots: false,
        infinite: true,
        speed: 1000,
        autoplaySpeed: 8000,
        autoplay: false,
        lazyLoad: "progressive",
        slidesToShow: 6,
        slidesToScroll: 6,
        responsive: [
          {
              breakpoint: 1199,
              settings: {
                  slidesToShow: 5,
                  slidesToScroll: 5,
                  infinite: true
              }
          },
          {
              breakpoint: 980,
              settings: {
                  slidesToShow: 4,
                  slidesToScroll: 4
              }
          },
          {
              breakpoint: 768,
              settings: {
                  slidesToShow: 3,
                  slidesToScroll: 3
              }
          },
          {
              breakpoint: 640,
              settings: {
                  slidesToShow: 2,
                  slidesToScroll: 2
              }
          }
        ]
    });
	$('.sl-news').slick({
        dots: false,
        infinite: true,
        speed: 1000,
        autoplaySpeed: 8000,
        autoplay: false,
        lazyLoad: "progressive",
        slidesToShow: 5,
        slidesToScroll: 5,
        responsive: [
          {
              breakpoint: 1199,
              settings: {
                  slidesToShow: 4,
                  slidesToScroll: 4,
                  infinite: true
              }
          },
          {
              breakpoint: 980,
              settings: {
                  slidesToShow: 3,
                  slidesToScroll: 3
              }
          },
          {
              breakpoint: 640,
              settings: {
                  slidesToShow: 2,
                  slidesToScroll: 2
              }
          },
          {
              breakpoint: 420,
              settings: {
                  slidesToShow: 1,
                  slidesToScroll: 1
              }
          }
        ]
    });	 
	$('.slideLogo').slick({
            dots: false,
            arrows: false,
            infinite: true,
            autoplay: true,
            autoplaySpeed: 4000,
            autoplay: true,
            speed: 1000,
            slidesToShow: 6,
            slidesToScroll: 1,
            responsive: [   
              {
                    breakpoint: 980,
                    settings: {
                        slidesToShow: 5,
                        slidesToScroll: 1
                    }
                },                             
                {
                    breakpoint: 767,
                    settings: {
                        slidesToShow: 4,
                        slidesToScroll: 1
                    }
                },                             
                {
                    breakpoint: 640,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 1
                    }
                },
                {
                    breakpoint: 400,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1
                    }
                }
            ]
        });  
    autoresize();
    $(window).resize(autoresize);

    function autoresize() {
	var ww = $(window).width();
	    hw = $(window).height(); 
	    w_c = $('.container').outerWidth();
	    w_t = $('.mod-sideDeal').outerWidth();
	    w_mnc = $('.payment-page>div:last-child').outerWidth();
		if ($( window ).width() > 980) {
				$('.slider-home img').css('height','407px');	
			} else {								
				$('.slider-home img').css('height',ww * 407 / 910);
			} 
		if ($(window).width() > 992) {
            $('#maincate-nav').removeClass('in');			
		}
		$('#mini-cart').css('width',w_mnc - 30);
        $('.other-products').css('width', w_t - 30);
        if ($(window).width() < 769) {            		
			$('.left-nav ul ul').hide();
			$('.left-nav li.has-sub h4').append('<span class="fa"></span>');
			$('.left-nav li.has-sub span').click(function(e){	 
				$(this).parents().toggleClass('active');			   
			 	$(this).parent().next('ul').slideToggle();
			});		
        }        
    }	    
    $("#filters div.toggler").click(function () {
        $(this).parent().toggleClass("float");
    });
$(window).load(function () {
		setTimeout(function(){ $('.clsconsolPopup').modal('show'); }, 500);
    });
    //Zooom			
    var zoomCollection = '#image';
    $(zoomCollection).elevateZoom({
        lensShape: "basic",
        lensSize: 150,
        //easing:true,
        gallery: 'image-additional-carousel',
        zoomType: "inner",
        cursor: "zoom-in",
        galleryActiveClass: "active",
        imageCrossfade: true,
        loadingIcon: 'http://www.elevateweb.co.uk/spinner.gif'
    });
    $('#image-additional-carousel .elevatezoom-gallery:first').addClass('active');
    $(zoomCollection).bind("click", function (e) {
        var ez = $(zoomCollection).data('elevateZoom');
        ez.closeAll(); //NEW: This function force hides the lens, tint and window	
        $.fancybox(ez.getGalleryList());
        return false;
    });
    $('#image-additional-carousel').each(function () {
        if ($(this).find(".elevatezoom-gallery").length > 1) {
            $(this).slick({
                slidesToShow: 4,
                slidesToScroll: 4,
                dots: false,
                arrows: true,
                centerMode: false,
                focusOnSelect: true,
                infinite: true,
                responsive:[{breakpoint:980,settings:{slidesToShow:7,slidesToScroll:7}},{breakpoint:768,settings:{slidesToShow:6,slidesToScroll:6}},{breakpoint:640,settings:{slidesToShow:5,slidesToScroll:5}},{breakpoint:560,settings:{slidesToShow:4,slidesToScroll:4}}]})
        } else {
            $(this).hide();
        }
    });	
    //Raty	
    $(".basic").jRating({
                    step: true,
                    length: 5,
                    decimalLength: 0
                });
$(".link-compare").fancybox({
            'titlePosition'     : 'inside',
            'transitionIn'      : 'none',
            'transitionOut'     : 'none'
    });
$("#popup-compare .merchant-logo img").wrap("<span'></span>");
jQuery('ul.tabs').each(function(){
    // For each set of tabs, we want to keep track of
    // which tab is active and it's associated content
    var $active, $content, $links = jQuery(this).find('a');

    // If the location.hash matches one of the links, use that as the active tab.
    // If no match is found, use the first link as the initial active tab.
    $active = jQuery($links.filter('[href="'+location.hash+'"]')[0] || $links[0]);
    $active.parent().addClass('active');

    $content = $($active[0].hash);

    // Hide the remaining content
    $links.not($active).each(function () {
        jQuery(this.hash).hide();
    });

    // Bind the click event handler
    jQuery(this).on('click', 'a', function(e){
        // Make the old tab inactive.
        $active.parent().removeClass('active');
        $content.hide();

        // Update the variables with the new link and content
        $active = jQuery(this);
        $content = jQuery(this.hash);

        // Make the tab active.
        $active.parent().addClass('active');
        $content.fadeIn(200);
	
        // Prevent the anchor's default click action
        e.preventDefault();
    });
});
    $('.pros-cate').slick({
        dots: false,
        infinite: true,
        speed: 1000,
        autoplaySpeed: 8000,
        autoplay: false,
        lazyLoad: "progressive",
        slidesToShow: 4,
        slidesToScroll: 4,
        responsive: [
          {
              breakpoint: 1199,
              settings: {
                  slidesToShow: 3,
                  slidesToScroll: 3,
                  infinite: true
              }
          },
          {
              breakpoint: 640,
              settings: {
                  slidesToShow: 2,
                  slidesToScroll: 2
              }
          }
        ]
    });
$(".other-products .slide-v-pros").slick({
        dots: true, arrows: false, speed: 1000, autoplaySpeed: 4000, slidesToShow: 5, slidesToScroll: 5, vertical: true, verticalSwiping: true, lazyLoad: "progressive",
        responsive: [
           {
               breakpoint: 1199,
               settings: {
                   slidesToShow: 4,
                   slidesToScroll: 4
               }
           },
          {
              breakpoint: 980,
              settings: {
                  slidesToShow: 3,
                  slidesToScroll: 3,
		vertical: false
              }
          },
          {
              breakpoint: 640,
              settings: {
                  slidesToShow: 2,
                  slidesToScroll: 2,
		vertical: false
              }
          },
          {
              breakpoint: 420,
              settings: {
                  slidesToShow: 1,
                  slidesToScroll: 1,
		vertical: false
              }
          }
        ]
    });
    //Stick
    $(".sticky").sticky({ topSpacing: 60, bottomSpacing: 900 });
    //Video
    $(".info-g iframe").wrap("<div class='videoWrapper'></div>");
    $(".videoWrapper").wrap("<div class='youtubevideowrap'></div>");
});