(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('MyPetsController', MyPetsController);

    MyPetsController.$inject = ['myPetsService', '$scope','userService','$location','$mdDialog'];

    function MyPetsController(myPetsService, $scope,userService,location,$mdDialog) {

        var vm = this;
        vm.pets = [];
        vm.current = '';
        vm.deletePet = deletePet;
        vm.goToSave = goToSave;
        vm.goToEdit = goToEdit;
        vm.showDeleteConfirm = showDeleteConfirm;
        vm.getConversations = getConversations;
        activate();



        function getAllPets() {
            userService.getUserId().then(
                function (result) {
                     myPetsService.getAllPets(result.data)
                         .then(function (result) {
                             vm.pets = result.data;
                        });
                },
                function (error) {

                });
        }

        function deletePet(petId) {
            myPetsService.deletePet(petId)
                .then(function () {
                    getAllPets();
                });
        }

        function showDeleteConfirm(ev,petId) {
            var confirm = $mdDialog.confirm()
                .title('Deleting this pet?')
                .textContent('There will be no option to undo this operation')
                .ariaLabel('Lucky day')
                .targetEvent(ev)
                .ok('Yes')
                .cancel('No');

            $mdDialog.show(confirm).then(function () {
                deletePet(petId);
                $scope.status = 'Pet deleted';
            }, function () {
               
            });
        }

        function goToSave(pet) {
            console.log("in create new");
            location.path("/pet-save");
        }

        function goToEdit(petId) {
            console.log("in create new");
            location.path("/pet-edit/"+petId);
        }

        function activate() {
            getAllPets();
        }

        function getConversations(petId) {
            console.log("get conversations");
        }
    }
})();