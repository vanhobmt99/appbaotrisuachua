/**
 * Created by tinhnguyenvan on 6/27/14.
 */
$(document).ready(function(){
    $("#translate_name").bind("blur",function(){
        translate_name = $(this).val();
        $("#tieng-viet").val(translate_name);
        if(translate_name==""){
            $("#translate_alias").val("");
        }else{
            datastring = 'translate_name='+translate_name;
            $.ajax({
                type:'post',
                data:datastring,
                url:configs.admin_url+'translate/aj_translate_alias/',
                success:function(data){
                    if(data){
                        $("#translate_alias").val(data);
                    }
                }
            });
        }
    });

    /**begin cap nhat ten dich thuat ngon ngu*/
    $(document).on("click",".edit_translate_name",function(){
        var translate_name = $(this).attr("data-name");
        var translate_id = $(this).attr("data-id");
        var translate_lang = $(this).attr("data-lang");
        $(this).parents(".sub_translate_name").html('<div class="input-group" style="max-width: 212px;">' +
            '<input type="text" class="form-control input-sm fr_translate_name" value="'+translate_name+'" />' +
            '<span class="input-group-btn">' +
            '<button class="btn btn-primary btn-flat btn-sm pointer save_translate_name" type="button" data-id="'+translate_id+'" data-lang="'+translate_lang+'" title="Save">' +
            '<i class="fa fa-save"></i>' +
            '</button>' +
            '</span>' +
            '</div>');
    });
    /**end cap nhat ten dich thuat ngon ngu*/

    /**begin save ngon ngu*/
    $(document).on("click",".save_translate_name",function(){
        var translate_name = $(this).parent("span").prev(".fr_translate_name").val();
        var translate_id = $(this).attr("data-id");
        var translate_lang = $(this).attr("data-lang");
        if(translate_name){
            /**begin xu ly ajax*/
            var obj = $(this).parent("span").parent("div.input-group");
            datastring = 'translate_name='+translate_name+'&translate_id='+translate_id+'&translate_lang='+translate_lang;
            $.ajax({
                type:'post',
                data:datastring,
                url:configs.admin_url+'translate/aj_update/',
                success:function(data){
                    if(data==1){
                        obj.parents(".sub_translate_name").html('<div class="input-group" style="max-width: 212px;">' +
                            '<input type="text" class="form-control input-sm" disabled placeholder="'+translate_name+'">' +
                            '<span class="input-group-btn">' +
                            '<button class="btn btn-success btn-flat btn-sm pointer edit_translate_name" data-id="'+translate_id+'" data-lang="'+translate_lang+'" data-name="'+translate_name+'">' +
                            '<i class="fa fa-edit"></i>' +
                            '</button>' +
                            '</span>' +
                            '</div>');
                    }else{
                        alert("Please check data !");
                    }
                }
            });
            /**end xu ly ajax*/
        }else{
            $(this).prev(".fr_translate_name").addClass("fr_error");
        }
    });
    /**end save ngon ngu*/

    /**begin search*/
    $(document).on("keyup","#table_search_translate",function(){
        val_search = $(this).val();
        datastring = 'translate_name='+val_search;
        $.ajax({
            type:'post',
            data:datastring,
            url:configs.admin_url+'translate/aj_search/',
            success:function(data){
                if(data){
                    $(".aj_search").html(data);
                }
            }
        });
    });
    /**end search*/
});