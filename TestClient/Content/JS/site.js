$(function () {
    $("#btnBanner").click(function () {
        $.ajax({
            url: 'http://localhost:1473/api/Banner/e2377608-4328-4747-bf19-d94ca74a48a0',
            type: 'GET',
            success: function (result) {
                alert(result);
            },
            error: function () {
                alert("error");
            }
        });
        return false;
    });
});
