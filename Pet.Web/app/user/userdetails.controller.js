(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('UserDetailsController', UserDetailsController);

    UserDetailsController.$inject = ['userService', '$scope',  '$location'];

    function UserDetailsController(userService, scope, location) {

        var vm = this;
        
        vm.goToEdit = goToEdit;
        activate();
        vm.user = {};
        vm.getUserDetails = getUserDetails;
        getUserDetails();
        
        function getUserDetails() {
            userService.getUserDetails().
                then(function (result) {
                    vm.user = result.data;
                });
        }
        
        

        function goToEdit(petId) {
            
        }

        function activate() {
            
        }
    }
})();