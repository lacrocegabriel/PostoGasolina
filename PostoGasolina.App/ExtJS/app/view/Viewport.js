Ext.define('PostoGasolina.view.Viewport', {
    extend: 'Ext.container.Viewport',
    requires:[
        'Ext.layout.container.Border',
        'PostoGasolina.view.Home',
        'PostoGasolina.view.HomeTab',
        'PostoGasolina.view.CombustiveisGrid',
        'PostoGasolina.view.ClientesGrid',
        'PostoGasolina.view.AbastecimentosGrid',
        'PostoGasolina.view.AbastecimentosForm',
        'PostoGasolina.view.VeiculosGrid'
    ],

    layout: {
        type: 'border'
       
    },

    items: [
    //    {
    //    region: 'west',
    //    xtype: 'menutree',
    //    //xtype: 'combustiveisgrid',
    //    split: true,
    //    margins: '5 0 0 5',
    //    width: 200,
    //    collapsible: true
    //}
    //,
    {
        region: 'center',
        xtype: 'gascontrolpanel',
        margins: '5 0 0 5'
        
    }
    ]
});
