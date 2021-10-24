<?php
/* Smarty version 3.1.39, created on 2021-10-24 20:02:04
  from '/bitnami/prestashop/administration/themes/default/template/controllers/stats/calendar.tpl' */

/* @var Smarty_Internal_Template $_smarty_tpl */
if ($_smarty_tpl->_decodeProperties($_smarty_tpl, array (
  'version' => '3.1.39',
  'unifunc' => 'content_61759f9c789105_44156773',
  'has_nocache_code' => false,
  'file_dependency' => 
  array (
    'b2d87a3511182aa0134c47a5f2be7c74ee38e273' => 
    array (
      0 => '/bitnami/prestashop/administration/themes/default/template/controllers/stats/calendar.tpl',
      1 => 1635096659,
      2 => 'file',
    ),
  ),
  'includes' => 
  array (
    'file:../../form_date_range_picker.tpl' => 1,
  ),
),false)) {
function content_61759f9c789105_44156773 (Smarty_Internal_Template $_smarty_tpl) {
?>
<div id="statsContainer" class="col-md-9">
	<?php $_smarty_tpl->_subTemplateRender("file:../../form_date_range_picker.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, $_smarty_tpl->cache_lifetime, array(), 0, false);
}
}
