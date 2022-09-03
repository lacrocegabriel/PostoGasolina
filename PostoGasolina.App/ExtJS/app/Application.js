Ext.define('PostoGasolina.Application', {
    name: 'PostoGasolina',

    extend: 'Ext.app.Application',

    appFolder: 'ExtJS/app',


    
   views: [
       //'Home',
       //'HomeTab',
       //'Clientes/ClientesGrid',
       //'Abastecimentos/AbastecimentosForm',
       //'Abastecimentos/AbastecimentosGrid',
       //'Veiculos/VeiculosGrid'
    ],

    controllers: [
        'Abastecimentos',
        'Clientes',
        'Veiculos'

    ],

    stores: [
        
    ]
});
