//show pages with fade
function show(target) {
    $('#general').hide();
    $('#addCampaign').hide();
    $('#productInfo').hide();
    $('#editCampaign').hide();
    $('#' + target).fadeIn(1300);
}

//build the campaign table
function BuildCampaignTable(name,description,voucher,dateCreated,isActive,shareCount) {

   // $('#CampaignTable > tbody:last').append('<tr><td>' + name + '</td><td>' + dateCreated + '</td><td>' + description + '</td><td>' + voucher + '</td><td>' + shareCount + '</td><td>' + isActive + '</td></tr>');
    $("#CampaignTable").last().append('<tr><td>' + name + '</td><td>' + dateCreated + '</td><td>' + description + '</td><td>' + voucher + '</td><td>' + shareCount + '</td><td>' + isActive + '</td></tr>');
}

//onload
$(document).ready(function () {
    $('#CampaignTable').dataTable({
        "oLanguage": {
            "sLengthMenu": "מציג _MENU_ רשומות",
            "sZeroRecords": "לא קיימים מוצרים בקטלוג",
            "sInfo": " מציג רשומה _START_ עד  _END_ מתוך _TOTAL_ רשומות",
            "sInfoEmpty": "",
            "sInfoFiltered": "(filtered from _MAX_ total records)",
            "sSearch": "חיפוש:"
        }
    });
});


//once a tr inside the campaign table is clicked a pop up window is open with the information about this campaign
$(function () {
    function launch() {
        $('#productInfo').lightbox_me({ centered: true, onLoad: function () { $('#productInfo').find('input:first').focus() } });
    }

    $('.tableData tr').click(function (e) {
//        getProductInfo($(this).index());
        $("#productInfo").lightbox_me({ centered: true, preventScroll: true, onLoad: function () {
            $("#productInfo").find("input:first").focus();
        }
        });

        e.preventDefault();
    });


    $('table tr:nth-child(even)').addClass('stripe');
});

////adding the close pop uo trigger
function CloseLightBox() {
    $('#productInfo').trigger('close');
}

////open the edit product window once the edit product button is clicked
function edit() {
    $('#productInfo').trigger('close');
    show("editCampaign");
}