$(document).ready(function(){$(".zoom_img").colorbox({rel:'zoom_img'});});
function include(filename)
{document.write('<script type="text/javascript" src="'+filename+'"></script>');}
if(configs.base_component!=""){include(configs.base_js+'include/'+configs.base_component+'.js');}
$(document).ready(function(){$("select").select2();$(".ajLoadCalendarHead").load(configs.admin_url+'calendar/ajHead/');$(".ajLoadMailHead").load(configs.admin_url+'mailto/mailhead/');$(".ajLoadBirthday").load(configs.admin_url+'user/birthday/');$(".ajLang").load(configs.admin_url+'language/ajLang/');});$(".view_poup").bind("click",function(e){var data_href=$(this).attr("data-href");var data_width=$(this).attr("data-width");var data_height=$(this).attr("data-height");if(data_width){_width=data_width;}else{_width="100%";}
if(data_height){_height=data_height;}else{_height="100%";}
$(".view_popup_body").html('<iframe src="'+data_href+'" width="'+_width+'" height="'+_height+'" scrolling="auto" frameborder="0"></iframe>');});function check_number(obj){var strvalue;if(eval(obj))
strvalue=eval(obj).value;else
strvalue=obj;var num;num=strvalue.toString().replace(/\$|\,/g,'');if(isNaN(num))
num="";sign=(num==(num=Math.abs(num)));num=Math.floor(num*100+0.50000000001);num=Math.floor(num/100).toString();for(var i=0;i<Math.floor((num.length-(1+i))/3);i++)
num=num.substring(0,num.length-(4*i+3))+''+
num.substring(num.length-(4*i+3));eval(obj).value=(((sign)?'':'-')+num);}
function Delete(){if(confirm("Bạn có muốn xóa không !"))
return true;return false;}
function FormatNumber(obj){var strvalue;if(eval(obj))
strvalue=eval(obj).value;else
strvalue=obj;var num;num=strvalue.toString().replace(/\$|\,/g,'');if(isNaN(num))
num="";sign=(num==(num=Math.abs(num)));num=Math.floor(num*100+0.50000000001);num=Math.floor(num/100).toString();for(var i=0;i<Math.floor((num.length-(1+i))/3);i++)
num=num.substring(0,num.length-(4*i+3))+','+
num.substring(num.length-(4*i+3));eval(obj).value=(((sign)?'':'-')+num);}
function Format_Number(text){var strvalue;strvalue=text;var num;num=strvalue.toString().replace(/\$|\,/g,'');if(isNaN(num))
num="";sign=(num==(num=Math.abs(num)));num=Math.floor(num*100+0.50000000001);num=Math.floor(num/100).toString();for(var i=0;i<Math.floor((num.length-(1+i))/3);i++)
num=num.substring(0,num.length-(4*i+3))+','+
num.substring(num.length-(4*i+3));return(((sign)?'':'-')+num);}
function checkCapsLock(e){var myKeyCode=0;var myShiftKey=false;if(document.all){myKeyCode=e.keyCode;myShiftKey=e.shiftKey;}else if(document.layers){myKeyCode=e.which;myShiftKey=(myKeyCode==16)?true:false;}else if(document.getElementById){myKeyCode=e.which;myShiftKey=(myKeyCode==16)?true:false;}
if((myKeyCode>=65&&myKeyCode<=90)&&!myShiftKey){alert(errormsg[100]);}else if((myKeyCode>=97&&myKeyCode<=122)&&myShiftKey){alert(errormsg[100]);}}
function checkNumber(val){var strPass=val.val();var strLength=strPass.length;var lchar=val.val().charAt((strLength)-1);var cCode=lchar.charCodeAt(0);if(cCode<48||cCode>57){var myNumber=val.val().substring(0,(strLength)-1);val.val(myNumber);}
return false;}
function IsEmpty(str){var text=str.val();if(text=='')
{str.addClass('error');return false;}
str.removeClass('error');return true;}
function isCompare(pass,passconf)
{var pass_val=pass.val();var passconf_val=passconf.val();if(passconf=="")
{passconf.addClass("error");return false;}
if(pass_val!=passconf_val)
{passconf.addClass("error");return false;}
passconf.removeClass("error");return true;}
function isEmail(str){var re=/^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;var email=str.val();if(email=='')
{str.addClass('error');return false;}
if(!re.test(email))
{str.addClass('error');return false;}
str.removeClass('error');return true;}
function isAlpha(str){var re=/[^a-zA-Z]/g
if(re.test(str))return false;return true;}
function isNumeric(str){var re=/[\D]/g
if(re.test(str))return false;return true;}
function isAlphaNumeric(str){var re=/[^a-zA-Z0-9]/g
if(re.test(str))return false;return true;}
function isLength(str,len){return str.length==len;}
function isLengthBetween(str,min,max){return(str.length>=min)&&(str.length<=max);}
function isMatch(str1,str2){return str1==str2;}
function isWhitespace(str){var re=/[\S]/g
if(re.test(str))return false;return true;}
function stripWhitespace(str,replacement){if(replacement==null)replacement='';var result=str;var re=/\s/g
if(str.search(re)!=-1){result=str.replace(re,replacement);}
return result;}
(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){(i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)})(window,document,'script','//www.google-analytics.com/analytics.js','ga');ga('create','UA-69868844-1','auto');ga('send','pageview');