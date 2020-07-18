$(document).ready(function () {
    $("#labelErrorMessage").hide();
    $("#buttonCalculateCost").click(function (e) {

        var Sku = new Object();
        Sku.SkuIds = $.trim($('#SkuIds').val());
        Sku.PromotionName = $.trim($('#PromotionTypeName').val());

        if (Sku.SkuIds == "" || Sku.PromotionName == "") {
            $("#labelErrorMessage").show();
            return false;
        }
        $.ajax({
            url: 'http://localhost:1819/api/values/',
            type: 'POST',
            dataType: 'json',
            data: Sku,
            success: function (data) {
                console.log(data);
                $("#labelCost").text('');
                $("#labelCost").text(data);
                $("#labelErrorMessage").hide();

            },
            error: function (e) {
                console.log('Error in Operation'+e);
            }
        });
    });
});