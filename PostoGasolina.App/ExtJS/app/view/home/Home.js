Ext.define('PostoGasolina.view.Home.Home', {
    title: 'Gas Control',
    extend: 'Ext.panel.Panel',
    alias: 'widget.gascontrolpanel',
    layout: 'border',
    items: [
        {
        xtype: 'hometab',
        region: 'center',
        layout: 'fit'
        }
    ]
});
