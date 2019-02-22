(function () {
    'use strict';

    angular
        .module('getAPet')
        .service('conversationsService', conversationsService);

    conversationsService.$inject = ['$http'];

    function conversationsService($http) {

        this.userConversations = userConversations;
        this.getConversation = getConversation;
        this.getConversationWith = getConversationWith;

        function userConversations() {
            return $http({
                method: 'GET',
                url: '/api/conversations'
            });
        }

        function getConversationWith(petId) {
            return $http({
                method: 'GET',
                url: '/api/conversations?petId=' + petId
            });
        }

        function getConversation(conversationId) {
            return $http({
                method: 'GET',
                url: '/api/conversations/' + conversationId
            });
        }

        function getConversationsAbout(petId) {
            return $http({
                method: 'GET',
                url: '/api/conversations/pet?petId=' + petId
            });
        }

        function getConversationMessages(conversationId) {
            return $http({
                method: 'GET',
                url: '/api/messages?conversationId=' + conversationId
            });
        }
    }
})();