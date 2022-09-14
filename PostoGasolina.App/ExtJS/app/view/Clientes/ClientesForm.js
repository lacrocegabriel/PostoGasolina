Ext.define('PostoGasolina.view.Clientes.ClientesForm', {

    extend: 'Ext.window.Window',
    alias: 'widget.clientesform',

    height: 215,
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
                    xtype: 'textfield',
                    name: 'nome',
                    fieldLabel: 'Nome'
                },
                {
                    xtype: 'textfield',
                    name: 'documento',
                    fieldLabel: 'Documento'
                },
                {
                    xtype: 'datefield',
                    anchor: '100%',
                    name: 'dataCadastro',
                    fieldLabel: 'Data Cadastro',
                    format: 'd/m/Y',
                    submitFormat: 'Y-m-d'
                },
                {
                    xtype: 'checkboxfield',
                    name: 'ativo',
                    fieldLabel: 'Ativo',
                    inputValue: 'true',
                    uncheckedValue: 'false',
                    checked: true,
                    itemId: 'chbativo'
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