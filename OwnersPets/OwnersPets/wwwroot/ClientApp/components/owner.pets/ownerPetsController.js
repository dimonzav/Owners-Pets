(function () {
    'use strict';

    angular
        .module('ownersPetsApp')
        .controller('petsController', petsController);

    petsController.$inject = ['$location', 'ownerPetService'];

    function petsController($location, ownerPetService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'petsController';

        activate();

        function activate() {

            vm.OwnerPets = function () {
                ownerPetService.getOwnerPets().then(response => {
                    vm.owners = response;
                });
            }

            vm.addOwnerPet = function () {
                ownerPetService.addOwnerPet().then(response => { });
            }

            vm.deleteOwnerPet = function () {
                ownerPetService.deleteOwnerPet().then(response => { });
            }

            vm.backToAllOwners = function () {
                $location.path('/owners');
            }
        }
    }
})();
