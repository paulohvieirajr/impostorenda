(function () {
    'use strict';

    angular.module('app').service('salarioMinimoService', service);

    service.$inject = ['$http', 'URLAPI'];

    function service($http, URLAPI) {

        function obter() {
            return $http.get(URLAPI + 'api/salariominimo');
        }

        function salvar(data) {
            return $http.post( URLAPI + 'api/salariominimo', data);
        }

        return {
            obter: obter,
            salvar: salvar
        };
    }
})();