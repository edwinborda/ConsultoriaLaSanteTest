$(document).ready(function () {
    
    $("#btnMore").click(function () {
        $("#filter").clone().appendTo("#filters");
    });

    $("#btnFilter").click(function () {
        var listObject = [];
        var filters = $(".form-filter");
        $.each(filters, function () {
            var obj = {
                field: $(this).find('#field').val(),
                oper: $(this).find('#operator').val(),
                value: $(this).find('#value').val()
            };

            listObject.push(obj);
        });
        
        listObject.push({
            field: 'OrderState',
            oper: 'eq',
            value: $("#chkSeeDelete").is(':checked') ? 0 : 1
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
            value: $("#chkSeeDelete").is(':checked') ? 0 : 1
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