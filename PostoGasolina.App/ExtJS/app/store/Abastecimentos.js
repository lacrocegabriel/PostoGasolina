Ext.define('PostoGasolina.store.Abastecimentos', {
    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.Abastecimento',

    pageSize: 30,

    proxy: {
        type: 'ajax',
        api: {
            create: '/Abastecimentos/SaveAbastecimento',
            read: '/Abastecimentos/GetGridAbastecimentos',
            update: '/Abastecimentos/EditAbastecimento',
            destroy: '/Abastecimentos/DeleteAbastecimento'
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

