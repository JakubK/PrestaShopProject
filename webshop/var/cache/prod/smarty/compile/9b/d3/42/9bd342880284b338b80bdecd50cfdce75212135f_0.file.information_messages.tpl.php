<?php
/* Smarty version 3.1.39, created on 2021-11-02 13:20:21
  from '/var/www/html/admin897rxfwwm/themes/new-theme/template/components/layout/information_messages.tpl' */

/* @var Smarty_Internal_Template $_smarty_tpl */
if ($_smarty_tpl->_decodeProperties($_smarty_tpl, array (
  'version' => '3.1.39',
  'unifunc' => 'content_61812d05842f99_68012837',
  'has_nocache_code' => false,
  'file_dependency' => 
  array (
    '9bd342880284b338b80bdecd50cfdce75212135f' => 
    array (
      0 => '/var/www/html/admin897rxfwwm/themes/new-theme/template/components/layout/information_messages.tpl',
      1 => 1635591657,
      2 => 'file',
    ),
  ),
  'includes' => 
  array (
  ),
),false)) {
function content_61812d05842f99_68012837 (Smarty_Internal_Template $_smarty_tpl) {
if ((isset($_smarty_tpl->tpl_vars['informations']->value)) && count($_smarty_tpl->tpl_vars['informations']->value) && $_smarty_tpl->tpl_vars['informations']->value) {?>
  <div class="bootstrap">
    <div class="alert alert-info">
      <button type="button" class="close" data-dismiss="alert">&times;</button>
      <ul id="infos_block" class="list-unstyled">
        <?php
$_from = $_smarty_tpl->smarty->ext->_foreach->init($_smarty_tpl, $_smarty_tpl->tpl_vars['informations']->value, 'info');
$_smarty_tpl->tpl_vars['info']->do_else = true;
if ($_from !== null) foreach ($_from as $_smarty_tpl->tpl_vars['info']->value) {
$_smarty_tpl->tpl_vars['info']->do_else = false;
?>
          <li><?php echo $_smarty_tpl->tpl_vars['info']->value;?>
</li>
        <?php
}
$_smarty_tpl->smarty->ext->_foreach->restore($_smarty_tpl, 1);?>
      </ul>
    </div>
  </div>
<?php }
}
}
