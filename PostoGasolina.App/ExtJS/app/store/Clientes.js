Ext.define('PostoGasolina.store.Clientes', {
    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.Cliente',

    pageSize: 10,

    proxy: {
        type: 'ajax',
        api: {
            create: '/Clientes/Create',
            read: '/Clientes/Index',
            update: '/Clientes/Edit',
            destroy: '/Clientes/Delete'
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

