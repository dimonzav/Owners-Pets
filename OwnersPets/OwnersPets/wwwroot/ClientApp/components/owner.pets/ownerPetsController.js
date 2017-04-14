(function () {
    'use strict';

    angular
        .module('ownersPetsApp')
        .controller('petsController', petsController);

    petsController.$inject = ['$location'];

    function petsController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'petsController';

        activate();

        function activate() {
            vm.backToAllOwners = function () {
                $location.path('/owners');
            }
        }
    }
})();
