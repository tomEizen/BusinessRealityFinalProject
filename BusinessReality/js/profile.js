
//open the edit comapny profile form
$(function () {
    function launch() {
        $('#sign_up').lightbox_me({ centered: true, onLoad: function () { $('#sign_up').find('input:first').focus() } });
    }

    $('#try-1').click(function (e) {
        $("#sign_up").lightbox_me({ centered: true, preventScroll: true, onLoad: function () {
            $("#sign_up").find("input:first").focus();
        } 
        });

        e.preventDefault();
    });


    $('table tr:nth-child(even)').addClass('stripe');
});


//open the new password profile form
$(function () {
    function launch() {
        $('#updatePassword').lightbox_me({ centered: true, onLoad: function () { $('#updatePassword').find('input:first').focus() } });
    }

    $('#try-2').click(function (e) {
        $("#updatePassword").lightbox_me({ centered: true, preventScroll: true, onLoad: function () {
            $("#updatePassword").find("input:first").focus();
        }
        });

        e.preventDefault();
    });


    $('table tr:nth-child(even)').addClass('stripe');
});

function CloseLightBox1() {
    $('#sign_up').trigger('close');
}

function CloseLightBox2() {
    $('#updatePassword').trigger('close');
}




