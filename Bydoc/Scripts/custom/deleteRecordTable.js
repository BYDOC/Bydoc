function Delete(url,id) {
    $.ajax({
        url: url + id,
        //url:id,
        type: "POST",
        success: function (result) {
            $("#a_" + id).fadeOut();
        }
    })
}
