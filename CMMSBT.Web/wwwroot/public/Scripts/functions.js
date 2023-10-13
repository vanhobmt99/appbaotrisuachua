$(document).ready(function () {
    loadDataHome();
    checkIsHome();

    var url = window.location.href;
    var sValueBr = getParameterByName("brand", url);
    if (sValueBr != "" && sValueBr != null) {
        var Values = sValueBr.split('-');
        for (var i = 0; i < Values.length; i++) {
            $('#brand_' + Values[i]).attr('checked', true);
        }
    }

    var sValueSanXuat = getParameterByName("madein", url);
    if (sValueSanXuat != "" && sValueSanXuat != null) {
        var Values = sValueSanXuat.split('-');
        for (var i = 0; i < Values.length; i++) {
            $('#madein_' + Values[i]).attr('checked', true);
        }
    }

    var sValueSor = getParameterByName("sort", url);
    if (sValueSor != "" && sValueSor != null) {
        var Values = sValueSor.split('-');
        for (var i = 0; i < Values.length; i++) {
            $("#sort-select").val(Values[i]);
        }
    }

    $("#txtsearch").keyup(function (event) {
        if (event.keyCode === 13) {
            window.location.href = "/tim-kiem.html?page=0&key=" + $("#txtsearch").val();
        }
    });
});
function loadDataHome() {
    //$('#loading').html("<img src='/vi-vn/images/loader.gif' alt='loading'/>").fadeIn('fast');
	var $opts = {
	    dots: false,
        infinite: true,
        speed: 1000,
        autoplaySpeed: 8000,
        autoplay: false,
        lazyLoad: "progressive",
        slidesToShow: 8,
        slidesToScroll: 8,
        responsive: [
          {
              breakpoint: 1199,
              settings: {
                  slidesToShow: 7,
                  slidesToScroll: 7,
                  infinite: true
              }
          },
          {
              breakpoint: 980,
              settings: {
                  slidesToShow: 6,
                  slidesToScroll: 6
              }
          },
          {
              breakpoint: 768,
              settings: {
                  slidesToShow: 5,
                  slidesToScroll: 5
              }
          },
          {
              breakpoint: 640,
              settings: {
                  slidesToShow: 4,
                  slidesToScroll: 4
              }
          },
          {
              breakpoint: 480,
              settings: {
                  slidesToShow: 3,
                  slidesToScroll: 3
              }
          }
        ]
	}

	$('.sl-logos').slick('unslick');
    $.ajax({
        type: "POST",
        url: '/vi-vn/AjaxHomeContent.aspx',
        success: function (e) {
            $("#ajaxHome").replaceWith("<div class='list-categories-pros' id='ajaxHome'>" + e + "</div>");
            //$('#loading').fadeOut('fast');
			// reinitialize 
        	$('.sl-logos').slick($opts);
        }
    });
}
function loadDataCompare(newid) {
    //$('#loading').html("<img src='/vi-vn/images/loader.gif' alt='loading'/>").fadeIn('fast');
    $.ajax({
        type: "POST",
        url: '/vi-vn/AjaxCompare.aspx?newid=' + newid,
        success: function (e) {
            $("#ajaxCompare").replaceWith("<div class='row' id='ajaxCompare'>" + e + "</div>");
            //$('#loading').fadeOut('fast');
        }
    });
}
function checkIsHome(){
    var sPath = window.location.pathname;
    if (sPath != "/" && sPath != "/trang-chu.html")
    {
        $("#maincate-nav").css("display", "none");
    }
}
function viewmore(slink) {
    $('#loading').html("<img src='/vi-vn/images/loader.gif' alt='loading'/>").fadeIn('fast');
    $.ajax({
        type: "POST",
        url: '/vi-vn/ajaxListProduct.aspx' + slink,
        data: "slink=" + slink + "",
        success: function (e) {
            $('#iGrid').fadeIn('fast');
            $("#ajaxLoad").replaceWith("<div class='list-products-page column-items' id='ajaxLoad'>" + e + "</div>");
            $("#iCountMain").text($('#iCountPro').val());
            $('#loading').fadeOut('fast');

            $("body, html").animate({
                scrollTop: $('#idTitleMain').offset().top
            }, 600);
        }
    });
}
function ChangeUrl(sType, sValue) {
    $('#iGrid').fadeOut('fast');
    var url = GetkUrl(sType, sValue);
    if (typeof (history.pushState) != "undefined") {
        var obj = { Title: sType, Url: url };
        history.pushState(obj, obj.Title, obj.Url);
        viewmore(obj.Url);
    } else {
        alert("Browser does not support HTML5.");
    }
}
function GetkUrl(sType, sValue) {
    var url = window.location.href;
    //if (url.includes("?page=")) {
    if (url.indexOf("?page=") > -1) {
        var lengTotal = url.length;
        var lengIdex = url.indexOf("?page=");
        var sQuery = url.substring(lengIdex, lengTotal);

        url = sQuery;
    }
    else {
        var idCat = $('#ContentPlaceHolder1_ctl00_idCatPage').val();
        url = "?page=0&price=&key=&brand=&madein=&sort=&idCat=" + idCat;
    }
    return updateQueryStringParameter(url, sType, sValue);
}
function updateQueryStringParameter(uri, key, value) {
    var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
    var separator = uri.indexOf('?') !== -1 ? "&" : "?";
    if (uri.match(re)) {
        if (key == "brand" || key == "madein" || key == "sort") {
            var _uri = uri.replace(re, '$1' + key + "=" + value + '$2');
            var _key = "page";
            var _value = "0";
            var _re = new RegExp("([?&])" + _key + "=.*?(&|$)", "i");
            if (_uri.match(_re)) {
                _uri = _uri.replace(_re, '$1' + _key + "=" + _value + '$2');
            }
            return _uri;
        }
        else {
            return uri.replace(re, '$1' + key + "=" + value + '$2');
        }
    }
    else {
        return uri + separator + key + "=" + value;
    }
}
function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}
//Begin Sort
$('#sort-select').change(function () {
    var val = $("#sort-select option:selected").val();
    ChangeUrl("sort", val);
});
//End Sort

//Begin Brand
$(".chk-manf-select").click(function () {
    someGlobalArray = [];
    $('.chk-manf-select:checked').each(function () {
        someGlobalArray.push($(this).val());
    });
    var _temp = "";
    for (var i = 0; i < someGlobalArray.length; i++) {
        if (i == 0)
            _temp += someGlobalArray[i];
        else
            _temp += "-" + someGlobalArray[i];
    }
    ChangeUrl("brand", _temp);
});
//End Brand

//Begin MadeIn
$(".madein-manf-select").click(function () {
    someGlobalArray = [];
    $('.madein-manf-select:checked').each(function () {
        someGlobalArray.push($(this).val());
    });
    var _temp = "";
    for (var i = 0; i < someGlobalArray.length; i++) {
        if (i == 0)
            _temp += someGlobalArray[i];
        else
            _temp += "-" + someGlobalArray[i];
    }
    ChangeUrl("madein", _temp);
});
//End MadeIn

$(".link-compare").click(function () {
    var newid = $("#ContentPlaceHolder1_ctl00_txtNewsId").val();
    loadDataCompare(newid);
});
$(".quotes").click(function () {
    $.ajax({
        type: "POST",
        url: '/vi-vn/Ajax-customer.aspx/CheckLogined',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (e) {
            if (e.d == "yes")
            {
                addToCart();
            }
        }
    });
});

function checkAction(sValue) {
    $(sValue).click();
}
function redirectDefault() {
    window.location.href = "/" + document.getElementById('ContentPlaceHolder1_ctl00_UrlCat').value;
}