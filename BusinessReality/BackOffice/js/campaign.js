//show pages with fade
function show(target) {
    $('#general').hide();
    $('#addCampaign').hide();
    $('#' + target).fadeIn(1300);
}

//build the campaign table
function BuildCampaignTable(name,description,voucher,dateCreated,isActive,shareCount) {

   // $('#CampaignTable > tbody:last').append('<tr><td>' + name + '</td><td>' + dateCreated + '</td><td>' + description + '</td><td>' + voucher + '</td><td>' + shareCount + '</td><td>' + isActive + '</td></tr>');
    $("#CampaignTable").last().append('<tr><td>' + name + '</td><td>' + dateCreated + '</td><td>' + description + '</td><td>' + voucher + '</td><td>' + shareCount + '</td><td>' + isActive + '</td></tr>');
}