var groupStore = Ext.create('PostoGasolina.store.Veiculos')

Ext.define('PostoGasolina.view.AbastecimentosForm', {

    extend: 'Ext.window.Window',
    alias: 'widget.abastecimentosform',

    height: 300,
    width: 450,
    layout: 'fit',

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
                    store: 'PostoGasolina.store.Clientes',
                    queryMode: 'local',
                    displayField: 'nome',
                    valueField: 'id',
                    itemId: 'cbcliente',
                    editable: false,
                    listeners: {
                        change: function (combo, value) {
                            console.log(value);
                            groupStore.load({
                                params: {
                                    data: value,
                                    datas: '1234'
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
                    editable: false
                    
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
        }
    ]
    //,

    //dockedItems: [
    //    {
    //        xtype: 'toolbar',
    //        dock: 'top',
    //        items: [
    //            {
    //                xtype: 'button',
    //                text: 'Adicionar'
    //            },
    //            {
    //                xtype: 'button',
    //                text: 'Editar'
    //            },
    //            {
    //                xtype: 'button',
    //                text: 'Excluir'
    //            }
    //        ]
    //    },
    //    {
    //        xtype: 'pagingtoolbar',
    //        store: 'PostoGasolina.store.Abastecimentos',
    //        dock: 'top',
    //        displayInfo: true,
    //        emptyMsg: 'Nenhum registro encontrado'
    //    }
    //]

});