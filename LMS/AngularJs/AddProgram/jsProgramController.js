HomeApp.controller('ProgramController', ['$scope', '$window', '$location', 'AjsFactory', function ($scope, $window, $location, AjsFactory) {

   // $scope.ProgramId = $scope.ProgramId ? $scope.ProgramId.split('?')[1] : window.location.search.slice(1);
   // alert($scope.ProgramId);


    $scope.addProgam = function () {
        //debugger;
        //var Type;
        //if ($scope.ProgramId == 0) {
        //    Type = 1;
        //}
        //else {
        //    Type = 2;
        //}


        debugger;
        var Data = {
            statusId: $scope.form.statusId,
            TimeFrame: $scope.form.TimeFrame,
            Activity: $scope.form.activity,
            Facilitation: $scope.form.facilitation,
            UserNameCreditsId: $scope.form.UserNameCreditsId,
            FundamentalInfo: $scope.form.fundamentalInfo,
            NoOfDays: $scope.form.noOfDays,

           // ProgramId: $scope.ProgramId,
            Type: 1,
            CurrUserId: 0,
            IsActive: 0
        };
        alert(JSON.stringify(Data));
        AjsFactory.AddProgramData(Data)
            .then(function (response) {
                debugger;
                if (response.data.length != 0) {
                    debugger;
                    alert('Request has been saved successfully.');
                  //  $scope.getProgramData();
                }

            });

    };

    //$scope.getProgramData = function () {
    //    debugger;
    //    var Data =
    //        {
    //            ProgramId: $scope.ProgramId,
    //            Type: 2,
    //        };

    //    AjsFactory.GetProgramData(Data)
    //        .then(function (response) {
    //            debugger;
    //           $scope.prgData = response.data;

    //                //$scope.form.statusId = $scope.prgData.StatusId,
    //                //$scope.form.TimeFrame = $scope.prgData.TimeFrame,
    //                //$scope.form.activity = $scope.prgData.Activity,
    //                //$scope.form.facilitation = $scope.prgData.FundamentalInfo,
    //                //$scope.form.UserNameCreditsId = $scope.prgData.UserNameCreditsId,
    //                //$scope.form.noOfDays = $scope.prgData.NoOfDays,

    //        });

    //};
    //$scope.getProgramData();

    $scope.getstatus = function () {
        debugger;
        var Data = {
            statusId: 0,
            Type:1,

        };

        AjsFactory.getStatusData(Data)
            .then(function (response) {
                debugger;
                $scope.statuslst = response.data[0];
            });
    };
    $scope.getstatus();
}]);