var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "author", "width": "25%" },
            { "data": "isbn", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="row  p-2">
                                <a href="/BookList/Upsert?id=${data}" class="btn btn-primary text-white col-3 offset-lg-3" style="cursor:pointer; ">Edit</a>
                                <a  class="btn btn-danger text-white col-3 offset-lg-1" style="cursor:pointer; " onclick=Delete('/api/book?id='+${data})>Delete</a>
                            </div>
                    `;
                },
                "width": "25%"
            }

        ],
        "language": { 
            "emptyTable": "No Data Found"
        },
        "width":"100%"
    })
}

function Delete(url) {
    swal({
        title: "Are you Sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons:true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    debugger;
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}