HomeApp.factory('AjsFactory', ['$http', '$q',function ($http,$q) {


    var dataFactory = {};

    

    dataFactory.AddUserData = function (data) {
        debugger;
        return $http.post('/User/AddUserDetailData',data);
    };
    dataFactory.getUserData = function (data) {
        //debugger;
        return $http.post('/User/GetUserDetailData', data);
    };

    //add site data
    dataFactory.addSiteData = function (data) {
        debugger;
        return $http.post('/Site/AddSiteDetail',data);
    };

    //add unit data
    dataFactory.addUnitData = function (data) {
        debugger;
        return $http.post('/Unit/AddUnitData', data);

    };

    //get site data
    dataFactory.GetSiteData = function (data) {
        debugger;
        return $http.post('/Site/GetSiteDetailsData', data);
    };

    //get unit data 
    dataFactory.getUnitData = function (data) {
        debugger;
        return $http.post('/Unit/GetUnitData', data);
    };

    //get unit details data
    dataFactory.getUnitDetailData = function (data) {
        debugger;
        return $http.post('/Unit/getUnitDetailData', data);
    };

    //add program data
    dataFactory.AddProgramData = function (data) {
        debugger;
        return $http.post('/Program/AddProgramsData', data);
    };


    dataFactory.GetProgramData = function (data) {
        debugger;
        return $http.post('/Program/GetProgramsData', data);
    };

    //get status data
    dataFactory.getStatusData = function (data) {
        debugger;
        return $http.post('/Program/getStatusDetailData',data);
    };

    return dataFactory;
}]);


