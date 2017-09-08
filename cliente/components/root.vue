<template>
	<div id="Root" class="container-fluid">
		<div id = "Menu">
			<ul class="nav nav-tabs" id="myTab" role="tablist">
			  <li class="nav-item">
				<a id='TiposColeccion'  data-toggle="tab"  class="nav-link active" href=""  role="tab"  @click="currentView='TiposColeccion'" v-on:click.prevent="">Tipos de Colección</a>
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
	</div>
</template>	



<script>
	import Distribuidores from './distribuidoresMaster.vue'
	import Colecciones from  './tiposColeccionMaster.vue'


	import constantes from './constants.js'


	export default{
		components:{
			detail,
			TiposColeccion,
			Distribuidores
		},
		data (){
			return{
				currentView: 'TiposColeccion'
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

<style></style>