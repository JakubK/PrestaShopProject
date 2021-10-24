<?php
/* Smarty version 3.1.39, created on 2021-10-24 20:02:01
  from '/bitnami/prestashop/administration/themes/default/template/content.tpl' */

/* @var Smarty_Internal_Template $_smarty_tpl */
if ($_smarty_tpl->_decodeProperties($_smarty_tpl, array (
  'version' => '3.1.39',
  'unifunc' => 'content_61759f998a0647_03887186',
  'has_nocache_code' => false,
  'file_dependency' => 
  array (
    'c14656886a2fe5c6804c40fd1f488ce16f55f51e' => 
    array (
      0 => '/bitnami/prestashop/administration/themes/default/template/content.tpl',
      1 => 1635096659,
      2 => 'file',
    ),
  ),
  'includes' => 
  array (
  ),
),false)) {
function content_61759f998a0647_03887186 (Smarty_Internal_Template $_smarty_tpl) {
?><div id="ajax_confirmation" class="alert alert-success hide"></div>
<div id="ajaxBox" style="display:none"></div>

<div class="row">
	<div class="col-lg-12">
		<?php if ((isset($_smarty_tpl->tpl_vars['content']->value))) {?>
			<?php echo $_smarty_tpl->tpl_vars['content']->value;?>

		<?php }?>
	</div>
</div>
<?php }
}
