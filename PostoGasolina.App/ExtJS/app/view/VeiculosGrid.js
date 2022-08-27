Ext.define('PostoGasolina.view.VeiculosGrid', {

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
            dataIndex: 'tipoCombustivel'
        },
        {
            text: 'Ativo',
            dataIndex: 'ativo'
        }
    ]

});