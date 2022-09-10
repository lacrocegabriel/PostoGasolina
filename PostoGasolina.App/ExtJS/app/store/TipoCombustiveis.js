Ext.define('PostoGasolina.store.TipoCombustiveis', {

    extend: 'Ext.data.Store',

    model: 'PostoGasolina.model.TipoCombustivel',

    data: [
        { id: '0', descricao: 'Gasolina' },
        { id: '1', descricao: 'Etanol' },
        { id: '2', descricao: 'Diesel S10' },
        { id: '3', descricao: 'Diesel S500' },
        { id: '4', descricao: 'Flex' }
        
    ]
    //,
    //listeners: {
    //    beforeload: function (store, operation, eOpts) {

    //        console.log(operation);

    //        var comboc = Ext.ComponentQuery.query('combo#cbveiculo')[0];

    //        /*operation.params.query = comboc.value;*/

    //    }
    //}

});
