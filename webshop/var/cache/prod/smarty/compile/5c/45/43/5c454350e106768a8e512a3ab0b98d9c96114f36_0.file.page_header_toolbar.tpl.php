<?php
/* Smarty version 3.1.39, created on 2021-11-02 13:11:30
  from '/var/www/html/admin897rxfwwm/themes/new-theme/template/controllers/orders/page_header_toolbar.tpl' */

/* @var Smarty_Internal_Template $_smarty_tpl */
if ($_smarty_tpl->_decodeProperties($_smarty_tpl, array (
  'version' => '3.1.39',
  'unifunc' => 'content_61812af2798db3_17530115',
  'has_nocache_code' => false,
  'file_dependency' => 
  array (
    '5c454350e106768a8e512a3ab0b98d9c96114f36' => 
    array (
      0 => '/var/www/html/admin897rxfwwm/themes/new-theme/template/controllers/orders/page_header_toolbar.tpl',
      1 => 1635591657,
      2 => 'file',
    ),
  ),
  'includes' => 
  array (
  ),
),false)) {
function content_61812af2798db3_17530115 (Smarty_Internal_Template $_smarty_tpl) {
$_smarty_tpl->_loadInheritance();
$_smarty_tpl->inheritance->init($_smarty_tpl, true);
?>


<?php 
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_164473808161812af2795951_79400162', 'pageTitle');
?>

<?php $_smarty_tpl->inheritance->endChild($_smarty_tpl, 'page_header_toolbar.tpl');
}
/* {block 'pageTitle'} */
class Block_164473808161812af2795951_79400162 extends Smarty_Internal_Block
{
public $subBlocks = array (
  'pageTitle' => 
  array (
    0 => 'Block_164473808161812af2795951_79400162',
  ),
);
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
?>

  <?php if (!(isset($_smarty_tpl->tpl_vars['use_regular_h1_structure']->value))) {?>
    <?php $_smarty_tpl->_assignInScope('use_regular_h1_structure', true);?>
  <?php }?>

  <?php if ($_smarty_tpl->tpl_vars['use_regular_h1_structure']->value) {?>
    <h1 class="title">
      <?php if (is_array($_smarty_tpl->tpl_vars['title']->value)) {
echo call_user_func_array($_smarty_tpl->registered_plugins[ 'modifier' ][ 'escape' ][ 0 ], array( end($_smarty_tpl->tpl_vars['title']->value) ));
} else {
echo call_user_func_array($_smarty_tpl->registered_plugins[ 'modifier' ][ 'escape' ][ 0 ], array( $_smarty_tpl->tpl_vars['title']->value ));
}?>
    </h1>
  <?php } else { ?>
    <?php echo $_smarty_tpl->tpl_vars['title']->value;?>

  <?php }
}
}
/* {/block 'pageTitle'} */
}
