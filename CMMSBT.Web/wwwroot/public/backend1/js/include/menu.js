/**
 * Created with JetBrains PhpStorm.
 * User: Tinh
 * Date: 11/9/13
 * Time: 9:48 AM
 * To change this template use File | Settings | File Templates.

 */

$(document).ready(function(){
    /*begin chon cac hien thi cho menu*/
    $('#menu_com').bind('change',function(){
        var _com = $(this).val();
        if(_com){
            $.ajax({
                url: configs.admin_url+'menu/getView/'+_com,
                dataType: 'html',
                success:function(data){
                    $('#menu_view').html(data);
                }
            });
            
        }
    });
    /*end chon cac hien thi cho menu*/
});
