Ext.define('PostoGasolina.model.Veiculo', {
    extend: 'Ext.data.Model',

    fields: [
        { name: 'id' },
        { name: 'marca', type: 'string' },
        { name: 'modelo', type: 'string' },
        { name: 'ano', type: 'string' },
        { name: 'placa', type: 'string' },
        { name: 'ativo', type: 'bool' },
        { name: 'clienteid', mapping: 'cliente.nome', type: 'guid' },
        { name: 'cliente_nome', mapping: 'cliente.nome', type: 'string' },
        { name: 'cliente_documento', mapping: 'cliente.documento', type: 'string' },
        { name: 'tipoCombustivelid', type: 'int' },
        { name: 'tipoCombustivel_descricao', mapping: 'tipoCombustivel.descricao', type: 'string' }
    ]

});