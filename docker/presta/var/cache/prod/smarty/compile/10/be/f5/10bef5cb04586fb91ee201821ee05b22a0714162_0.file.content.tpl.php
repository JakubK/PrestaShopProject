<?php
/* Smarty version 3.1.39, created on 2021-10-24 20:06:25
  from '/bitnami/prestashop/administration/themes/new-theme/template/content.tpl' */

/* @var Smarty_Internal_Template $_smarty_tpl */
if ($_smarty_tpl->_decodeProperties($_smarty_tpl, array (
  'version' => '3.1.39',
  'unifunc' => 'content_6175a0a16ebe30_06678656',
  'has_nocache_code' => false,
  'file_dependency' => 
  array (
    '10bef5cb04586fb91ee201821ee05b22a0714162' => 
    array (
      0 => '/bitnami/prestashop/administration/themes/new-theme/template/content.tpl',
      1 => 1635096660,
      2 => 'file',
    ),
  ),
  'includes' => 
  array (
  ),
),false)) {
function content_6175a0a16ebe30_06678656 (Smarty_Internal_Template $_smarty_tpl) {
?>
<div id="ajax_confirmation" class="alert alert-success" style="display: none;"></div>


<?php if ((isset($_smarty_tpl->tpl_vars['content']->value))) {?>
  <?php echo $_smarty_tpl->tpl_vars['content']->value;?>

<?php }
}
}
