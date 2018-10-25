HomeApp.controller('UnitController', ['$scope', '$window', '$location', 'AjsFactory', function ($scope, $window, $location, AjsFactory) {

    function BindGrid(dataItem) {
        try {
            debugger
            var UnitData = dataItem.Table;
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
                        data: UnitData,

                        schema: {
                            model: {
                                fields: {
                                    UnitTitle: { type: "string" },
                                    UnitType: { type: "number" },
                                    NQFLevel: { type: "string" },
                                    Credits: { type: "number" },
                                  


                                }
                            }
                        }
                    }
                , columns:
                    [
                       
                          { field: "UnitTitle", title: "Unit Title", template: "<a href='/Unit/Index?${UnitID}'>${UnitTitle}</a>" }
                        , { field: "UnitType", title: "Unit Type" }
                        , { field: "NQFLevel", title: "NQF Level" }
                        , { field: "Credits", title: "Credits" }
                        


                    ]


            });
        }
        catch (e) {

        }

    };

    $scope.GetUnitData = function () {
        debugger;

        var Data = {
            UnitID:0,
            Type: 1


        };
        AjsFactory.getUnitData(Data)
            .then(function (response) {

                if (response.data.length != 0) {
                    debugger;
                    //dataItem = JSON.parse(response.data[0]);
                    dataItem = JSON.parse(response.data);
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

    $scope.GetUnitData();

}]);