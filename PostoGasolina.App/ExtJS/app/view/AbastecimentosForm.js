var groupStore = Ext.create('PostoGasolina.store.Veiculos');

Ext.define('PostoGasolina.view.AbastecimentosForm', {

    extend: 'Ext.window.Window',
    alias: 'widget.abastecimentosform',

    height: 275,
    width: 450,
    layout: 'fit',
    autoShow: true,

    items: [
        {
            xtype: 'form',
            bodyPadding: 10,
            defaults: {
                anchor: '100%'
            },
            items: [
                {
                    xtype: 'combobox',
                    fieldLabel: 'Cliente',
                    name: 'clienteid',
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
                    name:'veiculoid',
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
                },
                {
                    xtype: 'datefield',
                    anchor: '100%',
                    name: 'dataAbastecimento',
                    fieldLabel: 'Data Abastecimento'
                }
            ]
        }
    ],
    dockedItems: [
        {
            xtype: 'toolbar',
            dock: 'bottom',
            layout: {
                type: 'hbox',
                pack: 'end'
            },
            items: [
                {
                    xtype: 'button',
                    text: 'Salvar',
                    itemId:'save'
                },
                {
                    xtype: 'button',
                    text: 'Cancelar',
                    itemId: 'cancel'
                }
            ]
        }
    ]
});