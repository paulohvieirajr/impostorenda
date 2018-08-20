(function () {
    'use strict';

    angular.module('app').controller('homeController', controller);

    controller.inject = ['$state', '$sce', 'URLBASE', 'contribuinteService', 'salarioMinimoService', 'toastr'];

    function controller($state, $sce, URLBASE, contribuinteService, salarioMinimoService, toastr) {
        var vm = this;
        vm.salariominimo = {};
        vm.contribuintes = [];

        vm.init = init;
        vm.novoContribuinte = novoContribuinte;
        vm.atualizarSalarioMinimo = atualizarSalarioMinimo;

        function init() {
            try {
                contribuinteService.listar()
                    .then(function (response) {
                        if (!response.data.result) {
                            toastr.error('Não há participantes a serem listados', 'Error');
                            return;
                        }

                        vm.contribuintes = response.data.object;
                    })
                    .catch(function (error) {
                        console.log(error);
                    });

                vm.salariominimo.valor = 0;
                salarioMinimoService.obter()
                    .then(function (response) {
                        if (!response.data.result) {
                            return;
                        }

                        vm.salariominimo = response.data.object;
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            } catch (e) {
                toastr.error(e, 'Error');
            }
        }

        function novoContribuinte() {
            try {
                $state.go(URLBASE + '/contribuinte');
            } catch (e) {
                toastr.error(e, 'Error');
            }
        }

        function atualizarSalarioMinimo() {
            try {
                if (vm.salariominimo <= 0) {
                    toastr.error('Por favor, informa um salário mínimo maior que zro.', 'Error');
                    return;
                }
                salarioMinimoService.salvar(vm.salariominimo)
                    .then(function (response) {
                        if (!response.data.result) {
                            toastr.error(response.data.messages[0]);
                            return;
                        }

                        toastr.success("Salário mínimo atualizado com sucesso");
                        init();
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            } catch (e) {
                toastr.error(e, 'Error');
            }
        }
    }
})();