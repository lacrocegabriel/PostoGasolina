Ext.define('PostoGasolina.view.Viewport', {
    extend: 'Ext.container.Viewport',
    requires:[
        'Ext.layout.container.Border',
        'PostoGasolina.view.Home.Home'
    ],

    layout: {
        type: 'border'
    },

    items: [
        {
            region: 'center',
            xtype: 'gascontrolpanel'
        }
    ]
});
