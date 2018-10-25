HomeApp.controller('SiteController', ['$scope', '$window', '$location', 'AjsFactory', function ($scope, $window, $location, AjsFactory) {

    function BindGrid(dataItem) {
        try {
            debugger;
            var Site = dataItem[0];
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
                        data: Site,

                        schema: {
                            model: {
                                fields: {
                                    LearningSiteName: { type: "string" },
                                    CityName: { type: "string" },
                                    StateName: { type: "string" },
                                    IsActive: { type: "bit" },


                                }
                            }
                        }
                    }
                , columns:
                    [
                        { field: "LearningSiteName", title: "Learning Site Name", template: "<a href='/Site/Index?${LearningSiteId}'>${LearningSiteName}</a>" }
                        , { field: "CityName", title: "City Name" }
                        , { field: "StateName", title: "State Name" }
                        , { field: "IsActive", title: "Is Active" }


                    ]


            });
        }
        catch (e) {

        }

    };



    //$scope.getSiteData = function () {
    //    debugger;

    //    AjsFactory.GetSiteData()
    //        .then(function (response) {
    //            debugger;
    //            if (response.data.length != 0) {
    //                $scope.siteData = response.data;
    //            }
    //        });

    //}


    $scope.getSiteData = function () {
        debugger;

        var data = {
            LearningSiteId : 0,
            Type: 1,


        };
        AjsFactory.GetSiteData(data)
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


    $scope.getSiteData();
}]);