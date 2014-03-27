//show pages with fade
function show(target) {
    $('#general').hide();
    $('#addProduct').hide();
    $('#editCategory').hide();
    $('#addCategory').hide();
    $('#editProduct').hide();
    $('#' + target).fadeIn(1300);
}

//set the table header to hebrew
$(document).ready(function () {
    $('#productTable').dataTable({
        "oLanguage": {
            "sLengthMenu": "מציג _MENU_ רשומות",
            "sZeroRecords": "לא קיימים מוצרים בקטלוג",
            "sInfo": " מציג רשומה _START_ עד רשומה _END_ מתוך _TOTAL_ רשומות",
            "sInfoEmpty": "",
            "sInfoFiltered": "(filtered from _MAX_ total records)",
            "sSearch": "חיפוש:"
        }
    });
});

function InitComplete(oSettings) {
   $('#tblOrders_filter')
       .contents()
       .filter(function() { return this.nodeType == 3 })
       .replaceWith('Refine search: ');
}



//once a tr inside the products table is clicked a pop up window is open with the info about this product
$(function () {
    function launch() {
        $('#productInfo').lightbox_me({ centered: true, onLoad: function () { $('#productInfo').find('input:first').focus() } });
    }

    $('.tableData tr').click(function (e) {
        EnterDetails($(this).index());
        $("#productInfo").lightbox_me({ centered: true, preventScroll: true, onLoad: function () {
            $("#productInfo").find("input:first").focus();
        }
        });

        e.preventDefault();
    });


    $('table tr:nth-child(even)').addClass('stripe');
});

//enter the details to the  product info window
function EnterDetails(row_number) {
    RemoveDetailsFromProductInfoPage();
    var MyRows = $('table#productTable').find('tbody').find('tr');
    $('#name').append($(MyRows[row_number]).find('td:eq(1)').text());

}

//empty all elements inside the product info window
function RemoveDetailsFromProductInfoPage() {
    $('#name').empty();
}

function CloseLightBox() {
    $('#productInfo').trigger('close');
}

function edit() {
    $('#productInfo').trigger('close');
    show("editProduct");
}

function addProperitesTB() {
    var propertiesAmpunt = $("#propertiesTable tr").length;
    if (propertiesAmpunt > 0) {
        for (var i = 0; i < propertiesAmpunt + 1; i++) {
            var row = $('#propertiesTable tr:nth-child(' + i + ' )');
            alert(i);
            row.append($('<td><input ID="propertyInput' + i + '" runat="server"/></</td>'));
        }
    }
    function getPropertiesElemants() {
        alert('SAsa');
    }
}

function discountTBvisible(bool) {
    if (bool == false) {
        $('#discountTB').hide();
        $('#discountTB').val("");
    }
    else
        $('#discountTB').fadeIn(1300);
}


$(function () {
    function launch() {
        $('#prodectInserted').lightbox_me({ centered: true, onLoad: function () { $('#prodectInserted').find('input:first').focus() } });
    }

    $('#Butt').click(function (e) {
        $("#prodectInserted").lightbox_me({ centered: true, preventScroll: true, onLoad: function () {
            $("#prodectInserted").find("input:first").focus();
        }
        });

        e.preventDefault();
    });

    $('table tr:nth-child(even)').addClass('stripe');
});

function productInsertedToDb(url) {
    addQrCode(url);
    $("#prodectInserted").lightbox_me({ centered: true, preventScroll: true, onLoad: function () {
        $("#prodectInserted").find("input:first").focus();
    }
    });
}

function addQrCode(url) {
    var qrcode = new QRCode(document.getElementById("qrcode"), {
        width: 100,
        height: 100
    });
    qrcode.makeCode("www.one.co.il");
}
function printDiv(divID, numberOfQR) {
    //Get the HTML of div
    var divElements = document.getElementById(divID).innerHTML;
    //Get the HTML of whole page
    var oldPage = document.body.innerHTML;

    //Reset the page's HTML with div's HTML only
    for (var i = 0; i < numberOfQR; i++) {
        divElements += divElements;
    }
    document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              divElements + "</body>";

    //Print Page
    window.print();

    //Restore orignal HTML
    document.body.innerHTML = oldPage;

    location.reload();
}

function productInfo(category) {
    alert(category);
    $('#lblCategory').text = category;
}

function addPropToTable() {
    var text = $('#NewCampaignProp').val();
    if ($('#AddCategoryProperties').text().match(text)) { }
    else {
        $('#AddCategoryProperties').append('<tr class="odd gradeX">><td>' + text + '</td></tr>');
    }
}
function addNewPropToTable() {
    var text = $('#newPropTB').val().trim();
    if ($('#AddCategoryProperties').text().match(text)) { }
    else {
        $('#AddCategoryProperties').append('<tr class="odd gradeX">><td>' + text + '</td></tr>');
    }
}
