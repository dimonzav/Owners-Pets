(function () {
    'use strict';

    angular
        .module('app')
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
            return $http.get('api/pets/GetOwnerPets?ownerId=' + ownerId).then(response => {
                return response;
            });
        }

        function addOwnerPet(pet) {
            return $http.post('api/pets/AddOwnerPet', pet).then(response => {
                return response;
            });
        }

        function deleteOwnerPet(petId) {
            return $http.delete('api/pets/DeleteOwnerPet?petId=' + petId).then(response => {
                return response;
            });
        }
    }
})();