var wait = 60;
var EmYzm;
function YzmFind() {
    if ($("#Email").val() == "")
    {
        alert("邮箱不能为空!");
        return;
    }
        $.ajax({
            url: "/Default/EmialYzm",
            data: { "email": $("#Email").val() },
            type: "get",
           
            success: function (EYzm) {
                var str = EYzm;
                EmYzm = EYzm;
                Timeout();
        }
    })
   

        function Timeout() {
            if (wait == 0) {
                $("#YZMpablo").removeAttr("disabled");
                $("#YZMpablo").val("获取验证码");
                wait = 60;
            }
            else {
                $("#YZMpablo").attr("disabled", true);
                $("#YZMpablo").val(wait + "秒后重新获取");
                wait--;
                setTimeout(function () {
                    Timeout();
                }, 1000)
            }
        }
    }
function Save() {
    var yzm = $("#regist_vcodes").val();
    var email = $("#Email").val();
    var idcard = $("#idcard").val();
    $.ajax({
        url: "https://localhost:44394/api/Default/ForgetPwd?email=" + email + "&idcard=" + idcard,       
        type: "get",
        success: function (data) {

            if (data > 0 && yzm == EmYzm && yzm != "") {
                alert("验证成功");


                $.ajax({
                    url: "https://localhost:44394/api/Default/ForgetId?email=" + email + "&idcard=" + idcard,
                    type: "get",
                    success: function (data) {
                        $(data).each(function () {
                            location.href = '/Default/UptPwd?id=' + this.Id;
                            
                        })
                    }
                })

                return;
            }
            if (data< 0) {
                alert("该邮箱没有被注册过");
                return;
            }
            if (yzm != EmYzm && yzm == "") {
                alert("验证码输入错误");
                return;
            }
            if (data> 0 && yzm == "" ) {
                alert("验证码输入错误");
                return;
            }
        }
    })
   
   

}

