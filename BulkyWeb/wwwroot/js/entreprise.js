﻿var dataTable;
$(document).ready(function () {
    loadDataTable();
});

//function loadDataTable() {
//    DataTable = $('#myTable').DataTable({
//        "ajax": { '/admin/produit/getall'},
//        "columns": [
//            { data: 'name',"width":"15%" },
//            { data: 'position', "width": "15%" },
//            { data: 'salary', "width": "15%" },
//            { data: 'office', "width": "15%" },
//            { data: 'category', "width": "15%" }

//        ]
//    });
//}

function loadDataTable() {
    dataTable = $('#entTable').DataTable({
        "ajax": { url: '/admin/entreprise/getall' },
        "columns": [
            { data: 'nom', "width": "15%" },
            { data: 'adresse', "width": "25%" },
            { data: 'ville', "width": "10%" },
            { data: 'code', "width": "15%" },
            { data: 'phoneNumber', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="dropdown">
                            <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                                Modification
                            </button>
                            <ul class="dropdown-menu" aria-labelledby="btnGroupDrop1">
                                <li><a href="/admin/entreprise/upsert?id=${data}"  class="btn btn-primary mx-2 pe-4 rounded mb-2"><i class="bi bi-pencil-square"></i> Editer</a></li>
                                <li><a onClick=Delete('/admin/entreprise/delete/${data}')  class=" btn btn-danger mx-2 rounded"><i class="bi bi-trash3"></i> Supprimer</a></li>
                            </ul>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: "Etes-vous sûr ?",
        text: "Cette action est definitive !",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        cancelButtonText:"Annuler",
        confirmButtonText: "Oui, je suis sûr !"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                    
                }
            })
        }
    });
}