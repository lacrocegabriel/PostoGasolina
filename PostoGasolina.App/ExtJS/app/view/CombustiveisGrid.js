Ext.define('PostoGasolina.view.CombustiveisGrid', {

    extend: 'Ext.grid.Panel',
    alias: 'widget.combustiveisgrid',

    store: 'PostoGasolina.store.Combustiveis',
    columns: [
        {
            text: 'Id',
            dataIndex: 'id',
            hidden: true
        },
        {
            text: 'Tipo Combustivel',
            dataIndex: 'tipoCombustivel',
            flex: 1
        },
        {
            text: 'Valor',
            dataIndex: 'valor'
        }
    ]

});