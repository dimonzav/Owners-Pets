(function () {
    'use strict';

    angular
        .module('ownersPetsApp')
        .controller('ownerPetsController', ownerPetsController);

    ownerPetsController.$inject = ['$location', '$routeParams', 'ownerPetsService'];

    function ownerPetsController($location, $routeParams, ownerPetsService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'petsController';

        activate();

        function activate() {
            vm.ownerId = $routeParams.ownerId;
            vm.owner = {};
            vm.ownerPets = [];
            vm.totalCount = 0;
            vm.newOwnerPet = {
                name: "",
                ownerId: ""
            }
            vm.pagination = {
                totalItems: 1,
                currentPage: 1,
                itemsPerPage: 3,
                change: () => {
                    vm.getOwnerPets();
                }
            }

            vm.getOwnerPets = function () {
                ownerPetsService.getOwnerPets(vm.ownerId, vm.pagination.currentPage, vm.pagination.itemsPerPage).then(response => {
                    vm.ownerPets = response.data.pets;
                    vm.owner = response.data;
                    vm.pagination.totalItems = response.data.petsCount;

                    vm.totalCount += vm.ownerPets.length;
                });
            }

            vm.addOwnerPet = function () {
                vm.newOwnerPet.ownerId = vm.owner.ownerId;
                ownerPetsService.addOwnerPet(vm.newOwnerPet).then(response => {
                    vm.ownerPets.push(response.data);
                    vm.newOwnerPet = {};
                });
            }

            vm.deleteOwnerPet = function (index) {
                ownerPetsService.deleteOwnerPet(vm.ownerPets[index].petId).then(response => {
                    vm.ownerPets.splice(index, 1);
                });
            }

            vm.backToAllOwners = function () {
                $location.path('/owners');
            }

            vm.getOwnerPets();
        }
    }
})();
