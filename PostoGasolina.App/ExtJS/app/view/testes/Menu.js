Ext.define('PostoGasolina.view.Menu', {
    extend: 'Ext.tree.Panel',

    alias: 'widget.menutree',
    title: 'Simple Tree',
    width: 200,
    height: 150,
    store: 'PostoGasolina.store.Menu',
    rootVisible: false
});