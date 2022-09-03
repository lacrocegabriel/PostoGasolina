Ext.define('PostoGasolina.view.Home.HomeTab', {
    extend: 'Ext.tab.Panel',

    alias: 'widget.hometab',
    width: 300,
    height: 200,
    activeTab: 0,
    plain: true,
    autoShow: true,
    items: [
        {
            title: 'Abastecimentos',

            items: [{
                xtype: 'abastecimentosgrid',
                layout: 'fit'
            }],
            itemId: 't3'
        },
        {
            title: 'Clientes',

            items: [{
                xtype: 'clientesgrid',
                layout: 'fit'
            }],
            itemId: 't1'
        },
        {
            title: 'Veiculos',

            items: [{
                xtype: 'veiculosgrid',
                layout: 'fit'
            }],
            itemId: 't2'
        }
    ]
});