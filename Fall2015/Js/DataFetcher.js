/**
 * Created by Mal on 12-11-2015.
 */
$(function() {

    $(document.body).on("click", "#btnSave", function() {
        

    

    $("#ColumnButton").click(function() {
        console.log("Click");
        console.log(this);
        var data = [];
        $.ajax({
            type: "POST",
            url: '@Url.Action("Create", "Competencies")',
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function(data) {
                console.log(data);
                if (data === 'Ok') {
                    alert("sucess");
                    //console.log($(this).parent().children());
                    $(this).parent().children(".CompetencyDiv").append(data);
                }

            },
            error: function() {
                alert("Something bad happened");
            }
        });
    });

    });
});
