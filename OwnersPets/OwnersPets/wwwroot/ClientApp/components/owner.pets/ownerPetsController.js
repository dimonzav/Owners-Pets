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
            vm.isDesc = false;

            vm.getOwnerPets = function () {
                ownerPetsService.getOwnerPets(vm.ownerId, vm.pagination.currentPage, vm.pagination.itemsPerPage, vm.isDesc).then(response => {
                    vm.ownerPets = response.data.pets;
                    vm.owner = response.data;
                    vm.pagination.totalItems = response.data.petsCount;
                });
            }

            vm.addOwnerPet = function () {
                vm.newOwnerPet.ownerId = vm.owner.ownerId;
                ownerPetsService.addOwnerPet(vm.newOwnerPet).then(response => {
                    vm.getOwnerPets();
                    vm.newOwnerPet = {};
                });
            }

            vm.deleteOwnerPet = function (index) {
                ownerPetsService.deleteOwnerPet(vm.ownerPets[index].petId).then(response => {
                    vm.pagination.currentPage = 1;
                    vm.getOwnerPets();
                });
            }

            vm.backToAllOwners = function () {
                $location.path('/owners');
            }

            vm.order = function () {
                vm.isDesc = !vm.isDesc;
                vm.getOwnerPets();
            }

            vm.getOwnerPets();
        }
    }
})();
