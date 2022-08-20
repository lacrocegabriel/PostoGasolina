Ext.define('PostoGasolina.view.ClientesGrid', {

    extend: 'Ext.grid.Panel',
    alias: 'widget.clientesgrid',

    store: 'PostoGasolina.store.Clientes',
    columns: [
        {
            text: 'Id',
            dataIndex: 'id'
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
    ]

});