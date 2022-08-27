Ext.define('PostoGasolina.model.Veiculo', {
    extend: 'Ext.data.Model',

    fields: [
        { name: 'id', type: 'guid' },
        { name: 'marca', type: 'string' },
        { name: 'modelo', type: 'string' },
        { name: 'ano', type: 'string' },
        { name: 'placa', type: 'string' },
        { name: 'tipoCombustivel', type: 'int'},
        { name: 'ativo', type: 'bool' }
    ]

});