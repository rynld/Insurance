// Write your Javascript code.

$('#name_filter').keyup(function () {
    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
    var rows = $('#transaction_table tr');
    rows.show().filter(function () {
        var text = $(this).find("#name_row").text().replace(/\s+/g, ' ').toLowerCase();
        return !~text.indexOf(val);
    }).hide();
});

$('#plantype_filter').keyup(function () {
    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
    var rows = $('#transaction_table tr');
    rows.show().filter(function () {
        var text = $(this).find("#plantype_row").text().replace(/\s+/g, ' ').toLowerCase();
        return !~text.indexOf(val);
    }).hide();
});


function complete(column_id, input_id) {
    var avaiblestag = [];
    cadena = "#transaction_table tr #" + column_id

    $(cadena).each(function (data) {
        avaiblestag.push(this.textContent);

    })

    $("#" + input_id).autocomplete({ source: $.unique(avaiblestag).sort() });
}

complete("name_row", "name_filter");
complete("plantype_row", "plantype_filter");

$("#startdate_filter").datepicker({
    onSelect: function (dateText, inst) {
        var selected_month = parseInt(inst.selectedMonth);
        var selected_year = parseInt(inst.selectedYear);
        var selected_day = parseInt(inst.selectedDay);

        var rows = $('#transaction_table tr');
        rows.show().filter(function () {
            var text = $(this).find("#transactiondate_row").text();
            var d = $.datepicker.parseDate("mm/dd/yy", text);
            
            if (parseInt(d.getFullYear()) < selected_year) return true;
            if (parseInt(d.getMonth()) < selected_month) return true;
            if (parseInt(d.getDate()) < selected_day) return true;
            return false;
            //return !~text.indexOf(val);
        }).hide();
    }
});


$("#enddate_filter").datepicker();

