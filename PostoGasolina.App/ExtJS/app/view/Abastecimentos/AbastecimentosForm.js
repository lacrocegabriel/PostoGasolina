var groupStore = Ext.create('PostoGasolina.store.TipoCombustiveis');

Ext.define('PostoGasolina.view.Abastecimentos.AbastecimentosForm', {

    extend: 'Ext.window.Window',
    alias: 'widget.abastecimentosform',

    height: 350,
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
                    xtype: 'datefield',
                    anchor: '100%',
                    name: 'dataAbastecimento',
                    fieldLabel: 'Data Abastecimento',
                    format: 'd/m/Y',
                    submitFormat: 'Y-m-d'
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'Cliente',
                    name: 'clienteid',
                    store: 'PostoGasolina.store.ClientesCombo',
                    queryMode: 'remote',
                    displayField: 'nome',
                    valueField: 'id',
                    itemId: 'cbcliente',
                    pageSize: 30,
                    queryDelay: 1000
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'Veiculo',
                    name:'veiculoid',
                    store: 'PostoGasolina.store.VeiculosCombo',
                    queryMode: 'remote',
                    displayField: 'modelo',
                    valueField: 'id',
                    itemId: 'cbveiculo',
                    pageSize: 30,
                    queryDelay: 1000

                    
                },
                {
                    xtype: 'combobox',
                    fieldLabel: 'Tipo Combustivel',
                    name: 'tipoCombustivelid',
                    store:  'PostoGasolina.store.TipoCombustiveis',
                    queryMode: 'local',
                    displayField: 'descricao',
                    valueField: 'id',
                    itemId: 'cbtipoCombustivel'
                    
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