var email = 'aviv@gmail.com';
var campaignID

//show pages with fade
function show(target) {
    $('#general').hide();
    $('#addCampaign').hide();
    $('#productInfo').hide();
    $('#editCampaign').hide();
    $('#' + target).fadeIn(1300);
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
        GetCampaignInfo($(this).index());
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


//getting the selected cmpaign informaiton from the db
function GetCampaignInfo(row_number) {
    var MyRows = $('table#CampaignTable').find('tbody').find('tr');
    campaignID = ($(MyRows[row_number]).find('td:eq(2)').text());
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/getCampaignInfo',   // JQuery loads serverside.php
        data: '{campaignId:"' + campaignID + '",email:"' + email + '"}',
        type: 'POST',
        dataType: 'json', // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8',
        success: function (data) // Variable data contains the data we get from serverside
        {
            p = $.parseJSON(data.d);
            EnterDetails(p);
        }, // end of success
        error: function (e) {
            alert(e.responseText);
        } // end of error
    }) // end of ajax call
}


//insert the campaign information to the campaign popup window and the edit section
function EnterDetails(campaign) {
    RemoveDetailsFromCampaignInfoPage();
    $('#infoCampaignName').text(campaign.Name);
    $('#txtCampaignNameEdit').val(campaign.Name);
    $('#lblCampsignId').text(campaign.Id);
    $('#lblCampaignDescription').text(campaign.Description);
    $('#txtCampaignDescriptionEdit').val(campaign.Description);
    $('#lblVoucher').text(campaign.Voucher);
    $('#txtVoucherEdit').val(campaign.Voucher);
    $("#lblExpirationTime").text(campaign.Expiration + ' שעות');
    $("#ddlExpirationEdit").val(campaign.Expiration);
    $('#lblShareCount').text(campaign.ShareCount);
    if (campaign.ImageUrl == "") {
        $('#productInfoImage').attr("src", "BackOffice/img/gallery/campaigns/noPicAvailable.jpg");
    }
    else {
        $('#productInfoImage').attr("src", campaign.ImageUrl);
        $('#uploadCampaignImgEdit').val(campaign.ImageUrl);
    }
    if (campaign.LinkUrl == "") {
        $("#lblCampaignLink").text('אין קישור מצורף');
        $("#txtCampaignLinkEdit").val('אין קישור מצורף');
    }
    else {
        $("#lblCampaignLink").text(campaign.LinkUrl);
        $("#txtCampaignLinkEdit").val(campaign.LinkUrl);
    }
    if (campaign.isActive == true) {
        $("#lblIsActive").text('פעיל');
    }
    else {
        $("#lblIsActive").text('לא פעיל');
    }
    
}

//empty all elements inside the campaign info window
function RemoveDetailsFromCampaignInfoPage() {
    $('#infoName').empty();
    $('#lblCampsignId').empty();
    $('#lblCampaignDescription').empty();
    $('#lblVoucher').empty();
    $('#lblProductDescription').empty();
    $("#lblExpirationTime").empty();
    $('#lblCampaignLink').empty();
    $('#productInfoImage').empty();
}

//call web service function to delete the campaign according to his id
function DeleteCampaign() {

    if (confirm('האם הינך משוכנע שברצונך למחוק את הקמפיין?')) {
        $.ajax({ // ajax call starts
            url: 'WebService.asmx/DeleteCampaign',   // JQuery loads serverside.php
            data: '{campaignID:"' + campaignID + '"}',
            type: 'POST',
            dataType: 'json', // Choosing a JSON datatype
            contentType: 'application/json; charset = utf-8',
            success: function (data) // Variable data contains the data we get from serverside
            {
                location.reload();

            }, // end of success
            error: function (e) {
                alert(e.responseText);
            } // end of error
        }) // end of ajax call
        
    } else {
     
        // Do nothing!
    }
    
 }