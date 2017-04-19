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
            vm.totalCount = 0;
            vm.newOwner = {
                name: ""
            }
            vm.pagination = {
                totalItems: 7,
                currentPage: 1,
                itemsPerPage: 3,
                change: () => {
                    vm.getOwners();
                }
            }

            vm.getOwners = function () {
                allOwnersService.getOwners(vm.pagination.currentPage, vm.pagination.itemsPerPage).then(response => {
                    vm.owners = response.data.owners;
                    vm.pagination.totalItems = response.data.totalItems;

                    for (let i = 0; i < vm.owners.length; i++) {
                        vm.totalCount += vm.owners[i].petsCount;
                    }
                });
            }

            vm.addOwner = function () {
                allOwnersService.addOwner(vm.newOwner).then(response => {
                    vm.owners.push(response.data);
                    vm.newOwner = {};
                });
            }

            vm.deleteOwner = function (index) {
                allOwnersService.deleteOwner(vm.owners[index].ownerId).then(response => {
                    vm.owners.splice(index, 1);
                });
            }

            vm.goToOwnersPage = function (index) {
                let path = '/owner-pets/' + vm.owners[index].ownerId;
                $location.path(path);
            }

            vm.getOwners();
        }
    }
})();
