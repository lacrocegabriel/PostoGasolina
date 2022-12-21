Ext.define('PostoGasolina.view.Abastecimentos.AbastecimentosGrid', {

    extend: 'Ext.grid.Panel',
    alias: 'widget.abastecimentosgrid',

    store: 'PostoGasolina.store.Abastecimentos',

    layout: 'fit',

    columns: [
        {
            text: 'Id',
            dataIndex: 'id',
            hidden: true
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
            text: 'Veiculo',
            dataIndex: 'veiculo_modelo',
            flex: 1
        },
        {
            text: 'Litragem',
            dataIndex: 'litragem',
            flex: 1
        },
        {
            text: 'Valor Litro',
            dataIndex: 'valorLitro'
        },
        {
            text: 'Tipo Combustivel',
            dataIndex: 'tipocombustivel_descricao'
        },
        {
            text: 'Data Abastecimento',
            dataIndex: 'dataAbastecimento',
            xtype: 'datecolumn',
            renderer: Ext.util.Format.dateRenderer('d/m/Y')
        },
        {
            text: 'Valor Total',
            dataIndex: 'total'
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
            store: 'PostoGasolina.store.Abastecimentos',
            dock: 'bottom',
            displayInfo: true,
            beforePageText: 'Página',
            afterPageText: 'de {0}',
            emptyMsg: 'Nenhum registro encontrado',
            displayMsg: 'Exibindo: {1} de {2} Abastecimentos'
        }
    ]

});