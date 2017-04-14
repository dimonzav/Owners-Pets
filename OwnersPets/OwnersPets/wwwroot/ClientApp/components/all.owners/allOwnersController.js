(function () {
    'use strict';

    angular
        .module('ownersPetsApp')
        .controller('ownersController', ownersController);

    ownersController.$inject = ['$location', 'ownersService'];

    function ownersController($location, ownersService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'homeController';

        activate();

        function activate() {
            vm.newOwner = "";
            vm.owners = [
                {
                    ownerId: 1,
                    name: "John",
                    petsCount: 4
                },
                {
                    ownerId: 2,
                    name: "Jim",
                    petsCount: 2
                },
                {
                    ownerId: 3,
                    name: "Madds",
                    petsCount: 5
                }];

            vm.addNewOwner = function () {
                ownersService.getData().then(response => {
                    vm.owners = response;
                });
            }

            vm.goToOwnersPage = function (index) {
                let path = '/owner-pets/1';
                $location.path('/owner-pets/').search({ ownerId: 1 });
            }

        }
    }
})();
