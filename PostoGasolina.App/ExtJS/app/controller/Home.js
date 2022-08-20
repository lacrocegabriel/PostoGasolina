Ext.define('PostoGasolina.controller.Home', {
    extend: 'Ext.app.Controller',

    models: [
        'PostoGasolina.model.Combustivel',
        'PostoGasolina.model.Cliente',
        'PostoGasolina.model.Abastecimento',
        'PostoGasolina.model.Veiculo'
    ],

    stores: [
        'PostoGasolina.store.Combustiveis',
        'PostoGasolina.store.Clientes',
        'PostoGasolina.store.Abastecimentos',
        'PostoGasolina.store.Veiculos'
    ],

    views: [
        'PostoGasolina.view.Home',
        'PostoGasolina.view.HomeTab',
        'PostoGasolina.view.CombustiveisGrid',
        'PostoGasolina.view.ClientesGrid',
        'PostoGasolina.view.AbastecimentosGrid',
        'PostoGasolina.view.VeiculosGrid'
        
    ],

    init: function (application) {
        this.control({
            "menutree": {
                itemclick: this.onAddClick
            },
             "combustiveisgrid": {
                 render: this.onGridRender
            },
            "clientesgrid": {
                render: this.onGridRender
            },
            "abastecimentosgrid": {
                render: this.onGridRender
            },
            "veiculosgrid": {
                render: this.onGridRender
            },
            "tabcombustiveis": {
                close: this.onTabRender
            }
            //"contatosgrid button#delete": {
            //    click: this.onDeleteClick
            //},
            //"contatosform button#save": {
            //    click: this.onSaveClick
            //}

        });
    },

    onGridRender: function (grid, eOpts) {
        grid.getStore().load();
    },
    onAddClick: function (tree,record, item, index, e, eOpts) {

        var id = record.getId();

        if (id == 'c1')
        {
            var tab = Ext.create('PostoGasolina.view.CombustiveisTab');

            var obj = tab.queryById('t1')

            obj.doAutoRender();
        }
        
    },
    onTabRender: function (tab, eOpts) {
        tab.setVisible(false);
    }
});
