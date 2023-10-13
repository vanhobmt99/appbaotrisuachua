/**
 * Created with JetBrains PhpStorm.
 * User: Tinh
 * Date: 11/27/13
 * Time: 12:08 AM
 * To change this template use File | Settings | File Templates.
 */


/**begin upload hinh anh*/
$(function () {
    'use strict';
    var url = configs.base_url+'public/backend/library/upload/banner/files.php';
    /**begin picture*/
    $('#banner_picture').fileupload({
        url: url,
        dataType: 'json',
        done: function (e, data) {
            $.each(data.result.files, function (index, file) {
                $('<li/>').html(file.name+'<i class="icon-trash trash_file_upload" data-file="picture" title="Xóa '+file.name+'" data-id="" data-name="'+file.name+'"></i><input type="hidden" name="banner_picture" value="'+file.name+'" />').appendTo('#files_picture');
            });
        },
        progressall: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progress_banner .bar').css(
                'width',
                progress + '%'
            );
        }
    });
    /**end picture*/

    /**begin xu ly xoa file*/
    $(document).on("click",".trash_file_upload",function(){
        var trash_file_upload = $(this);
        var url_file_news = "public/frontend/uploads/files/"+configs.base_component+"/";
        var name_file = $(this).attr("data-name");
        var id_name_file = $(this).attr("data-id");
        var type = $(this).attr("data-file");
        var data_file_news = "name_file="+name_file+"&url="+url_file_news+"&id="+id_name_file+"&type="+type ;
        $.ajax({
            type:'post',
            data:data_file_news,
            url:configs.admin_ajax+'ajbackend/delete_file_banner/',
            success:function(data){
                trash_file_upload.parent("li").remove();
            }
        });
    });
    /**end xu ly xoa file*/


});
/**end upload hinh anh*/