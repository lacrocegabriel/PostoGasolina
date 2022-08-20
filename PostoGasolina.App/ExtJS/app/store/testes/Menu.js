Ext.define('PostoGasolina.store.Menu', {
    extend: 'Ext.data.TreeStore',

    root: {
        expanded: true,
                
        children: [
            { text: "Combustiveis", id: 'c1', leaf: true },
            { text: "Teste", id: 'c2', leaf: true }
        ]
    }
});