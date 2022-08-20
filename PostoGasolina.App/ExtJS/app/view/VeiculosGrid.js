Ext.define('PostoGasolina.view.VeiculosGrid', {

    extend: 'Ext.grid.Panel',
    alias: 'widget.veiculosgrid',

    store: 'PostoGasolina.store.Veiculos',
    columns: [
        {
            text: 'Id',
            dataIndex: 'id'
        },
        {
            text: 'Marca',
            dataIndex: 'marca',
            flex: 1
        },
        {
            text: 'Modelo',
            dataIndex: 'modelo'
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
            dataIndex: 'tipoCombustivel'
        },
        {
            text: 'Ativo',
            dataIndex: 'ativo'
        }
    ]

});