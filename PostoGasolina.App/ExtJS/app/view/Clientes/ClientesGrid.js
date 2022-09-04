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
            dataIndex: 'documento'
        },
        {
            text: 'Data Cadastro',
            dataIndex: 'dataCadastro'
        },
        {
            text: 'Ativo',
            dataIndex: 'ativo'
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
                    itemId: 'add'
                },
                {
                    xtype: 'button',
                    text: 'Editar',
                    itemId: 'edit'
                },
                {
                    xtype: 'button',
                    text: 'Excluir',
                    itemId: 'delete'
                }
            ]
        },
        {
            xtype: 'pagingtoolbar',
            store: 'PostoGasolina.store.Clientes',
            dock: 'bottom',
            displayInfo: true,
            emptyMsg: 'Nenhum registro encontrado'
        }
    ]

});