Ext.define('PostoGasolina.controller.Abastecimentos', {
    extend: 'Ext.app.Controller',

    models: [
        'PostoGasolina.model.Abastecimento'
    ],

    stores: [
        'PostoGasolina.store.Abastecimentos',
        'PostoGasolina.store.Clientes',
        'PostoGasolina.store.ClientesCombo',
        'PostoGasolina.store.Veiculos',
        'PostoGasolina.store.VeiculosCombo',
        'PostoGasolina.store.TipoCombustiveis'
    ],

    views: [
        'PostoGasolina.view.Home.Home',
        'PostoGasolina.view.Home.HomeTab',
        'PostoGasolina.view.Abastecimentos.AbastecimentosGrid',
        'PostoGasolina.view.Abastecimentos.AbastecimentosForm'
    ],

    init: function (application) {
        this.control({
            "abastecimentosgrid": {
                render: this.onGridRender
                ,itemdblclick: this.onEditClick
            },
            "abastecimentosgrid button#add": {
                click: this.onAddClick
            },
            "abastecimentosgrid button#edit": {
                click: this.onBEditClick
            },
            "abastecimentosgrid button#delete": {
                click: this.onDeleteClick
            },
            "abastecimentosform combobox#cbcliente": {
                select: this.onClearComboVeiculo
            },
            "abastecimentosform combobox#cbveiculo": {
                select: this.onClearComboCombustivel
            },
            "abastecimentosform button#cancel": {
                click: this.onCancelClick
            },
            "abastecimentosform button#save": {
                click: this.onSaveClick
            }
        });
    },

    onGridRender: function (grid, eOpts) {
        grid.getStore().load();
    },
    onAddClick: function(btn, e, eOpts) {

        var win = Ext.create('PostoGasolina.view.Abastecimentos.AbastecimentosForm');

        win.setTitle('Adicionar');

        var form = win.down('form');

        var combotc = form.down('combo#cbtipoCombustivel');

        combotc.getStore().filter([
            { filterFn: function (tipoCombustivel) { return tipoCombustivel.get("id") < 0; } }
        ]);;
        
    },
    onBEditClick: function (btn, e, eOpts) {

        var grid = btn.up('grid');

        var record = grid.getSelectionModel().getLastSelected();

        var win = Ext.create('PostoGasolina.view.Abastecimentos.AbastecimentosForm');

        win.setTitle('Editar');

        var form = win.down('form');

        var comboc = form.down('combo#cbcliente')

        comboc.getStore().load({
            params: {
                data: record.data.clienteid
            }
        });

        comboc.setValue(record.data.clienteid);

        var combov = form.down('combo#cbveiculo')

        combov.getStore().load({
            params: {
                data: record.data.clienteid
            }
        });

        var combotc = form.down('combo#cbtipoCombustivel');

        combotc.setValue(record.data.tipoCombustivelid);

        form.loadRecord(record);

        if (record.data.tipoCombustivelid == 4) {
            combotc.getStore().filter([
                { filterFn: function (tipoCombustivel) { return tipoCombustivel.get("id") <= 1; } }
            ]);
        }
        else {
            combotc.getStore().filter("id", record.data.tipoCombustivelid);
        }
    },
    onEditClick: function (grid, record, item, index, e, eOpts) {

        var win = Ext.create('PostoGasolina.view.Abastecimentos.AbastecimentosForm');

        win.setTitle('Editar');

        var form = win.down('form');

        form.down('combo#cbcliente').setValue(record.data.clienteid);

        form.down('combo#cbcliente').getStore().load({
            params: {
                data: record.data.clienteid
            }
        });
               

        form.down('combo#cbveiculo').getStore().load({
            params: {
                data: record.data.clienteid
            }
        });

        var combotc = form.down('combo#cbtipoCombustivel')

        combotc.setValue(record.data.tipoCombustivelid);

        form.loadRecord(record);

        if (record.data.tipoCombustivelid == 4) {
            combotc.getStore().filter([
                { filterFn: function (tipoCombustivel) { return tipoCombustivel.get("id") <= 1; } }
            ]);
        }
        else {
            combotc.getStore().filter("id", record.data.tipoCombustivelid);
        }

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
            grid = Ext.ComponentQuery.query('abastecimentosgrid')[0],
            store = grid.getStore(),
            toolbar = grid.down('pagingtoolbar');
            
        if (record) {

            record.set(values);

        } else {
            var abastecimento = Ext.create('PostoGasolina.model.Abastecimento', {
                litragem: values.litragem,
                valorLitro: values.valorLitro,
                tipoCombustivel: values.tipoCombustivel,
                clienteid: values.clienteid,
                veiculoid: values.veiculoid,
                tipoCombustivelid: values.tipoCombustivelid,
                dataAbastecimento: values.dataAbastecimento
            });

            store.add(abastecimento);

        }

        store.sync();
        win.close();
    },
    onDeleteClick: function (btn, e, eOpts) {

        var grid = btn.up('grid');

        var record = grid.getSelectionModel().getLastSelected();
        
        var store = grid.getStore();

        store.remove(record);

        store.sync();
    },
    onClearComboVeiculo: function (combo, record, eOpts) {

        var form = combo.up('form');

        var combov = form.down('combo#cbveiculo')

        var combotc = form.down('combo#cbtipoCombustivel')

        combotc.clearValue();

        combotc.getStore().filter([
            { filterFn: function (tipoCombustivel) { return tipoCombustivel.get("id") < 0; } }
        ]);

        combov.clearValue();

        combov.getStore().load({
            params: {
                data: record[0].data.clienteid
            }
        });
    },
    onClearComboCombustivel: function (combo, record, eOpts) {

        var form = combo.up('form');

        var combotc = form.down('combo#cbtipoCombustivel')

        combotc.clearValue();

        combotc.getStore().clearFilter();

        if (record[0].raw.tipoCombustivelId == 4) {
            combotc.getStore().filter([
                { filterFn: function (tipoCombustivel) { return tipoCombustivel.get("id") <= 1; } }
            ]);
        }
        else {
            combotc.getStore().filter("id", record[0].raw.tipoCombustivelId);
        }
        

    }
});
