﻿(function () {
    'use strict';

    angular
        .module('ownersPetsApp')
        .factory('allOwnersService', allOwnersService);

    allOwnersService.$inject = ['$http'];

    function allOwnersService($http) {
        var service = {
            getOwners: getOwners,
            addOwner: addOwner,
            deleteOwner: deleteOwner
        };

        return service;

        function getOwners() {
            return $http.get('api/owners/GetOwner').then(response => {
                return response;
            });
        }

        function addOwner(owner) {
            return $http.post('api/owners/AddOwner', owner).then(response => {
                return response;
            });
        }

        function deleteOwner(ownerId) {
            return $http.delete('api/owners/DeleteOwner?ownerId=' + ownerId).then(response => {
                return response;
            });
        }
    }
})();