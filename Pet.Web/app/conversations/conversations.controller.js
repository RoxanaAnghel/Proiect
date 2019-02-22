(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('conversationsController', conversationsController);

    conversationsController.$inject = ['conversationsService', '$scope', '$location'];

    function conversationsController(conversationsService, scope, location) {

        var vm = this;
        vm.getUserConversations = getUserConversations;
        vm.userConversations = [];
        getUserConversations();
        vm.goToConversation = goToConversation;
        function getUserConversations() {
            conversationsService.userConversations().
                then(function (result) {
                    vm.userConversations = result.data;
                });
        }

        function goToConversation(conversationId) {
            console.log("its working");

            location.path("/userconversation/" + conversationId);
        }

        function go() {
            console.log("meregeee");
        }
    }
})();