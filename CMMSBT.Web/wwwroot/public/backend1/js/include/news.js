/**
 * Created with JetBrains PhpStorm.
 * User: ManhHuy
 * Date: 9/12/13
 * Time: 9:31 AM
 * To change this template use File | Settings | File Templates.
 */


$(document).ready(function(){
    var hd = $('#hdnews_type').val();
    if( hd ==3 ){
        $('.view_hidden').show(1);
    }
    else{
        $('.view_news').show(1);
    }
    $('#news_type').bind('change',function(){
    var _val = $(this).val();
    if(_val==3){
        $('.view_hidden').fadeIn(200);
        $('.view_news').fadeOut(200);
    }
    else{
        $('.view_hidden').fadeOut(200);
        $('.view_news').fadeIn(200);
    }
   });
    /*remove file*/
    $(document).on('click', '.removePic', function() {
        var filename = $(this).attr('data-name');
        var id = $(this).attr('data-service-id');
        var obj = $(this);
        if(filename)
        {
            datastring = 'filename='+filename+'&id='+id;
            $.ajax({
                data:datastring,
                type:'post',
                url:configs.admin_url+'news/removeFile/',
                success:function(data){
                    obj.parent('li').remove();
                }
            });
        }
    });
})
