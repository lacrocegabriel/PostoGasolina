Ext.define('PostoGasolina.store.ClientesCombo', {
    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.Cliente',

    //pageSize: 40,

    proxy: {
        type: 'ajax',
        api: {
            read: '/Clientes/GetComboClientes',
        },
        
        reader: {
            type: 'json',
            root: 'data'
        }
    },
    listeners: {
        beforeload: function (store, operation, eOpts) {

            var comboc = Ext.ComponentQuery.query('combo#cbcliente')[0];

            operation.params.query = comboc.value;

        }
    }
});

