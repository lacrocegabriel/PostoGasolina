Ext.define('PostoGasolina.store.Veiculos', {
    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.Veiculo',

    proxy: {
        type: 'ajax',
        api: {
            create: '/Veiculos/SaveVeiculo',
            read: '/Veiculos/GetGridVeiculos',
            update: '/Veiculos/EditVeiculo',
            destroy: '/Veiculos/DeleteVeiculo'
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

