﻿Ext.define('PostoGasolina.model.Cliente', {
    extend: 'Ext.data.Model',

    fields: [
        {name:'id', type: 'guid'},
        {name:'nome', type: 'string'},
        {name: 'documento', type: 'string'},
        {name:'dataCadastro', type: 'datetime'},
        {name:'ativo', type: 'bool'}
    ]

});