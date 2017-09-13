<template>
	<div class="container-fluid" style="width: 85%"> 
		<table class="table table-hover" role="tablist">

			<thead>
				<tr  v-if="computeShowNewDetail" colspan="6">
					<td colspan="6">
						<detail @cancelDetail ="removeDetail" @forceUpdate = "forceUpdate" :currentId = "elegido" :state ="state" role="tabpanel" class="float-right"> </detail>
					</td>
				</tr>
				<tr>

					<th>#</th>
					<th>Título</th>
					<th>Formato</th>
					<th>Periódica</th>
					<th><i id="icon" class="fa fa-user-plus fa-2x" aria-hidden="false" v-on:click="getNewDetail()"></i></th>

				</tr>
			</thead>
			<tbody @click="" v-for="(item, index) in lista">
				<tr v-on:click="renderDetail(item.Id)">
					<th scope="row" v-model='index'>{{index+1}}</th>  
					<td>{{item.Titulo}}</td>
					<td>{{item.Formato}}</td>
					<td>{{item.Periodica}}</td>
					<!-- <td><i id="icon" class="glyphicon glyphicon-trash" aria-hidden="false" v-on:click="buttonBorrar"></i></td> -->
				</tr>

				<tr id="detail-tr" v-if="item.Id == elegido">
					<td colspan="6">
						<detail @makeGet= "recargarMaster" @forceUpdate = "forceUpdate" @cancelDetail = "removeDetail" :currentId = "elegido" :state = "state" role="tabpanel" class="float-right" > </detail>
					</td>
				</tr>
			</tbody>
		</table>

		<!-- Paginado -->

		<!-- <tfoot>
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
		<hr> -->
	</div>
</template>

<script type="text/javascript">
	import constantes from './constants.js';
	import detail from './coleccionesDetail.vue'
	export default{
		name: "Colecciones",
		components:{
			detail,
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
			computeShowNewDetail(){
				return this.state === constantes.STATE_NEW;
			},
		},
		methods:{
			makeGetListRequest(){
				$.ajax({
					url: constantes.BASE_URL + this.menuChoice,
					method: "GET"
				})
				.done(this.submitGetListValues)
				.fail(function(){
					alert("Ha fallado la carga del objeto");
				})
			},
			forceUpdate: function(){
				this.removeDetail();
				this.makeGetListRequest();
			},
			recargarMaster: function(){
				this.removeDetail();
				this.makeGetListRequest();
			},
			removeDetail: function(){
				this.elegido = "";
				this.state = "";
			},
			submitGetListValues: function(datos){
				this.lista = datos;
				this.parseTipo(datos);
			},
			parseTipo: function(array){
				var _this = this;
				array.forEach(function(element, index) {
					
					if(element.Formato == 1){
						_this.lista[index].Formato = "Papel";
					}
					else if(element.Formato == 2){
						_this.lista[index].Formato = "Holográfica";
					}
					else if(element.Formato == 3){
						_this.lista[index].Formato = "3D";
					}
					else if(element.Formato == 4){
						_this.lista[index].Formato = "Plástico";
					}
					else if(element.Formato == 5){
						_this.lista[index].Formato = "Clásico";
					}
					if(element.Periodica == true){
						_this.lista[index].Periodica = "Si";
					} else {
						_this.lista[index].Periodica = "No";
					}
				});
			},
			getNewDetail: function(){
				this.state = constantes.STATE_NEW;
				this.elegido = "";
			},	
			// buttonBorrar: function(){
			// 	if(confirm("¿Está seguro de que quiere borrar?")){
			// 		$.ajax({
			// 			url:constantes.BASE_URL + this.menuChoice + "/" + elegido,
			// 			method: "DELETE"
			// 		})
			// 		.done(this.borradoHandler)
			// 		.fail(function(){alert("Ha habido un error al borrar.");})
			// 	}
			// },
			renderDetail: function(index){
				if(this.state == constantes.STATE_UPDATE){
					if(this.elegido == index){
						this.elegido ="";
						this.state = "";
					}
					else {
						this.elegido = index;
					}
				}
				else{
					this.state = constantes.STATE_UPDATE
					this.elegido = index;
				//this.showDetail == false ? this.showDetail = true :  this.showDetail = false;
			}

		},		
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
	th {
		text-align: center;
	}
	#icon {
		color: #337ab7;
		font-size: 1.3em;
	}
	td {
		text-align: center;
	}

</style>