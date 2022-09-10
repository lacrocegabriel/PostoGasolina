Ext.define('PostoGasolina.view.Veiculos.VeiculosGrid', {

    extend: 'Ext.grid.Panel',
    alias: 'widget.veiculosgrid',

    store: 'PostoGasolina.store.Veiculos',
    columns: [
        {
            text: 'Id',
            dataIndex: 'id',
            hidden: true
        },
        {
            text: 'Modelo',
            dataIndex: 'modelo',
            flex: 1
        },
        {
            text: 'Cliente',
            dataIndex: 'cliente_nome',
            flex: 1
        },
        {
            text: 'Documento',
            dataIndex: 'cliente_documento',
            flex: 1
        },
        {
            text: 'Marca',
            dataIndex: 'marca'
        },
        {
            text: 'Ano',
            dataIndex: 'ano'
        },
        {
            text: 'Placa',
            dataIndex: 'placa'
        },
        {
            text: 'Tipo Combustivel',
            dataIndex: 'tipoCombustivel_descricao'
        },
        {
            text: 'Ativo',
            dataIndex: 'ativo',
            xtype: 'booleancolumn',
            trueText: 'Sim',
            falseText: 'Não'
        }
    ],

    dockedItems: [
        {
            xtype: 'toolbar',
            dock: 'top',
            items: [
                {
                    xtype: 'button',
                    text: 'Adicionar',
                    itemId: 'add',
                    iconCls: 'icon-add'
                },
                {
                    xtype: 'button',
                    text: 'Editar',
                    itemId: 'edit',
                    iconCls: 'icon-edit'
                },
                {
                    xtype: 'button',
                    text: 'Excluir',
                    itemId: 'delete',
                    iconCls: 'icon-delete'
                }
            ]
        },
        {
            xtype: 'pagingtoolbar',
            store: 'PostoGasolina.store.Veiculos',
            dock: 'bottom',
            displayInfo: true,
            beforePageText: 'Página',
            afterPageText: 'de {0}',
            emptyMsg: 'Nenhum registro encontrado',
            displayMsg: 'Exibindo: {1} de {2} Veículos'
        }
    ]

});