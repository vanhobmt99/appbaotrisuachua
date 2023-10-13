function regis_mail() {
    var email = $('#Txtemail').val();
    var email_regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;
    if (email == "" || email == null)
    {
        alert("Xin vui lòng nhập email");
    }
    if (!email_regex.test(email)) {
        alert("Email chưa đúng định dạng");
        document.getElementById("Txtemail").value = "";
    }
    else {
        $("input[type='button']").attr("disabled", true);
        $.ajax({
            type: "POST",
            url: "../vi-vn/Ajax-customer.aspx/regis_mail",
            data: "{email:'" + email + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (e) {
                if (e.d == "success") {
                    alert("Bạn đã đăng ký thành công.");
                    document.getElementById("Txtemail").value = "";
                }
                else {
                    alert("Email đã tồn tại")
                }
                $("input[type='button']").attr("disabled", false);
            }
        });
    }
}
$(document).ready(function () {
    $("#Txtemail").keyup(function (event) {
        if (event.keyCode === 13) {
            regis_mail();
        }
    });
});