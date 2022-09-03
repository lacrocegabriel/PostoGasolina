Ext.define('PostoGasolina.store.Abastecimentos', {
    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.Abastecimento',

    proxy: {
        type: 'ajax',
        api: {
            create: '/Abastecimentos/Create',
            read: '/Abastecimentos/Index',
            update: '/Abastecimentos/Edit',
            destroy: '/Abastecimentos/Delete'
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

