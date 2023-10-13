/**
 * Created by tinhnguyenvan on 6/26/14.
 */
$(document).ready(function(){
    $(".show_more").bind("click",function(){
        val_id = $(this).attr("data-id");
        /**begin tra lai trang thai ban dau*/
        $(".show_more_hidden").hide(100);
        /**end tra lai trang thai ban dau*/

        /**begin su ly truoc*/
        $(".show_more_"+val_id).toggle(500);
        /**end su ly truoc*/
    });
});
