Ext.define('PostoGasolina.store.VeiculosCombo', {
    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.Veiculo',

    proxy: {
        type: 'ajax',
        api: {
            read: '/Veiculos/GetComboVeiculos'
        },
        
        reader: {
            type: 'json',
            root: 'data'
        }
    },
    listeners: {
        beforeload: function (store, operation, eOpts) {

            var comboc = Ext.ComponentQuery.query('combo#cbcliente')[0];

            operation.params.data = comboc.value;

        }
    }
});

