Ext.define('PostoGasolina.view.Home.Home', {

    iconCls: 'icon-grid',

    title: 'Controle de Abastecimentos',

    extend: 'Ext.panel.Panel',

    alias: 'widget.gascontrolpanel',
    
    layout: 'border',

    items: [
        {
            xtype: 'hometab', 
            region: 'center'
        }
    ]
});
