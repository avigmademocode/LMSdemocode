HomeApp.controller('UserController', ['$scope', '$window', '$location', 'AjsFactory', function ($scope, $window, $location, AjsFactory) {


    $scope.UserID = $scope.UserID ? $scope.UserID.split('?')[1] : window.location.search.slice(1);
    //alert($scope.UserID);

    $scope.submitForm = function () {

        var bool = true;
        bool = EmailValidation($scope.form.emailid);

        debugger;
        var Type;
        if ($scope.UserID == 0)
        {
            Type = 1;
        }
        else 
        {
            Type = 2;
        }
        var data = {

            UserName:  $scope.form.username,
            Password:  $scope.form.password,
            FirstName: $scope.form.firstname,
            LastName:  $scope.form.lastname,
            MobileNumber: $scope.form.mobileno,
            EmailId: $scope.form.emailid,
            UserId: $scope.UserID,

            Type: Type,
            CurrUserId: 0,
            IsActive: $scope.form.isactive
        };

        alert(JSON.stringify(data));
        AjsFactory.AddUserData(data)
            .then(function (response) {

                debugger;
                if (response.data.length != 0) {
                    alert('Request has been saved successfully.');
                    $scope.getUser();
                }
            });

    };


    $scope.getUser = function () {
        var data = {
            UserId: $scope.UserID,
            Type: 2


        };
        AjsFactory.getUserData(data)
            .then(function (response) {

                //debugger;
                if (response.data.length != 0) {
                    $scope.userLst = response.data;
                    //$scope.form = $scope.userLst;

                    $scope.form.firstname = $scope.userLst[0][0].FirstName;
                    $scope.form.lastname = $scope.userLst[0][0].LastName;
                    $scope.form.mobileno = $scope.userLst[0][0].MobileNumber;
                    $scope.form.emailid = $scope.userLst[0][0].EmailId;
                    $scope.form.username = $scope.userLst[0][0].UserName;
                    $scope.form.password = $scope.userLst[0][0].Password;
                    $scope.form.isactive = $scope.userLst[0][0].IsActive;
                }
            });

    };
    $scope.getUser();

   
        function EmailValidation(EmailId) {
             debugger;
            var reg = /^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/;
            if (reg.test(EmailId)) {
                return true;
            }
            else {
                alert('invalid email');
                return false;
               
            }
        }
    
  

}]);