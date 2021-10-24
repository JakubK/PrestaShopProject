<?php
/* Smarty version 3.1.39, created on 2021-10-25 00:06:12
  from '/bitnami/prestashop/themes/classic/templates/page.tpl' */

/* @var Smarty_Internal_Template $_smarty_tpl */
if ($_smarty_tpl->_decodeProperties($_smarty_tpl, array (
  'version' => '3.1.39',
  'unifunc' => 'content_6175d8d44f5100_07221626',
  'has_nocache_code' => false,
  'file_dependency' => 
  array (
    '3030dd9febca2e4f8bdd0e5f94678e5d5c92fe40' => 
    array (
      0 => '/bitnami/prestashop/themes/classic/templates/page.tpl',
      1 => 1635096661,
      2 => 'file',
    ),
  ),
  'includes' => 
  array (
  ),
),false)) {
function content_6175d8d44f5100_07221626 (Smarty_Internal_Template $_smarty_tpl) {
$_smarty_tpl->_loadInheritance();
$_smarty_tpl->inheritance->init($_smarty_tpl, true);
?>


<?php 
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_19837747926175d8d44eb992_10120154', 'content');
?>

<?php $_smarty_tpl->inheritance->endChild($_smarty_tpl, $_smarty_tpl->tpl_vars['layout']->value);
}
/* {block 'page_title'} */
class Block_18442137816175d8d44ec473_35499545 extends Smarty_Internal_Block
{
public $callsChild = 'true';
public $hide = 'true';
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
?>

        <header class="page-header">
          <h1><?php 
$_smarty_tpl->inheritance->callChild($_smarty_tpl, $this);
?>
</h1>
        </header>
      <?php
}
}
/* {/block 'page_title'} */
/* {block 'page_header_container'} */
class Block_4320327106175d8d44ebe70_23653462 extends Smarty_Internal_Block
{
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
?>

      <?php 
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_18442137816175d8d44ec473_35499545', 'page_title', $this->tplIndex);
?>

    <?php
}
}
/* {/block 'page_header_container'} */
/* {block 'page_content_top'} */
class Block_20698966566175d8d44f07f0_59876854 extends Smarty_Internal_Block
{
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
}
}
/* {/block 'page_content_top'} */
/* {block 'page_content'} */
class Block_17107884306175d8d44f14a0_73930847 extends Smarty_Internal_Block
{
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
?>

          <!-- Page content -->
        <?php
}
}
/* {/block 'page_content'} */
/* {block 'page_content_container'} */
class Block_1990671246175d8d44efc52_31765836 extends Smarty_Internal_Block
{
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
?>

      <div id="content" class="page-content card card-block">
        <?php 
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_20698966566175d8d44f07f0_59876854', 'page_content_top', $this->tplIndex);
?>

        <?php 
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_17107884306175d8d44f14a0_73930847', 'page_content', $this->tplIndex);
?>

      </div>
    <?php
}
}
/* {/block 'page_content_container'} */
/* {block 'page_footer'} */
class Block_9391463616175d8d44f3803_53860035 extends Smarty_Internal_Block
{
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
?>

          <!-- Footer content -->
        <?php
}
}
/* {/block 'page_footer'} */
/* {block 'page_footer_container'} */
class Block_13097064916175d8d44f2f55_24006157 extends Smarty_Internal_Block
{
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
?>

      <footer class="page-footer">
        <?php 
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_9391463616175d8d44f3803_53860035', 'page_footer', $this->tplIndex);
?>

      </footer>
    <?php
}
}
/* {/block 'page_footer_container'} */
/* {block 'content'} */
class Block_19837747926175d8d44eb992_10120154 extends Smarty_Internal_Block
{
public $subBlocks = array (
  'content' => 
  array (
    0 => 'Block_19837747926175d8d44eb992_10120154',
  ),
  'page_header_container' => 
  array (
    0 => 'Block_4320327106175d8d44ebe70_23653462',
  ),
  'page_title' => 
  array (
    0 => 'Block_18442137816175d8d44ec473_35499545',
  ),
  'page_content_container' => 
  array (
    0 => 'Block_1990671246175d8d44efc52_31765836',
  ),
  'page_content_top' => 
  array (
    0 => 'Block_20698966566175d8d44f07f0_59876854',
  ),
  'page_content' => 
  array (
    0 => 'Block_17107884306175d8d44f14a0_73930847',
  ),
  'page_footer_container' => 
  array (
    0 => 'Block_13097064916175d8d44f2f55_24006157',
  ),
  'page_footer' => 
  array (
    0 => 'Block_9391463616175d8d44f3803_53860035',
  ),
);
public function callBlock(Smarty_Internal_Template $_smarty_tpl) {
?>


  <section id="main">

    <?php 
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_4320327106175d8d44ebe70_23653462', 'page_header_container', $this->tplIndex);
?>


    <?php 
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_1990671246175d8d44efc52_31765836', 'page_content_container', $this->tplIndex);
?>


    <?php 
$_smarty_tpl->inheritance->instanceBlock($_smarty_tpl, 'Block_13097064916175d8d44f2f55_24006157', 'page_footer_container', $this->tplIndex);
?>


  </section>

<?php
}
}
/* {/block 'content'} */
}
