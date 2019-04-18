$(document).ready(function () {

    $("#btnMore").click(function () {
        $(".filter").clone().appendTo("#filters");

        if ($(".filter").length > 1) {
            $("#btnLess").removeAttr("style");
            $("#btnLess").attr("style", "display:block");
        }    
    });

    $("#btnLess").click(function () {
        var listfilter = $(".filter").toArray();
        listfilter.pop();
        if ($(".filter").length === 1) {
            $("#btnLess").removeAttr("style");
            $("#btnLess").attr("style", "display:none");
            return;
        }

        $("#filters").html(listfilter);

    });

    $("#btnFilter").click(function () {
        var listObject = [];
        var filters = $(".form-filter");
        $.each(filters, function () {
            var obj = {
                field: $(this).find('#field').val().split(':')[0],
                oper: $(this).find('#operator').val(),
                value: $(this).find('#value').val(),
                type: $(this).find('#value').val().split(':')[1]
            };

            listObject.push(obj);
        });
        
        listObject.push({
            field: 'OrderState',
            oper: 'eq',
            value: $("#chkSeeDelete").is(':checked') ? 0 : 1,
            type: 'Int'
        });

        $.ajax({
            url: '/home/ListOdata',
            type: 'POST',
            dataType: 'json',
            data: { 'filters': listObject },
            success: result
        });
    });

    $('#chkSeeDelete').change(function () {
        var listObject = [];
        listObject.push({
            field: 'OrderState',
            oper: 'eq',
            value: $("#chkSeeDelete").is(':checked') ? 0 : 1,
            type: 'Int'
        });

        $.ajax({
            url: '/home/ListOdata',
            type: 'POST',
            dataType: 'json',
            data: { 'filters': listObject },
            success: result
        });

    });
});

function result (content) {
    var res = '';
    $.each(content, function (i, item) {
        res += '<tr>' +
            '<td><a href="/home/Edit/' + item.FormNumber + '">' + item.FormNumber + '</a></td>' +
            '<td>' + item.BillNumber + '</td>' +
            '<td>' + item.PurchaseOrder + '</td>' +
            '<td>' + item.Nit + '</td>' +
            '<td>' + item.Name + '</td>' +
            '<td><a href="/home/deleteForm/' + item.FormNumber + '">Eliminar</a></td>' +
            '</tr>';
    });

    $("#invoicesTb > tbody").html(res);
}