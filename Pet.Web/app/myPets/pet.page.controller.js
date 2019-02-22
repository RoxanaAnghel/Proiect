(function () {
    'use-strict';

    angular
        .module('getAPet')
        .controller('PetPageController', PetPageController);

    PetPageController.$inject = ['$scope', '$routeParams', '$mdDialog', 'myPetsService', 'pet', 'conversationsService', '$location'];

    function PetPageController($scope, $routeParams, $mdDialog, myPetsService, pet, conversationsService, location) {

        
    }
})();