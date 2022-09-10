Ext.define('PostoGasolina.controller.Clientes', {
    extend: 'Ext.app.Controller',

    models: [
        'PostoGasolina.model.Cliente'
    ],

    stores: [
        'PostoGasolina.store.Clientes'
    ],

    views: [
        'PostoGasolina.view.Home.Home',
        'PostoGasolina.view.Home.HomeTab',
        'PostoGasolina.view.Clientes.ClientesGrid',
        'PostoGasolina.view.Clientes.ClientesForm'
    ],

    init: function (application) {
        this.control({
            "clientesgrid": {
                render: this.onGridRender,
                itemdblclick: this.onEditClick
            },
            "clientesgrid button#add": {
                click: this.onAddClick
            },
            "clientesgrid button#edit": {
                click: this.onBEditClick
            },
            "clientesgrid button#delete": {
                click: this.onDeleteClick
            },
            "clientesform button#cancel": {
                click: this.onCancelClick
            },
            "clientesform button#save": {
                click: this.onSaveClick
            }
            
        });
    },

    onGridRender: function (grid, eOpts) {
        grid.getStore().load();
    },
    onAddClick: function(btn, e, eOpts) {

        var win = Ext.create('PostoGasolina.view.Clientes.ClientesForm');

        win.setTitle('Adicionar');
        
    },
    onBEditClick: function (btn, e, eOpts) {

        var grid = btn.up('grid');

        var record = grid.getSelectionModel().getLastSelected();

        console.log(record);

        var win = Ext.create('PostoGasolina.view.Clientes.ClientesForm');

        win.setTitle('Editar');

        var form = win.down('form');

        form.loadRecord(record);

    },
    onEditClick: function (grid, record, item, index, e, eOpts) {

        console.log(record);

        var win = Ext.create('PostoGasolina.view.Clientes.ClientesForm');

        win.setTitle('Editar');

        var form = win.down('form');

        form.loadRecord(record);

    },
    onCancelClick: function (btn, e, eOpts) {
        var win = btn.up('window');

        var form = win.down('form');

        form.getForm().reset();

        win.close();
    },
    onSaveClick: function (btn, e, eOpts) {

        var win = btn.up('window'),
            form = win.down('form'),
            values = form.getValues(),
            record = form.getRecord(),
            grid = Ext.ComponentQuery.query('clientesgrid')[0],
            store = grid.getStore(),
            toolbar = grid.down('pagingtoolbar');

        if (record) {

            record.set(values);

        } else {
            var cliente = Ext.create('PostoGasolina.model.Cliente', {
                nome: values.nome,
                documento: values.documento,
                dataCadastro: values.dataCadastro,
                ativo: values.ativo,
            });

            store.add(cliente);
            toolbar.doRefresh();
        }

        store.sync();
        win.close();
        toolbar.doRefresh();
    },
    onDeleteClick: function (btn, e, eOpts) {

        var grid = btn.up('grid');

        var record = grid.getSelectionModel().getLastSelected();
        
        var store = grid.getStore();

        store.remove(record);

        store.sync();
    }
});
