<template>

	<div class="container-fluid">

		<ul class="nav nav-pills" role="tablist">
			<li>
				<a>
					<img src="/resources/logo.png" width="120" height="50" class="d-inline-block align-top" alt="">

				</a>
			</li>

			<li class="nav-item active">
				<hr>
				<hr>
				<hr>
				<a data-toggle="pill" href="" class="nav-link active" role="tab" @click="currentView='Colecciones', activeColeciones='active'" v-on:click.prevent="">Colecciones</a>
			</li>

			<li class="nav-item">
				<hr>
				<hr>
				<hr>
				<a data-toggle="pill" href="" class="nav-link" role="tab" @click="currentView='Distribuidores', activeColeciones=''" v-on:click.prevent="">Empresas distribuidoras</a>
			</li>

		</ul>

		<hr>

		<div class="row">
			<component :is="currentView" class="col-12"></component>
		</div>
	</div>

</template>	



<script>
	import Distribuidores from './distribuidoresMaster.vue'
	import Colecciones from  './coleccionesMaster.vue'
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