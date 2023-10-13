/**
 * Created with JetBrains PhpStorm.
 * User: Tinh
 * Date: 11/25/13
 * Time: 5:40 PM
 * To change this template use File | Settings | File Templates.
 */
$(document).ready(function(){
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
});