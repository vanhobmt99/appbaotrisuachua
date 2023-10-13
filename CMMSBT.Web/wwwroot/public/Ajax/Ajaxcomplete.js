$.widget("custom.catcomplete", $.ui.autocomplete, {
    _create: function () {
        this._super();
        this.widget().menu("option", "items", "> :not(.ui-autocomplete-category)");
    },
    _renderMenu: function (ul, items) {
        var that = this,
    currentCategory = "";
        $.each(items, function (index, item) {
            var li;
            if (item.category != currentCategory) {
                ul.append("<li class='ui-autocomplete-category'>" + item.category + "</li>");
                currentCategory = item.category;
            }
            li = that._renderItemData(ul, item);
            if (item.category) {
                li.attr("aria-label", item.category + " : " + item.label);
                li.attr("onclick", "redirect('" + item.NewSeoUrl + "')");
            }
        });
    }
});
$(function () {
    $('#txtsearch').catcomplete({
        delay: 0,
        source: function (request, response) {
            var sText = request.term;
            clearTimeout($(this).data('timer'));
            $(this).data('timer', setTimeout(function () {
                $.ajax({
                    type: "POST",
                    url: "/vi-vn/Ajax-customer.aspx/autocomplete",
                    data: "{searchitem:'" + sText + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        response($.map(result.d, function (el) {
                            return {
                                label: el.title,
                                category: el.catname,
                                NewSeoUrl: el.NewSeoUrl
                            };
                        }));
                    }
                });
            }, 400));
        }
        , select: function (event, ui) {
            //document.location = "/" + ui.item.NewSeoUrl + "/";
            //document.location = "/tim-kiem/?page=0&keyword=" + ui.item.value;
        }
    });
});
function redirect(str) {
    document.location = "/" + str + ".html";
}