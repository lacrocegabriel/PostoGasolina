Ext.define('PostoGasolina.model.Abastecimento', {
    extend: 'Ext.data.Model',

    fields: [
        { name: 'id', type: 'guid' },
        { name: 'litragem', type: 'decimal' },
        { name: 'valorLitro', type: 'decimal'},
        { name: 'tipoCombustivel', type: 'int' },
        { name: 'dataAbastecimento', type: 'date' },
        { name: 'clienteid', mapping: 'cliente.id', type: 'guid' },
        { name: 'cliente_nome', mapping: 'cliente.nome', type: 'string' },
        { name: 'cliente_documento', mapping: 'cliente.documento', type: 'string' },
        { name: 'veiculoid', mapping: 'veiculo.id', type: 'guid' },
        { name: 'veiculo_modelo', mapping: 'veiculo.modelo', type: 'string' },
        { name: 'tipoCombustivelid', mapping: 'tipoCombustivel.id', type: 'int' }, 
        { name: 'tipocombustivel_descricao', mapping: 'tipoCombustivel.descricao', type: 'string' }, 
        { name: 'tipoCombustivel', mapping: function (o) { return o.tipoCombustivel ? o.tipoCombustivel : null; } }, 
        {
            name: 'total',
            convert: function (value, record) {
                value = record.get('litragem') * record.get('valorLitro');
                return value.toFixed(2) ;
            }, type: 'decimal'   
        }
    ],
    associations: [
        { type: 'hasOne', model: 'Cliente' },
        { type: 'hasOne', model: 'Veiculo' },
        { type: 'hasOne', model: 'TipoCombustivel' }
    ]
});