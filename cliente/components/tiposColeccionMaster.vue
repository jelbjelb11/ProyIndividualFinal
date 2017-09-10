<template>
	<div class="container-fluid" style="width: 85%"> 
		<!-- <div id="ColeccionesMaster" class="master-div">  -->
		<table class="table table-hover" role="tablist">

			<!--			<table id="example" class="table table-hover table-bordered" cellspacing="0" width="100%" role="tablist">  -->
			<thead>
				<tr>
					<th>#</th>
					<th>Título1</th>
					<th>Formato</th>
					<th>Periodica</th>
					<th> <i class="fa fa-user-plus" aria-hidden="true" v-on:click=""></i> </a></th>
				</tr>
			</thead>
			<tbody @click="" v-for="(item, index) in lista">
				<tr v-on:click="renderDetail(item.Id)">
					<th scope="row" v-model='index'>{{index+1}}</th>  
					<td>{{item.Titulo}}</td>
					<td>{{item.Formato}}</td>
					<td>{{item.Periodica}}</td>
				</tr>

			</tbody>

		</table>
		<tfoot>
			<hr>
			<div class="container">
				<ul class="pagination pagination-lg pager">
					<li><a href="#">Anterior</a></li>
					<li><a href="#">1</a></li>
					<li><a href="#">2</a></li>
					<li class="active"><a href="#">3</a></li>
					<li><a href="#">4</a></li>
					<li><a href="#">5</a></li>
					<li><a href="#">Siguiente</a></li>
				</ul>
			</div>
		</tfoot>
		<hr>
		<!-- </div>  -->
	</div>
</template>

<script type="text/javascript">
	import constantes from './constants.js';
	import detail from './tiposColeccionDetail.vue'
	export default{
		components:{

		},
		data (){
			return{
				lista: [],
				menuChoice:"ColeccionTipos",
				state: "",
				elegido : "",
			}
		},
		computed:{
		},
		methods:{
			submitGetListValues: function(datos){
				this.lista = datos;
//				this.parseTipo(datos);
},
makeGetListRequest(){
	$.ajax({
		url: constantes.BASE_URL + this.menuChoice,
		method: "GET"
	})
	.done(this.submitGetListValues)
	.fail(function(){
		alert("Los elementos no se han cargado correctamente.");
	})
},
/*			parseTipo: function(array){
				var _this = this;
				array.forEach(function(element, index) {
					if(element.Estilo == 1){
						_this.lista[index].Estilo = "Formal";
					}
					else if(element.Estilo == 2){
						_this.lista[index].Estilo = "Informal";
					}
					else if(element.Estilo == 3){
						_this.lista[index].Estilo = "Libro";
					}
					else if(element.Estilo == 4){
						_this.lista[index].Estilo = "Académico";
					}
				});
			},*/


		},
		created(){
			this.makeGetListRequest();
		},
	}
</script>

<style type="text/css">
	#detail-tr:hover{
		background-color: white;
	}


</style>