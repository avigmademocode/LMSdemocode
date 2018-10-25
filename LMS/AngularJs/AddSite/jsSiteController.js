HomeApp.controller('SiteController', ['$scope', '$window', '$location', 'AjsFactory', function ($scope, $window, $location, AjsFactory) {

    $scope.LearningSiteId = $scope.LearningSiteId ? $scope.LearningSiteId.split('?')[1] : window.location.search.slice(1);
    alert($scope.LearningSiteId);


    $scope.SubmitForm = function () {

        debugger;

        var Type;
        if ($scope.LearningSiteId == 0) {
            Type = 1;
        }
        else {
            Type = 2;
        }

        var data = {

            LearningSiteName: $scope.form.LearningSiteName,
            SitePhysicalAddressLine1: $scope.form.AddressLine1,
            AddressLine2: $scope.form.AddressLine2,
            City: $scope.form.City,
            LearningSiteMunicipalDistrict: $scope.form.LearningSiteMunicipalDist,
            State: $scope.form.state,
            PostalCode: $scope.form.Zip,
            LearningSiteProvince: $scope.form.LearningSiteProvince,
            GPSLatitude: $scope.form.GPSLatitude,
            GPSLongitude: $scope.form.GPSLongitude,
            LocatedInMetros: $scope.form.LocatedInMetros,
            Rural: $scope.form.Rural,


            Type: Type,

            LearningSiteId: $scope.LearningSiteId,

            CurrUserId: 0,
            IsActive: $scope.form.IsActive,

        };
        alert(JSON.stringify(data));
        AjsFactory.addSiteData(data)
            .then(function (response) {
                debugger;
                if (response.data.length != 0) {
                    debugger;
                    alert('Request has been saved successfully.');
                    $scope.getSiteData();
                }
            });
        
    };


    $scope.getSiteData = function () {
        debugger;

        var Data = {
            LearningSiteId: $scope.LearningSiteId,
                Type: 2,
            };
        AjsFactory.GetSiteData(Data)
            .then(function (response) {
                debugger;
                if (response.data.length != 0) {
                    $scope.siteData = response.data;

                        $scope.form.LearningSiteName = $scope.siteData[0][0].LearningSiteName,
                        $scope.form.AddressLine1 = $scope.siteData[0][0].SitePhysicalAddressLine1,
                        $scope.form.AddressLine2 = $scope.siteData[0][0].AddressLine2,
                        $scope.form.City = $scope.siteData[0][0].City,
                        $scope.form.state = $scope.siteData[0][0].State,
                        $scope.form.Zip = $scope.siteData[0][0].PostalCode,
                        $scope.form.LearningSiteMunicipalDist = $scope.siteData[0][0].LearningSiteMunicipalDistrict,
                        $scope.form.LearningSiteProvince = $scope.siteData[0][0].LearningSiteProvince,
                        $scope.form.GPSLatitude = $scope.siteData[0][0].GPSLatitude,
                        $scope.form.GPSLongitude = $scope.siteData[0][0].GPSLongitude,
                        $scope.form.LocatedInMetros = $scope.siteData[0][0].LocatedInMetros,
                        $scope.form.Rural = $scope.siteData[0][0].Rural,
                        $scope.form.IsActive = $scope.siteData[0][0].IsActive
                }
            });

    };
    $scope.getSiteData();



    //$scope.GetcityData = function () {
    //    //debugger;

    //    AjsFactory.getCityData()
    //        .then(function (response) {
    //            // debugger;
    //            if (response.data[0].length != 0) {
    //                //   debugger;
    //                $scope.cityLst = response.data[0];
    //            }
    //        });


    //};
    //$scope.GetcityData();

    //$scope.GetStateData = function () {
    //    //debugger;

    //    AjsFactory.getStateData()
    //        .then(function (response) {
    //            //debugger;
    //            if (response.data[0].length != 0) {
    //                //  debugger;
    //                $scope.stateLst = response.data[0];
    //            }

    //        });
    //};
    //$scope.GetStateData();
}]);