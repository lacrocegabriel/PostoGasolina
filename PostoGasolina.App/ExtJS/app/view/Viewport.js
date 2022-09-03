Ext.define('PostoGasolina.view.Viewport', {
    extend: 'Ext.container.Viewport',
    requires:[
        'Ext.layout.container.Border',
        'PostoGasolina.view.Home',
        'PostoGasolina.view.HomeTab',
        'PostoGasolina.view.ClientesGrid',
        'PostoGasolina.view.AbastecimentosGrid',
        'PostoGasolina.view.AbastecimentosForm',
        'PostoGasolina.view.VeiculosGrid'
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
