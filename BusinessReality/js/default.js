$(document).ready(function () {
    $('#addNewProfile').click(function () {
        $('#general').hide();
        $('#companyRegister').fadeIn(1000);
    });
    $('#nextToRegister').click(function () {
        $('#companyRegister').hide();
        $('#register').fadeIn(1000);
    });
    $('#priBtn').click(function () {
        $('#register').hide();
        $('#companyRegister').fadeIn(1000);
    });
    $('#cancelCompanyRegisteration').click(function () {
        $('#companyRegister').hide();
        $('#general').fadeIn(1000);
    });
    $('#cancelRegisteration').click(function () {
        $('#register').hide();
        $('#general').fadeIn(1000);
    });

    var vlidedate = false;
    var num = 0;
    $('#MEMail').blur(function () {
        num + 1;
        if (!validateEmail($(this).val())) {
            num - 1;
            alert('בבקשה הכנס כתובת מייל תקינה');

        }

    });

    $('#Site').blur(function () {
        num + 1;
        if (!validateUrl($(this).val())) {
            alert('בבקשה הכנס כתובת תקינה');
            num - 1;
        }
    });


    $('#FaceBook').blur(function () {
        num + 1;
        if (!validateFacobook($(this).val())) {
            num - 1;
            alert('בבקשה הכנס כתובת תקינה');

        }
    });


    function validateEmail(email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }

    function validateUrl(url) {

        var re = /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i;
        return re.test(url);
    }

    function validateFacobook(url) {

        var re = /^(?:(?:http|https):\/\/)?(?:www.)?facebook.com\/?$/i;
        return re.test(url);
    }

    $('#SubmitNewProfileBtn').click(function () {
        if ($('#OName').val() == "" || $('#Odescription').val() == "" || $('#OName').val() == "" || $('#FaceBook').val() == "" || $('#Site').val() == "" || $('#Addres').val() == "" || $('#Phone').val() == "" || $('#MName').val() == "" || $('#MLName').val() == "" || $('#MEMail').val() == "" || $('#MP').val() == "" || $('#MP2').val() == "") {
            alert('חסר פרטים למילוי');
        }
        else {
            var el = document.getElementById('SubmitNewProfile');
            el.click();
        }
    });

});

