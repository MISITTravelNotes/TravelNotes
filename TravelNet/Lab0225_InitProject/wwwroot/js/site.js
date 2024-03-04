// 這裡放切頁面專用js

$('.tab-inner').hide();

$('#tab > ul > li > p').click(function (e) {
    var x = $(this).attr('class')
    if (x == "#tab-1") {
        $('#tab01').show()
        $('#tab02').hide()
    }
    else if (x == "#tab-2") {
        $('#tab02').show()
        $('#tab01').hide()
    }
    else {
        console.log("error!");
    }
})





