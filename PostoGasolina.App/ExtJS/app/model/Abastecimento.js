Ext.define('PostoGasolina.model.Abastecimento', {
    extend: 'Ext.data.Model',

    fields: [
        { name: 'id'},
        { name: 'litragem'},
        { name: 'valorLitro'},
        { name: 'tipoCombustivel'},
        { name: 'dataAbastecimento' },
        { name: 'cliente.nome', mapping: 'cliente.nome' },
        { name: 'cliente.documento', mapping: 'cliente.documento' },
        { name: 'veiculo.modelo', mapping: 'veiculo.modelo' },
        {
            name: 'total',
            convert: function (value, record) {
                value = record.get('litragem') * record.get('valorLitro');
                return value.toFixed(2) ;
            }   
        }
    ]
});