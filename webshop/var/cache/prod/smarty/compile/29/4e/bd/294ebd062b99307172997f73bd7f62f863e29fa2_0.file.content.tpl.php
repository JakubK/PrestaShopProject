<?php
/* Smarty version 3.1.39, created on 2021-10-31 15:57:21
  from '/var/www/html/admin897rxfwwm/themes/default/template/content.tpl' */

/* @var Smarty_Internal_Template $_smarty_tpl */
if ($_smarty_tpl->_decodeProperties($_smarty_tpl, array (
  'version' => '3.1.39',
  'unifunc' => 'content_617eaed1a42f50_12472895',
  'has_nocache_code' => false,
  'file_dependency' => 
  array (
    '294ebd062b99307172997f73bd7f62f863e29fa2' => 
    array (
      0 => '/var/www/html/admin897rxfwwm/themes/default/template/content.tpl',
      1 => 1635673464,
      2 => 'file',
    ),
  ),
  'includes' => 
  array (
  ),
),false)) {
function content_617eaed1a42f50_12472895 (Smarty_Internal_Template $_smarty_tpl) {
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
