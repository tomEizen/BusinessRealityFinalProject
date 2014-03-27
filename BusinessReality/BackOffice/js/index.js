//show pages with fade
function show(target) {
    $('#general').hide();
    $('#register').hide();
    $('#' + target).fadeIn(1300);
}
