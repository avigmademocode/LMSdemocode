HomeApp.controller('ProgramController', ['$scope', '$window', '$location', 'AjsFactory', function ($scope, $window, $location, AjsFactory) {

    function BindGrid(dataItem) {
        try {
            debugger;
            var ProgramData = dataItem[0];
            $('#grid').kendoGrid({
                scrollable: true,
                sortable: true,


                pageable: {
                    pageSizes: true,
                    input: true,
                    pageSize: 5,
                    pageSizes: [5, 10, 20, 500]
                }
                // selectable: "row",//""multiple row"",
                // filterable: true
                ///ViewRequest?{{ord.OrderId}}
                , dataSource:
                    {
                        data: ProgramData,

                        schema: {
                            model: {
                                fields: {
                                            StatusId: { type: "number" },
                                            Activity:{ type: "string" },
                                            Facilitation: { type: "string" },
                                            UserNameCreditsId: { type: "string" },
                                            TimeFrame: { type: "date" },
                                            FundamentalInfo: { type: "string" },
                                            NoOfDays: { type: "int" },
                                    

                                }
                            }
                        }
                    }
                , columns:
                    [
                        { field: "StatusId", title: "Status Id", template: "<a href='/Program/Index?${StatusId}'>${StatusId}</a>"}
                        , { field: "Activity", title: "Activity" }
                        , { field: "Facilitation", title: "Facilitation" }
                        , { field: "UserNameCreditsId", title: "UserName Credits Id" }
                        , { field: "TimeFrame", title: "Time Frame" }
                        , { field: "FundamentalInfo", title: "Fundamental Info" }
                        , { field: "NoOfDays", title: "No Of Days" }


                    ]


            });
        }
        catch (e) {

        }

    };

    $scope.getProgramData = function () {
        debugger;

        var Data =
            {
                ProgramId: 0,
                Type: 1,
            };
        AjsFactory.GetProgramData(Data)
            .then(function (response) {

                if (response.data.length != 0) {
                    debugger;
                    //dataItem = JSON.parse(response.data[0]);
                    dataItem = response.data;
                    try {

                        BindGrid(dataItem);

                    }
                    catch (e) {
                        alert(e);
                    }


                } else {
                    alert('Record Not Found!');
                }

            });

    }

    function isNumeric(n) {
        return !isNaN(parseFloat(n)) && isFinite(n);
    }


    $('#filter').on('input', function (e) {

        var grid = $('#grid').data('kendoGrid');
        var columns = grid.columns;

        var filter = { logic: 'or', filters: [] };
        columns.forEach(function (x) {
            if (x.field) {
                var type = grid.dataSource.options.schema.model.fields[x.field].type;
                if (type == 'string') {
                    filter.filters.push({
                        field: x.field,
                        operator: 'contains',
                        value: e.target.value
                    })
                }
                else if (type == 'number') {
                    if (isNumeric(e.target.value)) {
                        filter.filters.push({
                            field: x.field,
                            operator: 'eq',
                            value: e.target.value
                        });
                    }

                } else if (type == 'date') {
                    var data = grid.dataSource.data();
                    for (var i = 0; i < data.length; i++) {
                        var dateStr = kendo.format(x.format, data[i][x.field]);

                        if (dateStr.startsWith(e.target.value)) {
                            filter.filters.push({
                                field: x.field,
                                operator: 'eq',
                                value: data[i][x.field]
                            })
                        }
                    }
                } else if (type == 'boolean' && getBoolean(e.target.value) !== null) {
                    var bool = getBoolean(e.target.value);
                    filter.filters.push({
                        field: x.field,
                        operator: 'eq',
                        value: bool
                    });
                }
            }
        });
        grid.dataSource.filter(filter);
    });

    $scope.getProgramData();

}]);