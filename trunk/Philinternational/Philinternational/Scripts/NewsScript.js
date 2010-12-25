function ChangeStatusCheckBox(obj) {
    
    objey = "lblStatus_" + obj;
    alert(objey);
    $(objey).html('<a>masicatti</a>');
    $.ajax({
        type: "POST",
        url: "../Management/news.aspx/ChangeStatus",
        data: "{obj}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            objey = "lblStatus_" + obj;
            $(objey).value = "kjsdjsl";
        }
    });

}