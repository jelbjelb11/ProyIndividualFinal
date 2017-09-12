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
					<th>Razón Social</th>
					<th>Nombre de contacto</th>
					<th>Teléfono</th>
					<th><i id="icon" class="fa fa-user-plus fa-2x" aria-hidden="false" v-on:click="getNewDetail()"></i></th>

				</tr>
			</thead>
			<tbody @click="" v-for="(item, index) in lista">
				<tr v-on:click="renderDetail(item.Id)">
					<th scope="row" v-model='index'>{{index+1}}</th>  
					<td>{{item.RazonSocial}}</td>
					<td>{{item.NombreContacto}}</td>
					<td>{{item.Telefono}}</td>
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
	import detail from './distribuidoresDetail.vue'
	export default{
		name: "Distribuidores",
		components:{
			detail,
		},
		data (){
			return{
				lista: [],
				menuChoice:"DistribuidorEmpresas",
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
				// this.parseTipo(datos);
			},
			// parseTipo: function(array){
			// 	var _this = this;
			// 	array.forEach(function(element, index) {
			// 		if(element.Tipo == 4){
			// 			_this.lista[index].Tipo = "Texto";
			// 		}
			// 		else if(element.Tipo == 1){
			// 			_this.lista[index].Tipo = "Imagen";
			// 		}
			// 		else if(element.Tipo == 2){
			// 			_this.lista[index].Tipo = "HTML";
			// 		}
			// 		else if(element.Tipo == 3){
			// 			_this.lista[index].Tipo = "Hoja de cálculo";
			// 		}
			// 		if(element.SoloLectura){
			// 			_this.lista[index].SoloLectura = "Si";
			// 		}
			// 		else{
			// 			_this.lista[index].SoloLectura = "No";
			// 		}
			// 	});
			// },


			getNewDetail: function(){
				this.state = constantes.STATE_NEW;
				this.elegido = "";
			},	
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