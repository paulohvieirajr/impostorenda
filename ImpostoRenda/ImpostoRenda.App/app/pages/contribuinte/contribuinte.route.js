(function () {
    'use strict';

    angular.module('app').config(config);

    config.$inject = ['$stateProvider', 'URLBASE'];

    function config($stateProvider, URLBASE) {
        $stateProvider
           .state(URLBASE + '/contribuinte', {
               url: URLBASE + '/contribuinte',
               cache: false,
               templateUrl: 'app/pages/contribuinte/contribuinte.html',
               controller: 'contribuinteController as vm'
           });
    }
})();