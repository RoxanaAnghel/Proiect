(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('UserEditController', UserEditController);

    UserEditController.$inject = ['userService', '$scope', '$location'];

    function UserEditController(userService, scope, location) {

        var vm = this;

        vm.save = save;
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

        function save() {

        }

        function activate() {

        }
    }
})();