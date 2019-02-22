(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('myPetsService', myPetsService);

    myPetsService.$inject = ['$http'];

    function myPetsService($http) {

        this.getAllPets = getAllPets;
        this.deletePet = deletePet;
        this.getPet = getPet;
        this.addPet = addPet;
        this.updatePet = updatePet;
        var query = "";
        function getAllPets(userId) {
            var params = { ownerId: userId };
            if (userId) {
                query = "?ownerId=" + userId;
            }
            return $http({
                method: 'GET',
                url: '/api/pets' + query
            });
        }
        function deletePet(petId) {
            return $http({
                method: 'DELETE',
                url: '/api/pets/' + petId
            });
        }
        function getPet(petId) {
            return $http({
                method: 'GET',
                url: '/api/pets/' + petId
            });
        }
        function addPet(pet) {
            return $http({
                method: 'POST',
                url: '/api/pets',
                data: pet
            });
        }
        function updatePet(pet) {
            return $http({
                method: 'PUT',
                url: '/api/pets',
                data: pet
            });
        }
    }
})();