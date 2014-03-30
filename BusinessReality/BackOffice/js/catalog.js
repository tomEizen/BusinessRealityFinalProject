//show pages with fade
var products;
var propertyCount = 0;
function show(target) {
    $('#general').hide();
    $('#addProduct').hide();
    $('#editCategory').hide();
    $('#addCategory').hide();
    $('#editProduct').hide();
    $('#productInfo').hide();
    $('#' + target).fadeIn(1300);
}

//set the table header to hebrew
$(document).ready(function () {
    $('#productTable').dataTable({
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

$('#tblOrders_filter')
       .filter(function () { return this.nodeType == 3 })


function ValidateNewProduct() { 



}


//once a tr inside the products table is clicked a pop up window is open with the info about this product
$(function () {
    function launch() {
        $('#productInfo').lightbox_me({ centered: true, onLoad: function () { $('#productInfo').find('input:first').focus() } });
    }

    $('.tableData tr').click(function (e) {
        getProductInfo($(this).index());
        $("#productInfo").lightbox_me({ centered: true, preventScroll: true, onLoad: function () {
            $("#productInfo").find("input:first").focus();
        }
        });

        e.preventDefault();
    });


    $('table tr:nth-child(even)').addClass('stripe');
});

//getting the selected product from the web server
function getProductInfo(row_number) {
    var email = 'aviv@gmail.com';
    var MyRows = $('table#productTable').find('tbody').find('tr');
    var productID = ($(MyRows[row_number]).find('td:eq(2)').text());
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/getProductsInfo',   // JQuery loads serverside.php
        data: '{productId:"' + productID + '",email:"' + email + '"}',
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
//getting the selected product properties from the web server
function GetProductPropertiesInfo(productID) {
    var email = 'aviv@gmail.com';
    $.ajax({ // ajax call starts
        url: 'WebService.asmx/GetProductPropertiesInfo',   // JQuery loads serverside.php
        data: '{productId:"' + productID + '",email:"' + email + '"}',
        type: 'POST',
        dataType: 'json', // Choosing a JSON datatype
        contentType: 'application/json; charset = utf-8',
        success: function (data) // Variable data contains the data we get from serverside
        {
            p = $.parseJSON(data.d);
            EnterProperties(p);
        }, // end of success
        error: function (e) {
            alert(e.responseText);
        } // end of error
    }) // end of ajax call
}

//enter the details to the  product info window
function EnterDetails(product) {
    RemoveDetailsFromProductInfoPage();
    $('#infoName').text(product.Name);
    $('#lblCategory').text(product.CategoryName);
    $('#lblproductID').text(product.Id);
    $('#lblProductDescription').text(product.Description);
    $("#productInfoDiscount").text(product.Discount);
    $("#lblProductPrice").text(product.Price + ' ש"ח');
    $('#productInfoImage').attr("src", product.ImageUrl);
    addQrCode('www.one.co.il', 'qrcodePrint');
    GetProductPropertiesInfo(product.Id);
}

//enter the proporties to the  product info window
function EnterProperties(propeties) {
    $.each(propeties, function (index, Property) {
        $('#productInfoTB > tbody').append('<tr><th><label>' + Property.Name + '</th><td>' + Property.Description + '</td></tr>');
    });



}
//empty all elements inside the product info window
function RemoveDetailsFromProductInfoPage() {
    $('#infoName').empty();
    $('#lblCategory').empty();
    $('#lblproductID').empty();
    $('#lblProductDescription').empty();
    $('#productInfoTB > tbody').empty();
    $('#qrcodePrint').empty();
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

function addQrCode(url,div) {
    var qrcode = new QRCode(document.getElementById(div), {
        width: 100,
        height: 100
    });
    qrcode.makeCode(url);
}
function printDiv(divID, numberOfQR) {
    alert(divID);
    addQrCode('www.one.co.il',divID);
    //Get the HTML of div
    var divElements = document.getElementById(divID).innerHTML;
    //Get the HTML of whole page
    var oldPage = document.body.innerHTML;
    var div = "";
    //Reset the page's HTML with div's HTML only
    for (var i = 0; i < numberOfQR; i++) {
        div += divElements;
    }
    document.body.innerHTML =
              "<html><head><title></title></head><body>" +
              div + "</body></html>";
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
        $('#AddCategoryProperties').append('<tr  runat="server" class="odd gradeX"><td  runat="server"  ><label ID="addCategory' + propertyCount + '"  runat="server" >' + text + '</label></td></tr>');
    }
    propertyCount++;
}
function addNewPropToTable() {
    var text = $('#newPropTB').val().trim();
    if ($('#AddCategoryProperties').text().match(text)) { }
    else {
        $('#AddCategoryProperties').append('<tr class="odd gradeX" runat="server"><td  runat="server"  ><label ID="addCategory' + propertyCount + '"  runat="server" >' + text + '</label></td></tr>');
    }
    propertyCount++;
}


$(document).ready(function () {
    setupLeftMenu();
    $('#addPropBtn').click(function () {
        addPropToTable();
    });
    $('#addNewPropBtn').click(function () {
        addNewPropToTable();
    });
    $('.datatable').dataTable();
    setSidebarHeight();
    $('#RadioButtonList1').change(function () {
        if ($('#RadioButtonList1 input:checked').val() == 'לא')
            discountTBvisible(false)
        else
            discountTBvisible(true)
    });

});
