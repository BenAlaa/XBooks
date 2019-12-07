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
                                <a href="/BookList/Edit?id=${data}" class="btn btn-primary text-white col-3 offset-lg-3" style="cursor:pointer; ">Edit</a>
                                <a href="/BookList/Edit?id=${data}" class="btn btn-danger text-white col-3 offset-lg-1" style="cursor:pointer; ">Delete</a>
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