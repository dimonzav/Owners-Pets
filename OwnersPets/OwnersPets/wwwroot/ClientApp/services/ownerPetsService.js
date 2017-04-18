(function () {
    'use strict';

    angular
        .module('ownersPetsApp')
        .factory('ownerPetsService', ownerPetsService);

    ownerPetsService.$inject = ['$http'];

    function ownerPetsService($http) {
        var service = {
            getOwnerPets: getOwnerPets,
            addOwnerPet: addOwnerPet,
            deleteOwnerPet: deleteOwnerPet
        };

        return service;

        function getOwnerPets(ownerId) {
            return $http.get('api/Pets/GetOwnerPets?ownerId=' + ownerId).then(response => {
                return response;
            });
        }

        function addOwnerPet(pet) {
            return $http.post('api/Pets/AddOwnerPet', pet).then(response => {
                return response;
            });
        }

        function deleteOwnerPet(petId) {
            return $http.delete('api/Pets/DeleteOwnerPet?petId=' + petId).then(response => {
                return response;
            });
        }
    }
})();