(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('PetSaveController', PetSaveController);

    PetSaveController.$inject = ['myPetsService', '$scope', '$routeParams', '$location', 'uploadsService','Upload'];

    function PetSaveController(myPetsService, scope, $routeParams, location, fileService,Upload) {
        var apiUrl = '/api/uploads';
        var vm = this;
        vm.save = save;
        vm.pet = {

            Name: "Ola",
            Location: "",
            ImageUrl: "/uploads/get-a-pet-logo.jpg",
            Description: "",
            Species: 0,
            Breed: "",
            PureBreed: false,
            MainColour: 0,
            FurType: 0,
            Size: 0,
            Adopted: false,
            BirthDate: false
        };

        vm.file = [];
        vm.uploadImagine = uploadImagine;
        vm.species = [{ i: 1, v: "DOG" },
        { i: 2, v: "CAT" },
        { i: 2, v: "RODENT" },
        { i: 2, v: "FISH" },
        { i: 2, v: "REPTILE" },
        { i: 2, v: "INSECTS" },
        { i: 2, v: "HORSE" },
        { i: 2, v: "OTHER" }];

        vm.save = save;
        vm.cancel = cancel();
        vm.a = "123";

        scope.b = "3";


        function save() {
            myPetsService.addPet(vm.pet);
            location.path("/mypets");
            
        }

        function cancel() {

        }

        function uploadImagine(file) {
            console.log("in file");
            Upload.upload({
                url: apiUrl,
                data: { file: file }
            })
                .then(function (response) {
                    vm.pet.ImageUrl = "/uploads/"+response.data.Photos[0].Name;
                }, function (err) {
                    console.log("Error status: " + err.status);
                });

        }

        
    }
})();