Ext.define('PostoGasolina.view.Clientes.ClientesGrid', {

    extend: 'Ext.grid.Panel',
    alias: 'widget.clientesgrid',

    store: 'PostoGasolina.store.Clientes',

    columns: [
        {
            text: 'Id',
            dataIndex: 'id',
            hidden: true
        },
        {
            text: 'Nome',
            dataIndex: 'nome',
            flex: 1
        },
        {
            text: 'Documento',
            dataIndex: 'documento',
            
        },
        {
            text: 'Data Cadastro',
            dataIndex: 'dataCadastro',
            xtype: 'datecolumn',
            dateFormat: 'd/m/Y',
            format: 'd/m/Y'
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
            store: 'PostoGasolina.store.Clientes',
            dock: 'bottom',
            displayInfo: true,
            beforePageText: 'Página',
            afterPageText: 'de {0}',
            emptyMsg: 'Nenhum registro encontrado',
            displayMsg: 'Exibindo: {1} de {2} Clientes'
        }
    ]

});