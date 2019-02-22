(function () {
    'use strict';

    angular
        .module('getAPet')
        .controller('conversationController', conversationController);

    conversationController.$inject = ['conversationsService', 'messagesService', '$scope', '$location','$routeParams', '$q'];

    function conversationController(conversationsService, messagesService, scope, location, $routeParams, $q) {

        var vm = this;
        vm.messages = [];
        vm.conversation = {};
        vm.conversationId = $routeParams.conversationId;
        vm.currentText = "";

        vm.loadMessages = loadMessages;
        vm.sendMessage = sendMessage;

        activate();

        function loadMessages() {
            messagesService.getMessages($routeParams.conversationId).
                then(function (result) {
                    vm.messages = result.data;
                });
        }

        function loadConversation() {
            conversationsService.getConversation($routeParams.conversationId).
                then(function (result) {
                    vm.conversation = result.data;

                })
        }

        function sendMessage() {
            console.log("in mesaj");
            if (vm.currentText) {
                var message = {
                    ConversationId: vm.conversationId,
                    Text:vm.currentText
                };
                messagesService.sendMessage(message).
                    then(function (result) {
                        loadMessages();
                    });
            }
        }

        //setInterval(loadMessages, 100);


        function activate() {
            var getConversationPromise = conversationsService.getConversation($routeParams.conversationId);
            var getMessagesPromise = messagesService.getMessages($routeParams.conversationId);

            $q.all([getConversationPromise, getMessagesPromise]).then(function (result) {
                vm.conversation = result[0].data;
                vm.messages = result[1].data;
                console.log("your id");
                console.log(vm.messages[0].SentBy);
                console.log(vm.conversation.YourId);
                console.log(vm.conversation.WithID);
            });
        }
    }
})();