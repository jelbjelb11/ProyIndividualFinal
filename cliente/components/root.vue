<template>
<!-- 	<div id="Root" class="container-fluid">
		<div id = "Menu">
			<ul class="nav nav-pills" id="myTab" role="tablist">
				<li class="nav-item">
					<a id='Colecciones'  data-toggle="tab"  class="nav-link active" href=""  role="tab"  @click="currentView='Colecciones'" v-on:click.prevent="">Tipos de Colección2</a>
				</li>
				<li class="nav-item">
					<a id="Distribuidores" class="nav-link" data-toggle="tab" href="" role="tab"  @click="currentView='Distribuidores'" v-on:click.prevent="">Distribuidores</a>
				</li>
			</ul>

		</div>
		<hr>
		<div class="row">
			<component :is="currentView" class="col-12"></component>

		</div>
	</div>  -->



<!-- <div class="container">
  <h2>Dynamic Pills</h2>
  <p>To make the tabs toggleable, add the data-toggle="pill" attribute to each link. Then add a .tab-pane class with a unique ID for every tab and wrap them inside a div element with class .tab-content.</p>
  <ul class="nav nav-pills">
    <li class="active"><a data-toggle="pill" href="#home">Home</a></li>
    <li><a data-toggle="pill" href="#menu1">Menu 1</a></li>
    <li><a data-toggle="pill" href="#menu2">Menu 2</a></li>
    <li><a data-toggle="pill" href="#menu3">Menu 3</a></li>
  </ul>
  
  <div class="tab-content">
    <div id="home" class="tab-pane fade in active">
      <h3>HOME</h3>
      <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>
    </div>
    <div id="menu1" class="tab-pane fade">
      <h3>Menu 1</h3>
      <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
    </div>
    <div id="menu2" class="tab-pane fade">
      <h3>Menu 2</h3>
      <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam.</p>
    </div>
    <div id="menu3" class="tab-pane fade">
      <h3>Menu 3</h3>
      <p>Eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.</p>
    </div>
  </div>
</div> -->



<div class="container-fluid">
	<h2>Nombre de la Empresa</h2>
	<ul class="nav nav-pills" role="tablist">
		<li class="nav-item active">
			<a data-toggle="pill" href="" class="nav-link active" role="tab" @click="currentView='Colecciones', activeColeciones='active'" v-on:click.prevent="">Colecciones1</a>

		</li>

		<li class="nav-item">
			<a data-toggle="pill" href="" class="nav-link" role="tab" @click="currentView='Distribuidores', activeColeciones=''" v-on:click.prevent="">Empresas distribuidoras</a>
		</li>

	</ul>

	<hr>
	<div class="row">
		<component :is="currentView" class="col-12"></component>
	</div>
</div>


<!-- Just an image -->
<!-- Image and text -->
<!-- <nav class="navbar navbar-light bg-faded">
  <a class="navbar-brand" href="#">
    <img src="/components/logo.gif" width="30" height="30" class="d-inline-block align-top" alt="">
    Bootstrap
  </a>
</nav> -->
</template>	



<script>
	import Distribuidores from './distribuidoresMaster.vue'
	import Colecciones from  './tiposColeccionMaster.vue'
	import constantes from './constants.js'


	export default{
		components:{
			Colecciones,
			Distribuidores,
			active : true
		},
		data (){
			return{
				currentView: 'Colecciones'
			}
		},
		computed:{
			
		},
		methods:{
			anchorClass(tipo){

			}
		}
	}
</script>

<style type="text/css">

</style>