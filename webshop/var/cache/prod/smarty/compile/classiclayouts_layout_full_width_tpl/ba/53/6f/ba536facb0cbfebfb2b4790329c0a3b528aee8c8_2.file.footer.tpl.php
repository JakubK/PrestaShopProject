<?php
/* Smarty version 3.1.39, created on 2021-10-31 11:02:00
  from '/var/www/html/themes/classic/templates/checkout/_partials/footer.tpl' */

/* @var Smarty_Internal_Template $_smarty_tpl */
if ($_smarty_tpl->_decodeProperties($_smarty_tpl, array (
  'version' => '3.1.39',
  'unifunc' => 'content_617e6998ddb522_44823754',
  'has_nocache_code' => false,
  'file_dependency' => 
  array (
    'ba536facb0cbfebfb2b4790329c0a3b528aee8c8' => 
    array (
      0 => '/var/www/html/themes/classic/templates/checkout/_partials/footer.tpl',
      1 => 1635673466,
      2 => 'file',
    ),
  ),
  'includes' => 
  array (
  ),
),false)) {
function content_617e6998ddb522_44823754 (Smarty_Internal_Template $_smarty_tpl) {
$_smarty_tpl->_loadInheritance();
$_smarty_tpl->inheritance->init($_smarty_tpl, false);
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_1779606132617e6998dda752_69849971', 'footer');
?>

<?php }
/* {block 'footer'} */
class Block_1779606132617e6998dda752_69849971 extends Smarty_Internal_Block
{
public $subBlocks = array (
  'footer' => 
  array (
    0 => 'Block_1779606132617e6998dda752_69849971',
  ),
);
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
?>

<div class="text-sm-center">
  <?php echo call_user_func_array( $_smarty_tpl->smarty->registered_plugins[Smarty::PLUGIN_FUNCTION]['l'][0], array( array('s'=>'%copyright% %year% - Ecommerce software by %prestashop%','sprintf'=>array('%prestashop%'=>'PrestaShop™','%year%'=>date('Y'),'%copyright%'=>'©'),'d'=>'Shop.Theme.Global'),$_smarty_tpl ) );?>

</div>
<?php
}
}
/* {/block 'footer'} */
}
