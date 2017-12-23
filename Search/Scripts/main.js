$(document).ready(function () {
    $("#searchBtn").click(function () {
        var searchBy = $("#searchBy").val();
        //console.log(searchBy)
        var searchVal = $("#Search").val();
        //console.log(searchVal)
        var setData = $("#dataSearch");
        //console.log(setData)
        setData.html("");
        $.ajax({
            type: "post",
            url: "/Home/GetSearchData?searchBy=" + searchBy + "&searchVal=" + searchVal,
            contentType: "html",
            success: function (result) {
                if (result.length == 0) {
                    setData.append('<tr style="color:red"><td colspan="3">No match data</td></tr>')
                }
                else {
                    $.each(result, function (index, value) {
                        var Data = "<tr>" + "<td>" + value.id + "</td>" + "<td>" + value.name + "</td>" + "<td>" + value.degree + "</td>" + "</tr>";
                        setData.append(Data);
                    });
                }
            }

        });
    });

});