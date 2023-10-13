/**

 * Created with JetBrains PhpStorm.

 * User: Tinh

 * Date: 11/22/13

 * Time: 2:46 PM

 * To change this template use File | Settings | File Templates.

 */

/**begin thong tin doanh nghiep*/
$(document).ready(function () {


    $(".iCheck-helper").addClass("option_video config_mail");
    $(".view_map").bind("click", function () {

        view_id = $(this).attr("data-id");

        $(".show_view_map_" + view_id).animate({right: "0px"}, 600);

    });

    $(".close_view_map").bind("click", function () {

        view_id = $(this).attr("data-id");

        $(".show_view_map_" + view_id).animate({right: "-5000px"}, 600);

    });
    $(".add_contact").click(function () {
        $(".add_info_company").toggle();

    });

    $(".add_support").click(function () {
        $(".add_support_info").toggle();
    });

    /**end thong tin doanh nghiep*/


    /**begin xu ly chon gmail*/

    $(".common_mail_display").hide(1);

    $(".mail_display_gmail").show(100);

    hd_video = $("#hd_mail_type").val();

    if (hd_video) {

        $(".common_mail_display").hide(1);

        $(".mail_display_" + hd_video).show(1);

    }

    $(".config_mail").bind("click", function () {

        $(".common_mail_display").hide(400);

        type = $(this).prev("input").attr("data-link");

        $(".mail_display_" + type).show(400);

    });


    /**begin chon kieu upload*/

    $(".upload_google").hide(1);

    hd_type_upload = $("#hd_type_upload").val();

    if (hd_type_upload == "google") {

        $(".upload_google").show(1);

    }

    $(".type_upload").bind("click", function () {

        type = $(this).prev("input").val();

        if (type == "google")

            $(".upload_google").show(400);

        else {

            $(".upload_google").hide(400);

        }

    });

});

/**begin upload hinh anh*/

$(function () {

    'use strict';

    var url_favicon = configs.base_url + 'public/backend/library/upload/config/files_favicon.php';

    var url = configs.base_url + 'public/backend/library/upload/config/files_logo.php';

    /**begin logo*/

    $('#logo_picture').fileupload({

        url: url,

        dataType: 'json',

        done: function (e, data) {

            $.each(data.result.files, function (index, file) {

                $('<li/>').html(file.name + '<input type="hidden" name="config_logo" value="' + file.name + '" />').appendTo('#files_logo');

            });

        },

        progressall: function (e, data) {

            var progress = parseInt(data.loaded / data.total * 100, 10);

            $('#progress_logo .bar').css(

                'width',

                progress + '%'

            );

        }

    });

    /**end logo*/


    /**begin favicon*/

    $('#favicon_picture').fileupload({

        url: url_favicon,

        dataType: 'json',

        done: function (e, data) {

            $.each(data.result.files, function (index, file) {

                $('<li/>').html(file.name + '<input type="hidden" name="config_favicon" value="' + file.name + '" />').appendTo('#files_favicon');

            });

        },

        progressall: function (e, data) {

            var progress = parseInt(data.loaded / data.total * 100, 10);

            $('#progress_favicon .bar').css(

                'width',

                progress + '%'

            );

        }

    });

    /**end picture*/


    $('.delete_config_background').bind('click',function(){
        $.ajax({
            type:'post',
            url:configs.admin_url+'config/del_background/',
            success:function(data){
                $('.config_background,.delete_config_background').remove();
            }
        });
    });

});

/**end upload hinh anh*/

