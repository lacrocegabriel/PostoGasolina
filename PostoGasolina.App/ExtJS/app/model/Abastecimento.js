Ext.define('PostoGasolina.model.Abastecimento', {
    extend: 'Ext.data.Model',

    fields: [
        { name: 'id'},
        { name: 'litragem'},
        { name: 'valorLitro'},
        { name: 'tipoCombustivel'},
        { name: 'dataAbastecimento'}
    ]

});