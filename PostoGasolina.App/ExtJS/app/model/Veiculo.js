Ext.define('PostoGasolina.model.Veiculo', {
    extend: 'Ext.data.Model',

    fields: [
        { name: 'id' },
        { name: 'marca', type: 'string' },
        { name: 'modelo', type: 'string' },
        { name: 'ano', type: 'string' },
        { name: 'placa', type: 'string' },
        { name: 'tipoCombustivel', type: 'int'},
        { name: 'ativo', type: 'bool' },
        { name: 'cliente.nome', mapping: 'cliente.nome' },
        { name: 'cliente.documento', mapping: 'cliente.documento' }
    ]

});