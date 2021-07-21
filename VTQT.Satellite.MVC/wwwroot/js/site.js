
$('#kt_datatable').DataTable({
    responsive: true,
    processing: true,
    searchDelay: 500,
    serverSide: true,
    paging: true,
    pageLength: 10,
    ajax: {
        url: 'https://localhost:44365/api/Sub/GetPaginatedList',
        type: 'GET',
        dataSrc: 'data'
    },
    columns: [
        { data: 'id' },
        { data: 'customerName' },
        { data: 'province' },
        { data: 'status' }
    ],
    columnDefs: [
        {
            // xử lí cột có vị trí là 3 tính từ 0
            targets: 3,
            render: function (data, type, row) {
                //data: dữ liệu của cột
                //row:dữ liệu của hàng
                //  console.log(row)
                if (data == "ACTIVATED")
                    // return '<span class="badge badge-success">Đã kích hoạt ' + row.productID + '</span>'
                    return '<span class="badge badge-success">Đã kích hoạt</span>'
                else (data == "SUSPENDED")
                return '<span class="badge badge-success">Không xác định</span>'
                return '<span class="badge badge-danger">Chưa kích hoạt</span>';
            }
        },
        {
            targets: 4,
            title: 'Actions',
            orderable: false,
            render: function (data, type, full, meta, row) {
                // console.log(full)
                return '\
							<a class="btn btn-primary deletebtn" data-value='+ full.id + ' title="Edit details">\
								<i class="la la-edit">Click </i>\
							</a>\
							<a href="javascript:;" class="btn btn-primary" title="Delete">\
								<i class="la la-trash">Click</i>\
							</a>\
						';
            },
        },
    ]
});


