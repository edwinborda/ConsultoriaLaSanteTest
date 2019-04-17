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
        var result = function (content) {    
            var res = '';
            $.each(content, function (i, item) {

                    res += '<tr>' +
                            '<td><a href="#">' + item.formData + '</a></td>' +
                            '<td>' + item.billOrder + '</td>' +
                            '<td>' + item.PurchaseOrder + '</td>' +
                            '<td>' + item.Nit + '</td>' +
                            '<td>' + item.Name + '</td>' +
                            '<td><a href="#">Eliminar</a></td>' +
                        '</tr>';

                });

                $("#invoicesTb > tbody").html(res);
        };
        $.ajax({
            url: '/home/ListOdata',
            type: 'POST',
            dataType: 'json',
            data: {'filters': listObject },
            success: result
        });
    });
});

