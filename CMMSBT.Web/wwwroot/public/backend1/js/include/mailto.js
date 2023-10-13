/**begin popup binh luan*/
$(document).ready(function(){
    $('.view_popup').bind('click', function(e) {
        data_id = $(this).attr("data-id");
        e.preventDefault();
        $('.show_video_'+data_id).bPopup();        	
    });
    /**begin xoa muc chon*/
        //When unchecking the checkbox
    $("#check-all").on('ifUnchecked', function(event) {
        //Uncheck all checkboxes
        $("input[type='checkbox']", ".table-checkbox").iCheck("uncheck");
    });
    //When checking the checkbox
    $("#check-all").on('ifChecked', function(event) {
        //Check all checkboxes
        $("input[type='checkbox']", ".table-checkbox").iCheck("check");
    });

    $(".del_option").hide(1);
    $(".iCheck-helper").bind("click",function(){
        $(".del_option").slideDown(300);
        var arr = new Array();
        var temp = arr.length;
        $('.checked').each(function (index) {
            arr.push('checked');
        });
        if (arr.length > temp)
            $(".del_option").slideDown(300);
        else{
            $(".del_option").slideUp(300);
        }
    });
    /**end xoa muc chon*/

    /**begin cap nhat trang thai bang ajax*/
    $(".click_status").bind("click",function(){
    	obj = $(this);
    	var _id = $(this).attr("data-id");
    	$.ajax({
            type:'post',
            data:'&id='+_id,
            url:configs.admin_ajax+'ajbackend/updateStatusMail/',
            success:function(data){            	
            	if(data==1){
            		$(".click_status_"+_id).removeClass("btn-warning");
            		$(".click_status_"+_id).html("Đã duyệt");
            	}
            }
        });
    })
    /**end cap nhat trang thai bang ajax*/
});