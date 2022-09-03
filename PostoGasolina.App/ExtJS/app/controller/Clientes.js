Ext.define('PostoGasolina.controller.Clientes', {
    extend: 'Ext.app.Controller',

    models: [
        'PostoGasolina.model.Cliente'
    ],

    stores: [
        'PostoGasolina.store.Clientes'
        
    ],

    views: [
        'PostoGasolina.view.Home',
        'PostoGasolina.view.HomeTab',
        'PostoGasolina.view.ClientesGrid'
    ],

    init: function (application) {
        this.control({
            "clientesgrid": {
                render: this.onGridRender
            }
        });
    },

    onGridRender: function (grid, eOpts) {
        grid.getStore().load();
    }
//    ,
//    onFormRender: function (combo, eOpts) {
//        combo.getStore().load();
//    },
//    onAddClick: function(btn, e, eOpts) {

//        var win = Ext.create('PostoGasolina.view.AbastecimentosForm');

//        win.setTitle('Adicionar');
        
//    },
//    onBEditClick: function (btn, e, eOpts) {

//        var grid = btn.up('grid');

//        var record = grid.getSelectionModel().getLastSelected();

//        console.log(record);

//        var win = Ext.create('PostoGasolina.view.AbastecimentosForm');

//        win.setTitle('Editar');

//        var form = win.down('form');

//        var comboc = form.down('combo#cbcliente');

//        var combov = form.down('combo#cbveiculo');

//        var combot = form.down('combo#cbtipoCombustivel');

//        form.loadRecord(record);

//        comboc.setValue(record.data.clienteid);

//        combov.setValue(record.data.veiculoid);

//        combot.setValue(record.data.tipoCombustivelid);
//    },
//    onEditClick: function (grid, record, item, index, e, eOpts) {

//        console.log(record);

//        var win = Ext.create('PostoGasolina.view.AbastecimentosForm');

//        win.setTitle('Editar');

//        var form = win.down('form');

//        var comboc = form.down('combo#cbcliente');

//        var combov = form.down('combo#cbveiculo');

//        var combot = form.down('combo#cbtipoCombustivel');

//        form.loadRecord(record);

//        comboc.setValue(record.data.clienteid);
        
//        combov.setValue(record.data.veiculoid);

//        combot.setValue(record.data.tipoCombustivelid);
//    },
//    onCancelClick: function (btn, e, eOpts) {
//        var win = btn.up('window');

//        var form = win.down('form');

//        form.getForm().reset();

//        win.close();
//    },
//    onSaveClick: function (btn, e, eOpts) {

        

//        var win = btn.up('window'),
//            form = win.down('form'),
//            values = form.getValues(),
//            record = form.getRecord(),
//            grid = Ext.ComponentQuery.query('abastecimentosgrid')[0],
//            store = grid.getStore(),
//            toolbar = grid.down('pagingtoolbar');

//        console.log(values);

//        if (record) {

//            record.set(values);

//        } else {
//            var abastecimento = Ext.create('PostoGasolina.model.Abastecimento', {
//                litragem: values.litragem,
//                valorLitro: values.valorLitro,
//                tipoCombustivel: values.tipoCombustivel,
//                clienteid: values.clienteid,
//                veiculoid: values.veiculoid,
//                tipoCombustivelid: values.tipoCombustivelid,
//                dataAbastecimento: values.dataAbastecimento
//            });

//            store.add(abastecimento);
//            toolbar.doRefresh();
//        }

//        store.sync();
//        win.close();
//        toolbar.doRefresh();
//    },
//    onDeleteClick: function (btn, e, eOpts) {

//        var grid = btn.up('grid');

//        var record = grid.getSelectionModel().getLastSelected();
        
//        var store = grid.getStore();

//        store.remove(record);

//        store.sync();
//    }
});
