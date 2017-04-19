(function () {
    'use strict';

    angular
        .module('ownersPetsApp')
        .controller('allOwnersController', allOwnersController);

    allOwnersController.$inject = ['$location', 'allOwnersService'];

    function allOwnersController($location, allOwnersService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'homeController';

        activate();

        function activate() {
            vm.owners = [];
            vm.newOwner = {
                name: ""
            }
            vm.pagination = {
                totalItems: 1,
                currentPage: 1,
                itemsPerPage: 3,
                change: () => {
                    vm.getOwners();
                }
            }
            vm.isDesc = false;

            vm.getOwners = function () {
                allOwnersService.getOwners(vm.pagination.currentPage, vm.pagination.itemsPerPage, vm.isDesc).then(response => {
                    vm.owners = response.data.owners;
                    vm.pagination.totalItems = response.data.totalItems;
                });
            }

            vm.addOwner = function () {
                allOwnersService.addOwner(vm.newOwner).then(response => {
                    vm.getOwners();
                    vm.newOwner = {};
                });
            }

            vm.deleteOwner = function (index) {
                allOwnersService.deleteOwner(vm.owners[index].ownerId).then(response => {
                    vm.pagination.currentPage = 1;
                    vm.getOwners();
                });
            }

            vm.goToOwnersPage = function (index) {
                let path = '/owner-pets/' + vm.owners[index].ownerId;
                $location.path(path);
            }

            vm.order = function () {
                vm.isDesc = !vm.isDesc;

                vm.totalCount = 0;
                vm.getOwners();
            }

            vm.getOwners();
        }
    }
})();
