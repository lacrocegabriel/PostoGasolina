Ext.define('PostoGasolina.controller.Abastecimentos', {
    extend: 'Ext.app.Controller',

    models: [
        'PostoGasolina.model.Abastecimento'
    ],

    stores: [
        'PostoGasolina.store.Abastecimentos',
        'PostoGasolina.store.Clientes',
        'PostoGasolina.store.Veiculos',
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
                render: this.onFormRender
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
    onFormRender: function (combo, eOpts) {
        combo.getStore().load();
    },
    onAddClick: function(btn, e, eOpts) {

        var win = Ext.create('PostoGasolina.view.Abastecimentos.AbastecimentosForm');

        win.setTitle('Adicionar');
        
    },
    onBEditClick: function (btn, e, eOpts) {

        var grid = btn.up('grid');

        var record = grid.getSelectionModel().getLastSelected();

        console.log(record);

        var win = Ext.create('PostoGasolina.view.Abastecimentos.AbastecimentosForm');

        win.setTitle('Editar');

        var form = win.down('form');

        var comboc = form.down('combo#cbcliente');

        var combov = form.down('combo#cbveiculo');

        var combot = form.down('combo#cbtipoCombustivel');

        form.loadRecord(record);

        comboc.setValue(record.data.clienteid);

        combov.setValue(record.data.veiculoid);

        combot.setValue(record.data.tipoCombustivelid);
    },
    onEditClick: function (grid, record, item, index, e, eOpts) {

        var win = Ext.create('PostoGasolina.view.Abastecimentos.AbastecimentosForm');

        win.setTitle('Editar');

        var form = win.down('form');

        var comboc = form.down('combo#cbcliente');

        var combov = form.down('combo#cbveiculo');

        var combot = form.down('combo#cbtipoCombustivel');

        form.loadRecord(record);

        comboc.setValue(record.data.clienteid);
        
        combov.setValue(record.data.veiculoid);

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
    }
});
