Ext.define('PostoGasolina.view.Viewport', {
    extend: 'Ext.container.Viewport',
    requires:[
        'Ext.layout.container.Border',
        'PostoGasolina.view.Home.Home',
        'PostoGasolina.view.Home.HomeTab',
        'PostoGasolina.view.Clientes.ClientesGrid',
        'PostoGasolina.view.Abastecimentos.AbastecimentosGrid',
        'PostoGasolina.view.Abastecimentos.AbastecimentosForm',
        'PostoGasolina.view.Veiculos.VeiculosGrid'

        //'Home/Home',
        //'Home/HomeTab',
        //'Clientes/ClientesGrid',
        //'Abastecimentos/AbastecimentosForm',
        //'Abastecimentos/AbastecimentosGrid',
        //'Veiculos/VeiculosGrid'
    ],

    layout: {
        type: 'border'
       
    },

    items: [
        {
            region: 'center',
            xtype: 'gascontrolpanel',
            margins: '5 0 0 5'
        
        }
    ]
});
