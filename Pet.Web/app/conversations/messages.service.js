(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('messagesService', messagesService);

    messagesService.$inject = ['$http'];

    function messagesService($http) {

        this.getMessages = getMessages;
        this.sendMessage = sendMessage;

        function getMessages(conversationId) {
            return $http({
                method: 'GET',
                url: '/api/messages?conversationId=' + conversationId
            });
        }

        function sendMessage(message) {
            return $http({
                method: 'POST',
                url: '/api/messages',
                data:message
            })
        }
    }
})();