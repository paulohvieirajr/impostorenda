(function () {
    'use strict';

    angular.module('app').controller('contribuinteController', controller);

    controller.inject = ['$state', '$sce', 'URLBASE', 'contribuinteService', 'toastr'];

    function controller($state, $sce, URLBASE, contribuinteService, toastr) {
        var vm = this;

        vm.init = init;
        vm.salvar = salvar;
        vm.voltar = voltar;

        function init() {
            try {
                vm.model = {};
            } catch (e) {
                toastr.error(e, 'Error');
            }
        }

        function salvar() {
            try {
                contribuinteService.inserir(vm.model)
                    .then(function (response) {
                        if (!response.data.result) {
                            angular.forEach(response.data.messages, function (message) {
                                toastr.error(message, 'Error');
                            });
                        }
                        else {
                            toastr.success('Contribuinte atualizado com sucesso');
                        }
                    })
                    .catch(function (error) {
                        console.log(error)
                    });
            } catch (e) {
                toastr.error(e, 'Error');
            }
        }

        function voltar() {
            try {
                $state.go(URLBASE + '/home');
            } catch (e) {
                toastr.error(e, 'Error');
            }
        }
    }
})();