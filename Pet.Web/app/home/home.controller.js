(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['myPetsService', '$scope', '$mdDialog','conversationsService','$location'];

    function HomeController(myPetsService, scope, $mdDialog, conversationsService,location) {

        var vm = this;
        vm.pets = [];
        vm.getPetProfile = getPetProfile;
        vm.search = false;
        vm.showInput = false;
        vm.showSearch = showSearch;
        vm.clearSearch = clearSearch;
        vm.hideSearch = hideSearch;
        vm.getConversation = getConversation;
        vm.petProfile={}

        vm.searchOptions = {
            Species: 0,
            Color: 0,
            PureBreed: false,
            Breed: '',
            Size: 0,
            Fur: 0
        };

        activate();

        function hideSearch() {
            vm.showInput = false;
        }

        function showSearch() {
            vm.search = true;
            vm.showInput = true;
        }

        function clearSearch() {
            vm.search = false;
            vm.showInput = false;
        }

        function getAllPets() {
            myPetsService.getAllPets()
                .then(function (result) {
                    vm.pets = result.data;
                });
        }

        function activate() {
            getAllPets();
        }

        function getPetProfile(ev, pet) {
            vm.petProfile = pet;
            console.log("in pet profile get");
            $mdDialog.show({
                controller: "PetViewController",
                controllerAs: 'PetViewController',
                templateUrl: window.location.origin + "/Templates/PetViewProfile",
                parent: angular.element(document.body),
                targetEvent: ev,
                locals: {
                    pet: pet
                },
                clickOutsideToClose: true
            });

        }

        function getConversation(petId) {
            conversationsService.getConversationWith(petId)
                .then(function (result) {
                    var id = result.data.ID;
                    location.path("userconversation/" + id);
                });
        }

        
    }
})();