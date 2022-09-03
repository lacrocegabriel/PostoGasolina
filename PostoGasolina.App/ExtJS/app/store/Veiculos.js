Ext.define('PostoGasolina.store.Veiculos', {
    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.Veiculo',

    proxy: {
        type: 'ajax',
        api: {
            create: '/Veiculos/Create',
            read: '/Veiculos/Index',
            update: '/Veiculos/Edit',
            destroy: '/Veiculos/Delete'
        },
        
        reader: {
            type: 'json',
            root: 'data'
        },

        writer: {
            type: 'json',
            root: 'data',
            encode: true
        }
    }
});

