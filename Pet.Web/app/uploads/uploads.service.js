(function () {

    "use strict";

    // Service to do CRUD operations on photos
    angular
        .module("getAPet")
        .service("uploadsService", UploadsService)

    UploadsService.$inject = ["$http", "$q"];


    function UploadsService($http, $q) {

        var apiUrl = '/api/uploads';

        //Get all photos saved on the server  
        function getAll() {

            var deferred = $q.defer();

            $http.get(apiUrl)
                .success(function (result) {
                    deferred.resolve(result);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        //Get photo from server with given file name        
        function getPhoto(fileName) {

            var deferred = $q.defer();

            $http.get(apiUrl + fileName)
                .success(function (result) {
                    deferred.resolve(result);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        // Delete photo on the server with given file name      
        function deletePhoto(fileName) {

            var deferred = $q.defer();

            $http.delete(apiUrl, { params: { fileName: fileName } })
                .success(function (result) {
                    deferred.resolve(result);
                }).error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        return {
            getAll: getAll,
            getPhoto: getPhoto,
            deletePhoto: deletePhoto
        };
    };
})();