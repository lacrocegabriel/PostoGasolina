Ext.define('PostoGasolina.model.Veiculo', {
    extend: 'Ext.data.Model',

    fields: [
        { name: 'id'},
        { name: 'marca'},
        { name: 'modelo'},
        { name: 'ano'},
        { name: 'placa'},
        { name: 'tipoCombustivel'},
        { name: 'ativo'}
    ]

});