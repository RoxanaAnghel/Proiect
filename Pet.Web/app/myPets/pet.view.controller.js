(function () {
    'use-strict';

    angular
        .module('getAPet')
        .controller('PetViewController', PetViewController);

    PetViewController.$inject = ['$scope', '$routeParams', '$mdDialog', 'myPetsService', 'pet'];

    function PetViewController($scope, $routeParams, $mdDialog, myPetsService, pet) {

        var vm = this;
        vm.pet = pet;

        vm.cancel = function () {
            $mdDialog.cancel();
        };

        vm.answer = function (answer) {
            $mdDialog.hide(answer);
        };
    }
})();