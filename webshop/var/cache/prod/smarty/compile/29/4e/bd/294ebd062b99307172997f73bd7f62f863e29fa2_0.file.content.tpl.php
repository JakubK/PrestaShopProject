<?php
/* Smarty version 3.1.39, created on 2021-11-02 13:24:49
  from '/var/www/html/admin897rxfwwm/themes/default/template/content.tpl' */

/* @var Smarty_Internal_Template $_smarty_tpl */
if ($_smarty_tpl->_decodeProperties($_smarty_tpl, array (
  'version' => '3.1.39',
  'unifunc' => 'content_61812e117b8ef3_36303075',
  'has_nocache_code' => false,
  'file_dependency' => 
  array (
    '294ebd062b99307172997f73bd7f62f863e29fa2' => 
    array (
      0 => '/var/www/html/admin897rxfwwm/themes/default/template/content.tpl',
      1 => 1635591657,
      2 => 'file',
    ),
  ),
  'includes' => 
  array (
  ),
),false)) {
function content_61812e117b8ef3_36303075 (Smarty_Internal_Template $_smarty_tpl) {
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
