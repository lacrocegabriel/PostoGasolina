Ext.define('PostoGasolina.store.Clientes', {
    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.Cliente',

    //pageSize: 40,

    proxy: {
        type: 'ajax',
        api: {
            create: '/Clientes/SaveCliente',
            read: '/Clientes/GetGridClientes',
            update: '/Clientes/EditCliente',
            destroy: '/Clientes/DeleteCliente'
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

