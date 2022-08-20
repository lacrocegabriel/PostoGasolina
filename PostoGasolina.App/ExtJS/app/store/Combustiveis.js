Ext.define('PostoGasolina.store.Combustiveis', {
    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.Combustivel',

    proxy: {
        type: 'ajax',
        api: {
            create: '/Combustiveis/Create',
            read: '/Combustiveis/Index',
            update: '/Combustiveis/Edit',
            destroy: '/Combustiveis/DeleteConfirmed'
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

