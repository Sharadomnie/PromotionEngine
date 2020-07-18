$(document).ready(function () {
    $("#buttonCalculateCost").click(function () {
        var Sku = new Object();
        Sku.SkuIds = $.trim($('#SkuIds').val());
        Sku.PromotionName = $.trim($('#PromotionTypeName').val());
        $.ajax({
            url: 'http://localhost:1819/api/values/',
            type: 'POST',
            dataType: 'json',
            data: Sku,
            success: function (data) {
                console.log(data);
                $("#labelCost").text('');
                $("#labelCost").text(data);              

            },
            error: function (e) {
                console.log('Error in Operation'+e);
            }
        });
    });
});