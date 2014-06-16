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


    
    
});