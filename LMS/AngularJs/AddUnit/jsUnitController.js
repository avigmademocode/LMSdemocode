HomeApp.controller('UnitController', ['$scope', '$window', '$location', 'AjsFactory', function ($scope, $window, $location, AjsFactory) {


    $scope.UnitID = $scope.UnitID ? $scope.UnitID.split('?')[1] : window.location.search.slice(1);
    alert($scope.UnitID);

    $scope.SubmitUnit = function () {

        debugger;
        var Type;
        if ($scope.UnitID == 0) {
            Type = 1;

        }
        else
        {
            Type = 2;
        }

        var Data = {
            UnitType: $scope.form.unittype,
            UnitTitle: $scope.form.unittitle,
            NQFLevel: $scope.form.NQFLevel,
            Credits: $scope.form.credits,
            NumberOfDaysRequiredToComplete: $scope.form.NoOfDaysReqToComplete,
            AmountApprovedForTheUnit: $scope.form.AmountApprovedForTheUnit,

            Type: Type,
            UnitID: $scope.UnitID,
            CurrUserId: 0,
            IsActive:1,
        };

        alert(JSON.stringify(Data));
        AjsFactory.addUnitData(Data)
            .then(function (response) {
                alert('Request has been saved successfully.');
                $scope.GetUnitData();
            });
    };

    $scope.GetUnitData = function () {

        debugger;
        var Data = {
            UnitID: $scope.UnitID,
            Type: 2,

        };

        AjsFactory.getUnitDetailData(Data)
            .then(function (response) {
                debugger;
                if (response.data.length != 0) {
                    $scope.unitLst = response.data;


                   // $scope.form.unittype = response.data;
                    $scope.form.unittype = $scope.unitLst[0][0].UnitType;
                    $scope.form.unittitle = $scope.unitLst [0][0].UnitTitle;
                    $scope.form.NQFLevel = $scope.unitLst [0][0].NQFLevel;
                    $scope.form.credits = $scope.unitLst [0][0].Credits;
                    $scope.form.NoOfDaysReqToComplete = $scope.unitLst [0][0].NumberOfDaysRequiredToComplete;
                    $scope.form.AmountApprovedForTheUnit = $scope.unitLst [0][0].AmountApprovedForTheUnit;


                }
            });
    };

    $scope.GetUnitData(); 
}]);