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