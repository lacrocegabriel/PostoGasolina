Ext.define('PostoGasolina.view.AbastecimentosGrid', {

    extend: 'Ext.grid.Panel',
    alias: 'widget.abastecimentosgrid',

    store: 'PostoGasolina.store.Abastecimentos',
    columns: [
        {
            text: 'Id',
            dataIndex: 'id'
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
        }
    ]

});