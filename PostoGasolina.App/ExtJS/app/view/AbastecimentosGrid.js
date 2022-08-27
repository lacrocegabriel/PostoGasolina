Ext.define('PostoGasolina.view.AbastecimentosGrid', {

    extend: 'Ext.grid.Panel',
    alias: 'widget.abastecimentosgrid',

    store: 'PostoGasolina.store.Abastecimentos',

    columns: [
        {
            text: 'Id',
            dataIndex: 'id',
            hidden: true
        },
        {
            text: 'Cliente',
            dataIndex: 'cliente.nome',
            flex: 1
        },
        {
            text: 'Documento',
            dataIndex: 'cliente.documento',
            flex: 1
        },
        {
            text: 'Veiculo',
            dataIndex: 'veiculo.modelo',
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
            dataIndex: 'tipoCombustivel'
        },
        {
            text: 'Data Abastecimento',
            dataIndex: 'dataAbastecimento'
        },
        {
            text: 'Valor Total',
            dataIndex: 'total'
        }
        
    ]

});