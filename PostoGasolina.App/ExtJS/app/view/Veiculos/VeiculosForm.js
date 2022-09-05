Ext.define('PostoGasolina.view.Veiculos.VeiculosForm', {

    extend: 'Ext.window.Window',
    alias: 'widget.veiculosform',

    height: 330,
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
                    queryMode: 'remote',
                    displayField: 'nome',
                    valueField: 'id',
                    itemId: 'cbcliente',
                    pageSize: 30,
                    queryDelay: 1000
                },
                {
                    xtype: 'textfield',
                    name: 'modelo',
                    fieldLabel: 'Modelo'
                },
                {
                    xtype: 'textfield',
                    name: 'ano',
                    fieldLabel: 'Ano'
                },
                {
                    xtype: 'textfield',
                    name: 'marca',
                    fieldLabel: 'Marca'
                },
                {
                    xtype: 'textfield',
                    name: 'placa',
                    fieldLabel: 'Placa'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'Tipo Combustivel',
                    name: 'tipoCombustivelid',
                    store: 'PostoGasolina.store.TipoCombustiveis',
                    queryMode: 'local',
                    displayField: 'descricao',
                    valueField: 'id',
                    editable: false,
                    itemId: 'cbtipoCombustivel'

                },
                {
                    xtype: 'fieldcontainer',
                    fieldLabel: 'Ativo',
                    defaultType: 'checkboxfield',
                    items: [{
                        xtype: 'checkboxfield',
                        name: 'ativo',
                        inputValue: '1',
                        checked: true,
                        itemId: 'chbativo'
                    }
                   ]
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
                    itemId: 'save',
                    iconCls: 'icon-save'
                },
                {
                    xtype: 'button',
                    text: 'Cancelar',
                    itemId: 'cancel',
                    iconCls: 'icon-reset'
                }
            ]
        }
    ]
});