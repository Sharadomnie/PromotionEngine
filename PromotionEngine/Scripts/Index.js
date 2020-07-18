$(document).ready(function () {
    $("#buttonCalculateCost").click(function () {
        var sku = new Object();
        sku.SkuIds = $.trim($('#SkuIds').val());
        sku.PromotionName = $.trim($('#PromotionTypeName').val());
        $.ajax({
            url: 'http://localhost:1819/api/values/',
            type: 'POST',
            dataType: 'json',
            data: sku,
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