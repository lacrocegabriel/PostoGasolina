var groupStore = Ext.create('PostoGasolina.store.Veiculos');

Ext.define('PostoGasolina.view.AbastecimentosForm', {

    extend: 'Ext.form.Panel',
    alias: 'widget.abastecimentosform',
    autoShow: true,
    bodyPadding: 10,
    defaults: {
        anchor: '100%'
    },
    items: [
        {
            xtype: 'combobox',
            fieldLabel: 'Cliente',
            store: 'PostoGasolina.store.Clientes',
            queryMode: 'local',
            displayField: 'nome',
            valueField: 'id',
            itemId: 'cbcliente',
            editable: false,
            listeners: {
                change: function (combo, value) {
                    groupStore.load({
                        params: {
                            data: value
                        }
                    });
                }
            }
        },
        {
            xtype: 'combobox',
            fieldLabel: 'Veiculo',
            store: groupStore,
            queryMode: 'local',
            displayField: 'modelo',
            valueField: 'id',
            editable: false,
            itemId: 'cbveiculo'

        },
        {
            xtype: 'textfield',
            name: 'litragem',
            fieldLabel: 'Litragem'
        },
        {
            xtype: 'textfield',
            name: 'valorLitro',
            fieldLabel: 'Valor Litro'
        },
        {
            xtype: 'textfield',
            name: 'tipoCombustivel',
            fieldLabel: 'Tipo Combustivel'
        }
    ]

});