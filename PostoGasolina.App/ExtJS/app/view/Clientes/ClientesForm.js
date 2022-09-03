Ext.define('PostoGasolina.view.Clientes.ClientesForm', {

    extend: 'Ext.window.Window',
    alias: 'widget.clientesform',

    height: 200,
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
                    fieldLabel: 'Data Cadastro'
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