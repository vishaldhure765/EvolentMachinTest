EvolentApp.service('API', ['$http', function ($http, $scope) {

     this.Get = function (url, obj) {
            return $http({
                url: url,
                method: 'Get',
                async: false,
                params: obj,
                headers: {
                    "Content-Type": "application/json"
                }
            });
     };
     
     this.Post = function (url, obj) {
            return $http({
                url: url,
                dataType: 'json',
                contentType: "application/json",
                method: 'POST',
                data: JSON.stringify(obj) ,  //angular.toJson(obj),
                headers: {
                    "Content-Type": "application/json"
                }
            });
     };
     this.Put = function (url, param, obj) {
         return $http({
             url: url,
             dataType: 'json',
             method: 'Put',
             params: param,
             data: angular.toJson(obj),
             headers: {
                 "Content-Type": "application/json"
             }
         });
     };
     this.Delete = function (url, obj) {
         return $http({
             url: url,
             dataType: 'json',
             method: 'Get',
             params: obj,
             headers: {
                 "Content-Type": "application/json"
             }
         });
     };
     this.PostFile = function (url, obj) {
         var formdata = new FormData();
         angular.forEach(obj, function (value, key) {
             formdata.append(key, value);
         });
         return $.ajax({
            url: url,
            type: 'POST',
             data: formdata,
             async: false,
            processData: false,
            contentType: false 
        })
     };

}]);

