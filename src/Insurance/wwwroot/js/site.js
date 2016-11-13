

// Write your Javascript code.
$("#customer_table").dataTable({
   
    "scrollX": true
});
$("#transaction_table").dataTable({
    "scrollX": true
});



$('#name_filter').keyup(function () {
    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
    var rows = $('#transaction_table_body tr');
    rows.show().filter(function () {
        var text = $(this).find("#name_row").text().replace(/\s+/g, ' ').toLowerCase();
        return !~text.indexOf(val);
    }).hide();
});

$('#plantype_filter').keyup(function () {
    var val = $.trim($(this).val()).replace(/ +/g, ' ').toLowerCase();
    var rows = $('#transaction_table_body tr');
    rows.show().filter(function () {
        var text = $(this).find("#plantype_row").text().replace(/\s+/g, ' ').toLowerCase();
        return !~text.indexOf(val);
    }).hide();
});

function complete(column_id, input_id) {
    var avaiblestag = [];
    cadena = "#transaction_table_body tr #" + column_id

    $(cadena).each(function (data) {
        avaiblestag.push(this.textContent);

    })

    $("#" + input_id).autocomplete({ source: $.unique(avaiblestag).sort() });
}

complete("name_row", "name_filter");
complete("plantype_row", "plantype_filter");

$("#startdate_filter").datepicker();
$("#enddate_filter").datepicker();
$("#dateofbirth").datepicker();
$("#effectivedate").datepicker();
$("#terminationdate").datepicker();

function filter_by_date() {

    var inidate = $("#startdate_filter").datepicker("getDate");
    var enddate = $("#enddate_filter").datepicker("getDate");

    var rows = $('#transaction_table_body tr');
    rows.show().filter(function () {
        var text = $(this).find("#transactiondate_row").text();
        var d = $.datepicker.parseDate("mm/dd/yy", text);

        if (compareDates(inidate, d) <= 0 && compareDates(d, enddate) <= 0) return false;
        return true;
    }).hide();
}

function compareDates(x, y) {
    //return -1 if x is lower than y 0 if equals 1 otherwise
    var x_day = parseInt(x.getDate());
    var x_month = parseInt(x.getMonth());//january is the 0 month
    var x_year = parseInt(x.getFullYear());

    var y_day = parseInt(y.getDate());
    var y_month = parseInt(y.getMonth());
    var y_year = parseInt(y.getFullYear());

    console.log(y_day, y_month, y_year);
    if (x_year < y_year) return -1;
    if (x_year > y_year) return 1;
    if (x_month < y_month) return -1;
    if (x_month > y_month) return 1;
    if (x_day < y_day) return -1;
    if (x_day > y_day) return 1;
    return 0;


}


function validate_data() {
   
    if ($("#plantype").val() == "none" || $("#insurancename") == "none") {
      
        event.preventDefault();
        $("#submit_button").attr("data-target", "#myModal");
    }
    else {
       
        $("#submit_button").removeAttr("data-target");
    }
}


function showpayments(data)
{    
    var payment_info = data[0];
    var indatabase = data[1];
    console.log(payment_info.length)
    for (var i = 0; i < payment_info.length; i++) {
        var row = document.createElement("tr");
        
        if(indatabase[i] == false)
          row.className= "bg-danger";
        for (var x in payment_info[i]) {
            if (x == "nsPaymentID") continue;

            var col = document.createElement("td");
            var text = document.createTextNode(payment_info[i][x])
            col.appendChild(text);
            row.appendChild(col);
        }
        $("#payments_table_body").append(row);
    }
   
}

function add_input_search(table_name)
{
    console.log(table_name);
    table_name = "#" + table_name;

    $('#payment_table tfoot th').each(function () {
        var title = $(this).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });

    // DataTable
    var table = $("#payment_table").DataTable();

    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
}