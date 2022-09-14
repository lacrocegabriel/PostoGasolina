Ext.define('PostoGasolina.controller.Veiculos', {
    extend: 'Ext.app.Controller',

    models: [
        'PostoGasolina.model.Veiculo'
    ],

    stores: [
        'PostoGasolina.store.Veiculos',
        'PostoGasolina.store.Clientes',
        'PostoGasolina.store.ClientesCombo'
    ],

    views: [
        'PostoGasolina.view.Home.Home',
        'PostoGasolina.view.Home.HomeTab',
        'PostoGasolina.view.Veiculos.VeiculosGrid',
        'PostoGasolina.view.Veiculos.VeiculosForm'
        
    ],

    init: function (application) {
        this.control({
            "veiculosgrid": {
                render: this.onGridRender,
                itemdblclick: this.onEditClick
            },
            "veiculosgrid button#add": {
                click: this.onAddClick
            },
            "veiculosgrid button#edit": {
                click: this.onBEditClick
            },
            "veiculosgrid button#delete": {
                click: this.onDeleteClick
            },
            "veiculosform button#cancel": {
                click: this.onCancelClick
            },
            "veiculosform button#save": {
                click: this.onSaveClick
            }
        });
    },

    onGridRender: function (grid, eOpts) {
        grid.getStore().load();
    },
    onAddClick: function(btn, e, eOpts) {

        var win = Ext.create('PostoGasolina.view.Veiculos.VeiculosForm');

        win.setTitle('Adicionar');

        var form = win.down('form');

        var combotc = form.down('combo#cbtipoCombustivel');

        combotc.getStore().clearFilter();
    },
    onBEditClick: function (btn, e, eOpts) {

        var grid = btn.up('grid');

        var record = grid.getSelectionModel().getLastSelected();

        var win = Ext.create('PostoGasolina.view.Veiculos.VeiculosForm');

        win.setTitle('Editar');

        var form = win.down('form');

        var comboc = form.down('combo#cbcliente');

        comboc.getStore().load({
            params: {
                data: record.data.clienteid
            }
        });

        comboc.setValue(record.data.clienteid);

        var combotc = form.down('combo#cbtipoCombustivel');

        combotc.getStore().clearFilter();

        form.loadRecord(record);

        combotc.setValue(record.data.tipoCombustivelid);
    },
    onEditClick: function (grid, record, item, index, e, eOpts) {

        var win = Ext.create('PostoGasolina.view.Veiculos.VeiculosForm');

        win.setTitle('Editar');

        var form = win.down('form');

        form.down('combo#cbcliente').setValue(record.data.clienteid);

        form.down('combo#cbcliente').getStore().load({
            params: {
                data: record.data.clienteid
            }
        });

        var combotc = form.down('combo#cbtipoCombustivel');

        combotc.getStore().clearFilter();

        form.loadRecord(record);

        combot.setValue(record.data.tipoCombustivelid);
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
            grid = Ext.ComponentQuery.query('veiculosgrid')[0],
            store = grid.getStore(),
            toolbar = grid.down('pagingtoolbar');

        if (record) {

            record.set(values);
            

        } else {
            var veiculo = Ext.create('PostoGasolina.model.Veiculo', {
                marca: values.marca,
                modelo: values.modelo,
                ano: values.ano,
                placa: values.placa,
                clienteid: values.clienteid,
                ativo: values.ativo,
                tipoCombustivelid: values.tipoCombustivelid
            });

            store.add(veiculo);
            
        }

        store.sync();
        win.close();
        grid.getView().refresh();
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
