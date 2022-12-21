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

        if (store != undefined && cliente != undefined) { 
            
        }   

        var win = btn.up('window'),
            form = win.down('form'),
            values = form.getValues(),
            record = form.getRecord(),
            grid = Ext.ComponentQuery.query('clientesgrid')[0],
            store = grid.getStore(),
            toolbar = grid.down('pagingtoolbar');

        if (record) {

            record.set(values);

        }
        else {
            var cliente = Ext.create('PostoGasolina.model.Cliente', {
                nome: values.nome,
                documento: values.documento,
                dataCadastro: values.dataCadastro,
                ativo: values.ativo,
            });

            store.add(cliente);
        }

        store.sync({
            success: function (batch, opts) {
                win.close();
                Ext.Msg.alert({
                    title: 'Mensagem',
                    msg: 'Cliente salvo com sucesso!',
                    minWidth: 450,
                    buttons: Ext.Msg.OK,
                    icon: Ext.Msg.INFO
                });
                grid.getView().refresh();
                toolbar.doRefresh();
            },
            failure: function (batch, opts) {

                var reader = batch.proxy.getReader();

                var teste = '';

                Ext.Array.each(reader.jsonData.data, function (mensagem, index) {
                    teste = teste + mensagem.mensagem + '<br>';
                });

                var msgBox = Ext.Msg.alert({
                   title: 'Mensagem',
                   msg: teste,
                   minWidth: 450,
                   buttons: Ext.Msg.OK,
                   icon: Ext.Msg.WARNING
                });

                store.remove(cliente);
            }
        })

        
       
    },
    onDeleteClick: function (btn, e, eOpts) {

        var grid = btn.up('grid'),
            record = grid.getSelectionModel().getLastSelected(),
            store = grid.getStore(),
            toolbar = grid.down('pagingtoolbar');

        store.remove(record);

        store.sync({
            success: function (batch, opts) {
                win.close();
                Ext.Msg.alert({
                    title: 'Mensagem',
                    msg: 'Cliente excluido com sucesso!',
                    minWidth: 450,
                    buttons: Ext.Msg.OK,
                    icon: Ext.Msg.INFO
                });
                grid.getView().refresh();
                toolbar.doRefresh();
            },
            failure: function (batch, opts) {

                var reader = batch.proxy.getReader();
                var msgBox = Ext.Msg.alert({
                    title: 'Mensagem',
                    msg: reader.jsonData.data.mensagem,
                    minWidth: 450,
                    buttons: Ext.Msg.OK,
                    icon: Ext.Msg.WARNING
                });
                
            }
        })

        grid.getView().refresh();
        toolbar.doRefresh();
    }
});
